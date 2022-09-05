using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickReminders
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void ProgramFilesButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", System.Environment.GetEnvironmentVariable("AppData") + "\\QuickReminders\\");
        }

        private void EmailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:websites@jeffhiggins.net?subject=Quick Reminders");
        }

    }
}
