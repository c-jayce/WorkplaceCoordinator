using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
//
using System.Configuration;

namespace CSC_834__Individual_Project
{
    class User
    {
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


        //[User Class] - CONSTRUCTOR
        public User()
        {

        }

        public User(/*int _userID,*/ string _email, string _firstName, string _lastName, string _username, string _password, string _confirmPassword)
        {
            //userID = _userID;
            email = _email;
            firstName = _firstName;
            lastName = _lastName;
            username = _username;
            password = _password;
            confirmPassword = _confirmPassword;
        }

        public User(/*int _userID,*/ string _username, string _password)
        {
            //userID = _userID;
            //email = _email;
            //firstName = _firstName;
            //lastName = _lastName;
            username = _username;
            password = _password;
            //confirmPassword = _confirmPassword;
        }


        //userRegister() - INT type for error handling on return
        //0 = Success
        //-1 = Fail, EMAIL EXISTS
        //-2 = Fail, USERNAME EXISTS
        public int userRegister()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("email: " + email);
            Console.WriteLine("firstName: " + firstName);
            Console.WriteLine("lastName: " + lastName);
            Console.WriteLine("username: " + username);
            Console.WriteLine("password: " + password);
            //Console.WriteLine("confirmPassword: " + confirmPassword);

            //Send SQL Query
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["_db"].ConnectionString);
            try
            {
                //SEE IF EMAIL EXISTS IN DB ALREADY
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //add/alter code for user ID after coding functional login
                string sql = "SELECT COUNT(*) FROM z_corona_user WHERE email=@email";  //QUERY TO SEE IF EMAIL IS USED;
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                Console.WriteLine(email + "<<email");
                cmd.ExecuteNonQuery();

                Console.WriteLine("executescalar: " + cmd.ExecuteScalar());
                object pulledRecords = cmd.ExecuteScalar();
                Int32 records = 0;  //Initial Value 0
                if (pulledRecords != null)
                {
                    //records = (Int32)cmd.ExecuteScalar();  //Get INT value of # of rows returned...
                    records = Convert.ToInt32(cmd.ExecuteScalar());
                }
                Console.WriteLine("records: " + records);
                if (records == 0)
                {
                    //SEE IF USERNAME EXISTS IN DB ALREADY
                    //RESET SQL ADAPTER
                    cmd.Parameters.Clear();  //Clear SQL Statement
                    conn.Close();
                    conn.Open();

                    sql = "SELECT COUNT(*) FROM z_corona_user WHERE username=@username";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();

                    pulledRecords = cmd.ExecuteScalar();
                    if (pulledRecords != null)
                    {
                        //records = (Int32)cmd.ExecuteScalar();  //Get INT value of # of rows returned...
                        records = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (records == 0)
                    {
                        //REGISTER USER - INSERRT ROW
                        //RESET SQL ADAPTER
                        cmd.Parameters.Clear();  //Clear SQL Statement
                        conn.Close();
                        conn.Open();
                        
                        sql = "INSERT INTO z_corona_user (email, firstName, lastName, username, password) VALUES (@email, @firstName, @lastName, @username, @password)";
                        cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                        Console.WriteLine("email: " + email);
                        Console.WriteLine("firstName: " + firstName);
                        Console.WriteLine("lastName: " + lastName);
                        Console.WriteLine("username: " + username);
                        Console.WriteLine("password: " + password);

                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        return -2;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");


            //userLogin();  //Log the user in after registration
            return 0;
        }

        //Did not make a check for if a username exists as it would be bad security practice
        public Boolean userLogin()
        {
            Console.WriteLine("\n\n\n");
            //Console.WriteLine("email: " + email);
            //Console.WriteLine("firstName: " + firstName);
            //Console.WriteLine("lastName: " + lastName);
            Console.WriteLine("username: " + username);
            Console.WriteLine("password: " + password);
            //Console.WriteLine("confirmPassword: " + confirmPassword);

            //Send SQL Query
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["_db"].ConnectionString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //add/alter code for user ID after coding functional login
                string sql = "SELECT * FROM z_corona_user WHERE username=@username AND password=@password";  //QUERY TO SEE IF ACC EXISTS
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                //cmd.Parameters.AddWithValue("@firstName", firstName);
                //cmd.Parameters.AddWithValue("@lastName", lastName);
                //cmd.Parameters.AddWithValue("@username", username);
                //cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();

                Console.WriteLine("executescalar: " + cmd.ExecuteScalar());
                object pulledRecords = cmd.ExecuteScalar();
                Int32 records = 0;  //Initial Value 0
                if (pulledRecords != null)
                {
                    //records = (Int32)cmd.ExecuteScalar();  //Get INT value of # of rows returned...
                    records = Convert.ToInt32(cmd.ExecuteScalar());
                }
                Console.WriteLine("records: " + records);
                if (records == 0)
                {
                    return false;
                }
                //REGISTER USER - INSERRT ROW
                //RESET SQL ADAPTER
                cmd.Parameters.Clear();  //Clear SQL Statement
                conn.Close();
                conn.Open();

                sql = "SELECT * FROM z_corona_user WHERE username=@username AND password=@password";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userID = (int)reader["userID"];
                    role = reader["role"].ToString();
                }

                Console.WriteLine("reader: " + reader);
                Console.WriteLine("userID: " + userID);
                Console.WriteLine("role: " + role);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

            isLoggedIn = true;
            return true;
        }


        public Boolean getLoginStatus()
        {
            //set true in userLogin
            return isLoggedIn;
        }

        public int getUserID()
        {
            return userID;
        }

        public String getRole()
        {
            return role;
        }

        public String getUsername()
        {
            return username;
        }
    }
}

