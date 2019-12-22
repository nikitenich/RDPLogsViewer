using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using static RDPLogsViewer.RDPEvents;
using static RDPLogsViewer.IPData;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data;
using System.Text;
using System.IO;
using System.ComponentModel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RDPLogsViewer
{
    public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();
            // выставляем таймпикеры
            toDateTimePicker.Value = DateTime.Now;
            fromDateTimePicker.Value = toDateTimePicker.Value.AddDays(-1);

            // добавляем локальные IP по дефолту в белый список
            whiteList.addToWhiteList(new IPData(IPAddress.Parse("192.168.0.0"), 16));
            whiteList.addToWhiteList(new IPData(IPAddress.Parse("10.0.0.0"), 8));
            whiteList.addToWhiteList(new IPData(IPAddress.Parse("172.16.0.0"), 12));
            whiteList.addToWhiteList(new IPData(IPAddress.Parse("127.0.0.0"), 8));

            // добавление в контрол списка событий
            localServiceManagerIDcheckedListBox.Items.AddRange(GetLocalServiceManagerIDs());
            securityIDcheckedListBox.Items.AddRange(GetSecurityIDs());
            remoteConnectionIDcheckedListBox.Items.AddRange(GetRemoteConnectionManagerIDs());
            systemIDcheckedListBox.Items.AddRange(GetSystemIDs());
#if DEBUG
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Controls.Add(this.richTextBox3);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.checkIPButton);
            this.tabPage3.Controls.Add(this.securityEventLogButton);
            this.tabPage3.Controls.Add(this.securityElReaderOneThreadButton);
            this.tabPage3.Controls.Add(this.securityElReaderMultiThreadButton);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.viewLogsWaitButton);
#endif
        }

        #region GLOBAL VARS
        IPWhiteList whiteList = IPWhiteList.getInstance(); // получаем белый список
        Statistics stat = Statistics.getInstance();       // получаем статистику
        EventLog securitylog = new EventLog("Security", System.Environment.MachineName); // security log
        bool filtersEnabled = false;     // включены ли фильтры
        bool monitoringEnabled = false; // включён ли мониторинг событий
        private int tIndex = -1;

        //СПИСКИ С ОТМЕЧЕННЫМИ В ФИЛЬТРАХ ПО СОБЫТИЯМ СОБЫТИЯМИ
        List<int> selectedLocalServiceManagerIDs = new List<int>();
        List<int> selectedRemoteConnectionManagerIDs = new List<int>();
        List<int> selectedSecurityIDs = new List<int>();
        List<int> selectedSystemIDs = new List<int>();
        #endregion

        #region BUTTONS
        // Просмотр логов
        private void viewLogsButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
#endif
            eventLogsGridView.Rows.Clear();
            stat.clearStat(); myEvent.count = 0;

            var securityQuery = selectQueryStringByCondition("Security", selectedSecurityIDs);
            if (securityQuery.Item2)
            {
                var securityEvents = ParseEventsParallel("Security", securityQuery.Item1);
                addEventsToGridView(securityEvents, eventLogsGridView);

            }
            else MessageBox.Show("Ни одно событие в журнале Security не отмечено!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var remoteConnectionManagerQuery = selectQueryStringByCondition("Microsoft-Windows-TerminalServices-RemoteConnectionManager/Operational", selectedRemoteConnectionManagerIDs);
            if (remoteConnectionManagerQuery.Item2)
            {
                var remoteConnectionManagerEvents = ParseEventsParallel("Microsoft-Windows-TerminalServices-RemoteConnectionManager/Operational", remoteConnectionManagerQuery.Item1);
                addEventsToGridView(remoteConnectionManagerEvents, eventLogsGridView);
            }
            else MessageBox.Show("Ни одно событие в журнале RCM не отмечено!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var localSessionManagerQuery = selectQueryStringByCondition("Microsoft-Windows-TerminalServices-LocalSessionManager/Operational", selectedLocalServiceManagerIDs);
            if (localSessionManagerQuery.Item2)
            {
                var localSessionManagerEvents = ParseEventsParallel("Microsoft-Windows-TerminalServices-LocalSessionManager/Operational", localSessionManagerQuery.Item1);
                addEventsToGridView(localSessionManagerEvents, eventLogsGridView);
            }
            else MessageBox.Show("Ни одно событие в журнале LSM не отмечено!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var systemQuery = selectQueryStringByCondition("System", selectedSystemIDs);
            if (systemQuery.Item2)
            {
                var systemEvents = ParseEventsParallel("System", systemQuery.Item1);
                addEventsToGridView(systemEvents, eventLogsGridView);
            }
            else MessageBox.Show("Ни одно событие в журнале System не отмечено!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            stat.calcStat();

            eventLogsGridView.Sort(eventLogsGridView.Columns[2], ListSortDirection.Ascending); // сортируем по дате
#if DEBUG
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString() + "ms elapsed\n" + myEvent.count + " events recieved\n" +
                (float)myEvent.count / (stopwatch.ElapsedMilliseconds / 1000) + " events per sec");
#endif
            statisticsButton.Enabled = true;
            saveFileToolStripMenuItem.Enabled = true;
            pdfToolStripMenuItem.Enabled = true;
            clearLogsButton.Enabled = true;
            tabControl1.SelectedIndex = 0;
        }

        // Открытие файла
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable("Event");

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "evXML|*.evxml";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //open the file using a Stream
                    using (Stream stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        for (int i = 0; i < fileViewDataGridView.Columns.Count; i++)
                        {
                            table.Columns.Add(new DataColumn(eventLogsGridView.Columns[i].Name));
                            fileViewDataGridView.Columns[i].DataPropertyName = eventLogsGridView.Columns[i].Name;
                        }

                        //use ReadXml to read the XML stream
                        table.ReadXml(stream);
                    }

                    fileViewDataGridView.DataSource = table;
                    tabControl1.SelectedIndex = 2;
                    table.Dispose();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        // Сохранение файла
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Event";

            for (int i = 0; i < eventLogsGridView.Columns.Count; i++)
            {
                string headerText = eventLogsGridView.Columns[i].Name;
                headerText = Regex.Replace(headerText, "[-/, ]", "_");

                DataColumn column = new DataColumn(headerText);
                dt.Columns.Add(column);
            }

            foreach (DataGridViewRow DataGVRow in eventLogsGridView.Rows)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["id"] = DataGVRow.Cells[0].Value;
                dataRow["type"] = DataGVRow.Cells[1].Value;
                dataRow["date"] = DataGVRow.Cells[2].Value;
                dataRow["machine"] = DataGVRow.Cells[3].Value;
                dataRow["message"] = DataGVRow.Cells[4].Value;
                dataRow["IP"] = DataGVRow.Cells[5].Value;

                dt.Rows.Add(dataRow); //dt.Columns.Add();
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "evXML|*.evxml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Finally the save part:
                    XmlTextWriter xmlSave = new XmlTextWriter(sfd.FileName, Encoding.UTF8);
                    xmlSave.Formatting = Formatting.Indented;
                    ds.DataSetName = "RDPLogsView";
                    ds.WriteXml(xmlSave);
                    xmlSave.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editWhiteListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPWhiteListForm whiteListWindow = new IPWhiteListForm(); //открываем окно белого списка
            whiteListWindow.Show();
        }

        private void monitoringEventsButton_Click(object sender, EventArgs e)
        {
            EntryWrittenEventHandler eventHandler = new EntryWrittenEventHandler(OnEntrySecurityWritten);
            if (!monitoringEnabled)
            {
                securitylog.EnableRaisingEvents = true;
                securitylog.EntryWritten += eventHandler;
                monitoringEventsButton.Text = "Выключить мониторинг";
                monitoringEnabled = true;
            }
            else {
                securitylog.EnableRaisingEvents = false;
                securitylog.EntryWritten -= eventHandler;
                monitoringEventsButton.Text = "Включить мониторинг";
                monitoringEnabled = false;
            }
        }

        private void clearMonitoringButton_Click(object sender, EventArgs e)
        {
            monitoringGridView.Rows.Clear();
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            StatisticsForm sf = new StatisticsForm();
            sf.ShowDialog();
        }
        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(eventLogsGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            //pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in eventLogsGridView.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in eventLogsGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "pdf|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 0, 0, 0, 0);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            }
           
        }

        private void clearLogsButton_Click(object sender, EventArgs e)
        {
            eventLogsGridView.Rows.Clear();
            stat.clearStat(); myEvent.count = 0;
            statisticsButton.Enabled = false;
            saveFileToolStripMenuItem.Enabled = false;
            pdfToolStripMenuItem.Enabled = false;
            clearLogsButton.Enabled = false;
        }
        #endregion

        #region FUCTIONS
        /// <summary>
        /// Получение eventLog-запроса на основе пользовательского интерфейса
        /// </summary>
        /// <param name="logName">Название журнала EventLog</param>
        /// <param name="selectedIDs">Список с выбранными ID</param>
        /// <returns>Пару EventLog-запрос и логическую переменную, были ли вообще отмечены события</returns>
        private Tuple<string,bool> selectQueryStringByCondition(string logName, List<int> selectedIDs) {
            string resultQuery = "";
            bool notEmptySelected = true; // не пуст ли фильтр по событию? Если да, то в дальнейшем и не пытаемся искать и выводить

            if (!filtersEnabled || !filterEventsCheckBox.Checked) { //если фильтры выключены
                switch (logName) {                                  //или выключен фильтр по конкретным событиям
                    case "Security":
                        resultQuery = "*[System[(EventID=" + (int)SecurityIDs.AuthSuccessLoggedOn +
                                " or EventID=" + (int)SecurityIDs.AuthFailedLogOn +
                                " or EventID=" + (int)SecurityIDs.SessionDisconnectedToWS +
                                " or EventID=" + (int)SecurityIDs.SessionDisconnectedFromWS +
                                " or EventID=" + (int)SecurityIDs.AccountWasLoggedOff +
                                " or EventID=" + (int)SecurityIDs.UserInitialedLogoff + ")]]";
                        break;

                    case "Microsoft-Windows-TerminalServices-RemoteConnectionManager/Operational":
                        resultQuery = "*[System[(EventID="
                            + (int)RemoteConnectionManagerIDs.NetworkUserAuthSuccess + ")]]";
                        break;

                    case "Microsoft-Windows-TerminalServices-LocalSessionManager/Operational":
                        resultQuery = "*[System[(EventID=" + (int)LocalServiceManagerIDs.SessionLogonSucceded +
                        " or EventID=" + (int)LocalServiceManagerIDs.ShellStartNotifRecieved +
                        " or EventID=" + (int)LocalServiceManagerIDs.SessionReconnectionSucceded +
                        " or EventID=" + (int)LocalServiceManagerIDs.SessionDisconnectedBySession +
                        " or EventID=" + (int)LocalServiceManagerIDs.SessionDisconnectedByReason +
                        " or EventID=" + (int)LocalServiceManagerIDs.SessionLogoffSucceded +
                        " or EventID=" + (int)LocalServiceManagerIDs.SessionHasBeenDisconnected +
                        " or EventID=" + (int)LocalServiceManagerIDs.RDPServiceStartFailed + ")]]";
                        break;

                    case "System":
                        resultQuery = "*[System[(EventID=" + (int)SystemIDs.WindowManagExited + ")]]";
                        break;
                }
            }

            if (filtersEnabled && filterEventsCheckBox.Checked) { //если фильры включены и 
                                                                //включен фильтр по событиям
                if (selectedIDs.Count > 0) //если хоть что-то отмечено в интерфейсе пользователя
                    resultQuery = generateQueryStringByCheckedListBoxes(selectedIDs);
                else { //если не отмечено ничего, то нечего в этом журнале что-то и искать, тем более и по дате
                    notEmptySelected = false;
                    return Tuple.Create(resultQuery, notEmptySelected);
                }
            }

            if (filtersEnabled && filterTimeCheckBox.Checked) {
                resultQuery = addDateTimeToQuery(resultQuery);
            }

            return Tuple.Create(resultQuery, notEmptySelected);
        }


        /// <summary>
        /// Добавление к EventLogReader-запросу временнОго параметра
        /// </summary>
        /// <param name="origQuery">Запрос</param>
        /// <returns>Запрос с фильтром по времени</returns>
        public string addDateTimeToQuery(string origQuery) {
            // Обрабатываем что-то подобное:
            // *[System[(EventID=39 or EventID=40)]]
            // Получаем что-то подобное:
            // *[System[(EventID=39 or EventID=40) and TimeCreated[@SystemTime>='2019-05-04T20:16:10.0000000' and @SystemTime<='2019-05-05T20:16:10.0000000']]]

            string result = origQuery.Insert(origQuery.Length - 2, 
                " and TimeCreated[@SystemTime>='" + fromDateTimePicker.Value.ToString("o")
                + "' and @SystemTime<='" + toDateTimePicker.Value.ToString("o") + "']");
            
            return result;
        }

        /// <summary>
        /// Генерирование запроса по выбранным ID из чекбоксов
        /// </summary>
        /// <param name="selectedIDs">Список отмеченных ID</param>
        /// <returns>Запрос для EventLogReader</returns>
        public static string generateQueryStringByCheckedListBoxes(List<int> selectedIDs) {
            // Получаем что-то такое:
            // *[System[(EventID=39 or EventID=40)]]
            // Или такое:
            // *[System[(EventID=39)]]

            string result = "*[System[(EventID=";

            for (int i = 0; i < selectedIDs.Count; i++) {
                if (i == 0) { result += selectedIDs[i]; }
                else result += " or EventID=" + selectedIDs[i];
                if (i == selectedIDs.Count - 1) { result += ")]]"; }
            }
            return result;
        }

        public static volatile bool myHasStoppedReading = false;

        /// <summary>
        /// Получение списка событий по запросу (параллельно)
        /// </summary>
        /// <param name="journalName">Название журнала</param>
        /// <param name="queryRequest">Фильтр</param>
        /// <returns>Список</returns>
        public static ConcurrentQueue<myEvent> ParseEventsParallel(string journalName, string queryRequest)
        {
            var query = new EventLogQuery(journalName, PathType.LogName, queryRequest);

            const int BatchSize = 100;

            ConcurrentQueue<EventRecord> events = new ConcurrentQueue<EventRecord>();
            var readerTask = Task.Factory.StartNew(() =>
            {
                using (EventLogReader reader = new EventLogReader(query))
                {
                    EventRecord ev;
                    int count = 0;
                    while ((ev = reader.ReadEvent()) != null)
                    {
                        if (count % BatchSize == 0)
                        {
                            events.Enqueue(ev); //добавление события в очередь
                        }
                        count++;
                    }
                }
                myHasStoppedReading = true;
            });

            ConcurrentQueue<myEvent> eventsWithStrings = new ConcurrentQueue<myEvent>();

            Action conversion = () =>
            {
                EventRecord ev = null;
                using (var reader = new EventLogReader(query))
                {
                    while (!myHasStoppedReading || events.TryDequeue(out ev))
                    {
                        if (ev != null)
                        {
                            reader.Seek(ev.Bookmark);
                            for (int i = 0; i < BatchSize; i++)
                            {
                                ev = reader.ReadEvent();
                                if (ev == null)
                                {
                                    break;
                                }
                                eventsWithStrings.Enqueue(new myEvent(ev));
                            }
                        }
                    }
                }
            };

            Parallel.Invoke(Enumerable.Repeat(conversion, 8).ToArray());

            myHasStoppedReading=false;
            return eventsWithStrings;
            //return eventsWithStrings.ToList();
        }

        /// <summary>
        /// Вывод списка событий на DataGridView
        /// </summary>
        /// <param name="arr">Список с событиями</param>
        /// <param name="dgw">DataGridView</param>
        private void addEventsToGridView(ConcurrentQueue<myEvent> arr, DataGridView dgw)
        {
            foreach (myEvent ev in arr)
            {
                /*dgw.Rows.Add(
                    ev._id, ev._entryType, ev._timeGenerated, ev._machineName, ev._message, ev._ip);*/

                dgw.PerformSafely(()=>dgw.Rows.Add(
                    ev._id, ev._entryType, ev._timeGenerated, ev._machineName, ev._message, ev._ip));
            }
        }

        /// <summary>
        /// Заполнение списка выставленных событий по отмеченным чекбоксам
        /// </summary>
        /// <param name="checkedListBox"></param>
        /// <returns></returns>
        public void fillEventList(CheckedListBox checkedListBox)
        {
            List<int> ids = new List<int>();
            // Для начала сопоставляем полученный изменённый чеклистбокс со списком отмеченных в глобальной переменной
            switch (checkedListBox.Name)
            {
                case (nameof(localServiceManagerIDcheckedListBox)):
                    ids = selectedLocalServiceManagerIDs;
                    break;

                case (nameof(securityIDcheckedListBox)):
                    ids = selectedSecurityIDs;
                    break;
                case nameof(remoteConnectionIDcheckedListBox):
                    ids = selectedRemoteConnectionManagerIDs;
                    break;
                case nameof(systemIDcheckedListBox):
                    ids = selectedSystemIDs;
                    break;
                default: break;

            }
            ids.Clear(); //чистим-чистим

            foreach (RDPEvent item in checkedListBox.CheckedItems)
            {
                ids.Add(item.GetNumber()); //добавляем отмеченный элемент в список
            }
        }
        #endregion

        #region TEST THINGS/OLD STUFF
        /// <summary>
        /// Вывод eventlog в datagridview (OLD)
        /// </summary>
        /// <param name="logType">Путь до журнала событий</param>
        /// <param name="query">Запрос</param>
        /// <param name="dgw">Куда выводить</param>
        private int ViewEventLogOneThread(string logType, string query, DataGridView dgw)
        {
            var elQuery = new EventLogQuery(logType, PathType.LogName, query);
            var elReader = new EventLogReader(elQuery);
            bool notNullEvents = false;
            int count = 0;
            for (EventRecord eventInstance = elReader.ReadEvent(); eventInstance != null; eventInstance = elReader.ReadEvent())
            {
                if (!filtersEnabled)
                { // без фильтров
                    count++;
                    notNullEvents = true;
                    dgw.Rows.Add(
                        eventInstance.Id.ToString(),
                        eventInstance.LevelDisplayName.ToString(),
                        eventInstance.TimeCreated.ToString(),
                        eventInstance.MachineName.ToString(),
                        eventInstance.FormatDescription(),
                        myEvent.AnEventWithIP(eventInstance) ? GetIPfromEventXML(eventInstance.ToXml()) : "" //выводим IP, если таковая информация есть в событие
                        );
                }
            }
            if (!notNullEvents) MessageBox.Show("В журнале " + logType + " релевантных cобытий не найдено.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return count;
        }
        private void securityEventLogButton_Click(object sender, EventArgs e)
        {
            eventLogsGridView.Rows.Clear();
            tabControl1.SelectedIndex = 0;
            var stopwatch = Stopwatch.StartNew();

            EventLog ev = new EventLog("Security", System.Environment.MachineName); // получаем лог выбранного журнала
            int lastLogToShow = ev.Entries.Count; // общее кол-во логов выбранного журнала
            if (lastLogToShow <= 0)
            {
                string message = "В журнале: " + "Security" + " отсутствуют записи";
                string caption = "Просмотр журналов событий";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // чтение выбранного журнала
                int i = 0;
                for (i = 0; i < lastLogToShow; i++)
                {
                    EventLogEntry CurrentEntry = ev.Entries[i];
                    if (CurrentEntry.InstanceId == (int)SecurityIDs.AuthSuccessLoggedOn ||
                        CurrentEntry.InstanceId == (int)SecurityIDs.AuthFailedLogOn ||
                        CurrentEntry.InstanceId == (int)SecurityIDs.SessionDisconnectedToWS ||
                        CurrentEntry.InstanceId == (int)SecurityIDs.SessionDisconnectedFromWS ||
                        CurrentEntry.InstanceId == (int)SecurityIDs.AccountWasLoggedOff ||
                        CurrentEntry.InstanceId == (int)SecurityIDs.UserInitialedLogoff)

                        eventLogsGridView.Rows.Add(CurrentEntry.InstanceId,
                            CurrentEntry.EntryType.ToString(),
                            CurrentEntry.TimeGenerated.ToString(),
                            CurrentEntry.MachineName.ToString(),
                            CurrentEntry.Message);
                }
            }
            ev.Close();
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString() + "ms elapsed\n" + eventLogsGridView.Rows.Count + " events recieved\n" +
                (float)eventLogsGridView.Rows.Count / (stopwatch.ElapsedMilliseconds / 1000) + " events per sec");
        }

        private void securityElReaderOneThreadButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            eventLogsGridView.Rows.Clear();
            var stopwatch = Stopwatch.StartNew();
            string resultQuery = "*[System[(EventID=" + (int)SecurityIDs.AuthSuccessLoggedOn +
                               " or EventID=" + (int)SecurityIDs.AuthFailedLogOn +
                               " or EventID=" + (int)SecurityIDs.SessionDisconnectedToWS +
                               " or EventID=" + (int)SecurityIDs.SessionDisconnectedFromWS +
                               " or EventID=" + (int)SecurityIDs.AccountWasLoggedOff +
                               " or EventID=" + (int)SecurityIDs.UserInitialedLogoff + ")]]";
            ViewEventLogOneThread("Security", resultQuery, eventLogsGridView);
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString() + "ms elapsed\n" + eventLogsGridView.Rows.Count + " events recieved\n" +
                (float)eventLogsGridView.Rows.Count / (stopwatch.ElapsedMilliseconds / 1000) + " events per sec");
        }

        private void securityElReaderMultiThreadButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            eventLogsGridView.Rows.Clear();
            var stopwatch = Stopwatch.StartNew();
            string resultQuery = "*[System[(EventID=" + (int)SecurityIDs.AuthSuccessLoggedOn +
                               " or EventID=" + (int)SecurityIDs.AuthFailedLogOn +
                               " or EventID=" + (int)SecurityIDs.SessionDisconnectedToWS +
                               " or EventID=" + (int)SecurityIDs.SessionDisconnectedFromWS +
                               " or EventID=" + (int)SecurityIDs.AccountWasLoggedOff +
                               " or EventID=" + (int)SecurityIDs.UserInitialedLogoff + ")]]";
            addEventsToGridView(ParseEventsParallel("Security", resultQuery), eventLogsGridView);
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString() + "ms elapsed\n" + eventLogsGridView.Rows.Count + " events recieved\n" +
                (float)eventLogsGridView.Rows.Count / (stopwatch.ElapsedMilliseconds / 1000) + " events per sec");
        }

        private void checkIPButton_Click(object sender, EventArgs e)
        {
            IPAddress ipToCheck = IPAddress.Parse(textBox3.Text);

            label2.Text = (whiteList.IsIPinList(ipToCheck, false)) ? "true" : "false";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = IPData.checkStringIsIP(textBox4.Text) ? "true" : "false";
        }

        private void viewLogsWaitButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
#endif
            eventLogsGridView.Rows.Clear();
            stat.clearStat(); myEvent.count = 0;

            var securityQuery = selectQueryStringByCondition("Security", selectedSecurityIDs);
            if (securityQuery.Item2)
            {
                new WaitForm(() => {
                    var securityEvents = ParseEventsParallel("Security", securityQuery.Item1);
                    addEventsToGridView(securityEvents, eventLogsGridView);
                }).ShowDialog();
                //var securityEvents = ParseEventsParallel("Security", securityQuery.Item1);
                //addEventsToGridView(securityEvents, eventLogsGridView);

            }
            else MessageBox.Show("Ни одно событие в журнале Security не отмечено!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var remoteConnectionManagerQuery = selectQueryStringByCondition("Microsoft-Windows-TerminalServices-RemoteConnectionManager/Operational", selectedRemoteConnectionManagerIDs);
            if (remoteConnectionManagerQuery.Item2)
            {
                new WaitForm(() => {
                    var remoteConnectionManagerEvents = ParseEventsParallel("Microsoft-Windows-TerminalServices-RemoteConnectionManager/Operational", remoteConnectionManagerQuery.Item1);
                    addEventsToGridView(remoteConnectionManagerEvents, eventLogsGridView);
                }).ShowDialog();
                //var remoteConnectionManagerEvents = ParseEventsParallel("Microsoft-Windows-TerminalServices-RemoteConnectionManager/Operational", remoteConnectionManagerQuery.Item1);
                //addEventsToGridView(remoteConnectionManagerEvents, eventLogsGridView);
            }
            else MessageBox.Show("Ни одно событие в журнале RCM не отмечено!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var localSessionManagerQuery = selectQueryStringByCondition("Microsoft-Windows-TerminalServices-LocalSessionManager/Operational", selectedLocalServiceManagerIDs);
            if (localSessionManagerQuery.Item2)
            {
                new WaitForm(() => {
                    var localSessionManagerEvents = ParseEventsParallel("Microsoft-Windows-TerminalServices-LocalSessionManager/Operational", localSessionManagerQuery.Item1);
                    addEventsToGridView(localSessionManagerEvents, eventLogsGridView);
                }).ShowDialog();
                //var localSessionManagerEvents = ParseEventsParallel("Microsoft-Windows-TerminalServices-LocalSessionManager/Operational", localSessionManagerQuery.Item1);
                //addEventsToGridView(localSessionManagerEvents, eventLogsGridView);
            }
            else MessageBox.Show("Ни одно событие в журнале LSM не отмечено!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var systemQuery = selectQueryStringByCondition("System", selectedSystemIDs);
            if (systemQuery.Item2)
            {
                new WaitForm(() => {
                    var systemEvents = ParseEventsParallel("System", systemQuery.Item1);
                    addEventsToGridView(systemEvents, eventLogsGridView);
                }).ShowDialog();
                //var systemEvents = ParseEventsParallel("System", systemQuery.Item1);
                //addEventsToGridView(systemEvents, eventLogsGridView);
            }
            else MessageBox.Show("Ни одно событие в журнале System не отмечено!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            stat.calcStat();

            eventLogsGridView.Sort(eventLogsGridView.Columns[2], ListSortDirection.Ascending); // сортируем по дате
#if DEBUG
            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString() + "ms elapsed\n" + myEvent.count + " events recieved\n" +
                (float)myEvent.count / (stopwatch.ElapsedMilliseconds / 1000) + " events per sec");
#endif
            statisticsButton.Enabled = true;
            saveFileToolStripMenuItem.Enabled = true;
            pdfToolStripMenuItem.Enabled = true;
            clearLogsButton.Enabled = true;
        }
        #endregion

        #region EVENTS OCCUR SOME CONTROLS CHANGES
        protected void OnEntrySecurityWritten(object sender, EntryWrittenEventArgs e)
        {
            EventLogEntry entry = e.Entry;
            if (entry.InstanceId == (int)SecurityIDs.AccountWasLoggedOff ||
                entry.InstanceId == (int)SecurityIDs.AuthFailedLogOn ||
                entry.InstanceId == (int)SecurityIDs.AuthSuccessLoggedOn ||
                entry.InstanceId == (int)SecurityIDs.SessionDisconnectedFromWS ||
                entry.InstanceId == (int)SecurityIDs.SessionDisconnectedToWS ||
                entry.InstanceId == (int)SecurityIDs.UserInitialedLogoff)
            {
                monitoringGridView.PerformSafely(() => monitoringGridView.Rows.Add(entry.InstanceId,
                                                                                   entry.EntryType,
                                                                                   entry.TimeGenerated,
                                                                                   entry.MachineName,
                                                                                   entry.Message,
                                                                                   myEvent.getIPByTextDescription(entry.Message)
                                                                                   ));
            }
        }

        /// <summary>
        /// Событие при добавлении новой строки в DGW. Если сверяемый IP в нём не удовлетворяет белому списку,
        /// то выделить строку красным
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridsView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (enableWhiteListToolStripMenuItem.Checked) // если включён белый список
            {
                DataGridView dgw = sender as DataGridView;
                try
                {
                    //if (e.RowIndex > 1)
                    //{
                        DataGridViewCell cell = dgw[5, e.RowIndex];

                        bool isIP = false;
                        if (cell.Value != null) isIP = IPData.checkStringIsIP(cell.Value.ToString());
                        if (isIP)
                        {
                            IPAddress ip = IPAddress.Parse(cell.Value.ToString());
                            if (!(whiteList.IsIPinList(ip, false))) // если IP не в белом списке
                            {
                                dgw.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                            }
                        }
                    //}
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void filtersCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
             this.BeginInvoke(new Action(() => {
                fillEventList((CheckedListBox)sender);
            }));
        }

        private void enableWhiteListToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            editWhiteListToolStripMenuItem.Enabled = enableWhiteListToolStripMenuItem.Checked;
        }

        private void filterDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (toDateTimePicker.Value < fromDateTimePicker.Value)
            {
                MessageBox.Show("Некорректно выставленный интервал. Меняем местами.","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DateTime temp = toDateTimePicker.Value;
                toDateTimePicker.Value = fromDateTimePicker.Value;
                fromDateTimePicker.Value = temp;
            }
        }

        private void filterButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton recievedObject = sender as RadioButton;

            switch (recievedObject.Name)
            {
                case nameof(filterOffButton):
                    filtersEnabled = false;

                    filterTimeCheckBox.Enabled = false;
                    filterEventsCheckBox.Enabled = false;

                    filterTimeCheckBox.Checked = false;
                    filterEventsCheckBox.Checked = false;

                    break;
                case nameof(filterOnButton):
                    filtersEnabled = true;

                    filterTimeCheckBox.Enabled = true;
                    filterEventsCheckBox.Enabled = true;

                    filterTimeCheckBox.Checked = true;
                    break;
            }
        }

        private void filterCheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox recievedObject = sender as CheckBox;
            switch (recievedObject.Name)
            {
                case nameof(filterTimeCheckBox):
                    filterByTimeGroupBox.Enabled = filterTimeCheckBox.Checked;
                    break;
                case nameof(filterEventsCheckBox):
                    filterByEventsGroupBox.Enabled = filterEventsCheckBox.Checked;
                    break;
            }
        }

        // Событие при нажатии на описание события в таблице
        private void eventLogsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgw = sender as DataGridView;
            if (e.RowIndex == -1) return;
            if (dgw.CurrentCell.ColumnIndex.Equals(4)) // чекаем исключительно один столбец
                if (dgw.CurrentCell != null && dgw.CurrentCell.Value != null)
                    MessageBox.Show(dgw.CurrentCell.Value.ToString(),"Сообщение",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkedListBox_MouseHover(object sender, EventArgs e)
        {
            var el = sender as CheckedListBox;
            GetToolTip(el);
        }

        private void checkedListBox_MouseMove(object sender, MouseEventArgs e)
        {
            var el = sender as CheckedListBox;
            int index = el.IndexFromPoint(e.Location);
            if (tIndex != index)
            {
                GetToolTip(el);
            }
        }

        void GetToolTip(CheckedListBox el)
        {
            Point pos = el.PointToClient(MousePosition);
            tIndex = el.IndexFromPoint(pos);
            if (tIndex > -1)
            {
                pos = this.PointToClient(MousePosition);
                toolTip1.SetToolTip(el, el.Items[tIndex].ToString());
            }
        }
        #endregion
    }
}