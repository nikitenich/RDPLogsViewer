using System;
using System.Net;
using System.Windows.Forms;

namespace RDPLogsViewer
{
    public partial class IPWhiteListForm : Form
    {

        private IPWhiteList whiteList = IPWhiteList.getInstance();


        public IPWhiteListForm()
        {
            InitializeComponent();
            var source = new BindingSource(whiteList.getWhiteList(), null);
            whiteListGridView.DataSource = source;
        }

        string previousMaskValue;

        private void deleteIPbutton_Click(object sender, EventArgs e)
        {
            var d = whiteListGridView;
            BindingSource b = (BindingSource)d.DataSource;

            try
            {
                b.RemoveCurrent();
            }
            catch (Exception) {
                MessageBox.Show("Белый список пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void whiteListGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void addExceptionButton_Click(object sender, EventArgs e)
        {
            int mask=0;
            try {
                mask = Convert.ToInt32(maskTextBox.Text);
            }
            catch (Exception) {
                MessageBox.Show("Маска сети не может быть пустой","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPAddress address;
            IPAddress.TryParse(ipTextBox.Text, out address);

            if (address != null && (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                && (mask <= 32 && mask >= 0))
            {

                IPData ipd = new IPData(IPAddress.Parse(ipTextBox.Text), Convert.ToInt32(maskTextBox.Text)); //добавляем исключение
                whiteList.addToWhiteList(ipd);
            }
            else MessageBox.Show("Некорректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MaskTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void IpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void isSpecificIPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                previousMaskValue = maskTextBox.Text;
                maskTextBox.Text = "32";
                maskTextBox.Enabled = false;
            }
            else {
                maskTextBox.Text = previousMaskValue;
                maskTextBox.Enabled = true;
            }
        }
    }
}