using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QuickReminders
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static class GlobalConstants
        {
            public static String programFolder = System.Environment.GetEnvironmentVariable("AppData") + "\\QuickReminders\\";
            public static String reminderCSV = programFolder + "Reminders.csv";
            public static String reminderCSVLog = programFolder + "RemindersLog.csv";
            public static String settingsINI = programFolder + "Settings.ini";
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            String line;
            Directory.CreateDirectory(GlobalConstants.programFolder);
            
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader reminderCSVSR = new StreamReader(GlobalConstants.reminderCSV);
                //Read the first line of text
                line = reminderCSVSR.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //Read the fixed width sorting date/time and display date/time plus the message
                    string sortingDateTime = line.Substring(0, 19);
                    string displayDateTime = line.Substring(20, 16);
                    string reminderMessage = line.Substring(37);
                    String[] reminderFromCSV = { sortingDateTime, displayDateTime, reminderMessage };
                    //Build the list item array then add a new item to the listview
                    ListViewItem newReminder = new ListViewItem(reminderFromCSV);
                    ReminderList.Items.Add(newReminder);
                    //Read the next line
                    line = reminderCSVSR.ReadLine();
                }
                //close the file
                reminderCSVSR.Close();
            }
            catch (Exception f)
            {
                Console.WriteLine("Exception: " + f.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            String line;

            try
            {
                //Open the settings file
                StreamReader settingsFileSR = new StreamReader(GlobalConstants.settingsINI);
                //Read the first line of text
                line = settingsFileSR.ReadLine();
                //Continue to read until EOF reached
                while (line != null)
                {
                    //Get the 'Always On Top' setting and apply it to the form
                    String[] settingsFileLine = line.Split(':');
                    if (settingsFileLine[0].Contains("AlwaysOnTop"))
                    {
                        bool settingValue = System.Convert.ToBoolean(settingsFileLine[1]);
                        Form.ActiveForm.TopMost = settingValue;
                        AlwaysOnTopCheckbox.Checked = settingValue;
                    }
                    //Get the 'Dark Mode' setting and change colours based on value
                    if (settingsFileLine[0].Contains("DarkMode"))
                    {
                        bool settingValue = System.Convert.ToBoolean(settingsFileLine[1]);
                        DarkModeCheckbox.Checked = settingValue;
                        if (DarkModeCheckbox.Checked)
                        {
                            this.BackColor = Color.DimGray;
                            newReminderGroup.ForeColor = Color.White;
                            reminderListGroup.ForeColor = Color.White;
                            reminderControlGroup.ForeColor = Color.White;
                            AboutButton.ForeColor = Color.White;

                            ReminderList.BackColor = Color.Gray;
                            ReminderList.ForeColor = Color.White;
                            DateTimeLabel.ForeColor = Color.White;
                            MessageLabel.ForeColor = Color.White;

                        }
                        else
                        {
                            this.BackColor = SystemColors.Control;
                            newReminderGroup.ForeColor = SystemColors.ControlText;
                            reminderListGroup.ForeColor = SystemColors.ControlText;
                            reminderControlGroup.ForeColor = SystemColors.ControlText;
                            AboutButton.ForeColor = SystemColors.ControlText;

                            ReminderList.BackColor = SystemColors.Window;
                            ReminderList.ForeColor = SystemColors.WindowText;
                            DateTimeLabel.ForeColor = SystemColors.ControlText;
                            MessageLabel.ForeColor = SystemColors.ControlText;
                        }

                    }
                    //Get the 'Mute Reminders' setting and set the checkbox to its value
                    if (settingsFileLine[0].Contains("MuteReminderSounds"))
                    {
                        bool settingValue = System.Convert.ToBoolean(settingsFileLine[1]);
                        MuteReminderSounds.Checked = settingValue;
                    }

                    line = settingsFileSR.ReadLine();
                }
                settingsFileSR.Close();
            }
            catch (Exception f)
            {
                Console.WriteLine("Exception: " + f.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            ApplySettingsButton.Enabled = false;
            DeleteRemindersButton.Enabled = false;

            if (ReminderList.Items.Count > 0)
            {
                DateTime dateTimeReminderUTC = Convert.ToDateTime(ReminderList.Items[0].SubItems[0].Text);
                var timeUntilReminder = dateTimeReminderUTC.Subtract(DateTime.Now);
                if (timeUntilReminder.TotalSeconds <= 30 & timeUntilReminder.TotalSeconds > 0)
                {
                    Timer1Second.Enabled = true;
                }
                else if (timeUntilReminder.TotalSeconds < 0)
                {
                    if (MuteReminderSounds.Checked == false)
                    {
                        System.Media.SystemSounds.Hand.Play();
                    }
                    Timer1Second.Enabled = true;
                }
            }

        }

        //Import DLL for flashing Task Bar icon effect
        [DllImport("user32.dll")]
        public static extern int FlashWindow(IntPtr Hwnd, bool Revert);


        private void AddReminderButton_Click(object sender, EventArgs e)
        {
            //If there's something in the 'message' textbox...
            if (reminderMessageTextbox.TextLength > 0)
            {
                string[] newReminderEntry = new string[3];
                string dateWith24HTime = reminderDate.Value.ToString("d") + " " + reminderTime.Value.ToString("HH:mm");
                DateTime sortableDateTime = Convert.ToDateTime(dateWith24HTime);

                newReminderEntry[0] = sortableDateTime.ToString("s");
                newReminderEntry[1] = reminderDate.Text + " - " + reminderTime.Text;
                newReminderEntry[2] = reminderMessageTextbox.Text;

                ListViewItem newReminder = new ListViewItem(newReminderEntry);
                ReminderList.Items.Add(newReminder);
                
                String reminderCSVEntry = newReminderEntry[0] + "¦" + newReminderEntry[1] + "¦" + newReminderEntry[2];
                String reminderLogEntry = "ADD," + reminderCSVEntry;
                File.AppendAllText(GlobalConstants.reminderCSV, reminderCSVEntry + Environment.NewLine);
                File.AppendAllText(GlobalConstants.reminderCSVLog, reminderLogEntry + Environment.NewLine);

                //Clear the message textbox
                reminderMessageTextbox.Clear();

                if (Convert.ToDateTime(newReminderEntry[0]) < DateTime.Now)
                {
                    if (MuteReminderSounds.Checked == false)
                    {
                        System.Media.SystemSounds.Hand.Play();
                    }
                    Timer1Second.Enabled = true;
                }
            }
        }



        private void DeleteRemindersButton_Click(object sender, EventArgs e)
        {
            //Cycle through all of the reminders
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                //If this one is checked...
                if (ReminderList.Items[i].Checked)
                {
                    //...then log it...
                    String reminderCSVEntry = ReminderList.Items[i].SubItems[0].Text + "¦" + ReminderList.Items[i].SubItems[1].Text + "¦" + ReminderList.Items[i].SubItems[2].Text;
                    String reminderLogEntry = "DEL," + reminderCSVEntry;
                    File.AppendAllText(GlobalConstants.reminderCSVLog, reminderLogEntry + Environment.NewLine);
                    //...delete it...
                    ReminderList.Items[i].Remove();
                    //...and subtract 1 from the row number being checked so the same row is checked again
                    i--;
                }
            }

            if (ReminderList.Items.Count == 0)
            {
                Timer1Second.Enabled = false;
            }

            //Re-create the reminderCSV file
            File.Delete(GlobalConstants.reminderCSV);
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                String reminderCSVEntry = ReminderList.Items[i].SubItems[0].Text + "¦" + ReminderList.Items[i].SubItems[1].Text + "¦" + ReminderList.Items[i].SubItems[2].Text;
                File.AppendAllText(GlobalConstants.reminderCSV, reminderCSVEntry + Environment.NewLine);
            }
                
            DeleteRemindersButton.Enabled = false;
            CopyAsNewButton.Enabled = false;
            Delay10MinutesButton.Enabled = false;
            Delay1HourButton.Enabled = false;
        }

        private void ReminderList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CopyAsNewButton.Enabled = false;
            Delay1HourButton.Enabled = false;
            Delay10MinutesButton.Enabled = false;
            int numberSelected = 0;
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                if (ReminderList.Items[i].Checked)
                {
                    numberSelected++;
                }
            }
            if (numberSelected > 0)
            {
                DeleteRemindersButton.Enabled = true;
                if (numberSelected == 1)
                {
                    CopyAsNewButton.Enabled = true;
                    Delay1HourButton.Enabled = true;
                    Delay10MinutesButton.Enabled = true;
                }
            }
            else
            {
                DeleteRemindersButton.Enabled = false;
                CopyAsNewButton.Enabled = false;
                Delay1HourButton.Enabled = false;
                Delay10MinutesButton.Enabled = false;
            }

        }


        private void AlwaysOnTopCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ApplySettingsButton.Enabled = true;
        }

        private void ApplySettingsButton_Click(object sender, EventArgs e)
        {
            File.Delete(GlobalConstants.settingsINI);
            Form.ActiveForm.TopMost = AlwaysOnTopCheckbox.Checked;
            File.AppendAllText(GlobalConstants.settingsINI, "AlwaysOnTop:" + AlwaysOnTopCheckbox.Checked + Environment.NewLine);
            File.AppendAllText(GlobalConstants.settingsINI, "DarkMode:" + DarkModeCheckbox.Checked + Environment.NewLine);
            File.AppendAllText(GlobalConstants.settingsINI, "MuteReminderSounds:" + MuteReminderSounds.Checked + Environment.NewLine);

            if (DarkModeCheckbox.Checked)
            {
                this.BackColor = SystemColors.WindowFrame;
                newReminderGroup.ForeColor = Color.White;
                reminderListGroup.ForeColor = Color.White;
                reminderControlGroup.ForeColor = Color.White;
                AboutButton.ForeColor = Color.White;

                ReminderList.BackColor = Color.Gray;
                ReminderList.ForeColor = Color.White;
                DateTimeLabel.ForeColor = Color.White;
                MessageLabel.ForeColor = Color.White;
                
            }
            else
            {
                this.BackColor = SystemColors.Control;
                newReminderGroup.ForeColor = SystemColors.ControlText;
                reminderListGroup.ForeColor = SystemColors.ControlText;
                reminderControlGroup.ForeColor = SystemColors.ControlText;
                AboutButton.ForeColor = SystemColors.ControlText;

                ReminderList.BackColor = SystemColors.Window;
                ReminderList.ForeColor = SystemColors.WindowText;
                DateTimeLabel.ForeColor = SystemColors.ControlText;
                MessageLabel.ForeColor = SystemColors.ControlText;
            }

            
            ApplySettingsButton.Enabled = false;
        }

        private void DarkModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ApplySettingsButton.Enabled = true;
        }

        private void MuteReminderSounds_CheckedChanged(object sender, EventArgs e)
        {
            ApplySettingsButton.Enabled = true;
        }


        private void Timer15Seconds_Tick(object sender, EventArgs e)
        {
            if (ReminderList.Items.Count > 0)
            {
                DateTime dateTimeReminderUTC = Convert.ToDateTime(ReminderList.Items[0].SubItems[0].Text);
                var timeUntilReminder = dateTimeReminderUTC.Subtract(DateTime.Now);
                if (timeUntilReminder.TotalSeconds <= 30)
                {
                    Timer1Second.Enabled = true;
                }
                else
                {
                    Timer1Second.Enabled = false;
                }
            }
            else
            {
                Timer1Second.Enabled = false;
            }

            if (!this.ContainsFocus)
            {
                reminderDate.Value = DateTime.Now;
                reminderTime.Value = DateTime.Now;
            }

         }

        private void Timer1Second_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                DateTime dateTimeReminderUTC = Convert.ToDateTime(ReminderList.Items[i].SubItems[0].Text);
                var timeUntilReminder = dateTimeReminderUTC.Subtract(DateTime.Now);
                if (timeUntilReminder.TotalSeconds > 0 & timeUntilReminder.TotalSeconds <= 1)
                {
                    if (MuteReminderSounds.Checked == false)
                    {
                        System.Media.SystemSounds.Hand.Play();
                    }
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        FlashWindow(this.Handle, true);
                    }
                }

                if (Convert.ToDateTime(ReminderList.Items[i].SubItems[0].Text) < DateTime.Now)
                {
                    if (ReminderList.Items[i].BackColor == Color.Red)
                    {
                        if (ReminderList.BackColor == Color.Gray)
                        {
                            ReminderList.Items[i].BackColor = Color.Gray;
                        }
                        else
                        {
                            ReminderList.Items[i].BackColor = Color.White;
                        }
                    }
                    else
                    {
                        ReminderList.Items[i].BackColor = Color.Red;
                    }
                }
                else
                {
                    break;
                }
            }
        }


        private void Delay1HourButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                if (ReminderList.Items[i].Checked)
                {

                    string[] newReminderEntry = new string[3];

                    DateTime dateTimePlus1Hour = Convert.ToDateTime(ReminderList.Items[i].SubItems[0].Text);
                    dateTimePlus1Hour = dateTimePlus1Hour.AddHours(1);

                    newReminderEntry[0] = dateTimePlus1Hour.ToString("s");
                    newReminderEntry[1] = dateTimePlus1Hour.ToString("dd/MM") + " - " + dateTimePlus1Hour.ToString("hh:mm tt");
                    newReminderEntry[2] = ReminderList.Items[i].SubItems[2].Text;

                    ListViewItem newReminder = new ListViewItem(newReminderEntry);
                    ReminderList.Items.Add(newReminder);
                    ReminderList.Items[i].Remove();

                    File.Delete(GlobalConstants.reminderCSV);
                    for (int j = 0; j < ReminderList.Items.Count; j++)
                    {
                        String reminderCSVEntry = ReminderList.Items[j].SubItems[0].Text + "¦" + ReminderList.Items[j].SubItems[1].Text + "¦" + ReminderList.Items[j].SubItems[2].Text;
                        File.AppendAllText(GlobalConstants.reminderCSV, reminderCSVEntry + Environment.NewLine);
                    }

                    DeleteRemindersButton.Enabled = false;
                    CopyAsNewButton.Enabled = false;
                    Delay10MinutesButton.Enabled = false;
                    Delay1HourButton.Enabled = false;
                }



            }
        }

        private void Delay10MinutesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                if (ReminderList.Items[i].Checked)
                {

                    string[] newReminderEntry = new string[3];

                    DateTime dateTimePlus10Mins = Convert.ToDateTime(ReminderList.Items[i].SubItems[0].Text);
                    dateTimePlus10Mins = dateTimePlus10Mins.AddMinutes(10);

                    newReminderEntry[0] = dateTimePlus10Mins.ToString("s");
                    newReminderEntry[1] = dateTimePlus10Mins.ToString("dd/MM") + " - " + dateTimePlus10Mins.ToString("hh:mm tt");
                    newReminderEntry[2] = ReminderList.Items[i].SubItems[2].Text;

                    ListViewItem newReminder = new ListViewItem(newReminderEntry);
                    ReminderList.Items.Add(newReminder);
                    ReminderList.Items[i].Remove();

                    File.Delete(GlobalConstants.reminderCSV);
                    for (int j = 0; j < ReminderList.Items.Count; j++)
                    {
                        String reminderCSVEntry = ReminderList.Items[j].SubItems[0].Text + "¦" + ReminderList.Items[j].SubItems[1].Text + "¦" + ReminderList.Items[j].SubItems[2].Text;
                        File.AppendAllText(GlobalConstants.reminderCSV, reminderCSVEntry + Environment.NewLine);
                    }

                    DeleteRemindersButton.Enabled = false;
                    CopyAsNewButton.Enabled = false;
                    Delay10MinutesButton.Enabled = false;
                    Delay1HourButton.Enabled = false;

                }

            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm frm2 = new AboutForm();
            frm2.ShowDialog();

        }

        private void CopyAsNewButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                if (ReminderList.Items[i].Checked)
                {
                    reminderDate.Value = DateTime.Now;
                    reminderTime.Value = DateTime.Now;
                    reminderMessageTextbox.Text = ReminderList.Items[i].SubItems[2].Text;
                    ReminderList.Items[i].Checked = false;
                    DeleteRemindersButton.Enabled = false;
                    CopyAsNewButton.Enabled = false;
                    Delay10MinutesButton.Enabled = false;
                    Delay1HourButton.Enabled = false;
                }
            }
        }
    }
}
