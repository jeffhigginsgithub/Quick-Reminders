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
            //Creates global constants for the program file paths
            public static String programFolder = System.Environment.GetEnvironmentVariable("AppData") + "\\QuickReminders\\";
            public static String reminderCSV = programFolder + "Reminders.csv";
            public static String reminderCSVLog = programFolder + "RemindersLog.csv";
            public static String settingsINI = programFolder + "Settings.ini";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            String line;
            //Attempt to create the QuickReminders appdata folder
            Directory.CreateDirectory(GlobalConstants.programFolder);
            
            try
            {
                //Pass the Reminders.csv file to the StreamReader constructor
                StreamReader reminderCSVSR = new StreamReader(GlobalConstants.reminderCSV);
                //Read the first line of text
                line = reminderCSVSR.ReadLine();
                //Continue to read until EOF reached
                while (line != null)
                {
                    //Read the fixed width sorting date/time and display date/time plus the message
                    string sortingDateTime = line.Substring(0, 19);
                    string displayDateTime = line.Substring(20, 16);
                    string reminderMessage = line.Substring(37);
                    //Create an array of these strings
                    String[] reminderFromCSV = { sortingDateTime, displayDateTime, reminderMessage };
                    //Add the array as a new item to the listview
                    ListViewItem newReminder = new ListViewItem(reminderFromCSV);
                    ReminderList.Items.Add(newReminder);
                    //Read the next line
                    line = reminderCSVSR.ReadLine();
                }
                //Close the file
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
                //Open the Settings.ini file
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
                            DelayCombobox.BackColor = Color.Gray;
                            DelayCombobox.ForeColor = Color.White;
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
                            DelayCombobox.BackColor = SystemColors.Window;
                            DelayCombobox.ForeColor = SystemColors.WindowText;
                        }
                    }
                    //Get the 'Mute Reminders' setting and set the checkbox to its value
                    if (settingsFileLine[0].Contains("MuteReminderSounds"))
                    {
                        bool settingValue = System.Convert.ToBoolean(settingsFileLine[1]);
                        MuteReminderSounds.Checked = settingValue;
                    }
                    //Move to the next line in Settings.ini (next setting)
                    line = settingsFileSR.ReadLine();
                }
                //Close the Settings.ini file
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

            //Set the initial conditions for some of the form objects
            ApplySettingsButton.Enabled = false;
            DeleteRemindersButton.Enabled = false;
            DelayCombobox.SelectedIndex = 0;

            //If reminders exist in the list...
            if (ReminderList.Items.Count > 0)
            {
                //Check to see if they're going to trigger in the next 30 seconds
                DateTime dateTimeReminderUTC = Convert.ToDateTime(ReminderList.Items[0].SubItems[0].Text);
                var timeUntilReminder = dateTimeReminderUTC.Subtract(DateTime.Now);
                if (timeUntilReminder.TotalSeconds <= 30 & timeUntilReminder.TotalSeconds > 0)
                {
                    //If so, enable the 1 second timer
                    Timer1Second.Enabled = true;
                }
                //If they should have already triggered...
                else if (timeUntilReminder.TotalSeconds < 0)
                {
                    //... and if not muted...
                    if (MuteReminderSounds.Checked == false)
                    {
                        //...play a sound
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

                //Create a new array with a sortable date, display date, and reminder message
                newReminderEntry[0] = sortableDateTime.ToString("s");
                newReminderEntry[1] = reminderDate.Text + " - " + reminderTime.Text;
                newReminderEntry[2] = reminderMessageTextbox.Text;

                //Create a new listview item based on the array's values
                ListViewItem newReminder = new ListViewItem(newReminderEntry);
                ReminderList.Items.Add(newReminder);
                
                //Write the new reminder to the Reminders.csv and RemindersLog.csv files
                String reminderCSVEntry = newReminderEntry[0] + "¦" + newReminderEntry[1] + "¦" + newReminderEntry[2];
                String reminderLogEntry = "ADD," + reminderCSVEntry;
                File.AppendAllText(GlobalConstants.reminderCSV, reminderCSVEntry + Environment.NewLine);
                File.AppendAllText(GlobalConstants.reminderCSVLog, reminderLogEntry + Environment.NewLine);

                //Clear the message textbox
                reminderMessageTextbox.Clear();

                //If what was created is in the past (why?)...
                if (Convert.ToDateTime(newReminderEntry[0]) < DateTime.Now)
                {
                    //...and not muted...
                    if (MuteReminderSounds.Checked == false)
                    {
                        //...play a sound
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

            //If there are no reminders in the list then disable the 1 second timer
            if (ReminderList.Items.Count == 0)
            {
                Timer1Second.Enabled = false;
            }

            //Re-create the Reminders.csv file
            File.Delete(GlobalConstants.reminderCSV);
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                String reminderCSVEntry = ReminderList.Items[i].SubItems[0].Text + "¦" + ReminderList.Items[i].SubItems[1].Text + "¦" + ReminderList.Items[i].SubItems[2].Text;
                File.AppendAllText(GlobalConstants.reminderCSV, reminderCSVEntry + Environment.NewLine);
            }
            
            //Disable form items that shouldn't be enabled
            DeleteRemindersButton.Enabled = false;
            CopyAsNewButton.Enabled = false;
            DelayLabel.Enabled = false;
            DelayCombobox.Enabled = false;
            DelayButton.Enabled = false;
        }

        //If a reminder is checked...
        private void ReminderList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //Disable objects until it's known how many reminders are checked
            CopyAsNewButton.Enabled = false;
            DelayLabel.Enabled = false;
            DelayCombobox.Enabled = false;
            DelayButton.Enabled = false;

            int numberSelected = 0;
            //Run through the reminder list to see how many items are checked
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                if (ReminderList.Items[i].Checked)
                {
                    numberSelected++;
                }
            }
            //If there's 1 or more checked...
            if (numberSelected > 0)
            {
                //...enable the 'Delete Reminders' button
                DeleteRemindersButton.Enabled = true;
                //If there's exactly 1 reminder checked...
                if (numberSelected == 1)
                {
                    //Allow certain functions, otherwise they will remain disabled if >1 checked
                    CopyAsNewButton.Enabled = true;
                    DelayLabel.Enabled = true;
                    DelayCombobox.Enabled = true;
                    DelayButton.Enabled = true;
                }
            }
            else
            {
                //If there's nothing checked then disable form objects
                DeleteRemindersButton.Enabled = false;
                CopyAsNewButton.Enabled = false;
                DelayLabel.Enabled = false;
                DelayCombobox.Enabled = false;
                DelayButton.Enabled = false;
            }
        }

        //Enables the 'Apply' button if the settings checkboxes are changed
        private void EnableApplyButton(object sender, EventArgs e)
        {
            ApplySettingsButton.Enabled = true;
        }

        //Applies changes to settings
        private void ApplySettingsButton_Click(object sender, EventArgs e)
        {
            //Delete the current Settings.ini file
            File.Delete(GlobalConstants.settingsINI);
            //Sets the status of 'Always On Top' to the checkbox value
            Form.ActiveForm.TopMost = AlwaysOnTopCheckbox.Checked;
            //Writes the values of the checkboxes to the Settings.ini file
            File.AppendAllText(GlobalConstants.settingsINI, "AlwaysOnTop:" + AlwaysOnTopCheckbox.Checked + Environment.NewLine);
            File.AppendAllText(GlobalConstants.settingsINI, "DarkMode:" + DarkModeCheckbox.Checked + Environment.NewLine);
            File.AppendAllText(GlobalConstants.settingsINI, "MuteReminderSounds:" + MuteReminderSounds.Checked + Environment.NewLine);

            //Dark mode colours
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
                DelayCombobox.BackColor = Color.Gray;
                DelayCombobox.ForeColor = Color.White;

            }
            //Light mode colours
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
                DelayCombobox.BackColor = SystemColors.Window;
                DelayCombobox.ForeColor = SystemColors.WindowText;
            }
            //Disables the 'Apply' button after changes applied            
            ApplySettingsButton.Enabled = false;
        }

        //Constantly-running 15 second timer
        private void Timer15Seconds_Tick(object sender, EventArgs e)
        {
            //If there's a reminder in the list...
            if (ReminderList.Items.Count > 0)
            {
                DateTime dateTimeReminderUTC = Convert.ToDateTime(ReminderList.Items[0].SubItems[0].Text);
                var timeUntilReminder = dateTimeReminderUTC.Subtract(DateTime.Now);
                //...and it's scheduled to go off within the next 30 seconds...
                if (timeUntilReminder.TotalSeconds <= 30)
                {
                    //...enable the 1 second timer
                    Timer1Second.Enabled = true;
                }
                else
                {
                    //If it's not scheduled to go off within the next 30 seconds, disable the 1 second timer
                    Timer1Second.Enabled = false;
                }
            }
            else
            {
                //If there's no reminder in the list then no need for the 1 second timer, so disable it
                Timer1Second.Enabled = false;
            }

            //If the Quick Reminders program does not have focus, then update the date and time in the 'Add a new reminder' section to current
            if (!this.ContainsFocus)
            {
                reminderDate.Value = DateTime.Now;
                reminderTime.Value = DateTime.Now;
            }
         }

        //1 second timer
        private void Timer1Second_Tick(object sender, EventArgs e)
        {
            //For each reminder in the list...
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                DateTime dateTimeReminderUTC = Convert.ToDateTime(ReminderList.Items[i].SubItems[0].Text);
                var timeUntilReminder = dateTimeReminderUTC.Subtract(DateTime.Now);
                //...if it's time for the reminder to be triggered...
                if (timeUntilReminder.TotalSeconds > 0 & timeUntilReminder.TotalSeconds <= 1)
                {
                    //...and reminders aren't muted...
                    if (MuteReminderSounds.Checked == false)
                    {
                        //...play a sound
                        System.Media.SystemSounds.Hand.Play();
                    }
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        //Flash the taskbar icon if Quick Reminders is minimised
                        FlashWindow(this.Handle, true);
                    }
                }

                //If the reminder has been triggered...
                if (Convert.ToDateTime(ReminderList.Items[i].SubItems[0].Text) < DateTime.Now)
                {
                    //...flash the item, alternating between white/red or gray/red (if in dark mode)
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

        //Show the 'About' form
        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm frm2 = new AboutForm();
            frm2.ShowDialog();
        }

        //Copies the message of the selected reminder into the message textbox of the 'Add a reminder' area
        private void CopyAsNewButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                if (ReminderList.Items[i].Checked)
                {
                    //Fills out a new reminder with the current date and time, as well as the message of the selected reminder
                    reminderDate.Value = DateTime.Now;
                    reminderTime.Value = DateTime.Now;
                    reminderMessageTextbox.Text = ReminderList.Items[i].SubItems[2].Text;
                    ReminderList.Items[i].Checked = false;
                    DeleteRemindersButton.Enabled = false;
                    CopyAsNewButton.Enabled = false;
                    DelayButton.Enabled = false;
                }
            }
        }
        
        //Allows for delaying of reminders
        private void DelayButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ReminderList.Items.Count; i++)
            {
                if (ReminderList.Items[i].Checked)
                {
                    //Get the reminder that is checked
                    string[] newReminderEntry = new string[3];
                    
                    //If the reminder is in the future, add the delay to the reminder's date/time
                    //If the reminder is now or in the past, add the delay to the time now
                    DateTime dateTimePlusDelay = DateTime.Now;
                    if (Convert.ToDateTime(ReminderList.Items[i].SubItems[0].Text) > DateTime.Now)
                    {
                        dateTimePlusDelay = Convert.ToDateTime(ReminderList.Items[i].SubItems[0].Text);
                    }

                    //Add time to the DateTime object, the amount determined by the combobox
                    switch (DelayCombobox.Text)
                    {
                        case "10 minutes":
                            dateTimePlusDelay = dateTimePlusDelay.AddMinutes(10);
                            break;
                        case "1 hour":
                            dateTimePlusDelay = dateTimePlusDelay.AddHours(1);
                            break;
                        case "1 day":
                            dateTimePlusDelay = dateTimePlusDelay.AddDays(1);
                            break;
                        case "1 week":
                            dateTimePlusDelay = dateTimePlusDelay.AddDays(7);
                            break;
                    }

                    //Convert the DateTime object back into a sortable date
                    newReminderEntry[0] = dateTimePlusDelay.ToString("s");
                    //Convert the DateTime object back into a display date
                    newReminderEntry[1] = dateTimePlusDelay.ToString("dd/MM") + " - " + dateTimePlusDelay.ToString("hh:mm tt");
                    newReminderEntry[2] = ReminderList.Items[i].SubItems[2].Text;
                    //Add the reminder with the new details to the list
                    ListViewItem newReminder = new ListViewItem(newReminderEntry);
                    ReminderList.Items.Add(newReminder);
                    //Remove the reminder with the old details from the list
                    ReminderList.Items[i].Remove();

                    //Re-create the Reminders.csv file
                    File.Delete(GlobalConstants.reminderCSV);
                    for (int j = 0; j < ReminderList.Items.Count; j++)
                    {
                        String reminderCSVEntry = ReminderList.Items[j].SubItems[0].Text + "¦" + ReminderList.Items[j].SubItems[1].Text + "¦" + ReminderList.Items[j].SubItems[2].Text;
                        File.AppendAllText(GlobalConstants.reminderCSV, reminderCSVEntry + Environment.NewLine);
                    }

                    //Disable form objects
                    DeleteRemindersButton.Enabled = false;
                    CopyAsNewButton.Enabled = false;
                    DelayLabel.Enabled = false;
                    DelayCombobox.Enabled = false;
                    DelayButton.Enabled = false;
                }
            }
        }

        //Hides the selected blue colour from the combobox
        private void DelayCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelayLabel.Focus();
        }
    }
}
