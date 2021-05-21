using WorkplaceCoordinator;
using MultiSelectControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Globalization;  //FOR CORRECT TIMES (DATETIME/TIMESPAN .NOW)  //ADDED IN-CASE

namespace CSC_834__Individual_Project
{
    public partial class FormSubEventViewer : Form
    {
        //class   object
        ArrayList eventList = new ArrayList();
        FormSubEventControls subEventControls;  //Declare Object Attribute Type

        Event selectedEvent;  //View - get selected event detials in SubEventControls
        Event checkedEvents;  //for deleting multiple checked events
        //ArrayList selectedEventIndex;
        
        String selectedStartDate;
        String selectedEndDate;
        DateRangeEventArgs ee;

        //[USER VARS]
        int userID = -1;  //vars for deleting
        Boolean isLoggedIn = false;
        String role;
        //[EVENT VARS]
        //vars for editing
        int eventID;
        //String dateParsed = "2020-04-27";
        String dateParsed;
        String title;
        String startTimeParsed;
        String endTimeParsed;
        String location;
        String description;
        String reminderTimeParsed;

        //[MANAGEREVENT]
        int isManagerEvent;
        String attendees;


        //ManagerEvent 
        ArrayList AttendeeEventListTemp = new ArrayList();  //For building EventList for Attendee Availability Conflict Checking
        ArrayList AttendeeEventList = new ArrayList();  //For building EventList for Attendee Availability Conflict Checking
        String attendeeIDListString = null;  //FOR GETTING LIST OF IDS TO UPDATE
        Boolean isAddingEventManager = false;  //FLAG FOR IF MANAGER IS ADDING EVENT... SO THAT WE DONT UPDATE attendeeIDList into NULL or random existing event


        //[SubEventViewer] - CONSTRUCTOR
        public FormSubEventViewer()
        {
            InitializeComponent();
            //Initialize Object
            subEventControls = new FormSubEventControls();


            //Run getEventListSelection Initially ((explicitly defining '.TodayDate') -> SelectionRange.Start/End (explicitly defining '.TodayDate' works too)
            loadEventListSelection(monthCalendar1.TodayDate.ToString("yyyy-MM-dd"), monthCalendar1.TodayDate.ToString("yyyy-MM-dd"));
        }

        public void updateIsAddingEventManager(Boolean status)
        {
            isAddingEventManager = status;
        }

        //AGGREGATION SECTION
        #region //AGGREGATION SECTION
        //GET USER ID FROM FormMAIN
        public void updateUserID(int n)
        {
            userID = n;
            Console.WriteLine("SubEventViewer | userID = " + userID);

            subEventControls.updateUserID(userID);

            loadEventListSelection(monthCalendar1.TodayDate.ToString("yyyy-MM-dd"), monthCalendar1.TodayDate.ToString("yyyy-MM-dd"));
        }
        //GET LOGIN STATUS FROM FormMAIN
        public void updateLoginStatus(Boolean s)
        {
            isLoggedIn = s;
            Console.WriteLine("SubEventViewer | isLoggedIn = " + isLoggedIn);

            subEventControls.updateLoginStatus(isLoggedIn);
        }
        //GET ROLE FROM FormMAIN
        public void updateRole(String r)
        {
            role = r;
            Console.WriteLine("SubEventViewer | role = " + role);

            subEventControls.updateRole(role);
        }
        #endregion

        public void deleteSelectedEvents(object sender)
        {
            //
            int lastIndex = checkedListBox1.Items.Count-1;  //Index starts at 0
            Console.WriteLine("fullListCount= " + lastIndex);
            //
            int checkedCount = checkedListBox1.CheckedItems.Count;
            Console.WriteLine("COUNT = " + checkedCount);
            if (checkedCount == 0)
            {
                DialogResult NoItems = MessageBox.Show("No events have been [x]selected", "Error", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to delete the selected events?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //foreach (int indexChecked in checkedListBox1.CheckedIndices)
                    for (int i = lastIndex; i >= 0; i--)
                    //for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        //if (checkedListBox1.ite) { }
                        if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                        //if (checkedListBox1.GetItemChecked(i))
                        {
                            //Console.WriteLine("Index#: " + i + ", is checked. Checked state is:" +
                            //    checkedListBox1.GetItemCheckState(i).ToString() + ".");

                            checkedEvents = (Event)eventList[i];

                            //int userID = 1;
                            //userID = checkedEvents.getUserID();//CHECK THIS

                            //dateParsed
                            title = checkedEvents.getTitle();
                            startTimeParsed = checkedEvents.getStartTime();
                            endTimeParsed = checkedEvents.getEndTime();
                            location = checkedEvents.getLocation();
                            description = checkedEvents.getDescription();
                            reminderTimeParsed = checkedEvents.getReminderTime();
                            attendeeIDListString = attendeeIDListString;

                            Event delEvent = new Event(userID, dateParsed, title, startTimeParsed, endTimeParsed, location, description, reminderTimeParsed, attendeeIDListString);
                            delEvent.deleteEvent();
                        }
                    }
                    monthCalendar1_DateChanged(sender, ee);


                }
                else if (result == DialogResult.No)
                {
                    //...
                }
            }
        }

        //Pass Data to FormSubEventControls
        #region //Pass Data to FormSubEventControls
        public FormSubEventControls getSubEventControls()
        {
            subEventControls.passViewer(this);
            return subEventControls;
        }

        private void checkedListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isAddingEventManager = false;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isAddingEventManager = false;
            hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            btnAddRemoveAttendees.Visible = false;  //Hide Manager Add/Remove Attendees Button

            //Show Event Details (CONVERTED STRINGS TO DATETIME TYPE)
            int selectedIndex = checkedListBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                //Event selectedEvent = (Event)eventList[selectedIndex];
                selectedEvent = (Event)eventList[selectedIndex];
                eventID = selectedEvent.getEventID();
                subEventControls.eventID = selectedEvent.getEventID();  //FOR UPDATING EVENTS;

                subEventControls.textBox_Title.Text = selectedEvent.getTitle();
                subEventControls.dtpStartTime.Value = DateTime.Parse(selectedEvent.getStartTime());
                subEventControls.dtpEndTime.Value = DateTime.Parse(selectedEvent.getEndTime());
                subEventControls.textBox_Location.Text = selectedEvent.getLocation();
                subEventControls.textBox_Description.Text = selectedEvent.getDescription();
                subEventControls.dtpReminderTime.Value = DateTime.Parse(selectedEvent.getReminderTime());
            }
        }
        #endregion

        public void getSubEventControlsReset()
        {
            //RESET THIS VARIABLE IN CASE
            resetAttendeeIDListString();

            //Empty TextBoxes
            subEventControls.textBox_Title.Text = "";
            subEventControls.textBox_Location.Text = "";
            subEventControls.textBox_Description.Text = "";

            //Set Times w/ 00 Seconds
            TimeSpan timeNow = subEventControls.dtpStartTime.Value.TimeOfDay;
            TimeSpan zeroSeconds = new TimeSpan(timeNow.Hours, timeNow.Minutes, 00);
            subEventControls.dtpStartTime.Value = DateTime.Today.Add(zeroSeconds);

            subEventControls.dtpEndTime.Value = subEventControls.dtpStartTime.Value.AddHours(1);  //End Time Default +1 AFTER
            subEventControls.dtpReminderTime.Value = subEventControls.dtpStartTime.Value.AddHours(-0.5);  //Reminder Time Default -0.5 BEFORE

            //subEventControls.dtpStartTime.Value = DateTime.Now;
            //subEventControls.dtpEndTime.Value = DateTime.Now.AddHours(1);
            //subEventControls.dtpReminderTime.Value = DateTime.Now.AddHours(-0.5);
        }

        //Function to show buttons (called by FormMAIN)
        public void showSubEventControlsAdd()
        {
            subEventControls.btnSECAdd.Visible = true;
            subEventControls.btnSECEdit.Visible = false;
            subEventControls.btnSECAdd.BringToFront();
            //subEventControls.btnSECEdit.BringToFront();
            //Pass Date
            subEventControls.setDate(monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd"));
            //subEventControls.dateParsed = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            //Pass eventList

            //Send eventList to ForSubEventControls on monthCalendar_DateChanged so can check for conflicts.
            subEventControls.getEventList(eventList);
        }

        public void showSubEventControlsEdit()
        {
            subEventControls.btnSECAdd.Visible = false;
            subEventControls.btnSECEdit.Visible = true;
            //subEventControls.btnSECAdd.BringToFront();
            subEventControls.btnSECEdit.BringToFront();
            //Pass Date
            subEventControls.setDate(monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd"));

            //Send eventList to ForSubEventControls on monthCalendar_DateChanged so can check for conflicts.
            subEventControls.getEventList(eventList);
        }

        public void hideSubEventControlsAddEdit()
        {
            subEventControls.btnSECAdd.Visible = false;
            subEventControls.btnSECEdit.Visible = false;
            //Manager Add/Remove Button
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            btnAddRemoveAttendees.Visible = false;
        }

        //[PANEL VISIBILITY SETTINGS]
        #region //PanelVisibilitySettings
        public void showPanelViewEditAttendeesPersonal()
        {
            //[Visibility Settings]
            checkedListBox1.Visible = false;
            labelManagerEventTooltip.Visible = false;
            //
            panelViewEditAttendees.Visible = true;
            panelViewEditAttendees.BringToFront();
            //
            multiSelectControl1.Visible = true;
            btnCloseAttendees.Visible = true;
            btnNextCAAttendees.Visible = false;  //Can't Add Attendees In Personal
            //
            btnCloseAttendees.BringToFront();
            //btnSaveAttendees.BringToFront();
            //
            labelUsers.Visible = true;
            labelAttendees.Visible = true;
            //
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            btnAddRemoveAttendees.Visible = false;
            //
        }

        public void hidePanelViewEditAttendeesPersonal()
        {
            //[Visibility Settings]
            checkedListBox1.Visible = true;
            labelManagerEventTooltip.Visible = true;
            //
            panelViewEditAttendees.Visible = false;
            //panelViewEditAttendees.BringToFront();
            //
            multiSelectControl1.Visible = false;
            btnCloseAttendees.Visible = false;
            btnNextCAAttendees.Visible = false;  //Can't Add Attendees In Personal
            //
            //btnCloseAttendees.BringToFront();
            //btnSaveAttendees.BringToFront();
            //
            labelUsers.Visible = false;
            labelAttendees.Visible = false;
            //
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            btnAddRemoveAttendees.Visible = false;
            //
        }

        public void showPanelViewEditAttendeesManager()
        {
            //[Visibility Settings]
            checkedListBox1.Visible = false;
            labelManagerEventTooltip.Visible = false;
            //
            panelViewEditAttendees.Visible = true;
            panelViewEditAttendees.BringToFront();
            //
            multiSelectControl1.Visible = true;
            btnCloseAttendees.Visible = true;
            btnNextCAAttendees.Visible = true;  //Can't Add Attendees In Personal
            //
            btnCloseAttendees.BringToFront();
            btnNextCAAttendees.BringToFront();
            //
            labelUsers.Visible = true;
            labelAttendees.Visible = true;
            //
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            btnAddRemoveAttendees.Visible = true;  //Show btnAddRemoveAttendees  //KEEP IT VISIBLE, ASK PROMPT TO RESET CHANGES IF CLICKED AGAIN
            //
        }

        public void hidePanelViewEditAttendeesManager()
        {
            //[Visibility Settings]
            checkedListBox1.Visible = true;
            labelManagerEventTooltip.Visible = true;
            //
            panelViewEditAttendees.Visible = false;
            //panelViewEditAttendees.BringToFront();
            //
            multiSelectControl1.Visible = false;
            btnCloseAttendees.Visible = false;
            btnNextCAAttendees.Visible = false;  //Can't Add Attendees In Personal
            //
            //btnCloseAttendees.BringToFront();
            //btnSaveAttendees.BringToFront();
            //
            labelUsers.Visible = false;
            labelAttendees.Visible = false;
            //
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            btnAddRemoveAttendees.Visible = false;
            //
        }

        public void showPanelCheckAvailabilityAttendees()
        {
            //[Visibility Settings]
            panelCheckAvailabilityAttendees.Visible = true;
            panelCheckAvailabilityAttendees.BringToFront();
            //
            listBoxAttendeeAvailability.Visible = true;
            listBoxAttendeeAvailability.BringToFront();
            //
            panelCAAbtns.Visible = true;
            panelCAAbtns.BringToFront();
            btnBackToSelectAttendees.Visible = true;
            btnSaveAttendeesList.Visible = true;
            btnBackToSelectAttendees.BringToFront();
            btnSaveAttendeesList.BringToFront();
            //
            //Labels
            labelUsers.Visible = false;
            labelAttendees.Visible = false;
            labelUserAvailabilities.Visible = true;
            labelUserAvailabilities.BringToFront();
            //
            //dtp
            dtpRangeStartTime.Visible = true;
            dtpRangeEndTime.Visible = true;
            dtpRangeStartTime.Value = DateTime.Now;
            //dtpRangeEndTime.Value
            dtpRangeStartTime.BringToFront();
            dtpRangeEndTime.BringToFront();
            //
            //
            tlpCAAControls.Visible = true;
            tlpCAAControls.BringToFront();
            labelCAATooltip.Visible = true;
            labelCAATooltip.BringToFront();
            labelStartTimeRange.Visible = true;
            labelStartTimeRange.BringToFront();
            labelEndTimeRange.Visible = true;
            labelEndTimeRange.BringToFront();
            dtpRangeStartTime.Visible = true;
            dtpRangeStartTime.BringToFront();
            dtpRangeEndTime.Visible = true;
            dtpRangeEndTime.BringToFront();
            btnCAARefreshList.Visible = true;
            btnCAARefreshList.BringToFront();

        }

        public void hidePanelCheckAvailabilityAttendees()
        {
            //[Visibility Settings]
            panelCheckAvailabilityAttendees.Visible = false;
            //panelCheckAvailabilityAttendees.BringToFront();
            //
            listBoxAttendeeAvailability.Visible = false;
            //listBoxAttendeeAvailability.BringToFront();
            //
            panelCAAbtns.Visible = false;
            //panelCAAbtns.BringToFront();
            btnBackToSelectAttendees.Visible = false;
            btnSaveAttendeesList.Visible = false;
            //btnCloseAttendees2.BringToFront();
            //btnSaveAttendeesList.BringToFront();
            //Labels
            labelUsers.Visible = false;
            labelAttendees.Visible = false;
            labelUserAvailabilities.Visible = false;
            //labelUserAvailabilities.BringToFront();
            //
            //
            tlpCAAControls.Visible = false;
            //tlpCAAControls.BringToFront();
            labelCAATooltip.Visible = false;
            //labelCAATooltip.BringToFront();
            labelStartTimeRange.Visible = false;
            //labelStartTimeRange.BringToFront();
            labelEndTimeRange.Visible = false;
            //labelEndTimeRange.BringToFront();
            dtpRangeStartTime.Visible = false;
            //dtpRangeStartTime.BringToFront();
            dtpRangeEndTime.Visible = false;
            //dtpRangeEndTime.BringToFront();
            btnCAARefreshList.Visible = true;
            //btnCAARefreshList.BringToFront();
        }


        #endregion

        private void rbSoWSunday_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSoWSunday.Checked)
            {
                monthCalendar1.FirstDayOfWeek = Day.Sunday;
                monthCalendar1_DateChanged(sender, ee);
            }

            hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            hidePanelViewEditAttendeesPersonal();
            hidePanelViewEditAttendeesManager();
            hidePanelCheckAvailabilityAttendees();
        }

        private void rbSoWMonday_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSoWMonday.Checked)
            {
                monthCalendar1.FirstDayOfWeek = Day.Monday;
                monthCalendar1_DateChanged(sender, ee);
            }

            hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            hidePanelViewEditAttendeesPersonal();
            hidePanelViewEditAttendeesManager();
            hidePanelCheckAvailabilityAttendees();
        }

        //Update Event List - Called By SubEventControls Form
        public void updateEventList(object sender)
        {
            monthCalendar1_DateChanged(sender, ee);
        }

        private void loadEventListSelection(string dateStringStart, string dateStringEnd)
        {
            //Clear
            checkedListBox1.Items.Clear();
            //Fill
            //dateStringStart = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            //dateStringEnd = monthCalendar1.SelectionRange.End.ToString("yyyy-MM-dd");
            Console.WriteLine("USERID PASRSED: " + userID);
            eventList = Event.getEventListSelection(dateStringStart, dateStringEnd, userID);
            for (int i = 0; i < eventList.Count; i++)
            {
                //                   (castToEventObj//ArrayList)
                Event currentEvent = (Event)eventList[i];
                //String eventString = currentEvent.getDate() + "\t" + currentEvent.getStartTime() + "\t" + currentEvent.getTitle();
                //test works
                String eventString;
                if (currentEvent.getIsManagerEvent() == 1)
                {
                    eventString = "***" + currentEvent.getDate() + "  |  " + currentEvent.getStartTime() + " - " + currentEvent.getEndTime() + "  |  " + currentEvent.getTitle() + "  @  " + currentEvent.getLocation() + "  | Description:  " + currentEvent.getDescription();
                    checkedListBox1.Items.Add(eventString);
                }
                if (currentEvent.getIsManagerEvent() == 0)
                {
                    eventString = currentEvent.getDate() + "  |  " + currentEvent.getStartTime() + " - " + currentEvent.getEndTime() + "  |  " + currentEvent.getTitle() + "  @  " + currentEvent.getLocation() + "  | Description:  " + currentEvent.getDescription();
                    checkedListBox1.Items.Add(eventString);
                }
                //eventString = currentEvent.getDate() + "  |  " + currentEvent.getStartTime() + " - " + currentEvent.getEndTime() + "  |  " + currentEvent.getTitle() + "  @  " + currentEvent.getLocation() + "  | Description:  " + currentEvent.getDescription();
                //checkedListBox1.Items.Add(eventString);
            }
        }

        private void loadEventListMonth()
        {
            //Clear
            checkedListBox1.Items.Clear();
            //Fill
            string dateStringStart = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM");
            dateStringStart = dateStringStart + "%";
            eventList = Event.getEventListByMonth(dateStringStart, userID);
            for (int i = 0; i < eventList.Count; i++)
            {
                //                   (castToEventObj//ArrayList)
                Event currentEvent = (Event)eventList[i];
                //String eventString = currentEvent.getDate() + "\t" + currentEvent.getStartTime() + "\t" + currentEvent.getTitle();
                //test works
                String eventString;
                if (currentEvent.getIsManagerEvent() == 1)
                {
                    eventString = "***" + currentEvent.getDate() + "  |  " + currentEvent.getStartTime() + " - " + currentEvent.getEndTime() + "  |  " + currentEvent.getTitle() + "  @  " + currentEvent.getLocation() + "  | Description:  " + currentEvent.getDescription();
                    checkedListBox1.Items.Add(eventString);
                }
                if (currentEvent.getIsManagerEvent() == 0)
                {
                    eventString = currentEvent.getDate() + "  |  " + currentEvent.getStartTime() + " - " + currentEvent.getEndTime() + "  |  " + currentEvent.getTitle() + "  @  " + currentEvent.getLocation() + "  | Description:  " + currentEvent.getDescription();
                    checkedListBox1.Items.Add(eventString);
                }
                //String eventString = currentEvent.getDate() + "  |  " + currentEvent.getStartTime() + " - " + currentEvent.getEndTime() + "  |  " + currentEvent.getTitle() + "  @  " + currentEvent.getLocation() + "  | Description:  " + currentEvent.getDescription();
                //checkedListBox1.Items.Add(eventString);
            }
        }

        private void monthCalendar1_MouseDown(object sender, MouseEventArgs e)
        {
            isAddingEventManager = false;
            hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            hidePanelViewEditAttendeesPersonal();
            hidePanelViewEditAttendeesManager();
            hidePanelCheckAvailabilityAttendees();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            isAddingEventManager = false;
            hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            hidePanelViewEditAttendeesPersonal();
            hidePanelViewEditAttendeesManager();
            hidePanelCheckAvailabilityAttendees();

            selectedStartDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            selectedEndDate = monthCalendar1.SelectionRange.End.ToString("yyyy-MM-dd");
            ee = e;
            //DAY
            if (rbDay.Checked)
            {
                loadEventListSelection(selectedStartDate, selectedEndDate);
            }

            if (rbWeek.Checked)
            {
                checkedListBox1.Items.Clear();
                //loadEventListSelection();
                //figure out a way to calculate weeks later
                DateTime selectedDate = monthCalendar1.SelectionRange.Start;
                //Console.WriteLine("SelectedDate: " + selectedDate);
                //Console.WriteLine("SelectedDay: " + selectedDate.DayOfWeek);
                DateTime startOfWeek;
                DateTime endOfWeek;
                int curDayOffset = (int)selectedDate.DayOfWeek;
                //Console.WriteLine("curDayOffset= " + curDayOffset);


                if (rbSoWSunday.Checked)
                {
                    startOfWeek = selectedDate.AddDays(-curDayOffset);
                    //Console.WriteLine("startOfWeek=" + startOfWeek);
                    //Console.WriteLine(startOfWeek.DayOfWeek);
                    endOfWeek = selectedDate.AddDays((int)DayOfWeek.Saturday - curDayOffset);
                    //Console.WriteLine("endOfWeek="+ endOfWeek);
                    //Console.WriteLine(endOfWeek.DayOfWeek);
                    loadEventListSelection(startOfWeek.ToString("yyyy-MM-dd"), endOfWeek.ToString("yyyy-MM-dd"));
                }

                if (rbSoWMonday.Checked)
                {
                    startOfWeek = selectedDate.AddDays(-curDayOffset + 1);
                    //Console.WriteLine("startOfWeek=" + startOfWeek);
                    //Console.WriteLine(startOfWeek.DayOfWeek);
                    endOfWeek = selectedDate.AddDays((int)DayOfWeek.Sunday - curDayOffset + 7);
                    //Console.WriteLine("endOfWeek=" + endOfWeek);
                    //Console.WriteLine(endOfWeek.DayOfWeek);
                    loadEventListSelection(startOfWeek.ToString("yyyy-MM-dd"), endOfWeek.ToString("yyyy-MM-dd"));
                }
            }
            if (rbMonth.Checked)
            {
                loadEventListMonth();
            }
        }



        private void rbDay_CheckedChanged(object sender, EventArgs e)
        {
            loadEventListSelection(selectedStartDate, selectedEndDate);

            hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            hidePanelViewEditAttendeesPersonal();
            hidePanelViewEditAttendeesManager();
            hidePanelCheckAvailabilityAttendees();
        }

        private void rbWeek_CheckedChanged(object sender, EventArgs e)
        {
            monthCalendar1_DateChanged(sender, ee);

            hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            hidePanelViewEditAttendeesPersonal();
            hidePanelViewEditAttendeesManager();
            hidePanelCheckAvailabilityAttendees();
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            loadEventListMonth();

            hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            btnViewAttendees.Visible = true;  //Show btnViewAttendees
            hidePanelViewEditAttendeesPersonal();
            hidePanelViewEditAttendeesManager();
            hidePanelCheckAvailabilityAttendees();
        }


        private void btnViewAttendees_Click(object sender, EventArgs e)
        {
            //IF ALREADY OPEN DO NOTHING
            if (multiSelectControl1.Visible == true)
            {
                return;
            }

            //CLEAR PREVIOUS
            multiSelectControl1.SourceItems.Clear();
            multiSelectControl1.DestinationItems.Clear();

            //Get eventID from checkedListBox1.SelectedIndex
            int selectedIndex = checkedListBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                selectedEvent = (Event)eventList[selectedIndex];
                eventID = selectedEvent.getEventID();
            }
            else
            {
                DialogResult Error = MessageBox.Show("No event is selected!", "Error", MessageBoxButtons.OK);
                return;
            }

            //Setup
            ManagerEvent listUsers = new ManagerEvent();

            //GET CURRENTATTENDEES
            ArrayList currentAttendeesList = new ArrayList();  //ArrayList2 | [userID, firstName, lastName] | For multiSelectControl1.DestinationItems.Add();
            String AttendeeIDList = listUsers.getExistingAttendees(eventID);  //Return String attendeesIDList, e.g. "3,4,5"
            //Console.WriteLine("attendeesIDList: " + listUsers.getExistingAttendees(eventID));
            //convert list and get array of [userID, firstName, lastName]
            currentAttendeesList = listUsers.convertExistingAttendeesIDsStringToArray(AttendeeIDList);

            //Stop and return msgbox if no attendees listed...
            if (currentAttendeesList.Count == 0)
            {
                DialogResult Error = MessageBox.Show("This event has no listed Attendees!", "System", MessageBoxButtons.OK);
                return;
            }

            /*//GET FULL LIST OF USERS
            ArrayList fullUserList = new ArrayList();  //ArrayList1 | [userID, firstName, lastName]
            fullUserList = listUsers.getUsersList();

            //BUILD AVAILABLE USER LIST
            ArrayList availableUserList = new ArrayList();  //ArrayList3 | [userID, firstName, lastName] | User's not already attending the event | For multiSelectControl1.SourceItems.Add();
            availableUserList = listUsers.compareArrayLists(fullUserList, currentAttendeesList);*/

            //[Visibility Settings]
            showPanelViewEditAttendeesPersonal();

            /*// Fill MultiSelectControl listBox [LEFT | SOURCE]
            for (int i = 0; i < availableUserList.Count; i++)
            {
                ManagerEvent currentAttendee = (ManagerEvent)availableUserList[i];
                String attendeeFullName = currentAttendee.getLastName() + ", " + currentAttendee.getFirstName() + "  |  " + currentAttendee.getEmail();
                //Console.WriteLine("attendeeFullName: " + attendeeFullName);
                multiSelectControl1.SourceItems.Add(attendeeFullName);
            }*/

            //Fill MultiSelectControl listBox [RIGHT | DESTINATION]
            for (int i=0; i< currentAttendeesList.Count; i++)
            {
                ManagerEvent currentAttendee = (ManagerEvent)currentAttendeesList[i];
                String attendeeFullName = currentAttendee.getLastName() + ", " + currentAttendee.getFirstName() + "  |  " + currentAttendee.getEmail();
                //Console.WriteLine("attendeeFullName: " + attendeeFullName);
                multiSelectControl1.DestinationItems.Add(attendeeFullName);
            }



        }



        private void btnAddRemoveAttendees_Click(object sender, EventArgs e)
        {
            //IF ALREADY OPEN DO NOTHING
            if (multiSelectControl1.Visible == true)
            {
                //PROMPT USER RESET CHANGES?
                DialogResult result = MessageBox.Show("Do you wish to reset any changes made?", "System | Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
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

            //CLEAR PREVIOUS
            multiSelectControl1.SourceItems.Clear();
            multiSelectControl1.DestinationItems.Clear();

            //Get eventID from checkedListBox1.SelectedIndex
            int selectedIndex = checkedListBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                selectedEvent = (Event)eventList[selectedIndex];
                eventID = selectedEvent.getEventID();
            }
            else
            {
                eventID = -1;
            }
            /*else
            {
                //CALL VIEW EVENT()
                btnViewAttendees_Click(sender, e);
                //DialogResult Error = MessageBox.Show("No event is selected!", "Error", MessageBoxButtons.OK);
                return;
            }*/

            //Setup
            ManagerEvent listUsers = new ManagerEvent();

            //GET CURRENTATTENDEES
            ArrayList currentAttendeesList = new ArrayList();  //ArrayList2 | [userID, firstName, lastName] | For multiSelectControl1.DestinationItems.Add();
            String AttendeeIDList = listUsers.getExistingAttendees(eventID);  //Return String attendeesIDList, e.g. "3,4,5"
            //Console.WriteLine("attendeesIDList: " + listUsers.getExistingAttendees(eventID));
            //convert list and get array of [userID, firstName, lastName]
            currentAttendeesList = listUsers.convertExistingAttendeesIDsStringToArray(AttendeeIDList);

            //Stop and return msgbox if no attendees listed...
            /*if (currentAttendeesList.Count == 0)
            {
                DialogResult Error = MessageBox.Show("This event has no listed Attendees!", "System", MessageBoxButtons.OK);
                return;
            }*/

            //GET FULL LIST OF USERS
            ArrayList fullUserList = new ArrayList();  //ArrayList1 | [userID, firstName, lastName]
            fullUserList = listUsers.getUsersList();

            //BUILD AVAILABLE USER LIST
            ArrayList availableUserList = new ArrayList();  //ArrayList3 | [userID, firstName, lastName] | User's not already attending the event | For multiSelectControl1.SourceItems.Add();
            availableUserList = listUsers.compareArrayLists(fullUserList, currentAttendeesList);

            //[Visibility Settings]
            showPanelViewEditAttendeesManager();

            //Fill MultiSelectControl listBox [LEFT | SOURCE]
            for (int i = 0; i < availableUserList.Count; i++)
            {
                ManagerEvent currentAttendee = (ManagerEvent)availableUserList[i];
                String attendeeFullName = currentAttendee.getLastName() + ", " + currentAttendee.getFirstName() + "  |  " + currentAttendee.getEmail();
                //Console.WriteLine("attendeeFullName: " + attendeeFullName);
                multiSelectControl1.SourceItems.Add(attendeeFullName);
            }

            //Fill MultiSelectControl listBox [RIGHT | DESTINATION]
            for (int i = 0; i < currentAttendeesList.Count; i++)
            {
                ManagerEvent currentAttendee = (ManagerEvent)currentAttendeesList[i];
                String attendeeFullName = currentAttendee.getLastName() + ", " + currentAttendee.getFirstName() + "  |  " + currentAttendee.getEmail();
                //Console.WriteLine("attendeeFullName: " + attendeeFullName);
                multiSelectControl1.DestinationItems.Add(attendeeFullName);
            }

        }
        /*
        private void multiSelectControl1_Load(object sender, EventArgs e)
        {
            //multiSelectControl1.SourceItems.Add
        }*/




        private void btnCloseAttendees_Click(object sender, EventArgs e)
        {
            //[Visibility Settings]
            hidePanelViewEditAttendeesPersonal();
            hidePanelViewEditAttendeesManager();





        }

        private void btnBackToSelectAttendees_Click(object sender, EventArgs e)
        {
            //[Visibility Settings]
            //hidePanelViewEditAttendeesPersonal();
            //hidePanelViewEditAttendeesManager();
            hidePanelCheckAvailabilityAttendees();
        }




        private void btnNextCAAttendees_Click(object sender, EventArgs e)
        {
            if (multiSelectControl1.DestinationItems.Count == 0)
            {
                //PROMPT USER NO ATTENDEES
                DialogResult result = MessageBox.Show("There are 0 attendees selected.\nDo you wish to remove all attendees from this event?", "System | Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    attendeeIDListString = null;  //should be already null but put in case
                    subEventControls.getAttendeeIDListString(attendeeIDListString);
                    ManagerEvent.updateAttendees(eventID, attendeeIDListString);
                    subEventControls.resetAttendeeIDListString();
                    hidePanelViewEditAttendeesManager();
                    hidePanelCheckAvailabilityAttendees();  //in case
                    return;
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
            //[Visibility Settings]
            showPanelCheckAvailabilityAttendees();

            //SET DEFAULT TIMES TO CHECK
            dtpRangeStartTime.Value = DateTime.Today.AddHours(7);  //Defualt 7am
            dtpRangeEndTime.Value = DateTime.Today.AddHours(19);  //Default 7pm

            //RUN ONCE
            checkAttendeeAvailability();


        }

        public void resetAttendeeIDListString()
        {
            attendeeIDListString = null;
            subEventControls.resetAttendeeIDListString();
        }

        public void passAttendeeIDListString()
        {
            subEventControls.getAttendeeIDListString(attendeeIDListString);
        }

        private void btnCAARefreshList_Click(object sender, EventArgs e)
        {
            checkAttendeeAvailability();
        }

        public void checkAttendeeAvailability()
        {
            //EXPLICITLY RESET THESE VARIABLES BEFORE RUNNING
            AttendeeEventListTemp.Clear();
            AttendeeEventList.Clear();
            listBoxAttendeeAvailability.Items.Clear();
            attendeeIDListString = null;
            Console.WriteLine("attendeeIDListString RESETCHECK=" + attendeeIDListString);

            //Setup
            ManagerEvent addUsers = new ManagerEvent();  //Use Class Objects/Functions
            List<int> attendeeIDList = new List<int>();  //List to store attendeeIDs

            //EXTRACT EMAIL FROM multSelectControl1.DestinationItems
            int lastIndex = multiSelectControl1.DestinationItems.Count - 1;
            for (int i = 0; i <= lastIndex; i++)
            {
                //SAVE EMAIL TO STRING
                Console.WriteLine("itesmindex=" + multiSelectControl1.DestinationItems[i]);
                int indexOfEmailStart = multiSelectControl1.DestinationItems[i].ToString().IndexOf('|') + 3;
                String extractedEmail = multiSelectControl1.DestinationItems[i].ToString().Substring(indexOfEmailStart);
                Console.WriteLine("extractedEmail=" + extractedEmail);

                //PASS EMAIL TO DB TO GET USERID [STORE IN LIST]
                attendeeIDList.Add(addUsers.getUserIDviaEmail(extractedEmail));
            }

            //USE attendeeIDList TO GET AN EVENTLIST OF ALL THESE USER'S EVENTS + MANAGER EVENTS FOR THAT DAY...
            selectedStartDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            Console.WriteLine("selectedStartDate: = " + selectedStartDate);


            Console.WriteLine("datetimenow=" + DateTime.Now);
            Console.WriteLine("datetimenowTOSTRING=" + DateTime.Now.ToString());
            Console.WriteLine("datetimenowTOSHOTTIMESTRING=" + DateTime.Now.ToShortTimeString());
            Console.WriteLine("datetimenowTOLONGIMESTRING=" + DateTime.Now.ToLongTimeString());

            int lastIndex2 = attendeeIDList.Count - 1;
            for (int i = 0; i <= lastIndex2; i++)
            {
                AttendeeEventListTemp = ManagerEvent.getAttendeeEventList(selectedStartDate, attendeeIDList[i]);

                for (int j = 0; j < AttendeeEventListTemp.Count; j++)
                {
                    ManagerEvent currentEvent = (ManagerEvent)AttendeeEventListTemp[j];
                    String eventString = "id=" + currentEvent.getEventID() + "\tstartTime=" + currentEvent.getStartTime() + "\tendTime=" + currentEvent.getEndTime() + "\tisManaerEvent=" + currentEvent.getIsManagerEvent();
                    Console.WriteLine("curevent: " + eventString);


                    //listBoxAttendeeAvailability.Items.Add(eventString);  //temp for debugging
                    AttendeeEventList.Add(currentEvent);
                }

            }

            //Get TimeSpan Range To Compare TO attendeeEventList Times
            TimeSpan getstartTimeRange = dtpRangeStartTime.Value.TimeOfDay;
            TimeSpan getendTimeRange = dtpRangeEndTime.Value.TimeOfDay;
            TimeSpan startTimeRange = new TimeSpan(getstartTimeRange.Hours, getstartTimeRange.Minutes, 00);
            TimeSpan endTimeRange = new TimeSpan(getendTimeRange.Hours, getendTimeRange.Minutes, 00);

            Console.WriteLine("startTimeRange=" + startTimeRange);
            Console.WriteLine("endTimeRange=" + endTimeRange);

            //DEBUG
            //int attendeeListLastIndex = currentEvent.Count - 1;
            Console.WriteLine("AttendeeEventListCount= " + AttendeeEventList.Count);  //gets the correct # of items in the list
            if (AttendeeEventList.Count >= 0)
            {

                //Console.WriteLine(((ManagerEvent)AttendeeEventList[0]).getEventID());
                //END DEBUG


                //SETUP TIME VARIABLES TO COMPARE AND INCREASE VALUE PER LOOP
                TimeSpan tempStart = startTimeRange;
                TimeSpan addHour = new TimeSpan(0, 1, 0, 0);
                TimeSpan tempEnd = startTimeRange.Add(addHour);

                Console.WriteLine("tempStart=" + startTimeRange);
                Console.WriteLine("tempEnd=" + tempEnd);

                TimeSpan add15 = new TimeSpan(0, 0, 15, 0);
                TimeSpan add30 = new TimeSpan(0, 0, 30, 0);
                Console.WriteLine("testadd15=" + startTimeRange.Add(add15));
                Console.WriteLine("testadd30=" + startTimeRange.Add(add30));


                int AttendeeEventListLastIndex = AttendeeEventList.Count - 1;  //Var for Inner For Loop
                Boolean existsConflict = false;  //Flag for if there is a conflict or not

                //Outer For Loop
                //STOPPING CONDITION IS WHEN tempEnd == endTimeRange
                while (tempEnd <= endTimeRange) {

                    //Inner For Loop
                    for (int i = 0; i <= AttendeeEventListLastIndex; i++)
                    {
                        ManagerEvent currentEvent = (ManagerEvent)AttendeeEventList[i];

                        //GET START/END TIMES OF EVENTS INTO VARIABLES FOR EASIER READING
                        TimeSpan currentEventStart = currentEvent.getStartTime();
                        TimeSpan currentEventEnd = currentEvent.getEndTime();
                        Console.WriteLine("AttendeeEventList start=" + currentEvent.getStartTime() + "  endtime="+ currentEvent.getEndTime());

                        if ((TimeSpan.Compare(tempStart, currentEventStart) <= 0 && TimeSpan.Compare(tempEnd, currentEventStart) <= 0) ||
                        (TimeSpan.Compare(tempStart, currentEventEnd) >= 0 && TimeSpan.Compare(tempEnd, currentEventEnd) >= 0))
                        {
                            continue;
                        }
                        else  //Conflict
                        {
                            existsConflict = true;
                        }
                    }
                    if (existsConflict == false)
                    {
                        Console.WriteLine("NO CONFLICT FOR ABOVE TIME");

                        //do the thing  -->>>>  add current timespans to a list after checking debug

                        listBoxAttendeeAvailability.Items.Add("FROM:  " + tempStart + " - " + tempEnd);

                    }
                    if (existsConflict == true)
                    {
                        Console.WriteLine("CONFLICT!!!!!!!");
                    }



                    existsConflict = false;
                    tempStart = tempStart.Add(add30);
                    tempEnd = tempEnd.Add(add30);
                    Console.WriteLine("\nnextrun tempstart=" + tempStart);
                    Console.WriteLine("nextrun tempend=" + tempEnd);
                }


                //GET STRING OF ATTENDEE IDs TO BE UPDATED TO THE DATABASE
                attendeeIDListString = String.Join(",", attendeeIDList);
                Console.WriteLine("attendeeIDListString=" + attendeeIDListString + ".");
            }
            else
            {
                attendeeIDListString = null;
            }

            subEventControls.getAttendeeIDListString(attendeeIDListString);

        }

        private void btnSaveAttendeesList_Click(object sender, EventArgs e)
        {
            if (listBoxAttendeeAvailability.SelectedIndex == -1 && attendeeIDListString != null)
            {
                DialogResult Error = MessageBox.Show("No Time Slot Is Selected!", "Error", MessageBoxButtons.OK);
                return;
            }
            if (attendeeIDListString == null)  //Removing Attendees
            {
                subEventControls.getAttendeeIDListString(attendeeIDListString);
                ManagerEvent.updateAttendees(eventID, attendeeIDListString);
                subEventControls.resetAttendeeIDListString();
                return;
            }
            if (isAddingEventManager == true)
            {
                //subEventControls.btnSECAdd_Click(sender, e);
                hidePanelViewEditAttendeesManager();
                hidePanelCheckAvailabilityAttendees();
                return;
            }

            int i = listBoxAttendeeAvailability.SelectedIndex;
            //GET TIMES FROM listBoxAttendeeAvailability | String -> Timespan
            ////Console.WriteLine("listboxitem=" + listBoxAttendeeAvailability.Items[i]);  //Is a String
            String selectedItem = listBoxAttendeeAvailability.Items[i].ToString();

            String startTimeString = selectedItem.Substring(7, 8); //
            String endTimeString = selectedItem.Substring(18, 8); //or just .Substring(18);
            ////Console.WriteLine("startTime=" + startTimeString + ".");
            ////Console.WriteLine("startTime=" + endTimeString + ".");

            TimeSpan startTime = TimeSpan.Parse(startTimeString);
            TimeSpan endTime = TimeSpan.Parse(endTimeString);
            Console.WriteLine("TimeSpanStart=" + startTime);
            Console.WriteLine("TimeSpanEnd=" + endTime);

            //CHANGE DATETIMEPICKERS IN SubEventControl TO MATCH THIS SELECTED TIME
            subEventControls.dtpStartTime.Value = DateTime.Today.Add(startTime);
            subEventControls.dtpEndTime.Value = DateTime.Today.Add(endTime);
            subEventControls.dtpReminderTime.Value = subEventControls.dtpStartTime.Value.AddHours(-0.5);

            ManagerEvent.updateAttendees(eventID, attendeeIDListString);





        }



        private void listBoxAttendeeAvailability_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAttendeeAvailability.SelectedIndex == -1)
            {
                DialogResult Error = MessageBox.Show("No Time Slot Is Selected!", "Error", MessageBoxButtons.OK);
                return;
            }

            int i = listBoxAttendeeAvailability.SelectedIndex;
            //GET TIMES FROM listBoxAttendeeAvailability | String -> Timespan
            ////Console.WriteLine("listboxitem=" + listBoxAttendeeAvailability.Items[i]);  //Is a String
            String selectedItem = listBoxAttendeeAvailability.Items[i].ToString();

            String startTimeString = selectedItem.Substring(7, 8); //
            String endTimeString = selectedItem.Substring(18, 8); //or just .Substring(18);
            ////Console.WriteLine("startTime=" + startTimeString + ".");
            ////Console.WriteLine("startTime=" + endTimeString + ".");

            TimeSpan startTime = TimeSpan.Parse(startTimeString);
            TimeSpan endTime = TimeSpan.Parse(endTimeString);
            Console.WriteLine("TimeSpanStart=" + startTime);
            Console.WriteLine("TimeSpanEnd=" + endTime);

            //CHANGE DATETIMEPICKERS IN SubEventControl TO MATCH THIS SELECTED TIME
            subEventControls.dtpStartTime.Value = DateTime.Today.Add(startTime);
            subEventControls.dtpEndTime.Value = DateTime.Today.Add(endTime);
            subEventControls.dtpReminderTime.Value = subEventControls.dtpStartTime.Value.AddHours(-0.5);



        }

        #region //SETTINGS TO MAKE DATETIMEPICKER SECONDS ALWAYS 00
        private void dtpRangeStartTime_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan timeNow = dtpRangeStartTime.Value.TimeOfDay;
            TimeSpan zeroSeconds = new TimeSpan(timeNow.Hours, timeNow.Minutes, 00);
            dtpRangeStartTime.Value = DateTime.Today.Add(zeroSeconds);
        }

        private void dtpRangeEndTime_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan timeNow = dtpRangeEndTime.Value.TimeOfDay;
            TimeSpan zeroSeconds = new TimeSpan(timeNow.Hours, timeNow.Minutes, 00);
            dtpRangeEndTime.Value = DateTime.Today.Add(zeroSeconds);
        }
        #endregion


    }
}