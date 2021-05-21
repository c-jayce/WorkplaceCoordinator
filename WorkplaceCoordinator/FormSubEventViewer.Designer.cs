namespace CSC_834__Individual_Project
{
    partial class FormSubEventViewer
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panelSpacerTopMargin = new System.Windows.Forms.Panel();
            this.labelUsers = new System.Windows.Forms.Label();
            this.labelUserAvailabilities = new System.Windows.Forms.Label();
            this.labelManagerEventTooltip = new System.Windows.Forms.Label();
            this.labelAttendees = new System.Windows.Forms.Label();
            this.panelCLBContainer = new System.Windows.Forms.Panel();
            this.panelCheckAvailabilityAttendees = new System.Windows.Forms.Panel();
            this.labelCAATooltip = new System.Windows.Forms.Label();
            this.tlpCAAControls = new System.Windows.Forms.TableLayoutPanel();
            this.labelStartTimeRange = new System.Windows.Forms.Label();
            this.dtpRangeEndTime = new System.Windows.Forms.DateTimePicker();
            this.labelEndTimeRange = new System.Windows.Forms.Label();
            this.dtpRangeStartTime = new System.Windows.Forms.DateTimePicker();
            this.btnCAARefreshList = new System.Windows.Forms.Button();
            this.panelCAAbtns = new System.Windows.Forms.Panel();
            this.btnSaveAttendeesList = new System.Windows.Forms.Button();
            this.btnBackToSelectAttendees = new System.Windows.Forms.Button();
            this.listBoxAttendeeAvailability = new System.Windows.Forms.ListBox();
            this.panelViewEditAttendees = new System.Windows.Forms.Panel();
            this.panelVEAbtns = new System.Windows.Forms.Panel();
            this.btnNextCAAttendees = new System.Windows.Forms.Button();
            this.btnCloseAttendees = new System.Windows.Forms.Button();
            this.multiSelectControl1 = new MultiSelectControl.MultiSelectControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSoWSunday = new System.Windows.Forms.RadioButton();
            this.rbSoWMonday = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddRemoveAttendees = new System.Windows.Forms.Button();
            this.btnViewAttendees = new System.Windows.Forms.Button();
            this.panelSpacerTopMargin.SuspendLayout();
            this.panelCLBContainer.SuspendLayout();
            this.panelCheckAvailabilityAttendees.SuspendLayout();
            this.tlpCAAControls.SuspendLayout();
            this.panelCAAbtns.SuspendLayout();
            this.panelViewEditAttendees.SuspendLayout();
            this.panelVEAbtns.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(9, 20);
            this.monthCalendar1.MaxSelectionCount = 42;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.monthCalendar1_MouseDown);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(442, 567);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.checkedListBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBox1_MouseDown);
            // 
            // panelSpacerTopMargin
            // 
            this.panelSpacerTopMargin.Controls.Add(this.labelUsers);
            this.panelSpacerTopMargin.Controls.Add(this.labelUserAvailabilities);
            this.panelSpacerTopMargin.Controls.Add(this.labelManagerEventTooltip);
            this.panelSpacerTopMargin.Controls.Add(this.labelAttendees);
            this.panelSpacerTopMargin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSpacerTopMargin.Location = new System.Drawing.Point(0, 0);
            this.panelSpacerTopMargin.Margin = new System.Windows.Forms.Padding(0);
            this.panelSpacerTopMargin.Name = "panelSpacerTopMargin";
            this.panelSpacerTopMargin.Size = new System.Drawing.Size(690, 20);
            this.panelSpacerTopMargin.TabIndex = 2;
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsers.Location = new System.Drawing.Point(249, 0);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(73, 17);
            this.labelUsers.TabIndex = 15;
            this.labelUsers.Text = "All Users";
            this.labelUsers.Visible = false;
            // 
            // labelUserAvailabilities
            // 
            this.labelUserAvailabilities.AutoSize = true;
            this.labelUserAvailabilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserAvailabilities.Location = new System.Drawing.Point(247, 0);
            this.labelUserAvailabilities.Name = "labelUserAvailabilities";
            this.labelUserAvailabilities.Size = new System.Drawing.Size(138, 17);
            this.labelUserAvailabilities.TabIndex = 16;
            this.labelUserAvailabilities.Text = "User Availabilities";
            this.labelUserAvailabilities.Visible = false;
            // 
            // labelManagerEventTooltip
            // 
            this.labelManagerEventTooltip.AutoSize = true;
            this.labelManagerEventTooltip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelManagerEventTooltip.Location = new System.Drawing.Point(269, 0);
            this.labelManagerEventTooltip.Name = "labelManagerEventTooltip";
            this.labelManagerEventTooltip.Size = new System.Drawing.Size(229, 17);
            this.labelManagerEventTooltip.TabIndex = 0;
            this.labelManagerEventTooltip.Text = "***Events added by a Manager";
            // 
            // labelAttendees
            // 
            this.labelAttendees.AutoSize = true;
            this.labelAttendees.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelAttendees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttendees.Location = new System.Drawing.Point(609, 0);
            this.labelAttendees.Name = "labelAttendees";
            this.labelAttendees.Size = new System.Drawing.Size(81, 17);
            this.labelAttendees.TabIndex = 14;
            this.labelAttendees.Text = "Attendees";
            this.labelAttendees.Visible = false;
            // 
            // panelCLBContainer
            // 
            this.panelCLBContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCLBContainer.Controls.Add(this.panelCheckAvailabilityAttendees);
            this.panelCLBContainer.Controls.Add(this.panelViewEditAttendees);
            this.panelCLBContainer.Controls.Add(this.checkedListBox1);
            this.panelCLBContainer.Location = new System.Drawing.Point(251, 20);
            this.panelCLBContainer.Name = "panelCLBContainer";
            this.panelCLBContainer.Size = new System.Drawing.Size(442, 567);
            this.panelCLBContainer.TabIndex = 3;
            // 
            // panelCheckAvailabilityAttendees
            // 
            this.panelCheckAvailabilityAttendees.AutoSize = true;
            this.panelCheckAvailabilityAttendees.Controls.Add(this.labelCAATooltip);
            this.panelCheckAvailabilityAttendees.Controls.Add(this.tlpCAAControls);
            this.panelCheckAvailabilityAttendees.Controls.Add(this.panelCAAbtns);
            this.panelCheckAvailabilityAttendees.Controls.Add(this.listBoxAttendeeAvailability);
            this.panelCheckAvailabilityAttendees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheckAvailabilityAttendees.Location = new System.Drawing.Point(0, 0);
            this.panelCheckAvailabilityAttendees.Margin = new System.Windows.Forms.Padding(0);
            this.panelCheckAvailabilityAttendees.Name = "panelCheckAvailabilityAttendees";
            this.panelCheckAvailabilityAttendees.Size = new System.Drawing.Size(442, 567);
            this.panelCheckAvailabilityAttendees.TabIndex = 14;
            this.panelCheckAvailabilityAttendees.Visible = false;
            // 
            // labelCAATooltip
            // 
            this.labelCAATooltip.AutoSize = true;
            this.labelCAATooltip.Location = new System.Drawing.Point(3, 189);
            this.labelCAATooltip.Name = "labelCAATooltip";
            this.labelCAATooltip.Size = new System.Drawing.Size(364, 51);
            this.labelCAATooltip.TabIndex = 22;
            this.labelCAATooltip.Text = "User Availabilities are listed above. (Default = 7AM-7PM)\r\nUpdate the times below" +
    " and click \'Refresh List\' to specify\r\na new time range (e.g. 8AM-5PM)";
            this.labelCAATooltip.Visible = false;
            // 
            // tlpCAAControls
            // 
            this.tlpCAAControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCAAControls.AutoSize = true;
            this.tlpCAAControls.ColumnCount = 2;
            this.tlpCAAControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCAAControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tlpCAAControls.Controls.Add(this.labelStartTimeRange, 0, 0);
            this.tlpCAAControls.Controls.Add(this.dtpRangeEndTime, 1, 1);
            this.tlpCAAControls.Controls.Add(this.labelEndTimeRange, 0, 1);
            this.tlpCAAControls.Controls.Add(this.dtpRangeStartTime, 1, 0);
            this.tlpCAAControls.Controls.Add(this.btnCAARefreshList, 1, 2);
            this.tlpCAAControls.Location = new System.Drawing.Point(0, 256);
            this.tlpCAAControls.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCAAControls.Name = "tlpCAAControls";
            this.tlpCAAControls.RowCount = 3;
            this.tlpCAAControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tlpCAAControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpCAAControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpCAAControls.Size = new System.Drawing.Size(439, 102);
            this.tlpCAAControls.TabIndex = 21;
            this.tlpCAAControls.Visible = false;
            // 
            // labelStartTimeRange
            // 
            this.labelStartTimeRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStartTimeRange.AutoSize = true;
            this.labelStartTimeRange.Location = new System.Drawing.Point(3, 8);
            this.labelStartTimeRange.Name = "labelStartTimeRange";
            this.labelStartTimeRange.Size = new System.Drawing.Size(119, 17);
            this.labelStartTimeRange.TabIndex = 19;
            this.labelStartTimeRange.Text = "Start Time Range";
            this.labelStartTimeRange.Visible = false;
            // 
            // dtpRangeEndTime
            // 
            this.dtpRangeEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpRangeEndTime.CustomFormat = "";
            this.dtpRangeEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpRangeEndTime.Location = new System.Drawing.Point(261, 38);
            this.dtpRangeEndTime.Name = "dtpRangeEndTime";
            this.dtpRangeEndTime.ShowUpDown = true;
            this.dtpRangeEndTime.Size = new System.Drawing.Size(93, 23);
            this.dtpRangeEndTime.TabIndex = 18;
            this.dtpRangeEndTime.Visible = false;
            this.dtpRangeEndTime.ValueChanged += new System.EventHandler(this.dtpRangeEndTime_ValueChanged);
            // 
            // labelEndTimeRange
            // 
            this.labelEndTimeRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelEndTimeRange.AutoSize = true;
            this.labelEndTimeRange.Location = new System.Drawing.Point(3, 41);
            this.labelEndTimeRange.Name = "labelEndTimeRange";
            this.labelEndTimeRange.Size = new System.Drawing.Size(114, 17);
            this.labelEndTimeRange.TabIndex = 20;
            this.labelEndTimeRange.Text = "End Time Range";
            this.labelEndTimeRange.Visible = false;
            // 
            // dtpRangeStartTime
            // 
            this.dtpRangeStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpRangeStartTime.CustomFormat = "";
            this.dtpRangeStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpRangeStartTime.Location = new System.Drawing.Point(261, 5);
            this.dtpRangeStartTime.Name = "dtpRangeStartTime";
            this.dtpRangeStartTime.ShowUpDown = true;
            this.dtpRangeStartTime.Size = new System.Drawing.Size(93, 23);
            this.dtpRangeStartTime.TabIndex = 17;
            this.dtpRangeStartTime.Visible = false;
            this.dtpRangeStartTime.ValueChanged += new System.EventHandler(this.dtpRangeStartTime_ValueChanged);
            // 
            // btnCAARefreshList
            // 
            this.btnCAARefreshList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCAARefreshList.AutoSize = true;
            this.btnCAARefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnCAARefreshList.FlatAppearance.BorderSize = 0;
            this.btnCAARefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCAARefreshList.Location = new System.Drawing.Point(258, 71);
            this.btnCAARefreshList.Margin = new System.Windows.Forms.Padding(0);
            this.btnCAARefreshList.Name = "btnCAARefreshList";
            this.btnCAARefreshList.Size = new System.Drawing.Size(181, 27);
            this.btnCAARefreshList.TabIndex = 16;
            this.btnCAARefreshList.Text = "Refresh List";
            this.btnCAARefreshList.UseVisualStyleBackColor = false;
            this.btnCAARefreshList.Visible = false;
            this.btnCAARefreshList.Click += new System.EventHandler(this.btnCAARefreshList_Click);
            // 
            // panelCAAbtns
            // 
            this.panelCAAbtns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCAAbtns.AutoSize = true;
            this.panelCAAbtns.Controls.Add(this.btnSaveAttendeesList);
            this.panelCAAbtns.Controls.Add(this.btnBackToSelectAttendees);
            this.panelCAAbtns.Location = new System.Drawing.Point(0, 393);
            this.panelCAAbtns.Margin = new System.Windows.Forms.Padding(0);
            this.panelCAAbtns.Name = "panelCAAbtns";
            this.panelCAAbtns.Size = new System.Drawing.Size(439, 23);
            this.panelCAAbtns.TabIndex = 16;
            // 
            // btnSaveAttendeesList
            // 
            this.btnSaveAttendeesList.AutoSize = true;
            this.btnSaveAttendeesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnSaveAttendeesList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveAttendeesList.FlatAppearance.BorderSize = 0;
            this.btnSaveAttendeesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAttendeesList.Location = new System.Drawing.Point(258, 0);
            this.btnSaveAttendeesList.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveAttendeesList.Name = "btnSaveAttendeesList";
            this.btnSaveAttendeesList.Size = new System.Drawing.Size(181, 23);
            this.btnSaveAttendeesList.TabIndex = 14;
            this.btnSaveAttendeesList.Text = "Save Attendees";
            this.btnSaveAttendeesList.UseVisualStyleBackColor = false;
            this.btnSaveAttendeesList.Visible = false;
            this.btnSaveAttendeesList.Click += new System.EventHandler(this.btnSaveAttendeesList_Click);
            // 
            // btnBackToSelectAttendees
            // 
            this.btnBackToSelectAttendees.AutoSize = true;
            this.btnBackToSelectAttendees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnBackToSelectAttendees.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBackToSelectAttendees.FlatAppearance.BorderSize = 0;
            this.btnBackToSelectAttendees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToSelectAttendees.Location = new System.Drawing.Point(0, 0);
            this.btnBackToSelectAttendees.Margin = new System.Windows.Forms.Padding(0);
            this.btnBackToSelectAttendees.Name = "btnBackToSelectAttendees";
            this.btnBackToSelectAttendees.Size = new System.Drawing.Size(184, 23);
            this.btnBackToSelectAttendees.TabIndex = 15;
            this.btnBackToSelectAttendees.Text = "Back";
            this.btnBackToSelectAttendees.UseVisualStyleBackColor = false;
            this.btnBackToSelectAttendees.Visible = false;
            this.btnBackToSelectAttendees.Click += new System.EventHandler(this.btnBackToSelectAttendees_Click);
            // 
            // listBoxAttendeeAvailability
            // 
            this.listBoxAttendeeAvailability.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxAttendeeAvailability.FormattingEnabled = true;
            this.listBoxAttendeeAvailability.ItemHeight = 16;
            this.listBoxAttendeeAvailability.Location = new System.Drawing.Point(0, 0);
            this.listBoxAttendeeAvailability.Margin = new System.Windows.Forms.Padding(0);
            this.listBoxAttendeeAvailability.Name = "listBoxAttendeeAvailability";
            this.listBoxAttendeeAvailability.Size = new System.Drawing.Size(442, 180);
            this.listBoxAttendeeAvailability.Sorted = true;
            this.listBoxAttendeeAvailability.TabIndex = 0;
            this.listBoxAttendeeAvailability.Visible = false;
            this.listBoxAttendeeAvailability.SelectedIndexChanged += new System.EventHandler(this.listBoxAttendeeAvailability_SelectedIndexChanged);
            // 
            // panelViewEditAttendees
            // 
            this.panelViewEditAttendees.AutoSize = true;
            this.panelViewEditAttendees.Controls.Add(this.panelVEAbtns);
            this.panelViewEditAttendees.Controls.Add(this.multiSelectControl1);
            this.panelViewEditAttendees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewEditAttendees.Location = new System.Drawing.Point(0, 0);
            this.panelViewEditAttendees.Margin = new System.Windows.Forms.Padding(0);
            this.panelViewEditAttendees.Name = "panelViewEditAttendees";
            this.panelViewEditAttendees.Size = new System.Drawing.Size(442, 567);
            this.panelViewEditAttendees.TabIndex = 0;
            this.panelViewEditAttendees.Visible = false;
            // 
            // panelVEAbtns
            // 
            this.panelVEAbtns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVEAbtns.AutoSize = true;
            this.panelVEAbtns.Controls.Add(this.btnNextCAAttendees);
            this.panelVEAbtns.Controls.Add(this.btnCloseAttendees);
            this.panelVEAbtns.Location = new System.Drawing.Point(0, 393);
            this.panelVEAbtns.Margin = new System.Windows.Forms.Padding(0);
            this.panelVEAbtns.Name = "panelVEAbtns";
            this.panelVEAbtns.Size = new System.Drawing.Size(439, 23);
            this.panelVEAbtns.TabIndex = 15;
            // 
            // btnNextCAAttendees
            // 
            this.btnNextCAAttendees.AutoSize = true;
            this.btnNextCAAttendees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnNextCAAttendees.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNextCAAttendees.FlatAppearance.BorderSize = 0;
            this.btnNextCAAttendees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextCAAttendees.Location = new System.Drawing.Point(258, 0);
            this.btnNextCAAttendees.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextCAAttendees.Name = "btnNextCAAttendees";
            this.btnNextCAAttendees.Size = new System.Drawing.Size(181, 23);
            this.btnNextCAAttendees.TabIndex = 12;
            this.btnNextCAAttendees.Text = "Next / Check Availability";
            this.btnNextCAAttendees.UseVisualStyleBackColor = false;
            this.btnNextCAAttendees.Visible = false;
            this.btnNextCAAttendees.Click += new System.EventHandler(this.btnNextCAAttendees_Click);
            // 
            // btnCloseAttendees
            // 
            this.btnCloseAttendees.AutoSize = true;
            this.btnCloseAttendees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnCloseAttendees.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseAttendees.FlatAppearance.BorderSize = 0;
            this.btnCloseAttendees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseAttendees.Location = new System.Drawing.Point(0, 0);
            this.btnCloseAttendees.Margin = new System.Windows.Forms.Padding(0);
            this.btnCloseAttendees.Name = "btnCloseAttendees";
            this.btnCloseAttendees.Size = new System.Drawing.Size(184, 23);
            this.btnCloseAttendees.TabIndex = 13;
            this.btnCloseAttendees.Text = "Close";
            this.btnCloseAttendees.UseVisualStyleBackColor = false;
            this.btnCloseAttendees.Visible = false;
            this.btnCloseAttendees.Click += new System.EventHandler(this.btnCloseAttendees_Click);
            // 
            // multiSelectControl1
            // 
            this.multiSelectControl1.AutoSize = true;
            this.multiSelectControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiSelectControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiSelectControl1.Location = new System.Drawing.Point(0, 0);
            this.multiSelectControl1.Margin = new System.Windows.Forms.Padding(0);
            this.multiSelectControl1.Name = "multiSelectControl1";
            this.multiSelectControl1.Size = new System.Drawing.Size(442, 567);
            this.multiSelectControl1.TabIndex = 14;
            this.multiSelectControl1.Visible = false;
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Checked = true;
            this.rbDay.Location = new System.Drawing.Point(171, 212);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(51, 21);
            this.rbDay.TabIndex = 4;
            this.rbDay.TabStop = true;
            this.rbDay.Text = "Day";
            this.rbDay.UseVisualStyleBackColor = true;
            this.rbDay.CheckedChanged += new System.EventHandler(this.rbDay_CheckedChanged);
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Location = new System.Drawing.Point(171, 239);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(62, 21);
            this.rbWeek.TabIndex = 5;
            this.rbWeek.Text = "Week";
            this.rbWeek.UseVisualStyleBackColor = true;
            this.rbWeek.CheckedChanged += new System.EventHandler(this.rbWeek_CheckedChanged);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(171, 266);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(65, 21);
            this.rbMonth.TabIndex = 6;
            this.rbMonth.Text = "Month";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "View by:";
            // 
            // rbSoWSunday
            // 
            this.rbSoWSunday.AutoSize = true;
            this.rbSoWSunday.Checked = true;
            this.rbSoWSunday.Location = new System.Drawing.Point(19, 0);
            this.rbSoWSunday.Name = "rbSoWSunday";
            this.rbSoWSunday.Size = new System.Drawing.Size(74, 21);
            this.rbSoWSunday.TabIndex = 8;
            this.rbSoWSunday.TabStop = true;
            this.rbSoWSunday.Text = "Sunday";
            this.rbSoWSunday.UseVisualStyleBackColor = true;
            this.rbSoWSunday.CheckedChanged += new System.EventHandler(this.rbSoWSunday_CheckedChanged);
            // 
            // rbSoWMonday
            // 
            this.rbSoWMonday.AutoSize = true;
            this.rbSoWMonday.Location = new System.Drawing.Point(19, 21);
            this.rbSoWMonday.Name = "rbSoWMonday";
            this.rbSoWMonday.Size = new System.Drawing.Size(76, 21);
            this.rbSoWMonday.TabIndex = 9;
            this.rbSoWMonday.Text = "Monday";
            this.rbSoWMonday.UseVisualStyleBackColor = true;
            this.rbSoWMonday.CheckedChanged += new System.EventHandler(this.rbSoWMonday_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Start of Week:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbSoWMonday);
            this.panel1.Controls.Add(this.rbSoWSunday);
            this.panel1.Location = new System.Drawing.Point(152, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 83);
            this.panel1.TabIndex = 11;
            // 
            // btnAddRemoveAttendees
            // 
            this.btnAddRemoveAttendees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnAddRemoveAttendees.FlatAppearance.BorderSize = 0;
            this.btnAddRemoveAttendees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRemoveAttendees.Location = new System.Drawing.Point(53, 413);
            this.btnAddRemoveAttendees.Name = "btnAddRemoveAttendees";
            this.btnAddRemoveAttendees.Size = new System.Drawing.Size(169, 23);
            this.btnAddRemoveAttendees.TabIndex = 12;
            this.btnAddRemoveAttendees.Text = "Add/Remove Attendees";
            this.btnAddRemoveAttendees.UseVisualStyleBackColor = false;
            this.btnAddRemoveAttendees.Visible = false;
            this.btnAddRemoveAttendees.Click += new System.EventHandler(this.btnAddRemoveAttendees_Click);
            // 
            // btnViewAttendees
            // 
            this.btnViewAttendees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            this.btnViewAttendees.FlatAppearance.BorderSize = 0;
            this.btnViewAttendees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAttendees.Location = new System.Drawing.Point(53, 384);
            this.btnViewAttendees.Name = "btnViewAttendees";
            this.btnViewAttendees.Size = new System.Drawing.Size(169, 23);
            this.btnViewAttendees.TabIndex = 13;
            this.btnViewAttendees.Text = "View Attendees";
            this.btnViewAttendees.UseVisualStyleBackColor = false;
            this.btnViewAttendees.Click += new System.EventHandler(this.btnViewAttendees_Click);
            // 
            // FormSubEventViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(690, 446);
            this.Controls.Add(this.btnViewAttendees);
            this.Controls.Add(this.btnAddRemoveAttendees);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbMonth);
            this.Controls.Add(this.rbWeek);
            this.Controls.Add(this.rbDay);
            this.Controls.Add(this.panelCLBContainer);
            this.Controls.Add(this.panelSpacerTopMargin);
            this.Controls.Add(this.monthCalendar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(690, 446);
            this.Name = "FormSubEventViewer";
            this.Text = "FormSubEventViewer";
            this.panelSpacerTopMargin.ResumeLayout(false);
            this.panelSpacerTopMargin.PerformLayout();
            this.panelCLBContainer.ResumeLayout(false);
            this.panelCLBContainer.PerformLayout();
            this.panelCheckAvailabilityAttendees.ResumeLayout(false);
            this.panelCheckAvailabilityAttendees.PerformLayout();
            this.tlpCAAControls.ResumeLayout(false);
            this.tlpCAAControls.PerformLayout();
            this.panelCAAbtns.ResumeLayout(false);
            this.panelCAAbtns.PerformLayout();
            this.panelViewEditAttendees.ResumeLayout(false);
            this.panelViewEditAttendees.PerformLayout();
            this.panelVEAbtns.ResumeLayout(false);
            this.panelVEAbtns.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panelSpacerTopMargin;
        private System.Windows.Forms.Panel panelCLBContainer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rbDay;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbSoWSunday;
        private System.Windows.Forms.RadioButton rbSoWMonday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnAddRemoveAttendees;
        public System.Windows.Forms.Button btnViewAttendees;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.Button btnNextCAAttendees;
        public System.Windows.Forms.Button btnCloseAttendees;
        public System.Windows.Forms.Label labelUsers;
        public System.Windows.Forms.Label labelAttendees;
        public System.Windows.Forms.Label labelManagerEventTooltip;
        public System.Windows.Forms.Panel panelCheckAvailabilityAttendees;
        public System.Windows.Forms.Panel panelViewEditAttendees;
        public System.Windows.Forms.Button btnSaveAttendeesList;
        public System.Windows.Forms.Button btnBackToSelectAttendees;
        private System.Windows.Forms.ListBox listBoxAttendeeAvailability;
        public System.Windows.Forms.Panel panelCAAbtns;
        public System.Windows.Forms.Panel panelVEAbtns;
        public System.Windows.Forms.Label labelUserAvailabilities;
        public MultiSelectControl.MultiSelectControl multiSelectControl1;
        public System.Windows.Forms.DateTimePicker dtpRangeEndTime;
        public System.Windows.Forms.DateTimePicker dtpRangeStartTime;
        private System.Windows.Forms.Label labelCAATooltip;
        private System.Windows.Forms.TableLayoutPanel tlpCAAControls;
        private System.Windows.Forms.Label labelStartTimeRange;
        private System.Windows.Forms.Label labelEndTimeRange;
        public System.Windows.Forms.Button btnCAARefreshList;
    }
}