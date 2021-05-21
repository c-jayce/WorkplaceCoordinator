namespace CSC_834__Individual_Project
{
    partial class FormMAIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMAIN));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelManagerCalSubMenu = new System.Windows.Forms.Panel();
            this.btnManagerEditEvent = new System.Windows.Forms.Button();
            this.btnManagerDeleteEvent = new System.Windows.Forms.Button();
            this.btnManagerAddEvent = new System.Windows.Forms.Button();
            this.btnManagerCalendar = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelPersonalCalSubMenu = new System.Windows.Forms.Panel();
            this.btnEditEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnPersonalCalendar = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label_FormMAIN_Time_TopLeft = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelParentBot = new System.Windows.Forms.Panel();
            this.panelParentTop = new System.Windows.Forms.Panel();
            this.label_FormMAIN_Time_Mid = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSideMenu.SuspendLayout();
            this.panelManagerCalSubMenu.SuspendLayout();
            this.panelPersonalCalSubMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelParentTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.panelManagerCalSubMenu);
            this.panelSideMenu.Controls.Add(this.btnManagerCalendar);
            this.panelSideMenu.Controls.Add(this.btnLogout);
            this.panelSideMenu.Controls.Add(this.btnExit);
            this.panelSideMenu.Controls.Add(this.panelPersonalCalSubMenu);
            this.panelSideMenu.Controls.Add(this.btnPersonalCalendar);
            this.panelSideMenu.Controls.Add(this.btnLogin);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.MinimumSize = new System.Drawing.Size(250, 571);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 571);
            this.panelSideMenu.TabIndex = 0;
            // 
            // panelManagerCalSubMenu
            // 
            this.panelManagerCalSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelManagerCalSubMenu.Controls.Add(this.btnManagerEditEvent);
            this.panelManagerCalSubMenu.Controls.Add(this.btnManagerDeleteEvent);
            this.panelManagerCalSubMenu.Controls.Add(this.btnManagerAddEvent);
            this.panelManagerCalSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelManagerCalSubMenu.Location = new System.Drawing.Point(0, 366);
            this.panelManagerCalSubMenu.Name = "panelManagerCalSubMenu";
            this.panelManagerCalSubMenu.Size = new System.Drawing.Size(238, 131);
            this.panelManagerCalSubMenu.TabIndex = 7;
            // 
            // btnManagerEditEvent
            // 
            this.btnManagerEditEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagerEditEvent.FlatAppearance.BorderSize = 0;
            this.btnManagerEditEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerEditEvent.ForeColor = System.Drawing.Color.Silver;
            this.btnManagerEditEvent.Location = new System.Drawing.Point(0, 80);
            this.btnManagerEditEvent.Name = "btnManagerEditEvent";
            this.btnManagerEditEvent.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnManagerEditEvent.Size = new System.Drawing.Size(238, 40);
            this.btnManagerEditEvent.TabIndex = 9;
            this.btnManagerEditEvent.Text = "Edit Event";
            this.btnManagerEditEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagerEditEvent.UseVisualStyleBackColor = true;
            this.btnManagerEditEvent.Click += new System.EventHandler(this.btnManagerEditEvent_Click);
            // 
            // btnManagerDeleteEvent
            // 
            this.btnManagerDeleteEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagerDeleteEvent.FlatAppearance.BorderSize = 0;
            this.btnManagerDeleteEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerDeleteEvent.ForeColor = System.Drawing.Color.Silver;
            this.btnManagerDeleteEvent.Location = new System.Drawing.Point(0, 40);
            this.btnManagerDeleteEvent.Name = "btnManagerDeleteEvent";
            this.btnManagerDeleteEvent.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnManagerDeleteEvent.Size = new System.Drawing.Size(238, 40);
            this.btnManagerDeleteEvent.TabIndex = 8;
            this.btnManagerDeleteEvent.Text = "Delete Event(s)";
            this.btnManagerDeleteEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagerDeleteEvent.UseVisualStyleBackColor = true;
            this.btnManagerDeleteEvent.Click += new System.EventHandler(this.btnManagerDeleteEvent_Click);
            // 
            // btnManagerAddEvent
            // 
            this.btnManagerAddEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagerAddEvent.FlatAppearance.BorderSize = 0;
            this.btnManagerAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerAddEvent.ForeColor = System.Drawing.Color.Silver;
            this.btnManagerAddEvent.Location = new System.Drawing.Point(0, 0);
            this.btnManagerAddEvent.Name = "btnManagerAddEvent";
            this.btnManagerAddEvent.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnManagerAddEvent.Size = new System.Drawing.Size(238, 40);
            this.btnManagerAddEvent.TabIndex = 7;
            this.btnManagerAddEvent.Text = "Add Event";
            this.btnManagerAddEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagerAddEvent.UseVisualStyleBackColor = true;
            this.btnManagerAddEvent.Click += new System.EventHandler(this.btnManagerAddEvent_Click);
            // 
            // btnManagerCalendar
            // 
            this.btnManagerCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagerCalendar.FlatAppearance.BorderSize = 0;
            this.btnManagerCalendar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnManagerCalendar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnManagerCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerCalendar.ForeColor = System.Drawing.Color.Silver;
            this.btnManagerCalendar.Location = new System.Drawing.Point(0, 321);
            this.btnManagerCalendar.Name = "btnManagerCalendar";
            this.btnManagerCalendar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnManagerCalendar.Size = new System.Drawing.Size(238, 45);
            this.btnManagerCalendar.TabIndex = 6;
            this.btnManagerCalendar.Text = "Manager Calendar";
            this.btnManagerCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagerCalendar.UseVisualStyleBackColor = true;
            this.btnManagerCalendar.Click += new System.EventHandler(this.btnManagerCalendar_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Silver;
            this.btnLogout.Location = new System.Drawing.Point(0, 497);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(238, 45);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Silver;
            this.btnExit.Location = new System.Drawing.Point(0, 542);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(238, 45);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Logout  >>  Quit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelPersonalCalSubMenu
            // 
            this.panelPersonalCalSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelPersonalCalSubMenu.Controls.Add(this.btnEditEvent);
            this.panelPersonalCalSubMenu.Controls.Add(this.btnDeleteEvent);
            this.panelPersonalCalSubMenu.Controls.Add(this.btnAddEvent);
            this.panelPersonalCalSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPersonalCalSubMenu.Location = new System.Drawing.Point(0, 190);
            this.panelPersonalCalSubMenu.Name = "panelPersonalCalSubMenu";
            this.panelPersonalCalSubMenu.Size = new System.Drawing.Size(238, 131);
            this.panelPersonalCalSubMenu.TabIndex = 3;
            // 
            // btnEditEvent
            // 
            this.btnEditEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditEvent.FlatAppearance.BorderSize = 0;
            this.btnEditEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditEvent.ForeColor = System.Drawing.Color.Silver;
            this.btnEditEvent.Location = new System.Drawing.Point(0, 80);
            this.btnEditEvent.Name = "btnEditEvent";
            this.btnEditEvent.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnEditEvent.Size = new System.Drawing.Size(238, 40);
            this.btnEditEvent.TabIndex = 5;
            this.btnEditEvent.Text = "Edit Event";
            this.btnEditEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditEvent.UseVisualStyleBackColor = true;
            this.btnEditEvent.Click += new System.EventHandler(this.btnEditEvent_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteEvent.FlatAppearance.BorderSize = 0;
            this.btnDeleteEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEvent.ForeColor = System.Drawing.Color.Silver;
            this.btnDeleteEvent.Location = new System.Drawing.Point(0, 40);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDeleteEvent.Size = new System.Drawing.Size(238, 40);
            this.btnDeleteEvent.TabIndex = 4;
            this.btnDeleteEvent.Text = "Delete Event(s)";
            this.btnDeleteEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddEvent.FlatAppearance.BorderSize = 0;
            this.btnAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEvent.ForeColor = System.Drawing.Color.Silver;
            this.btnAddEvent.Location = new System.Drawing.Point(0, 0);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAddEvent.Size = new System.Drawing.Size(238, 40);
            this.btnAddEvent.TabIndex = 3;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnPersonalCalendar
            // 
            this.btnPersonalCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPersonalCalendar.FlatAppearance.BorderSize = 0;
            this.btnPersonalCalendar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnPersonalCalendar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnPersonalCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonalCalendar.ForeColor = System.Drawing.Color.Silver;
            this.btnPersonalCalendar.Location = new System.Drawing.Point(0, 145);
            this.btnPersonalCalendar.Name = "btnPersonalCalendar";
            this.btnPersonalCalendar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPersonalCalendar.Size = new System.Drawing.Size(238, 45);
            this.btnPersonalCalendar.TabIndex = 2;
            this.btnPersonalCalendar.Text = "Personal Calendar";
            this.btnPersonalCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonalCalendar.UseVisualStyleBackColor = true;
            this.btnPersonalCalendar.Click += new System.EventHandler(this.btnPersonalCalendar_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(62)))), ((int)(((byte)(136)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.Silver;
            this.btnLogin.Location = new System.Drawing.Point(0, 100);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogin.Size = new System.Drawing.Size(238, 45);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label_FormMAIN_Time_TopLeft);
            this.panelLogo.Controls.Add(this.pictureBox2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(238, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // label_FormMAIN_Time_TopLeft
            // 
            this.label_FormMAIN_Time_TopLeft.AutoSize = true;
            this.label_FormMAIN_Time_TopLeft.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.label_FormMAIN_Time_TopLeft.Location = new System.Drawing.Point(82, 48);
            this.label_FormMAIN_Time_TopLeft.Name = "label_FormMAIN_Time_TopLeft";
            this.label_FormMAIN_Time_TopLeft.Size = new System.Drawing.Size(179, 13);
            this.label_FormMAIN_Time_TopLeft.TabIndex = 2;
            this.label_FormMAIN_Time_TopLeft.Text = "MM/DD/YYYY HH:MM:SS TT";
            this.label_FormMAIN_Time_TopLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelParentBot
            // 
            this.panelParentBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelParentBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelParentBot.Location = new System.Drawing.Point(250, 446);
            this.panelParentBot.Name = "panelParentBot";
            this.panelParentBot.Size = new System.Drawing.Size(690, 125);
            this.panelParentBot.TabIndex = 1;
            // 
            // panelParentTop
            // 
            this.panelParentTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelParentTop.Controls.Add(this.label_FormMAIN_Time_Mid);
            this.panelParentTop.Controls.Add(this.pictureBox1);
            this.panelParentTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParentTop.Location = new System.Drawing.Point(250, 0);
            this.panelParentTop.MinimumSize = new System.Drawing.Size(690, 446);
            this.panelParentTop.Name = "panelParentTop";
            this.panelParentTop.Size = new System.Drawing.Size(690, 446);
            this.panelParentTop.TabIndex = 2;
            // 
            // label_FormMAIN_Time_Mid
            // 
            this.label_FormMAIN_Time_Mid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FormMAIN_Time_Mid.AutoSize = true;
            this.label_FormMAIN_Time_Mid.Font = new System.Drawing.Font("Verdana", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FormMAIN_Time_Mid.Location = new System.Drawing.Point(173, 380);
            this.label_FormMAIN_Time_Mid.Name = "label_FormMAIN_Time_Mid";
            this.label_FormMAIN_Time_Mid.Size = new System.Drawing.Size(503, 38);
            this.label_FormMAIN_Time_Mid.TabIndex = 100;
            this.label_FormMAIN_Time_Mid.Text = "MM/DD/YYYY HH:MM:SS TT";
            this.label_FormMAIN_Time_Mid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(224, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 571);
            this.Controls.Add(this.panelParentTop);
            this.Controls.Add(this.panelParentBot);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "FormMAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMAIN_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelManagerCalSubMenu.ResumeLayout(false);
            this.panelPersonalCalSubMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelParentTop.ResumeLayout(false);
            this.panelParentTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelPersonalCalSubMenu;
        private System.Windows.Forms.Button btnEditEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnPersonalCalendar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelParentBot;
        private System.Windows.Forms.Panel panelParentTop;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label_FormMAIN_Time_Mid;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_FormMAIN_Time_TopLeft;
        private System.Windows.Forms.Panel panelManagerCalSubMenu;
        private System.Windows.Forms.Button btnManagerEditEvent;
        private System.Windows.Forms.Button btnManagerDeleteEvent;
        private System.Windows.Forms.Button btnManagerAddEvent;
        private System.Windows.Forms.Button btnManagerCalendar;
    }
}

