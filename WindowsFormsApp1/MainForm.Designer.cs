namespace RDPLogsViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.eventLogsGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.enableWhiteListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editWhiteListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.clearLogsButton = new System.Windows.Forms.Button();
            this.filterByTimeGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.filterByEventsGroupBox = new System.Windows.Forms.GroupBox();
            this.sysLabel = new System.Windows.Forms.Label();
            this.rcmLabel = new System.Windows.Forms.Label();
            this.lsmLabel = new System.Windows.Forms.Label();
            this.secLabel = new System.Windows.Forms.Label();
            this.systemIDcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.remoteConnectionIDcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.securityIDcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.localServiceManagerIDcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.filtersGroupBox = new System.Windows.Forms.GroupBox();
            this.filterEventsCheckBox = new System.Windows.Forms.CheckBox();
            this.filterOnButton = new System.Windows.Forms.RadioButton();
            this.filterTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.filterOffButton = new System.Windows.Forms.RadioButton();
            this.viewLogsButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clearMonitoringButton = new System.Windows.Forms.Button();
            this.monitoringGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monitoringEventsButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fileInfoLabel = new System.Windows.Forms.Label();
            this.fileViewDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewLogsWaitButton = new System.Windows.Forms.Button();
            this.securityElReaderMultiThreadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.securityEventLogButton = new System.Windows.Forms.Button();
            this.securityElReaderOneThreadButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkIPButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eventLogsGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.filterByTimeGroupBox.SuspendLayout();
            this.filterByEventsGroupBox.SuspendLayout();
            this.filtersGroupBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileViewDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLogsGridView
            // 
            this.eventLogsGridView.AllowUserToAddRows = false;
            this.eventLogsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventLogsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.type,
            this.date,
            this.machine,
            this.message,
            this.IP});
            this.eventLogsGridView.Location = new System.Drawing.Point(0, 0);
            this.eventLogsGridView.Name = "eventLogsGridView";
            this.eventLogsGridView.ReadOnly = true;
            this.eventLogsGridView.Size = new System.Drawing.Size(667, 523);
            this.eventLogsGridView.TabIndex = 1;
            this.eventLogsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventLogsGridView_CellContentClick);
            this.eventLogsGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridsView_RowsAdded);
            // 
            // id
            // 
            this.id.HeaderText = "Идентификатор";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "Тип";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // date
            // 
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.date.DefaultCellStyle = dataGridViewCellStyle1;
            this.date.HeaderText = "Дата";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 120;
            // 
            // machine
            // 
            this.machine.HeaderText = "Компьютер";
            this.machine.Name = "machine";
            this.machine.ReadOnly = true;
            // 
            // message
            // 
            this.message.HeaderText = "Сообщение";
            this.message.Name = "message";
            this.message.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.statisticsButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(1031, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.pdfToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(49, 22);
            this.toolStripDropDownButton1.Text = "Файл";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileToolStripMenuItem.Image")));
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openFileToolStripMenuItem.Text = "Открыть";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Enabled = false;
            this.saveFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveFileToolStripMenuItem.Image")));
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.saveFileToolStripMenuItem.Text = "Сохранить";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // pdfToolStripMenuItem
            // 
            this.pdfToolStripMenuItem.Enabled = false;
            this.pdfToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pdfToolStripMenuItem.Image")));
            this.pdfToolStripMenuItem.Name = "pdfToolStripMenuItem";
            this.pdfToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pdfToolStripMenuItem.Text = "Сохранить PDF";
            this.pdfToolStripMenuItem.Click += new System.EventHandler(this.pdfToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableWhiteListToolStripMenuItem,
            this.editWhiteListToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(64, 22);
            this.toolStripDropDownButton2.Text = "IP Menu";
            // 
            // enableWhiteListToolStripMenuItem
            // 
            this.enableWhiteListToolStripMenuItem.Checked = true;
            this.enableWhiteListToolStripMenuItem.CheckOnClick = true;
            this.enableWhiteListToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableWhiteListToolStripMenuItem.Name = "enableWhiteListToolStripMenuItem";
            this.enableWhiteListToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.enableWhiteListToolStripMenuItem.Text = "Включить белый список";
            this.enableWhiteListToolStripMenuItem.CheckedChanged += new System.EventHandler(this.enableWhiteListToolStripMenuItem_CheckedChanged);
            // 
            // editWhiteListToolStripMenuItem
            // 
            this.editWhiteListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editWhiteListToolStripMenuItem.Image")));
            this.editWhiteListToolStripMenuItem.Name = "editWhiteListToolStripMenuItem";
            this.editWhiteListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editWhiteListToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.editWhiteListToolStripMenuItem.Text = "Редактировать белый список";
            this.editWhiteListToolStripMenuItem.Click += new System.EventHandler(this.editWhiteListToolStripMenuItem_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.Enabled = false;
            this.statisticsButton.Image = ((System.Drawing.Image)(resources.GetObject("statisticsButton.Image")));
            this.statisticsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(88, 22);
            this.statisticsButton.Text = "Статистика";
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1031, 550);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.clearLogsButton);
            this.tabPage1.Controls.Add(this.filterByTimeGroupBox);
            this.tabPage1.Controls.Add(this.filterByEventsGroupBox);
            this.tabPage1.Controls.Add(this.filtersGroupBox);
            this.tabPage1.Controls.Add(this.eventLogsGridView);
            this.tabPage1.Controls.Add(this.viewLogsButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1023, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Просмотр событий";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // clearLogsButton
            // 
            this.clearLogsButton.Enabled = false;
            this.clearLogsButton.Image = ((System.Drawing.Image)(resources.GetObject("clearLogsButton.Image")));
            this.clearLogsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearLogsButton.Location = new System.Drawing.Point(681, 217);
            this.clearLogsButton.Name = "clearLogsButton";
            this.clearLogsButton.Size = new System.Drawing.Size(111, 40);
            this.clearLogsButton.TabIndex = 27;
            this.clearLogsButton.Text = "Очистить вывод";
            this.clearLogsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clearLogsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.clearLogsButton.UseVisualStyleBackColor = true;
            this.clearLogsButton.Click += new System.EventHandler(this.clearLogsButton_Click);
            // 
            // filterByTimeGroupBox
            // 
            this.filterByTimeGroupBox.Controls.Add(this.label4);
            this.filterByTimeGroupBox.Controls.Add(this.label3);
            this.filterByTimeGroupBox.Controls.Add(this.fromDateTimePicker);
            this.filterByTimeGroupBox.Controls.Add(this.toDateTimePicker);
            this.filterByTimeGroupBox.Enabled = false;
            this.filterByTimeGroupBox.Location = new System.Drawing.Point(802, 6);
            this.filterByTimeGroupBox.Name = "filterByTimeGroupBox";
            this.filterByTimeGroupBox.Size = new System.Drawing.Size(218, 100);
            this.filterByTimeGroupBox.TabIndex = 26;
            this.filterByTimeGroupBox.TabStop = false;
            this.filterByTimeGroupBox.Text = "Фильтр по дате";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "До";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "От";
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Location = new System.Drawing.Point(4, 34);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fromDateTimePicker.TabIndex = 17;
            this.fromDateTimePicker.Value = new System.DateTime(2019, 5, 4, 20, 16, 10, 0);
            this.fromDateTimePicker.ValueChanged += new System.EventHandler(this.filterDateTimePicker_ValueChanged);
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Location = new System.Drawing.Point(6, 78);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.toDateTimePicker.TabIndex = 18;
            this.toDateTimePicker.Value = new System.DateTime(2019, 5, 5, 0, 0, 0, 0);
            this.toDateTimePicker.ValueChanged += new System.EventHandler(this.filterDateTimePicker_ValueChanged);
            // 
            // filterByEventsGroupBox
            // 
            this.filterByEventsGroupBox.Controls.Add(this.sysLabel);
            this.filterByEventsGroupBox.Controls.Add(this.rcmLabel);
            this.filterByEventsGroupBox.Controls.Add(this.lsmLabel);
            this.filterByEventsGroupBox.Controls.Add(this.secLabel);
            this.filterByEventsGroupBox.Controls.Add(this.systemIDcheckedListBox);
            this.filterByEventsGroupBox.Controls.Add(this.remoteConnectionIDcheckedListBox);
            this.filterByEventsGroupBox.Controls.Add(this.securityIDcheckedListBox);
            this.filterByEventsGroupBox.Controls.Add(this.localServiceManagerIDcheckedListBox);
            this.filterByEventsGroupBox.Enabled = false;
            this.filterByEventsGroupBox.Location = new System.Drawing.Point(802, 115);
            this.filterByEventsGroupBox.Name = "filterByEventsGroupBox";
            this.filterByEventsGroupBox.Size = new System.Drawing.Size(218, 401);
            this.filterByEventsGroupBox.TabIndex = 25;
            this.filterByEventsGroupBox.TabStop = false;
            this.filterByEventsGroupBox.Text = "Фильтры по событиям";
            // 
            // sysLabel
            // 
            this.sysLabel.AutoSize = true;
            this.sysLabel.Location = new System.Drawing.Point(9, 311);
            this.sysLabel.Name = "sysLabel";
            this.sysLabel.Size = new System.Drawing.Size(84, 13);
            this.sysLabel.TabIndex = 32;
            this.sysLabel.Text = "Журнал System";
            // 
            // rcmLabel
            // 
            this.rcmLabel.AutoSize = true;
            this.rcmLabel.Location = new System.Drawing.Point(9, 271);
            this.rcmLabel.Name = "rcmLabel";
            this.rcmLabel.Size = new System.Drawing.Size(183, 13);
            this.rcmLabel.TabIndex = 31;
            this.rcmLabel.Text = "Журнал RemoteConnectionManager";
            // 
            // lsmLabel
            // 
            this.lsmLabel.AutoSize = true;
            this.lsmLabel.Location = new System.Drawing.Point(9, 18);
            this.lsmLabel.Name = "lsmLabel";
            this.lsmLabel.Size = new System.Drawing.Size(155, 13);
            this.lsmLabel.TabIndex = 30;
            this.lsmLabel.Text = "Журнал LocalSessionManager";
            // 
            // secLabel
            // 
            this.secLabel.AutoSize = true;
            this.secLabel.Location = new System.Drawing.Point(9, 158);
            this.secLabel.Name = "secLabel";
            this.secLabel.Size = new System.Drawing.Size(88, 13);
            this.secLabel.TabIndex = 29;
            this.secLabel.Text = "Журнал Security";
            // 
            // systemIDcheckedListBox
            // 
            this.systemIDcheckedListBox.FormattingEnabled = true;
            this.systemIDcheckedListBox.Location = new System.Drawing.Point(9, 327);
            this.systemIDcheckedListBox.Name = "systemIDcheckedListBox";
            this.systemIDcheckedListBox.Size = new System.Drawing.Size(203, 19);
            this.systemIDcheckedListBox.TabIndex = 28;
            this.systemIDcheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.filtersCheckedListBox_ItemCheck);
            this.systemIDcheckedListBox.MouseHover += new System.EventHandler(this.checkedListBox_MouseHover);
            this.systemIDcheckedListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_MouseMove);
            // 
            // remoteConnectionIDcheckedListBox
            // 
            this.remoteConnectionIDcheckedListBox.FormattingEnabled = true;
            this.remoteConnectionIDcheckedListBox.Location = new System.Drawing.Point(9, 287);
            this.remoteConnectionIDcheckedListBox.Name = "remoteConnectionIDcheckedListBox";
            this.remoteConnectionIDcheckedListBox.Size = new System.Drawing.Size(203, 19);
            this.remoteConnectionIDcheckedListBox.TabIndex = 27;
            this.remoteConnectionIDcheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.filtersCheckedListBox_ItemCheck);
            this.remoteConnectionIDcheckedListBox.MouseHover += new System.EventHandler(this.checkedListBox_MouseHover);
            this.remoteConnectionIDcheckedListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_MouseMove);
            // 
            // securityIDcheckedListBox
            // 
            this.securityIDcheckedListBox.FormattingEnabled = true;
            this.securityIDcheckedListBox.Location = new System.Drawing.Point(9, 174);
            this.securityIDcheckedListBox.Name = "securityIDcheckedListBox";
            this.securityIDcheckedListBox.Size = new System.Drawing.Size(203, 94);
            this.securityIDcheckedListBox.TabIndex = 26;
            this.securityIDcheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.filtersCheckedListBox_ItemCheck);
            this.securityIDcheckedListBox.MouseHover += new System.EventHandler(this.checkedListBox_MouseHover);
            this.securityIDcheckedListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_MouseMove);
            // 
            // localServiceManagerIDcheckedListBox
            // 
            this.localServiceManagerIDcheckedListBox.FormattingEnabled = true;
            this.localServiceManagerIDcheckedListBox.Location = new System.Drawing.Point(9, 31);
            this.localServiceManagerIDcheckedListBox.Name = "localServiceManagerIDcheckedListBox";
            this.localServiceManagerIDcheckedListBox.Size = new System.Drawing.Size(203, 124);
            this.localServiceManagerIDcheckedListBox.TabIndex = 22;
            this.localServiceManagerIDcheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.filtersCheckedListBox_ItemCheck);
            this.localServiceManagerIDcheckedListBox.MouseHover += new System.EventHandler(this.checkedListBox_MouseHover);
            this.localServiceManagerIDcheckedListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_MouseMove);
            // 
            // filtersGroupBox
            // 
            this.filtersGroupBox.Controls.Add(this.filterEventsCheckBox);
            this.filtersGroupBox.Controls.Add(this.filterOnButton);
            this.filtersGroupBox.Controls.Add(this.filterTimeCheckBox);
            this.filtersGroupBox.Controls.Add(this.filterOffButton);
            this.filtersGroupBox.Location = new System.Drawing.Point(681, 6);
            this.filtersGroupBox.Name = "filtersGroupBox";
            this.filtersGroupBox.Size = new System.Drawing.Size(111, 144);
            this.filtersGroupBox.TabIndex = 21;
            this.filtersGroupBox.TabStop = false;
            this.filtersGroupBox.Text = "Фильтрация";
            // 
            // filterEventsCheckBox
            // 
            this.filterEventsCheckBox.AutoSize = true;
            this.filterEventsCheckBox.Enabled = false;
            this.filterEventsCheckBox.Location = new System.Drawing.Point(21, 83);
            this.filterEventsCheckBox.Name = "filterEventsCheckBox";
            this.filterEventsCheckBox.Size = new System.Drawing.Size(94, 17);
            this.filterEventsCheckBox.TabIndex = 30;
            this.filterEventsCheckBox.Text = "По событиям";
            this.filterEventsCheckBox.UseVisualStyleBackColor = true;
            this.filterEventsCheckBox.CheckedChanged += new System.EventHandler(this.filterCheckBoxes_CheckedChanged);
            // 
            // filterOnButton
            // 
            this.filterOnButton.AutoSize = true;
            this.filterOnButton.Location = new System.Drawing.Point(6, 42);
            this.filterOnButton.Name = "filterOnButton";
            this.filterOnButton.Size = new System.Drawing.Size(75, 17);
            this.filterOnButton.TabIndex = 3;
            this.filterOnButton.TabStop = true;
            this.filterOnButton.Text = "Включена";
            this.filterOnButton.UseVisualStyleBackColor = true;
            this.filterOnButton.CheckedChanged += new System.EventHandler(this.filterButtons_CheckedChanged);
            // 
            // filterTimeCheckBox
            // 
            this.filterTimeCheckBox.AutoSize = true;
            this.filterTimeCheckBox.Enabled = false;
            this.filterTimeCheckBox.Location = new System.Drawing.Point(21, 65);
            this.filterTimeCheckBox.Name = "filterTimeCheckBox";
            this.filterTimeCheckBox.Size = new System.Drawing.Size(66, 17);
            this.filterTimeCheckBox.TabIndex = 29;
            this.filterTimeCheckBox.Text = "По дате";
            this.filterTimeCheckBox.UseVisualStyleBackColor = true;
            this.filterTimeCheckBox.CheckedChanged += new System.EventHandler(this.filterCheckBoxes_CheckedChanged);
            // 
            // filterOffButton
            // 
            this.filterOffButton.AutoSize = true;
            this.filterOffButton.Checked = true;
            this.filterOffButton.Location = new System.Drawing.Point(6, 19);
            this.filterOffButton.Name = "filterOffButton";
            this.filterOffButton.Size = new System.Drawing.Size(81, 17);
            this.filterOffButton.TabIndex = 2;
            this.filterOffButton.TabStop = true;
            this.filterOffButton.Text = "Отключена";
            this.filterOffButton.UseVisualStyleBackColor = true;
            this.filterOffButton.CheckedChanged += new System.EventHandler(this.filterButtons_CheckedChanged);
            // 
            // viewLogsButton
            // 
            this.viewLogsButton.Image = ((System.Drawing.Image)(resources.GetObject("viewLogsButton.Image")));
            this.viewLogsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewLogsButton.Location = new System.Drawing.Point(681, 171);
            this.viewLogsButton.Name = "viewLogsButton";
            this.viewLogsButton.Size = new System.Drawing.Size(111, 40);
            this.viewLogsButton.TabIndex = 16;
            this.viewLogsButton.Text = "Просмотр логов";
            this.viewLogsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.viewLogsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewLogsButton.UseVisualStyleBackColor = true;
            this.viewLogsButton.Click += new System.EventHandler(this.viewLogsButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.clearMonitoringButton);
            this.tabPage2.Controls.Add(this.monitoringGridView);
            this.tabPage2.Controls.Add(this.monitoringEventsButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Мониторинг событий";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clearMonitoringButton
            // 
            this.clearMonitoringButton.Image = ((System.Drawing.Image)(resources.GetObject("clearMonitoringButton.Image")));
            this.clearMonitoringButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearMonitoringButton.Location = new System.Drawing.Point(807, 64);
            this.clearMonitoringButton.Name = "clearMonitoringButton";
            this.clearMonitoringButton.Size = new System.Drawing.Size(156, 43);
            this.clearMonitoringButton.TabIndex = 4;
            this.clearMonitoringButton.Text = "Очистить вывод";
            this.clearMonitoringButton.UseVisualStyleBackColor = true;
            this.clearMonitoringButton.Click += new System.EventHandler(this.clearMonitoringButton_Click);
            // 
            // monitoringGridView
            // 
            this.monitoringGridView.AllowUserToAddRows = false;
            this.monitoringGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monitoringGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.monitoringGridView.Location = new System.Drawing.Point(0, 0);
            this.monitoringGridView.Name = "monitoringGridView";
            this.monitoringGridView.Size = new System.Drawing.Size(667, 523);
            this.monitoringGridView.TabIndex = 3;
            this.monitoringGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventLogsGridView_CellContentClick);
            this.monitoringGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridsView_RowsAdded);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Идентификатор";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Компьютер";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Сообщение";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "IP";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // monitoringEventsButton
            // 
            this.monitoringEventsButton.Image = ((System.Drawing.Image)(resources.GetObject("monitoringEventsButton.Image")));
            this.monitoringEventsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.monitoringEventsButton.Location = new System.Drawing.Point(807, 6);
            this.monitoringEventsButton.Name = "monitoringEventsButton";
            this.monitoringEventsButton.Size = new System.Drawing.Size(156, 43);
            this.monitoringEventsButton.TabIndex = 1;
            this.monitoringEventsButton.Text = "Включить мониторинг";
            this.monitoringEventsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.monitoringEventsButton.UseVisualStyleBackColor = true;
            this.monitoringEventsButton.Click += new System.EventHandler(this.monitoringEventsButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.fileInfoLabel);
            this.tabPage3.Controls.Add(this.fileViewDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(596, 524);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Файл";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fileInfoLabel
            // 
            this.fileInfoLabel.AutoSize = true;
            this.fileInfoLabel.Location = new System.Drawing.Point(747, 237);
            this.fileInfoLabel.Name = "fileInfoLabel";
            this.fileInfoLabel.Size = new System.Drawing.Size(298, 13);
            this.fileInfoLabel.TabIndex = 35;
            this.fileInfoLabel.Text = "Чтобы открыть файл, перейдите в меню Файл->Открыть";
            // 
            // fileViewDataGridView
            // 
            this.fileViewDataGridView.AllowUserToAddRows = false;
            this.fileViewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileViewDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.fileViewDataGridView.Location = new System.Drawing.Point(0, 0);
            this.fileViewDataGridView.Name = "fileViewDataGridView";
            this.fileViewDataGridView.Size = new System.Drawing.Size(667, 523);
            this.fileViewDataGridView.TabIndex = 34;
            this.fileViewDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventLogsGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Идентификатор";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn9.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Компьютер";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Сообщение";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "IP";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // viewLogsWaitButton
            // 
            this.viewLogsWaitButton.Location = new System.Drawing.Point(684, 270);
            this.viewLogsWaitButton.Name = "viewLogsWaitButton";
            this.viewLogsWaitButton.Size = new System.Drawing.Size(110, 23);
            this.viewLogsWaitButton.TabIndex = 36;
            this.viewLogsWaitButton.Text = "wait window";
            this.viewLogsWaitButton.UseVisualStyleBackColor = true;
            this.viewLogsWaitButton.Click += new System.EventHandler(this.viewLogsWaitButton_Click);
            // 
            // securityElReaderMultiThreadButton
            // 
            this.securityElReaderMultiThreadButton.Location = new System.Drawing.Point(681, 67);
            this.securityElReaderMultiThreadButton.Name = "securityElReaderMultiThreadButton";
            this.securityElReaderMultiThreadButton.Size = new System.Drawing.Size(126, 23);
            this.securityElReaderMultiThreadButton.TabIndex = 37;
            this.securityElReaderMultiThreadButton.Text = "Sec ElRead MultiThread";
            this.securityElReaderMultiThreadButton.UseVisualStyleBackColor = true;
            this.securityElReaderMultiThreadButton.Click += new System.EventHandler(this.securityElReaderMultiThreadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(837, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "К проверке";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(996, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "label2";
            // 
            // securityEventLogButton
            // 
            this.securityEventLogButton.Location = new System.Drawing.Point(695, 9);
            this.securityEventLogButton.Name = "securityEventLogButton";
            this.securityEventLogButton.Size = new System.Drawing.Size(75, 23);
            this.securityEventLogButton.TabIndex = 35;
            this.securityEventLogButton.Text = "Sec EvLog";
            this.securityEventLogButton.UseVisualStyleBackColor = true;
            this.securityEventLogButton.Click += new System.EventHandler(this.securityEventLogButton_Click);
            // 
            // securityElReaderOneThreadButton
            // 
            this.securityElReaderOneThreadButton.Location = new System.Drawing.Point(681, 38);
            this.securityElReaderOneThreadButton.Name = "securityElReaderOneThreadButton";
            this.securityElReaderOneThreadButton.Size = new System.Drawing.Size(140, 23);
            this.securityElReaderOneThreadButton.TabIndex = 36;
            this.securityElReaderOneThreadButton.Text = "Sec ElRead OneThread";
            this.securityElReaderOneThreadButton.UseVisualStyleBackColor = true;
            this.securityElReaderOneThreadButton.Click += new System.EventHandler(this.securityElReaderOneThreadButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1035, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 25;
            this.button5.Text = " str is ip?";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkIPButton
            // 
            this.checkIPButton.Location = new System.Drawing.Point(1018, 37);
            this.checkIPButton.Name = "checkIPButton";
            this.checkIPButton.Size = new System.Drawing.Size(95, 23);
            this.checkIPButton.TabIndex = 33;
            this.checkIPButton.Text = "В белом?";
            this.checkIPButton.UseVisualStyleBackColor = true;
            this.checkIPButton.Click += new System.EventHandler(this.checkIPButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(930, 117);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(175, 114);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(782, 265);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(323, 250);
            this.richTextBox3.TabIndex = 32;
            this.richTextBox3.Text = resources.GetString("richTextBox3.Text");
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(908, 40);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 20;
            this.textBox3.Text = "95.158.238.123";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(908, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 24;
            this.textBox4.Text = "192.168.1.1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 575);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RDP Logs Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.eventLogsGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.filterByTimeGroupBox.ResumeLayout(false);
            this.filterByTimeGroupBox.PerformLayout();
            this.filterByEventsGroupBox.ResumeLayout(false);
            this.filterByEventsGroupBox.PerformLayout();
            this.filtersGroupBox.ResumeLayout(false);
            this.filtersGroupBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monitoringGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileViewDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion
        private System.Windows.Forms.DataGridView eventLogsGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem enableWhiteListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editWhiteListToolStripMenuItem;
        private System.Windows.Forms.Button viewLogsButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button monitoringEventsButton;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.GroupBox filtersGroupBox;
        private System.Windows.Forms.CheckedListBox localServiceManagerIDcheckedListBox;
        private System.Windows.Forms.CheckedListBox securityIDcheckedListBox;
        private System.Windows.Forms.GroupBox filterByEventsGroupBox;
        private System.Windows.Forms.CheckedListBox remoteConnectionIDcheckedListBox;
        private System.Windows.Forms.RadioButton filterOffButton;
        private System.Windows.Forms.GroupBox filterByTimeGroupBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox filterEventsCheckBox;
        private System.Windows.Forms.CheckBox filterTimeCheckBox;
        private System.Windows.Forms.RadioButton filterOnButton;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.DataGridView monitoringGridView;
        private System.Windows.Forms.Button checkIPButton;
        private System.Windows.Forms.DataGridView fileViewDataGridView;
        private System.Windows.Forms.Button clearMonitoringButton;
        private System.Windows.Forms.ToolStripMenuItem pdfToolStripMenuItem;
        private System.Windows.Forms.Button clearLogsButton;
        private System.Windows.Forms.CheckedListBox systemIDcheckedListBox;
        private System.Windows.Forms.Label lsmLabel;
        private System.Windows.Forms.Label secLabel;
        private System.Windows.Forms.Label sysLabel;
        private System.Windows.Forms.Label rcmLabel;
        private System.Windows.Forms.Button securityEventLogButton;
        private System.Windows.Forms.Button securityElReaderOneThreadButton;
        private System.Windows.Forms.ToolStripButton statisticsButton;
        private System.Windows.Forms.Label fileInfoLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.Button securityElReaderMultiThreadButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn machine;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button viewLogsWaitButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

