using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Renci.SshNet.Security.Cryptography;
using System.Globalization;
using Org.BouncyCastle.Asn1.Cms;
using CSC_834__Individual_Project;
//
using System.Configuration;

namespace WorkplaceCoordinator
{
    class ManagerEvent
    {
        //ArrayList eventlist = new ArrayList();
        Event borrowEvent = new Event();

        //[User Vars]
        int userID = -1;


        //[Event Vars]
        int eventID;
        DateTime date;
        String dateParsed;
        String title;
        TimeSpan startTime;
        String startTimeParsed;
        TimeSpan endTime;
        String endTimeParsed;
        String location;
        String description;
        TimeSpan reminderTime;
        String reminderTimeParsed;

        int isManagerEvent;
        String attendees;

        String firstName;
        String lastName;
        String email;

        //CONSTRUCTOR
        public ManagerEvent()
        {

        }


        //Return String attendeesIDList, e.g. "3,4,5"
        public String getExistingAttendees(int eventID)
        {
            ArrayList attendeesListArray = new ArrayList();
            String attendeesIDList = "";

            //prepare an SQL query to retrieve all the users in DB  //*EXCLUDING userID=1 AND userID=2 because that is SYSTEM & ADMIN
            DataTable myTable = new DataTable();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["_db"].ConnectionString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT attendees FROM z_corona_event WHERE eventID=@eventID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                //Console.WriteLine("curr eventID: " + eventID);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)  //Should be only 1 row
            {
                //ManagerEvent attendee = new ManagerEvent();
                //attendee.attendees = row["attendees"].ToString();
                attendeesIDList = row["attendees"].ToString();
            }
            //Console.WriteLine("attendeesIDList = " + attendeesIDList);

            return attendeesIDList;  //return the event list
        }


        //Converts String attendeesIDList, e.g. "3,4,5"  TO ArrayList [userID, firstName, lastName]
        public ArrayList convertExistingAttendeesIDsStringToArray(String attendeesIDList)
        {
            ArrayList attendeesListArray = new ArrayList();  //Return This

            //Split String to List<int>
            List<int> userIDList = new List<int>();
            userIDList = attendeesIDList.Split(',').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList();

            //For Each Item
            int lastIndex = userIDList.Count - 1;
            for (int i = 0; i<= lastIndex; i++)
            {
                Console.WriteLine("LIST ID = " + userIDList[i]);

                //prepare an SQL query to retrieve all the users in DB  //*EXCLUDING userID=1 AND userID=2 because that is SYSTEM & ADMIN
                DataTable myTable = new DataTable();
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["_db"].ConnectionString);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "SELECT userID, firstName, lastName, email FROM z_corona_user WHERE userID<>1 AND userID<>2 AND userID=@userID;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@userID", userIDList[i]);
                    myAdapter.Fill(myTable);
                    Console.WriteLine("Table is ready.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
                //convert the retrieved data to events and save them to the list
                foreach (DataRow row in myTable.Rows)
                {
                    ManagerEvent user = new ManagerEvent();
                    user.userID = (int)row["userID"];  //Retrieve userID
                    user.firstName = row["firstName"].ToString();
                    user.lastName = row["lastName"].ToString();
                    user.email = row["email"].ToString();

                    attendeesListArray.Add(user);
                }
            }
            //TestPrint [WORKS!]
            /*
            for (int i = 0; i <= lastIndex; i++)
            {
                Console.WriteLine("USER: " + ((ManagerEvent)attendeesListArray[i]).getUserID() + " " + ((ManagerEvent)attendeesListArray[i]).getFirstName() +" " + ((ManagerEvent)attendeesListArray[i]).getLastName());
            }*/

                return attendeesListArray;
        }


        //Function gets userID, fistName, lastName of ALL USERS (EXPT 1 AND 2 | SYSTEM & ADMIN) | [userID, firstName, lastName]
        public ArrayList getUsersList()
        {
            ArrayList usersList = new ArrayList();

            //prepare an SQL query to retrieve all the users in DB  //*EXCLUDING userID=1 AND userID=2 because that is SYSTEM & ADMIN
            DataTable myTable = new DataTable();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["_db"].ConnectionString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT userID, firstName, lastName, email FROM z_corona_user WHERE userID<>1 AND userID<>2 ORDER BY lastName ASC, firstName ASC, userID ASC;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                ManagerEvent user = new ManagerEvent();
                user.userID = (int)row["userID"];  //Retrieve userID = for group project
                user.firstName = row["firstName"].ToString();
                user.lastName = row["lastName"].ToString();
                user.email = row["email"].ToString();

                usersList.Add(user);
            }
            return usersList;  //return the event list
        }


        //COMPARE ARRAYLISTS TO FILL dualistbox [RIGHT] with existing attendees and [LEFT] with fulluserlist-existingattendees
        public ArrayList compareArrayLists(ArrayList fullUserList, ArrayList currentAttendees)
        {
            ArrayList availableUsers = new ArrayList();

            int lastIndex1 = fullUserList.Count - 1;
            int lastIndex2 = currentAttendees.Count - 1;

            for (int i = lastIndex1; i >= 0; i--)
            {
                Boolean exists = false;
                for (int j = lastIndex2; j >= 0; j--)
                {
                    if (((ManagerEvent)fullUserList[i]).getUserID() == ((ManagerEvent)currentAttendees[j]).getUserID())
                    {
                        exists = true;
                    }
                }
                if (exists == false)
                {
                    availableUsers.Add(fullUserList[i]);
                }
            }
            return availableUsers;
        }


        //Function gets userID w/ email string
        public int getUserIDviaEmail(String attendeeEmail)
        {
            ArrayList attendeesListArray = new ArrayList();
            int attendeeID = -1;

            //prepare an SQL query to retrieve all the users in DB  //*EXCLUDING userID=1 AND userID=2 because that is SYSTEM & ADMIN
            DataTable myTable = new DataTable();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["_db"].ConnectionString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT userID FROM z_corona_user WHERE email=@email;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", attendeeEmail);
                Console.WriteLine("curr email=" + attendeeEmail);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)  //Should be only 1 row
            {
                //ManagerEvent attendee = new ManagerEvent();
                //attendee.attendees = row["attendees"].ToString();
                attendeeID = (int)row["userID"];
            }
            Console.WriteLine("attendeeID = " + attendeeID);
            return attendeeID;
        }


        //Function to return an eventList of ALL SELECTED ATTENDEES ON THE SELECTED DATE
        public static ArrayList getAttendeeEventList(string dateStringStart, int userID)
        {
            //Console.WriteLine("dateStart=" + dateStringStart);
            //Console.WriteLine("dateEnd=" + dateStringEnd);
            ArrayList attendeeEventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["_db"].ConnectionString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM z_corona_event WHERE (date=@myDateStart AND userID=@userID) OR (date=@myDateStart AND isManagerEvent=1) ORDER BY date ASC, startTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDateStart", dateStringStart);
                //cmd.Parameters.AddWithValue("@myDateEnd", dateStringEnd);
                cmd.Parameters.AddWithValue("@userID", userID);
                //cmd.Parameters.AddWithValue("@isManagerEvent", 1);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                ManagerEvent newEvent = new ManagerEvent();
                newEvent.eventID = (int)row["eventID"];  //Retrieve eventID to use for editing events... DB side is auto-increment...
                newEvent.userID = (int)row["userID"];  //Retrieve userID = for group project
                //newEvent.title = row["title"].ToString();
                //newEvent.date = (DateTime)row["date"];  //works
                newEvent.startTime = (TimeSpan)row["startTime"];
                newEvent.endTime = (TimeSpan)row["endTime"];
                //newEvent.location = row["location"].ToString();
                //newEvent.description = row["description"].ToString();
                //newEvent.reminderTime = (TimeSpan)row["reminderTime"];

                newEvent.isManagerEvent = (int)row["isManagerEvent"];
                //newEvent.attendees = row["attendees"].ToString();
                attendeeEventList.Add(newEvent);
            }
            return attendeeEventList;
        }

        //FUNCTION TO UPDATE attendeeIDList TO DB
        public static void updateAttendees(int eventID, String attendeeIDList)
        {
            //Send SQL Query
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["_db"].ConnectionString);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //add/alter code for user ID after coding functional login
                //string sql = "UPDATE z_corona_event SET attendees=@attendeeIDList WHERE eventID=@eventID";
                string sql = "UPDATE z_corona_event SET attendees=@attendeeIDList, isManagerEvent=1 WHERE eventID=@eventID";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                cmd.Parameters.AddWithValue("@attendeeIDList", attendeeIDList);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");


        }

        public int getEventID()
        {
            return eventID;
        }

        public int getUserID()
        {
            return userID;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public String getEmail()
        {
            return email;
        }

        public TimeSpan getStartTime()
        {
            //Console.WriteLine("startTime ORIGINAL="+startTime);
            //Console.WriteLine("ROUNDED: " + RoundToNearestMinutes(startTime, 30));

            //String temp = borrowEvent.convertTimeSpanToString(startTime);
            //Console.WriteLine("startimeTEMP= " + temp);
            //startTimeParsed = borrowEvent.convertStringToTimeSpanFormat(temp);
            //Console.WriteLine("startTimeParsed= " + startTimeParsed);
            return startTime;
        }

        public TimeSpan getEndTime()
        {
            //Console.WriteLine("endTime ORIGINAL=" + endTime);
            //Console.WriteLine("ROUNDED: " + RoundToNearestMinutes(endTime, 30));

            //String temp = borrowEvent.convertTimeSpanToString(endTime);
            //Console.WriteLine("endimeTEMP= " + temp);
            //endTimeParsed = borrowEvent.convertStringToTimeSpanFormat(temp);
            //Console.WriteLine("endTimeParsed= " + endTimeParsed);
            return endTime;
        }

        public int getIsManagerEvent()
        {
            return isManagerEvent;
        }


        /*public static TimeSpan RoundToNearestMinutes(this TimeSpan input, int minutes)
        {
            var totalMinutes = (int)(input + new TimeSpan(0, minutes / 2, 0)).TotalMinutes;

            return new TimeSpan(0, totalMinutes - totalMinutes % minutes, 0);
        }*/
    }
}

