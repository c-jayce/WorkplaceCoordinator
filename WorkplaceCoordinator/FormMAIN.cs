using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;  //FOR CORRECT TIMES (DATETIME/TIMESPAN .NOW)  //ADDED IN-CASE

//ICON SOURCE: https://www.flaticon.com/free-icon/calendar_2693560 


namespace CSC_834__Individual_Project
{
    public partial class FormMAIN : Form
    {
        //[USER VARS]
        int userID = -1;
        Boolean isLoggedIn = false;
        String role;

        //[MANAGER VARS]
        int isManagerEvent = 1;  //Manager events have a INT value of 1, non-manager events have have a value of '0'.
        //Default is 1, var not passed for Employees, only Managers+. Value for Employees is set to '0' by default via/in DB.
        Boolean asManager = false;  //Set to true if the manager clicked on btnManagerCalendar, passed and used in SubForms...

        String attendeeIDListString = null;  //Variable for Manager Attendee List To Update To DB, DEFAULT IS NULL
        //STRING NULL WILL BE PASSED WHEN MANAGER CLICKS ADD/EDIT EVENT IN MAIN FORM
        Boolean isAddingEventManager = false;  //FLAG FOR IF MANAGER IS ADDING EVENT... SO THAT WE DONT UPDATE attendeeIDList into NULL or random existing event


        FormSubEventViewer subEventViewer = new FormSubEventViewer();
        //FormSubEventControls subEventControls = new FormSubEventControls();


        //[MAIN FORM] - CONSTRUCTOR
        public FormMAIN()
        {
            //Constructor
            InitializeComponent();
            hideSubMenu();  //Invoke hideSubMenu();

            //btnManagerCalendar.Visible = true;  //Changing the Visibility of this button causes panelManagerSubMenu to be buggy
            //SEE @ showbtnManagerCalendar() under //[MANAGER] BUTTONS
            btnManagerCalendar.Enabled = false;
            btnManagerCalendar.ForeColor = Color.FromArgb(11, 7, 17);
        }

        //AGGREGATION SECTION
        #region //AGGREGATION SECTION
        //GET USER ID FROM FormSubLogin
        public void updateUserID(int n)
        {
            userID = n;
            Console.WriteLine("MAIN | userID = " + userID);

            subEventViewer.updateUserID(userID);
        }
        //GET LOGIN STATUS FROM FormSubLogin
        public void updateLoginStatus(Boolean s)
        {
            isLoggedIn = s;
            Console.WriteLine("MAIN | isLoggedIn = " + isLoggedIn);

            subEventViewer.updateLoginStatus(isLoggedIn);
        }
        //GET ROLE FROM FormSubLogin
        public void updateRole(String r)
        {
            role = r;
            Console.WriteLine("MAIN | role = " + role);

            subEventViewer.updateRole(role);
        }
        #endregion

        //CUSTOM DESIGN
        #region //CUSTOM DESIGN
        //LIVE TIME LABELS - https://www.youtube.com/watch?v=0JB7LWh41jQ
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.label_FormMAIN_Time_Mid.Text = datetime.ToString();
            this.label_FormMAIN_Time_TopLeft.Text = datetime.ToString();
        }
        private void FormMAIN_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //
        //VISIBILITY
        public void hideSubMenu()
        {
            panelPersonalCalSubMenu.Visible = false;
            panelManagerCalSubMenu.Visible = false;
            //...
        }
        private void showSubMenuCal(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        //After Registering Or Logging In:
        public void hideAll()
        {
            hideSubMenu();
            //Change Main Menu Button Colors
            btnLogin.BackColor = Color.FromArgb(11, 7, 17);
            btnPersonalCalendar.BackColor = Color.FromArgb(11, 7, 17);
            btnManagerCalendar.BackColor = Color.FromArgb(11, 7, 17);
            //
            if (activeSubFormBot != null) activeSubFormBot.Close();  //Bot - Condition for FormSubLogin
        }
        #endregion

        //[MAIN FORM] - BUTTONS
        #region [MAIN FORM] BUTTONS
        private void btnLogin_Click(object sender, EventArgs e)
        {
            resetIsAddingEventManager();
            if (isLoggedIn == false && userID == -1)
            {
                //Close Attendee Panels If Open
                subEventViewer.hidePanelViewEditAttendeesPersonal();
                subEventViewer.hidePanelViewEditAttendeesManager();
                subEventViewer.hidePanelCheckAvailabilityAttendees();

                hideSubMenu();
                //Change Main Menu Button Colors
                btnLogin.BackColor = Color.FromArgb(91, 62, 136);
                btnPersonalCalendar.BackColor = Color.FromArgb(11, 7, 17);
                btnManagerCalendar.BackColor = Color.FromArgb(11, 7, 17);
                //
                //SubFormTop
                if (SubFormTopInitialized == true)
                {
                    if (activeSubFormTop != null) activeSubFormTop.Hide();  //Top
                                                                            //if (activeSubFormBot != null) activeSubFormBot.Close();  //Bot
                    if (activeSubFormBot != null) activeSubFormBot.Hide();  //Bot
                    //btnPersonalCalendarToggled = false;
                }
                FormSubLogin loginForm = new FormSubLogin();
                openSubFormBot(loginForm);
                loginForm.passMAIN(this);

                //openSubFormBot(new FormSubLogin());
            }
            else
            {
                DialogResult Error = MessageBox.Show("You are already logged in.", "Error", MessageBoxButtons.OK);
            }
        }

        //[PERSONAL | EMPLOYEE] BUTTONS
        #region //[PERSONAL | EMPLOYEE] BUTTONS
        private Boolean SubFormTopInitialized = true;
        private Boolean getSubMenuOpen()
        {
            if (panelPersonalCalSubMenu.Visible == true || panelManagerCalSubMenu.Visible == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //private Boolean btnPersonalCalendarToggled = false;
        public void btnPersonalCalendar_Click(object sender, EventArgs e)
        {
            resetIsAddingEventManager();
            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();
            subEventViewer.hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons

            if (isLoggedIn == true && userID != -1)
            {
                //Show PersonalCalSubMenu
                showSubMenuCal(panelPersonalCalSubMenu);

                //Change Main Menu Button Colors
                btnLogin.BackColor = Color.FromArgb(11, 7, 17);
                btnPersonalCalendar.BackColor = Color.FromArgb(91, 62, 136);
                btnManagerCalendar.BackColor = Color.FromArgb(11, 7, 17);

                //Initialize SubEventViewer & SubEventControls
                openSubFormTop(subEventViewer);
                openSubFormBot(subEventViewer.getSubEventControls());

                //If()Else() To Hide SubForms If SubMenu Is Hidden...
                if (getSubMenuOpen() == false)
                {
                    if (activeSubFormTop != null) activeSubFormTop.Hide();  //Top
                    if (activeSubFormBot != null) activeSubFormBot.Hide();  //Bot
                }
                else if (getSubMenuOpen() == true)
                {
                    if (activeSubFormTop != null) activeSubFormTop.Show();  //Top
                    if (activeSubFormBot != null) activeSubFormBot.Show();  //Bot
                }
            }
            //
            else
            {
                DialogResult Error = MessageBox.Show("You must be logged in to do this.", "Error", MessageBoxButtons.OK);
            }
        }

        
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();

            //Deselect Selected Items (If Any)
            subEventViewer.checkedListBox1.SelectedIndex = -1;
            //Then
            //Set SubEventControls >> Clear / Default
            subEventViewer.getSubEventControlsReset();
            subEventViewer.showSubEventControlsAdd();  //Show SubEventControlsAdd Button
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();

            subEventViewer.hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons

            //USAGE ERROR CHECKING
            int selectedIndex = subEventViewer.checkedListBox1.CheckedItems.Count;
            if (selectedIndex == 0)
            {
                DialogResult Error = MessageBox.Show("No events are selected.", "Error", MessageBoxButtons.OK);
                return;
            }
            subEventViewer.hideSubEventControlsAddEdit();
            subEventViewer.deleteSelectedEvents(sender);
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();

            //USAGE ERROR CHECKING
            int selectedIndex = subEventViewer.checkedListBox1.SelectedIndex;
            if (selectedIndex == -1)
            {
                DialogResult Error = MessageBox.Show("No events are selected.", "Error", MessageBoxButtons.OK);
                return;
            }
            subEventViewer.showSubEventControlsEdit();
        }
        #endregion

        //[MANAGER] BUTTONS
        #region //[MANAGER] BUTTONS
        public void showbtnManagerCalendar()
        {
            //btnManagerCalendar.Visible = true;  //Changing the Visibility of this button causes panelManagerSubMenu to be buggy
            //ALTERNATIVE BELOW INITIALIZED IN FormMAIN CONSTRUCTOR vvvv
            //btnManagerCalendar.Enabled = false;
            //btnManagerCalendar.ForeColor = Color.FromArgb(11, 7, 17);

            btnManagerCalendar.Enabled = true;
            btnManagerCalendar.ForeColor = Color.Silver;
        }

        //Boolean btnManagerCalendarClicked = false;  //Flag to see if this button is clicked, so personal events do not shot up in manager calendar, decided not to add in for now...
        public void btnManagerCalendar_Click(object sender, EventArgs e)
        {
            resetIsAddingEventManager();
            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();
            subEventViewer.hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons

            if (isLoggedIn == true && userID != -1 && (role == "SYSTEM" || role == "Admin" || role == "Manager"))
            {
                //Show ManagerCalSubMenu
                showSubMenuCal(panelManagerCalSubMenu);

                //Change Main Menu Button Colors
                btnLogin.BackColor = Color.FromArgb(11, 7, 17);
                btnPersonalCalendar.BackColor = Color.FromArgb(11, 7, 17);
                btnManagerCalendar.BackColor = Color.FromArgb(91, 62, 136);
                
                //If()Else() To Hide SubForms If SubMenu Is Hidden...
                if (getSubMenuOpen() == false)
                {
                    if (activeSubFormTop != null) activeSubFormTop.Hide();  //Top
                    if (activeSubFormBot != null) activeSubFormBot.Hide();  //Bot
                }
                else
                {
                    if (activeSubFormTop != null) activeSubFormTop.Show();  //Top
                    if (activeSubFormBot != null) activeSubFormBot.Show();  //Bot
                }
            }
            //
            else
            {
                DialogResult Error = MessageBox.Show("You must be logged in to do this.", "Error", MessageBoxButtons.OK);
            }
        }

        private void resetIsAddingEventManager()
        {
            isAddingEventManager = false;
            subEventViewer.updateIsAddingEventManager(isAddingEventManager);
            attendeeIDListString = null;
            subEventViewer.resetAttendeeIDListString();
            subEventViewer.hideSubEventControlsAddEdit();
            subEventViewer.getSubEventControlsReset();
        }

        private void btnManagerAddEvent_Click(object sender, EventArgs e)
        {
            //FLAG FOR IF MANAGER IS UPDATING EVENT;
            isAddingEventManager = true;
            subEventViewer.updateIsAddingEventManager(isAddingEventManager);


            //RESET THIS VARIABLE
            subEventViewer.resetAttendeeIDListString();

            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();

            //Deselect Selected Items (If Any)
            subEventViewer.checkedListBox1.SelectedIndex = -1;
            //Then
            //Set SubEventControls >> Clear / Default
            subEventViewer.getSubEventControlsReset();
            subEventViewer.hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            subEventViewer.showSubEventControlsAdd();  //Show SubEventControlsAdd Button

            //Attendee Button Visibility
            subEventViewer.btnViewAttendees.Visible = false;
            subEventViewer.btnAddRemoveAttendees.Visible = true;
        }

        private void btnManagerDeleteEvent_Click(object sender, EventArgs e)
        {
            resetIsAddingEventManager();
            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();

            subEventViewer.hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons

            //USAGE ERROR CHECKING
            int selectedIndex = subEventViewer.checkedListBox1.CheckedItems.Count;
            if (selectedIndex == 0)
            {
                DialogResult Error = MessageBox.Show("No events are selected.", "Error", MessageBoxButtons.OK);
                return;
            }

            //Attendee Button Visibility
            subEventViewer.btnViewAttendees.Visible = true;
            subEventViewer.btnAddRemoveAttendees.Visible = false;
        }

        private void btnManagerEditEvent_Click(object sender, EventArgs e)
        {
            //FLAG FOR IF MANAGER IS UPDATING EVENT;
            isAddingEventManager = true;
            subEventViewer.updateIsAddingEventManager(isAddingEventManager);

            //resetIsAddingEventManager();
            //RESET THIS VARIABLE
            subEventViewer.resetAttendeeIDListString();

            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();

            //USAGE ERROR CHECKING
            int selectedIndex = subEventViewer.checkedListBox1.SelectedIndex;
            if (selectedIndex == -1)
            {
                DialogResult Error = MessageBox.Show("No events are selected.", "Error", MessageBoxButtons.OK);
                return;
            }

            //Deselect Selected Items (If Any)
            //subEventViewer.checkedListBox1.SelectedIndex = -1;  //Dont do this<^ | Not what it should do...
            //Then
            //Set SubEventControls >> Clear / Default
            //subEventViewer.getSubEventControlsReset();  //Don't Reset Fields
            subEventViewer.hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            subEventViewer.showSubEventControlsEdit();  //Show SubEventControlsEdit Button

            //Attendee Button Visibility
            subEventViewer.btnViewAttendees.Visible = true;
            subEventViewer.btnAddRemoveAttendees.Visible = true;
        }


        #endregion




        private void btnLogout_Click(object sender, EventArgs e)
        {
            resetIsAddingEventManager();
            btnManagerCalendar.Enabled = false;
            btnManagerCalendar.ForeColor = Color.FromArgb(11, 7, 17);
            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();

            subEventViewer.hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            hideSubMenu();
            //Change Main Menu Button Colors
            btnLogin.BackColor = Color.FromArgb(11, 7, 17);
            btnPersonalCalendar.BackColor = Color.FromArgb(11, 7, 17);
            //
            //SubFormTop
            if (SubFormTopInitialized == true)
            {
                if (activeSubFormTop != null) activeSubFormTop.Hide();  //Top
                //if (activeSubFormBot != null) activeSubFormBot.Close();  //Bot
                if (activeSubFormBot != null) activeSubFormBot.Hide();  //Bot
                //btnPersonalCalendarToggled = false;
            }
            if (activeSubFormBot != null) activeSubFormBot.Hide();  //Bot (Login Form)
            //CODE TO LOGOUT
            if (isLoggedIn == true)
            {
                updateUserID(-1);
                updateLoginStatus(false);
                DialogResult Success = MessageBox.Show("You have been logged out.", "System", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult Error = MessageBox.Show("You are not logged in.", "Error", MessageBoxButtons.OK);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            resetIsAddingEventManager();
            btnManagerCalendar.Enabled = false;
            btnManagerCalendar.ForeColor = Color.FromArgb(11, 7, 17);
            //Close Attendee Panels If Open
            subEventViewer.hidePanelViewEditAttendeesPersonal();
            subEventViewer.hidePanelViewEditAttendeesManager();
            subEventViewer.hidePanelCheckAvailabilityAttendees();

            subEventViewer.hideSubEventControlsAddEdit();  //Hide Add/Edit Buttons
            hideSubMenu();  //IS THIS REALL NECESSARY?<^
            //Change Main Menu Button Colors
            btnLogin.BackColor = Color.FromArgb(11, 7, 17);
            btnPersonalCalendar.BackColor = Color.FromArgb(11, 7, 17);
            //
            //SubFormTop
            if (SubFormTopInitialized == true)
            {
                if (activeSubFormTop != null) activeSubFormTop.Hide();  //Top
                //if (activeSubFormBot != null) activeSubFormBot.Close();  //Bot
                if (activeSubFormBot != null) activeSubFormBot.Hide();  //Bot
                //btnPersonalCalendarToggled = false;
            }
            if (activeSubFormBot != null) activeSubFormBot.Hide();  //Bot (Login Form)
            //ADD CODE TO LOGOUT
            updateUserID(-1);
            updateLoginStatus(false);

            //EXIT
            Application.Exit();
        }
        #endregion



        //PARENT PANELS // CHILD FORMS
        #region [MAIN FORM] - PARENT PANELS // CHILD FORMS
        //REFERENCE CODE
        #region REFERENCE CODE
        /*
        //https://www.youtube.com/watch?v=JP5rgXO_5Sk&list=PLEpPP4NSi_InQJTPfTO4uEKxPgHltkq-y
        //https://rjcodeadvance.com/iu-moderno-submenu-desplegable-deslizante-menu-lateral-responsivo-only-form-c-winform/
        //https://github.com/RJCodeAdvance/Modern-Media-Player-UI-C-Sharp
        //
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;  //Set in design already, can be re-enabled in case...
            childForm.Dock = DockStyle.Fill;
            panelParentBot.Controls.Add(childForm);
            panelParentBot.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        */
        #endregion
        #region [MAIN FORM] - activeSubFormBot
        //activeSubFormBot (for panelParentBot)
        private Form activeSubFormBot = null;
        private void openSubFormBot(Form SubFormBot)
        {
            //if (activeSubFormBot != null) activeSubFormBot.Close();
            if (activeSubFormBot != null) activeSubFormBot.Hide();
            activeSubFormBot = SubFormBot;
            SubFormBot.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;  //Set in design already, can be re-enabled in case...
            SubFormBot.Dock = DockStyle.Fill;
            panelParentBot.Controls.Add(SubFormBot);
            panelParentBot.Tag = SubFormBot;
            SubFormBot.BringToFront();
            SubFormBot.Show();
        }
        #endregion
        #region [MAIN FORM] - activeSubFormTop
        //activeSubFormBot (for panelParentBot)
        private Form activeSubFormTop = null;
        private void openSubFormTop(Form SubFormTop)
        {
            //if (activeSubFormTop != null) activeSubFormTop.Close();
            if (activeSubFormTop != null) activeSubFormTop.Hide();
            activeSubFormTop = SubFormTop;
            SubFormTop.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;  //Set in design already, can be re-enabled in case...
            SubFormTop.Dock = DockStyle.Fill;
            panelParentTop.Controls.Add(SubFormTop);
            panelParentTop.Tag = SubFormTop;
            SubFormTop.BringToFront();
            SubFormTop.Show();
        }






        #endregion

        #endregion
    }
}