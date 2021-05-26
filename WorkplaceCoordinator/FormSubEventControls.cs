using Org.BouncyCastle.Bcpg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;  //FOR CORRECT TIMES (DATETIME/TIMESPAN .NOW)  //ADDED IN-CASE

namespace CSC_834__Individual_Project
{
    public partial class FormSubEventControls : Form
    {
        //FormSubEventViewer subEventViewer;
        FormSubEventViewer parentForm;

        //[EVENT & USER VARS]
        int userID = -1;
        Boolean isLoggedIn = false;
        String role;
        //For Editings
        public int eventID;
        //String dateParsed = "2020-04-27";
        String dateParsed;
        String title;
        String startTimeParsed;
        String endTimeParsed;
        String location;
        String description;
        String reminderTimeParsed;

        ArrayList eventList = new ArrayList();
        Event conflictCheckList;

        //ManagerEvent Attendees
        String attendeeIDListString = null;  //FOR GETTING LIST OF IDS TO UPDATE
        Boolean isAddingEventManager = false;  //FLAG FOR IF MANAGER IS ADDING EVENT...

        //[MANAGEREVENT]
        int isManagerEvent;

        //[SubEventControls] - CONSTRUCTOR
        public FormSubEventControls()
        {
            InitializeComponent();
        }

        public void updateIsAddingEventManager(Boolean status)
        {
            isAddingEventManager = status;
        }

        public void resetAttendeeIDListString()
        {
            attendeeIDListString = null;
        }

        public void getAttendeeIDListString(String list)
        {
            attendeeIDListString = list;
        }

        #region //SETTINGS TO MAKE DATETIMEPICKER SECONDS ALWAYS 00
        private void FormSubEventControls_Load(object sender, EventArgs e)
        {
            //ON LOAD SET TIMES + ZERO SECONDS
            parentForm.getSubEventControlsReset();
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan timeNow = dtpStartTime.Value.TimeOfDay;
            TimeSpan zeroSeconds = new TimeSpan(timeNow.Hours, timeNow.Minutes, 00);
            dtpStartTime.Value = DateTime.Today.Add(zeroSeconds);
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan timeNow = dtpEndTime.Value.TimeOfDay;
            TimeSpan zeroSeconds = new TimeSpan(timeNow.Hours, timeNow.Minutes, 00);
            dtpEndTime.Value = DateTime.Today.Add(zeroSeconds);
        }

        private void dtpReminderTime_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan timeNow = dtpReminderTime.Value.TimeOfDay;
            TimeSpan zeroSeconds = new TimeSpan(timeNow.Hours, timeNow.Minutes, 00);
            dtpReminderTime.Value = DateTime.Today.Add(zeroSeconds);
        }
        #endregion

        //passViewer - Allows passing data to SubEventViewer
        //c# how to implement aggrigation
        //AGGREGATION SECTION
        #region //AGGREGATION SECTION
        //GET USER ID FROM FormMAIN
        public void updateUserID(int n)
        {
            userID = n;
            Console.WriteLine("SubEventControls | userID = " + userID);
        }
        //GET LOGIN STATUS FROM FormMAIN
        public void updateLoginStatus(Boolean s)
        {
            isLoggedIn = s;
            Console.WriteLine("SubEventControls | isLoggedIn = " + isLoggedIn);
        }
        //GET ROLE FROM FormMAIN
        public void updateRole(String r)
        {
            role = r;
            Console.WriteLine("SubEventControls | role = " + role);
        }
        //
        //
        public void passViewer(FormSubEventViewer v)
        {
            parentForm = v;
        }

        public void setDate(String s)
        {
            dateParsed = s;
        }

        //Get eventList to ForSubEventControls on monthCalendar_DateChanged so can check for conflicts.
        public void getEventList(ArrayList e)
        {
            eventList = e;
        }
        #endregion

        public void btnSECAdd_Click(object sender, EventArgs e)
        {
            //IF ATTENDEES PANELS ARE OPEN  >> PROMPT
            if (parentForm.panelViewEditAttendees.Visible == true || parentForm.panelCheckAvailabilityAttendees.Visible == true)
            {
                DialogResult result = MessageBox.Show("'Add/Remove Attendees' is still open.\nNo attendees will be added to or removed from this event and all existing attendees will be removed!\n\nDo you wish to continue?", "System", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    resetAttendeeIDListString();
                    //continue;
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    return;
                }
            }

            //Console.WriteLine("ADD EVENT USERID = " + userID);
            //int userID = 1;
            //dateParsed
            title = textBox_Title.Text; ;


            #region CONFLICT CHECKING
            int compare = DateTime.Compare(dtpStartTime.Value, dtpEndTime.Value);
            //Console.WriteLine("COMPARE VALUE: " + compare);
            //Compare//
            //Compare =  1 if date1>date2
            //Compare =  0 if same
            //Compare = -1 if date2>date1
            if (DateTime.Compare(dtpStartTime.Value, dtpEndTime.Value) > 0)
            {
                DialogResult Error = MessageBox.Show("[Error] 'End Time' cannot be the earlier than 'Start Time'", "Error", MessageBoxButtons.OK);
                return;
            }


            int lastIndex = eventList.Count - 1;
            for (int i = lastIndex; i >= 0; i--)
            {
                conflictCheckList = (Event)eventList[i];

                String checkStartTimeS = conflictCheckList.getStartTime();  //String "hh:mm:ss tt"
                DateTime checkStartTimeDT = DateTime.Parse(checkStartTimeS);  //Parse to DT
                String checkEndTimeS = conflictCheckList.getEndTime();  //String "hh:mm:ss tt"
                DateTime checkEndTimeDT = DateTime.Parse(checkEndTimeS);  //Parse to DT

                //Console.WriteLine("\n\n\n\n dtpStartTime.Value: " + dtpStartTime.Value);
                //Console.WriteLine("checkStartTimeDT: " + checkStartTimeDT);
                //Console.WriteLine("\n\n\n\n dtpEndTime.Value: " + dtpEndTime.Value);
                //Console.WriteLine("checkEndTimeDT: " + checkEndTimeDT);
                //Console.WriteLine("comp1<: " + DateTime.Compare(dtpStartTime.Value, checkStartTimeDT));
                //Console.WriteLine("comp2<: " + DateTime.Compare(dtpEndTime.Value, checkStartTimeDT));
                //Console.WriteLine("comp3>: " + DateTime.Compare(dtpStartTime.Value, checkEndTimeDT));
                //Console.WriteLine("comp4>: " + DateTime.Compare(dtpEndTime.Value, checkEndTimeDT));

                //Conflict check for selected date -> Stop getting errors when viewing events by week/month
                //dateParsed
                //Console.WriteLine("edit DATEPARSED: " + dateParsed);  //Format: YYYY-MM-DD
                String selectedDate = dateParsed.Substring(5, 2) + "/" + dateParsed.Substring(8, 2);
                //Console.WriteLine("selectedDate = " + selectedDate);
                //If 'dateParsed' matches conflictCheckList.getDate()
                //Console.WriteLine("dateofitem = " + conflictCheckList.getDate());  //Format: 04/27
                if (selectedDate == conflictCheckList.getDate())
                {
                    //Console.WriteLine("\n\n\n\n compare this" + dtpStartTime.Value);
                    //Console.WriteLine("\n\n\n\n to this" + conflictCheckList.getDateAsDateTime());
                    //If new start & end time < old start times &
                    //   new start & end times > old end times
                    if ((DateTime.Compare(dtpStartTime.Value, checkStartTimeDT) <= 0 && DateTime.Compare(dtpEndTime.Value, checkStartTimeDT) <= 0) ||
                    (DateTime.Compare(dtpStartTime.Value, checkEndTimeDT) >= 0 && DateTime.Compare(dtpEndTime.Value, checkEndTimeDT) >= 0))
                    {
                        continue;
                    }
                    else
                    {
                        //Give Conflict Error
                        DialogResult Error = MessageBox.Show("[Error] Time Conflict with \"" + conflictCheckList.getTitle() + "\" !", "Error", MessageBoxButtons.OK);
                        //Give option to still add the event, regardless of conflicts...
                        DialogResult result = MessageBox.Show("Do you still want to add this event?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            continue;
                        }
                        else if (result == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }
                        //
                    }
                }

            }
#endregion


            startTimeParsed = dtpStartTime.Value.ToString("hh:mm:ss tt");
            endTimeParsed = dtpEndTime.Value.ToString("hh:mm:ss tt");
            location = textBox_Location.Text;
            description = textBox_Description.Text;
            reminderTimeParsed = dtpReminderTime.Value.ToString("hh:mm:ss tt");
            //Console.WriteLine("PRE SEND: :" + startTimeParsed);
            //Console.WriteLine("PRE SEND: :" + endTimeParsed);
            //Console.WriteLine("PRE SEND: :" + reminderTimeParsed);
            //Console.WriteLine("DATE NOW: " + dateParsed);
            
            parentForm.passAttendeeIDListString();
            //attendeeIDListString = parentForm.passAttendeeIDListString();

            if (isAddingEventManager == true)
            {
                Event newEvent = new Event(userID, dateParsed, title, startTimeParsed, endTimeParsed, location, description, reminderTimeParsed, attendeeIDListString, 1);
                newEvent.addEvent();
                Console.WriteLine("--[[Manager Event Added]]--");
            }
            else
            {
                Event newEvent = new Event(userID, dateParsed, title, startTimeParsed, endTimeParsed, location, description, reminderTimeParsed, attendeeIDListString, 0);
                newEvent.addEvent();
                Console.WriteLine("--[[Normal Event Added]]--");
            }
            //newEvent.addEvent();

            parentForm.updateEventList(sender);  //Call FormSubEventViewer.updateEventList which calls 'monthCalendar1_DateChanged()'
            parentForm.hideSubEventControlsAddEdit();
            parentForm.getSubEventControlsReset();
            //subEventViewer.hideSubEventControlsAddEdit();
            //subEventViewer.getSubEventControlsReset();

            parentForm.resetAttendeeIDListString();
            //resetAttendeeIDListString();

        }

        private void btnSECEdit_Click(object sender, EventArgs e)
        {
            //IF ATTENDEES PANELS ARE OPEN  >> PROMPT
            if (parentForm.panelViewEditAttendees.Visible == true || parentForm.panelCheckAvailabilityAttendees.Visible == true)
            {
                DialogResult result = MessageBox.Show("'Add/Remove Attendees' is still open.\nNo attendees will be added to or removed from this event and all existing attendees will be removed!\n\nDo you wish to continue?", "System", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    resetAttendeeIDListString();
                    //continue;
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    return;
                }
            }

            //Console.WriteLine("EDIT EVENT USERID = " + userID);
            //int userID = 1;
            //eventID;  //FOR EDITING  //USING GLOBAL WITHIN THIS CLASS, Assigned Value From FormSubEventViewer



            #region CONFLICT CHECKING
            int compare = DateTime.Compare(dtpStartTime.Value, dtpEndTime.Value);
            //Console.WriteLine("COMPARE VALUE: " + compare);
            //Compare//
            //Compare =  1 if date1>date2
            //Compare =  0 if same
            //Compare = -1 if date2>date1
            if (DateTime.Compare(dtpStartTime.Value, dtpEndTime.Value) > 0)
            {
                DialogResult Error = MessageBox.Show("[Error] 'End Time' cannot be the earlier than 'Start Time'", "Error", MessageBoxButtons.OK);
                return;
            }


            int lastIndex = eventList.Count - 1;
            for (int i = lastIndex; i >= 0; i--)
            {
                conflictCheckList = (Event)eventList[i];

                //EDIT EVENT -> IGNORE SELECTED EVENT WHEN CHECKING FOR CONFLICTS
                //Console.WriteLine("EDIT EVENT eventID = " + eventID);
                //Console.WriteLine("conflictCheckList.eventID = " + conflictCheckList.getEventID());
                if (eventID == conflictCheckList.getEventID())
                {
                    continue;
                }


                String checkStartTimeS = conflictCheckList.getStartTime();  //String "hh:mm:ss tt"
                DateTime checkStartTimeDT = DateTime.Parse(checkStartTimeS);  //Parse to DT
                String checkEndTimeS = conflictCheckList.getEndTime();  //String "hh:mm:ss tt"
                DateTime checkEndTimeDT = DateTime.Parse(checkEndTimeS);  //Parse to DT

                //Console.WriteLine("\n\n\n\n dtpStartTime.Value: " + dtpStartTime.Value);
                //Console.WriteLine("checkStartTimeDT: " + checkStartTimeDT);
                //Console.WriteLine("\n\n\n\n dtpEndTime.Value: " + dtpEndTime.Value);
                //Console.WriteLine("checkEndTimeDT: " + checkEndTimeDT);
                //Console.WriteLine("comp1<: " + DateTime.Compare(dtpStartTime.Value, checkStartTimeDT));
                //Console.WriteLine("comp2<: " + DateTime.Compare(dtpEndTime.Value, checkStartTimeDT));
                //Console.WriteLine("comp3>: " + DateTime.Compare(dtpStartTime.Value, checkEndTimeDT));
                //Console.WriteLine("comp4>: " + DateTime.Compare(dtpEndTime.Value, checkEndTimeDT));

                //Conflict check for selected date -> Stop getting errors when viewing events by week/month
                //dateParsed
                //Console.WriteLine("edit DATEPARSED: " + dateParsed);  //Format: YYYY-MM-DD
                String selectedDate = dateParsed.Substring(5, 2) + "/" + dateParsed.Substring(8, 2);
                //Console.WriteLine("selectedDate = " + selectedDate);
                //If 'dateParsed' matches conflictCheckList.getDate()
                //Console.WriteLine("dateofitem = " + conflictCheckList.getDate());  //Format: 04/27
                if (selectedDate == conflictCheckList.getDate()) {
                    //Console.WriteLine("\n\n\n\n compare this" + dtpStartTime.Value);
                    //Console.WriteLine("\n\n\n\n to this" + conflictCheckList.getDateAsDateTime());
                    //If new start & end time < old start times &
                    //   new start & end times > old end times
                    if ((DateTime.Compare(dtpStartTime.Value, checkStartTimeDT) <= 0 && DateTime.Compare(dtpEndTime.Value, checkStartTimeDT) <= 0) ||
                        (DateTime.Compare(dtpStartTime.Value, checkEndTimeDT) >= 0 && DateTime.Compare(dtpEndTime.Value, checkEndTimeDT) >= 0))
                    {
                        continue;
                    }
                    else
                    {
                        //Give Conflict Error
                        DialogResult Error = MessageBox.Show("[Error] Time Conflict with \"" + conflictCheckList.getTitle() + "\" !", "Error", MessageBoxButtons.OK);
                        //Give option to still add the event, regardless of conflicts...
                        DialogResult result = MessageBox.Show("Do you still want to edit this event?", "Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            continue;
                        }
                        else if (result == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            return;
                        }
                        //
                    }
                }

            }
            #endregion


            title = textBox_Title.Text;
            startTimeParsed = dtpStartTime.Value.ToString("hh:mm:ss tt");
            endTimeParsed = dtpEndTime.Value.ToString("hh:mm:ss tt");
            location = textBox_Location.Text;
            description = textBox_Description.Text;
            reminderTimeParsed = dtpReminderTime.Value.ToString("hh:mm:ss tt");

            //Console.WriteLine("PRE SEND: :" + startTimeParsed);
            //Console.WriteLine("PRE SEND: :" + endTimeParsed);
            //Console.WriteLine("PRE SEND: :" + reminderTimeParsed);

            //Console.WriteLine("\n\n\n\nEVENTID" + eventID + "\n\n\n");  //returns correct eventID
            parentForm.passAttendeeIDListString();

            //vv Before adding ability to edit normal events to manager events...
            //Event changeEvent = new Event(userID, eventID, dateParsed, title, startTimeParsed, endTimeParsed, location, description, reminderTimeParsed, attendeeIDListString, isManagerEvent);
            //changeEvent.editEvent();

            if (isAddingEventManager == true)
            {
                Event changeEvent = new Event(userID, eventID, dateParsed, title, startTimeParsed, endTimeParsed, location, description, reminderTimeParsed, attendeeIDListString, 1);
                changeEvent.editEvent();
                Console.WriteLine("--[[Manager Event Edited // Normal Event Elevated]]--");
            }
            else
            {
                Event changeEvent = new Event(userID, eventID, dateParsed, title, startTimeParsed, endTimeParsed, location, description, reminderTimeParsed, attendeeIDListString, 0);
                changeEvent.editEvent();
                Console.WriteLine("--[[Normal Event Edited]]--");
            }


            parentForm.updateEventList(sender);  //Call FormSubEventViewer.updateEventList which calls 'monthCalendar1_DateChanged()'
            parentForm.hideSubEventControlsAddEdit();

            parentForm.resetAttendeeIDListString();
            //resetAttendeeIDListString();
        }
    }
}

