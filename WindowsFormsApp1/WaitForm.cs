using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDPLogsViewer
{
    public partial class WaitForm : Form
    {
        private readonly MethodInvoker method;

        public WaitForm(MethodInvoker action)
        {
            InitializeComponent();
            method = action;
        }

        private void WaitForm_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                method.Invoke();
                InvokeAction(this, Dispose);
            }).Start();
        }

        public static void InvokeAction(Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
