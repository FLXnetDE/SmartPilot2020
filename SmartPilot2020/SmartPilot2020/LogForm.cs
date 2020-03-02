using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPilot2020
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        // Clear log
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            clbLog.Items.Clear();
        }

        // Add message to CheckedListBox
        public void Log(String text)
        {
            clbLog.Invoke((MethodInvoker)delegate
            {
                clbLog.Items.Add("[" + DateTime.Now + "] " + text);
            });
        }

    }
}
