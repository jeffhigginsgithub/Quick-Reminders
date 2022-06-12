
namespace QuickReminders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.reminderDate = new System.Windows.Forms.DateTimePicker();
            this.reminderTime = new System.Windows.Forms.DateTimePicker();
            this.reminderMessageTextbox = new System.Windows.Forms.TextBox();
            this.AddReminderButton = new System.Windows.Forms.Button();
            this.newReminderGroup = new System.Windows.Forms.GroupBox();
            this.reminderListGroup = new System.Windows.Forms.GroupBox();
            this.CopyAsNewButton = new System.Windows.Forms.Button();
            this.DeleteRemindersButton = new System.Windows.Forms.Button();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.ReminderList = new System.Windows.Forms.ListView();
            this.UTCColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MessageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reminderControlGroup = new System.Windows.Forms.GroupBox();
            this.DarkModeCheckbox = new System.Windows.Forms.CheckBox();
            this.ApplySettingsButton = new System.Windows.Forms.Button();
            this.AlwaysOnTopCheckbox = new System.Windows.Forms.CheckBox();
            this.MuteReminderSounds = new System.Windows.Forms.CheckBox();
            this.Timer15Seconds = new System.Windows.Forms.Timer(this.components);
            this.Timer1Second = new System.Windows.Forms.Timer(this.components);
            this.AboutButton = new System.Windows.Forms.Button();
            this.DelayButton = new System.Windows.Forms.Button();
            this.DelayCombobox = new System.Windows.Forms.ComboBox();
            this.DelayLabel = new System.Windows.Forms.Label();
            this.newReminderGroup.SuspendLayout();
            this.reminderListGroup.SuspendLayout();
            this.reminderControlGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // reminderDate
            // 
            this.reminderDate.CustomFormat = "dd/MM";
            this.reminderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.reminderDate.Location = new System.Drawing.Point(6, 28);
            this.reminderDate.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.reminderDate.Name = "reminderDate";
            this.reminderDate.Size = new System.Drawing.Size(72, 20);
            this.reminderDate.TabIndex = 0;
            // 
            // reminderTime
            // 
            this.reminderTime.CustomFormat = "hh:mm tt";
            this.reminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.reminderTime.Location = new System.Drawing.Point(84, 28);
            this.reminderTime.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.reminderTime.Name = "reminderTime";
            this.reminderTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.reminderTime.ShowUpDown = true;
            this.reminderTime.Size = new System.Drawing.Size(76, 20);
            this.reminderTime.TabIndex = 1;
            // 
            // reminderMessageTextbox
            // 
            this.reminderMessageTextbox.Location = new System.Drawing.Point(166, 28);
            this.reminderMessageTextbox.Name = "reminderMessageTextbox";
            this.reminderMessageTextbox.Size = new System.Drawing.Size(257, 20);
            this.reminderMessageTextbox.TabIndex = 2;
            // 
            // AddReminderButton
            // 
            this.AddReminderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddReminderButton.Location = new System.Drawing.Point(429, 26);
            this.AddReminderButton.Name = "AddReminderButton";
            this.AddReminderButton.Size = new System.Drawing.Size(96, 23);
            this.AddReminderButton.TabIndex = 3;
            this.AddReminderButton.Text = "Add reminder";
            this.AddReminderButton.UseVisualStyleBackColor = true;
            this.AddReminderButton.Click += new System.EventHandler(this.AddReminderButton_Click);
            // 
            // newReminderGroup
            // 
            this.newReminderGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.newReminderGroup.Controls.Add(this.reminderDate);
            this.newReminderGroup.Controls.Add(this.AddReminderButton);
            this.newReminderGroup.Controls.Add(this.reminderTime);
            this.newReminderGroup.Controls.Add(this.reminderMessageTextbox);
            this.newReminderGroup.Location = new System.Drawing.Point(12, 12);
            this.newReminderGroup.Name = "newReminderGroup";
            this.newReminderGroup.Size = new System.Drawing.Size(531, 60);
            this.newReminderGroup.TabIndex = 5;
            this.newReminderGroup.TabStop = false;
            this.newReminderGroup.Text = "Add a new reminder";
            // 
            // reminderListGroup
            // 
            this.reminderListGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.reminderListGroup.Controls.Add(this.DelayLabel);
            this.reminderListGroup.Controls.Add(this.DelayCombobox);
            this.reminderListGroup.Controls.Add(this.DelayButton);
            this.reminderListGroup.Controls.Add(this.CopyAsNewButton);
            this.reminderListGroup.Controls.Add(this.DeleteRemindersButton);
            this.reminderListGroup.Controls.Add(this.DateTimeLabel);
            this.reminderListGroup.Controls.Add(this.MessageLabel);
            this.reminderListGroup.Controls.Add(this.ReminderList);
            this.reminderListGroup.Location = new System.Drawing.Point(12, 86);
            this.reminderListGroup.Name = "reminderListGroup";
            this.reminderListGroup.Size = new System.Drawing.Size(531, 220);
            this.reminderListGroup.TabIndex = 6;
            this.reminderListGroup.TabStop = false;
            this.reminderListGroup.Text = "Reminders";
            // 
            // CopyAsNewButton
            // 
            this.CopyAsNewButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CopyAsNewButton.Enabled = false;
            this.CopyAsNewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyAsNewButton.Location = new System.Drawing.Point(125, 188);
            this.CopyAsNewButton.Name = "CopyAsNewButton";
            this.CopyAsNewButton.Size = new System.Drawing.Size(113, 23);
            this.CopyAsNewButton.TabIndex = 16;
            this.CopyAsNewButton.TabStop = false;
            this.CopyAsNewButton.Text = "Copy msg to new";
            this.CopyAsNewButton.UseVisualStyleBackColor = true;
            this.CopyAsNewButton.Click += new System.EventHandler(this.CopyAsNewButton_Click);
            // 
            // DeleteRemindersButton
            // 
            this.DeleteRemindersButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteRemindersButton.Enabled = false;
            this.DeleteRemindersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteRemindersButton.Location = new System.Drawing.Point(6, 188);
            this.DeleteRemindersButton.Name = "DeleteRemindersButton";
            this.DeleteRemindersButton.Size = new System.Drawing.Size(113, 23);
            this.DeleteRemindersButton.TabIndex = 12;
            this.DeleteRemindersButton.TabStop = false;
            this.DeleteRemindersButton.Text = "Delete reminder/s";
            this.DeleteRemindersButton.UseVisualStyleBackColor = true;
            this.DeleteRemindersButton.Click += new System.EventHandler(this.DeleteRemindersButton_Click);
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.Location = new System.Drawing.Point(31, 23);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.DateTimeLabel.TabIndex = 10;
            this.DateTimeLabel.Text = "Date - time";
            // 
            // MessageLabel
            // 
            this.MessageLabel.Location = new System.Drawing.Point(129, 23);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(50, 13);
            this.MessageLabel.TabIndex = 9;
            this.MessageLabel.Text = "Message";
            // 
            // ReminderList
            // 
            this.ReminderList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ReminderList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ReminderList.BackColor = System.Drawing.SystemColors.Window;
            this.ReminderList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReminderList.CheckBoxes = true;
            this.ReminderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UTCColumn,
            this.DateTimeColumn,
            this.MessageColumn});
            this.ReminderList.GridLines = true;
            this.ReminderList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ReminderList.HideSelection = false;
            this.ReminderList.LabelWrap = false;
            this.ReminderList.Location = new System.Drawing.Point(6, 39);
            this.ReminderList.MultiSelect = false;
            this.ReminderList.Name = "ReminderList";
            this.ReminderList.ShowGroups = false;
            this.ReminderList.Size = new System.Drawing.Size(517, 143);
            this.ReminderList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ReminderList.TabIndex = 8;
            this.ReminderList.TabStop = false;
            this.ReminderList.UseCompatibleStateImageBehavior = false;
            this.ReminderList.View = System.Windows.Forms.View.Details;
            this.ReminderList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ReminderList_ItemChecked);
            // 
            // UTCColumn
            // 
            this.UTCColumn.Text = "";
            this.UTCColumn.Width = 20;
            // 
            // DateTimeColumn
            // 
            this.DateTimeColumn.Text = "Date - time";
            this.DateTimeColumn.Width = 100;
            // 
            // MessageColumn
            // 
            this.MessageColumn.Text = "Message";
            this.MessageColumn.Width = 380;
            // 
            // reminderControlGroup
            // 
            this.reminderControlGroup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.reminderControlGroup.Controls.Add(this.DarkModeCheckbox);
            this.reminderControlGroup.Controls.Add(this.ApplySettingsButton);
            this.reminderControlGroup.Controls.Add(this.AlwaysOnTopCheckbox);
            this.reminderControlGroup.Controls.Add(this.MuteReminderSounds);
            this.reminderControlGroup.Location = new System.Drawing.Point(12, 321);
            this.reminderControlGroup.Name = "reminderControlGroup";
            this.reminderControlGroup.Size = new System.Drawing.Size(378, 48);
            this.reminderControlGroup.TabIndex = 7;
            this.reminderControlGroup.TabStop = false;
            this.reminderControlGroup.Text = "Settings";
            // 
            // DarkModeCheckbox
            // 
            this.DarkModeCheckbox.AutoSize = true;
            this.DarkModeCheckbox.Location = new System.Drawing.Point(104, 19);
            this.DarkModeCheckbox.Name = "DarkModeCheckbox";
            this.DarkModeCheckbox.Size = new System.Drawing.Size(78, 17);
            this.DarkModeCheckbox.TabIndex = 4;
            this.DarkModeCheckbox.Text = "Dark mode";
            this.DarkModeCheckbox.UseVisualStyleBackColor = true;
            this.DarkModeCheckbox.CheckedChanged += new System.EventHandler(this.EnableApplyButton);
            // 
            // ApplySettingsButton
            // 
            this.ApplySettingsButton.Enabled = false;
            this.ApplySettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplySettingsButton.Location = new System.Drawing.Point(295, 15);
            this.ApplySettingsButton.Name = "ApplySettingsButton";
            this.ApplySettingsButton.Size = new System.Drawing.Size(75, 23);
            this.ApplySettingsButton.TabIndex = 3;
            this.ApplySettingsButton.TabStop = false;
            this.ApplySettingsButton.Text = "Apply";
            this.ApplySettingsButton.UseVisualStyleBackColor = true;
            this.ApplySettingsButton.Click += new System.EventHandler(this.ApplySettingsButton_Click);
            // 
            // AlwaysOnTopCheckbox
            // 
            this.AlwaysOnTopCheckbox.AutoSize = true;
            this.AlwaysOnTopCheckbox.Location = new System.Drawing.Point(6, 19);
            this.AlwaysOnTopCheckbox.Name = "AlwaysOnTopCheckbox";
            this.AlwaysOnTopCheckbox.Size = new System.Drawing.Size(92, 17);
            this.AlwaysOnTopCheckbox.TabIndex = 2;
            this.AlwaysOnTopCheckbox.TabStop = false;
            this.AlwaysOnTopCheckbox.Text = "Always on top";
            this.AlwaysOnTopCheckbox.UseVisualStyleBackColor = true;
            this.AlwaysOnTopCheckbox.CheckedChanged += new System.EventHandler(this.EnableApplyButton);
            // 
            // MuteReminderSounds
            // 
            this.MuteReminderSounds.AutoSize = true;
            this.MuteReminderSounds.Location = new System.Drawing.Point(188, 19);
            this.MuteReminderSounds.Name = "MuteReminderSounds";
            this.MuteReminderSounds.Size = new System.Drawing.Size(98, 17);
            this.MuteReminderSounds.TabIndex = 1;
            this.MuteReminderSounds.TabStop = false;
            this.MuteReminderSounds.Text = "Mute reminders";
            this.MuteReminderSounds.UseVisualStyleBackColor = true;
            this.MuteReminderSounds.CheckedChanged += new System.EventHandler(this.EnableApplyButton);
            // 
            // Timer15Seconds
            // 
            this.Timer15Seconds.Enabled = true;
            this.Timer15Seconds.Interval = 15000;
            this.Timer15Seconds.Tick += new System.EventHandler(this.Timer15Seconds_Tick);
            // 
            // Timer1Second
            // 
            this.Timer1Second.Interval = 1000;
            this.Timer1Second.Tick += new System.EventHandler(this.Timer1Second_Tick);
            // 
            // AboutButton
            // 
            this.AboutButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutButton.Location = new System.Drawing.Point(460, 336);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(75, 23);
            this.AboutButton.TabIndex = 8;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // DelayButton
            // 
            this.DelayButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DelayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelayButton.Location = new System.Drawing.Point(448, 188);
            this.DelayButton.Name = "DelayButton";
            this.DelayButton.Size = new System.Drawing.Size(75, 23);
            this.DelayButton.TabIndex = 17;
            this.DelayButton.Text = "Delay";
            this.DelayButton.UseVisualStyleBackColor = true;
            this.DelayButton.Click += new System.EventHandler(this.DelayButton_Click);
            // 
            // DelayCombobox
            // 
            this.DelayCombobox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DelayCombobox.BackColor = System.Drawing.SystemColors.Window;
            this.DelayCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DelayCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelayCombobox.FormattingEnabled = true;
            this.DelayCombobox.Items.AddRange(new object[] {
            "10 minutes",
            "1 hour",
            "1 day",
            "1 week"});
            this.DelayCombobox.Location = new System.Drawing.Point(364, 190);
            this.DelayCombobox.Name = "DelayCombobox";
            this.DelayCombobox.Size = new System.Drawing.Size(78, 21);
            this.DelayCombobox.TabIndex = 18;
            this.DelayCombobox.TabStop = false;
            this.DelayCombobox.SelectedIndexChanged += new System.EventHandler(this.DelayCombobox_SelectedIndexChanged);
            this.DelayCombobox.DropDownClosed += new System.EventHandler(this.DelayCombobox_SelectedIndexChanged);
            // 
            // DelayLabel
            // 
            this.DelayLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.Location = new System.Drawing.Point(300, 193);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(58, 13);
            this.DelayLabel.TabIndex = 19;
            this.DelayLabel.Text = "Delay for...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(554, 381);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.reminderControlGroup);
            this.Controls.Add(this.reminderListGroup);
            this.Controls.Add(this.newReminderGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 4000);
            this.MinimumSize = new System.Drawing.Size(570, 350);
            this.Name = "MainForm";
            this.Text = "Quick Reminders";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.newReminderGroup.ResumeLayout(false);
            this.newReminderGroup.PerformLayout();
            this.reminderListGroup.ResumeLayout(false);
            this.reminderListGroup.PerformLayout();
            this.reminderControlGroup.ResumeLayout(false);
            this.reminderControlGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker reminderDate;
        private System.Windows.Forms.DateTimePicker reminderTime;
        private System.Windows.Forms.TextBox reminderMessageTextbox;
        private System.Windows.Forms.Button AddReminderButton;
        private System.Windows.Forms.GroupBox newReminderGroup;
        private System.Windows.Forms.GroupBox reminderListGroup;
        private System.Windows.Forms.GroupBox reminderControlGroup;
        private System.Windows.Forms.CheckBox MuteReminderSounds;
        private System.Windows.Forms.ListView ReminderList;
        private System.Windows.Forms.ColumnHeader DateTimeColumn;
        private System.Windows.Forms.ColumnHeader MessageColumn;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.Button DeleteRemindersButton;
        private System.Windows.Forms.CheckBox AlwaysOnTopCheckbox;
        private System.Windows.Forms.Button ApplySettingsButton;
        private System.Windows.Forms.Timer Timer15Seconds;
        private System.Windows.Forms.ColumnHeader UTCColumn;
        private System.Windows.Forms.Timer Timer1Second;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.CheckBox DarkModeCheckbox;
        private System.Windows.Forms.Button CopyAsNewButton;
        private System.Windows.Forms.Label DelayLabel;
        private System.Windows.Forms.ComboBox DelayCombobox;
        private System.Windows.Forms.Button DelayButton;
    }
}

