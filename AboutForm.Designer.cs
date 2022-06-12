
namespace QuickReminders
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.ContactMessageLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ProgramFilesButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.EmailLinkLabel = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(21, 19);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(156, 24);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Quick Reminders";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(22, 43);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(194, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "A simple program to help you remember.";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(22, 77);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(63, 13);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "Version: 0.5";
            // 
            // ContactMessageLabel
            // 
            this.ContactMessageLabel.AutoSize = true;
            this.ContactMessageLabel.Location = new System.Drawing.Point(22, 215);
            this.ContactMessageLabel.Name = "ContactMessageLabel";
            this.ContactMessageLabel.Size = new System.Drawing.Size(170, 26);
            this.ContactMessageLabel.TabIndex = 4;
            this.ContactMessageLabel.Text = "Please feel free to contact me with\r\nsuggestions.";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(22, 253);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(65, 13);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "-Jeff Higgins";
            // 
            // ProgramFilesButton
            // 
            this.ProgramFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgramFilesButton.Location = new System.Drawing.Point(25, 299);
            this.ProgramFilesButton.Name = "ProgramFilesButton";
            this.ProgramFilesButton.Size = new System.Drawing.Size(87, 23);
            this.ProgramFilesButton.TabIndex = 7;
            this.ProgramFilesButton.Text = "Program files";
            this.ProgramFilesButton.UseVisualStyleBackColor = true;
            this.ProgramFilesButton.Click += new System.EventHandler(this.ProgramFilesButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(133, 299);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(87, 23);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // EmailLinkLabel
            // 
            this.EmailLinkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.EmailLinkLabel.AutoSize = true;
            this.EmailLinkLabel.Location = new System.Drawing.Point(22, 266);
            this.EmailLinkLabel.Name = "EmailLinkLabel";
            this.EmailLinkLabel.Size = new System.Drawing.Size(124, 13);
            this.EmailLinkLabel.TabIndex = 9;
            this.EmailLinkLabel.TabStop = true;
            this.EmailLinkLabel.Text = "websites@jeffhiggins.net";
            this.EmailLinkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.EmailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EmailLinkLabel_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 94);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(195, 110);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(243, 339);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EmailLinkLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ProgramFilesButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ContactMessageLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label ContactMessageLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button ProgramFilesButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.LinkLabel EmailLinkLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}