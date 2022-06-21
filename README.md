# Quick Reminders

A simple program to help you remember.

I wanted a tool that sat somewhere between Post-It notes and Outlook in terms of complexity. Just a little program that could stay on my screen and alert me when the predetermined time came to notes that I'd entered. Add in a few QOL options but nothing too much.

### To install
Download 'Quick Reminders Installer.exe' found in the 'published' folder above, or [click here](https://github.com/jeffhigginsgithub/Quick-Reminders/raw/master/published/Quick%20Reminders%20Installer.exe). Run the executable to install the program and kindly ignore any Microsoft Defender SmartScreen warning messages by clicking the 'More info' link then the 'Run anyway' button.

### Use

![Quick Reminders](https://user-images.githubusercontent.com/51849062/174615168-f5e44f7f-7aaa-4e11-8885-95a560ac177e.png)


To add a reminder, select a date and time, enter a message, then click the 'Add reminder' button. Reminders are displayed in chronological order, with the next reminder at the top of the list. Reminders will flash red when the date and time have been met.

If you'd like to delay a reminder, select it by clicking its checkbox, select an amount of time to delay the reminder, then click the 'Delay' button. You can only delay one reminder at a time.

To 'copy' a reminder, click its checkbox then click 'Copy msg as new'. This will copy the text of the reminder into the new reminder area. This is useful if you need to reschedule a reminder for a time that isn't handled by the delay options. You can only copy one reminder at a time.

To delete reminders, select the checkboxes next to the reminders you want to delete, then click the 'Delete reminder/s' button.

There are a few settings you can change:

* 'Always on top' - keep the window above others for easy viewing
* 'Dark mode' - change the colours to a dark theme
* 'Mute reminders' - don't play a sound when an alert goes off

Check/uncheck a setting then click the 'Apply' button to save. Settings will persist between program restarts.

Click 'About' to view the About dialog.


![About](https://user-images.githubusercontent.com/51849062/174622129-a9414425-9a1c-4d27-83b7-e8531367bd30.png)


Click the 'Program files' button to see the files that Quick Reminders reads from/saves to. They are:

* Reminders.csv - the main file that Quick Reminders reads from when starting up and saves to when changes are made. You can copy this file to back up reminders.
* RemindersLog.csv - keeps a running log of reminders added and removed. Useful if you delete a reminder then need to reference it later.
* Settings.ini - keeps track of the latest settings so that they can be reapplied at each startup.
