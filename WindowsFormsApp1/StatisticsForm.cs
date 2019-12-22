using System;
using System.Windows.Forms;

namespace RDPLogsViewer
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        Statistics stat = Statistics.getInstance();

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            int all = myEvent.count;
            chart1.Series["s1"].IsValueShownAsLabel = true;
            chart1.Series["s1"].Points.AddXY("Локальные", stat.countLocal);
            chart1.Series["s1"].Points.AddXY("Внешние", stat.countExternal);
            chart1.Series["s1"].Points.AddXY("Без адресов", (all - stat.countElem));

            float withoutIP = (float)(all - stat.countElem)/all*100;

            label1.Text = "Уникальных IP-адресов: " + stat.getStatList().Count + "\n"
                + "Записей с локальными IP-адресами: " + stat.countLocal + " (" + (float)stat.countLocal/all*100 + "%)\n"
                + "Записей с внешними IP-адресами: " + stat.countExternal + " (" + (float)stat.countExternal / all * 100 + "%)\n"
                + "Всего записей с IP-адресами: " + stat.countElem + " (" + (float)stat.countElem / all * 100 + "%)\n"
                + "Записей без IP-адресов: " + (all - stat.countElem) + " ("+ withoutIP +"%)";
        }

        private void closeWindowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
