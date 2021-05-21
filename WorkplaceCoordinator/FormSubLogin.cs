using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC_834__Individual_Project
{
    public partial class FormSubLogin : Form
    {
        //FormSubEventViewer subEventViewer;
        FormMAIN parentForm;


        //[User Vars]
        Boolean isLoggedIn = false;
        int userID = -1;

        String email;
        String firstName;
        String lastName;

        String username;
        String password;
        String confirmPassword;

        String role;


        //[SubLogin] - CONSTRUCTOR
        public FormSubLogin()
        {
            InitializeComponent();
        }

        //passMAIN - Allows passing data to FormMAIN
        //c# how to implement aggrigation
        public void passMAIN(FormMAIN v)
        {
            parentForm = v;
        }

        //[FormSubLogin] - LF textBoxes
        #region [FormSubLogin] - LF textBoxes
        private void FormSubLogin_Load(object sender, EventArgs e)
        {
            textBox_Username.Text = "Username";
            textBox_Password.Text = "Password";
            textBox_ConfirmPassword.Text = "Confirm Password";
        }

        private void textBox_Username_Enter(object sender, EventArgs e)
        {
            if (textBox_Username.Text == "Username")
            {
                textBox_Username.Text = "";
            }
        }

        private void textBox_Username_Leave(object sender, EventArgs e)
        {
            if (textBox_Username.Text == "")
            {
                textBox_Username.Text = "Username";
            }
        }

        private void textBox_Password_Enter(object sender, EventArgs e)
        {
            if (textBox_Password.Text == "Password")
            {
                if (textBox_Password.UseSystemPasswordChar == false)
                {
                    textBox_Password.Text = "";
                    textBox_Password.UseSystemPasswordChar = true;
                }
            }
        }

        private void textBox_Password_Leave(object sender, EventArgs e)
        {
            if (textBox_Password.Text == "")
            {
                textBox_Password.Text = "Password";
                textBox_Password.UseSystemPasswordChar = false;
            }
        }

        private void textBox_ConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (textBox_ConfirmPassword.Text == "Confirm Password")
            {
                if (textBox_ConfirmPassword.UseSystemPasswordChar == false)
                {
                    textBox_ConfirmPassword.Text = "";
                    textBox_ConfirmPassword.UseSystemPasswordChar = true;
                }
            }
        }

        private void textBox_ConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (textBox_ConfirmPassword.Text == "")
            {
                textBox_ConfirmPassword.Text = "Confirm Password";
                textBox_ConfirmPassword.UseSystemPasswordChar = false;
            }
        }

        private void textBox_Email_Enter(object sender, EventArgs e)
        {
            if (textBox_Email.Text == "Email")
            {
                textBox_Email.Text = "";
            }
        }

        private void textBox_Email_Leave(object sender, EventArgs e)
        {
           if (textBox_Email.Text == "")
            {
                textBox_Email.Text = "Email";
            }
        }

        private void textBox_FirstName_Enter(object sender, EventArgs e)
        {
            if (textBox_FirstName.Text == "First Name")
            {
                textBox_FirstName.Text = "";
            }
        }

        private void textBox_FirstName_Leave(object sender, EventArgs e)
        {
            if (textBox_FirstName.Text == "")
            {
                textBox_FirstName.Text = "First Name";
            }
        }

        private void textBox_LastName_Enter(object sender, EventArgs e)
        {
            if (textBox_LastName.Text == "Last Name")
            {
                textBox_LastName.Text = "";
            }
        }

        private void textBox_LastName_Leave(object sender, EventArgs e)
        {
            if (textBox_LastName.Text == "")
            {
                textBox_LastName.Text = "Last Name";
            }
        }


        #endregion


        //[FormSubLogin] - BUTTONS
        #region - [FormSubLogin] - BUTTONS
        private void btnLFRegister_Click(object sender, EventArgs e)
        {
            //[Button Colors]
            btnLFRegister.BackColor = Color.FromArgb(54, 49, 60);
            btnLFLogin.BackColor = Color.FromArgb(35, 32, 39);
            btnLFAccountRecovery.BackColor = Color.FromArgb(35, 32, 39);
            //
            //[Register UI]
            //TextBoxes
            textBox_Email.Visible = true;
            textBox_FirstName.Visible = true;
            textBox_LastName.Visible = true;
            textBox_Password.Visible = true;
            textBox_ConfirmPassword.Visible = true;

            //Buttons
            btnLFRegisterConfirm.Visible = true;
            btnLFLoginConfirm.Visible = false;
            btnLFAccountRecoveryConfirm.Visible = false;

            //Reset Textboxes
            textBox_Email.Text = "Email";
            textBox_Username.Text = "Username";
            textBox_Password.Text = "Password";
            textBox_ConfirmPassword.Text = "Confirm Password";
            textBox_Password.UseSystemPasswordChar = false;
            textBox_ConfirmPassword.UseSystemPasswordChar = false;
        }

        private void btnLFLogin_Click(object sender, EventArgs e)
        {
            //[Button Colors]
            btnLFRegister.BackColor = Color.FromArgb(35, 32, 39);
            btnLFLogin.BackColor = Color.FromArgb(54, 49, 60);
            btnLFAccountRecovery.BackColor = Color.FromArgb(35, 32, 39);
            //
            //[Login UI]
            //TextBoxes
            textBox_Email.Visible = false;
            textBox_FirstName.Visible = false;
            textBox_LastName.Visible = false;
            textBox_Password.Visible = true;
            textBox_ConfirmPassword.Visible = false;

            //Buttons
            btnLFRegisterConfirm.Visible = false;
            btnLFLoginConfirm.Visible = true;
            btnLFAccountRecoveryConfirm.Visible = false;

            //Reset Textboxes
            textBox_Username.Text = "Username";
            textBox_Password.Text = "Password";
            textBox_Password.UseSystemPasswordChar = false;

        }

        private void btnLFAccountRecovery_Click(object sender, EventArgs e)
        {
            //[Button Colors]
            btnLFRegister.BackColor = Color.FromArgb(35, 32, 39);
            btnLFLogin.BackColor = Color.FromArgb(35, 32, 39);
            btnLFAccountRecovery.BackColor = Color.FromArgb(54, 49, 60);
            //
            //[Login UI]
            //TextBoxes
            textBox_Email.Visible = true;
            textBox_FirstName.Visible = true;
            textBox_LastName.Visible = true;
            textBox_Password.Visible = false;
            textBox_ConfirmPassword.Visible = false;

            //Buttons
            btnLFRegisterConfirm.Visible = false;
            btnLFLoginConfirm.Visible = false;
            btnLFAccountRecoveryConfirm.Visible = true;

            //Reset Textboxes
            textBox_Email.Text = "Email";
            textBox_Username.Text = "Username";
        }






        #endregion

        private void btnLFRegisterConfirm_Click(object sender, EventArgs e)
        {
            email = textBox_Email.Text;
            firstName = textBox_FirstName.Text;
            lastName = textBox_LastName.Text;
            username = textBox_Username.Text;
            password = textBox_Password.Text;
            confirmPassword = textBox_ConfirmPassword.Text;
            if (password != confirmPassword)
            {
                DialogResult PasswordsDontMatch = MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK);
                textBox_Password.Text = "Password";
                textBox_ConfirmPassword.Text = "Confirm Password";
                textBox_Password.UseSystemPasswordChar = false;
                textBox_ConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                User newUser = new User(email, firstName, lastName, username, password, confirmPassword);
                //userRegister() - INT type for error handling on return
                //0 = Success
                //-1 = Fail, EMAIL EXISTS
                //-2 = Fail, USERNAME EXISTS
                if (newUser.userRegister() == 0)
                {
                    //Console.WriteLine("Login Success!");
                    DialogResult Success = MessageBox.Show("Registration Success!\nYou will be logged in automatically.", "System", MessageBoxButtons.OK);
                    
                    btnLFLoginConfirm_Click(sender, e);
                }
                else if (newUser.userRegister() == -1)
                {
                    DialogResult Error = MessageBox.Show("Email is already registered.", "Error", MessageBoxButtons.OK);
                }
                else if (newUser.userRegister() == -2)
                {
                    DialogResult Error = MessageBox.Show("Username is already registered.", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult Error = MessageBox.Show("Something went wrong! Please check your network connection, else contact the Administrator.", "Error", MessageBoxButtons.OK);
                }

            }


        }

        private void btnLFLoginConfirm_Click(object sender, EventArgs e)
        {
            username = textBox_Username.Text;
            password = textBox_Password.Text;
            User existingUser = new User(username, password);
            if (existingUser.userLogin() == false)
            {
                DialogResult Error = MessageBox.Show("Username or password is incorrect!", "Error", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult Success = MessageBox.Show("Login Success!", "System", MessageBoxButtons.OK);

                //userID = 1000;

                //Set User Vars
                userID = existingUser.getUserID();
                isLoggedIn = existingUser.getLoginStatus();
                role = existingUser.getRole();

                //Pass User Vars To All Forms W/ Aggregation Chain
                parentForm.updateUserID(userID);
                parentForm.updateLoginStatus(isLoggedIn);
                parentForm.updateRole(role);

                //Close FormSubLogin & Open Personal Calendar
                parentForm.hideAll();
                parentForm.btnPersonalCalendar_Click(sender, e);

                //IF A MANAGER SIGNS IN -> DISPLAY 'btnManagerCalendar'
                if (role == "SYSTEM" || role == "Admin" || role == "Manager")
                {
                    parentForm.showbtnManagerCalendar();
                }
            }
        }

        private void btnLFAccountRecoveryConfirm_Click(object sender, EventArgs e)
        {
            //parentForm.hideAll();
            //parentForm.btnPersonalCalendar_Click(sender, e);
        }

    }
}
