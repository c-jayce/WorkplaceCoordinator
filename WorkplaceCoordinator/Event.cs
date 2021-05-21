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

namespace CSC_834__Individual_Project
{
    class Event
    {
        ArrayList eventlist = new ArrayList();

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

        //[MANAGER VARS]
        int isManagerEvent = 1;  //Manager events have a INT value of 1, non-manager events have have a value of '0'.
        //Default is 1, var not passed for Employees, only Managers+. Value for Employees is set to '0' by default via/in DB.
        String attendeeIDListString = null;  //FOR GETTING LIST OF IDS TO UPDATE

        String attendees;

        //[Event Class] - CONSTRUCTORS
        public Event()
        {

        }

        //Constructor for [addEvent][deleteEvent]
        public Event(int _userID, string _dateParsed, string _title, string _startTimeParsed, string _endTimeParsed, string _location, string _description, string _reminderTimeParsed, string _attendeeIDList)
        {
            userID = _userID;
            dateParsed = _dateParsed;
            //Console.WriteLine("CONSTRUCTOR DATE: " + _dateParsed);  //empty?
            title = _title;
            startTimeParsed = convertStringToTimeSpanFormat(_startTimeParsed);
            endTimeParsed = convertStringToTimeSpanFormat(_endTimeParsed);
            location = _location;
            description = _description;
            reminderTimeParsed = convertStringToTimeSpanFormat(_reminderTimeParsed);

            attendeeIDListString = _attendeeIDList;
        }

        //Constructor for [editEvent]
        public Event(int _userID, int _eventID, string _dateParsed, string _title, string _startTimeParsed, string _endTimeParsed, string _location, string _description, string _reminderTimeParsed, string _attendeeIDList)
        {
            userID = _userID;
            eventID = _eventID;
            dateParsed = _dateParsed;
            //Console.WriteLine("CONSTRUCTOR DATE: " + _dateParsed);  //empty?
            title = _title;
            startTimeParsed = convertStringToTimeSpanFormat(_startTimeParsed);
            endTimeParsed = convertStringToTimeSpanFormat(_endTimeParsed);
            location = _location;
            description = _description;
            reminderTimeParsed = convertStringToTimeSpanFormat(_reminderTimeParsed);

            attendeeIDListString = _attendeeIDList;
        }

        //GET EVENT LIST FROM DB
        #region //GET EVENT LIST FROM DB
        public static ArrayList getEventListSelection(string dateStringStart, string dateStringEnd, int userID)
        {
            //Console.WriteLine("dateStart=" + dateStringStart);
            //Console.WriteLine("dateEnd=" + dateStringEnd);
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            //string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            //string connStr = "server=127.0.0.1;user=root;database=corona;port=3306;password=;";
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM z_corona_event WHERE (date>=@myDateStart AND date<=@myDateEnd AND userID=@userID) OR (date>=@myDateStart AND date<=@myDateEnd AND isManagerEvent=1) ORDER BY date ASC, startTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDateStart", dateStringStart);
                cmd.Parameters.AddWithValue("@myDateEnd", dateStringEnd);
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
                Event newEvent = new Event();
                newEvent.eventID = (int)row["eventID"];  //Retrieve eventID to use for editing events... DB side is auto-increment...
                newEvent.userID = (int)row["userID"];  //Retrieve userID = for group project
                newEvent.title = row["title"].ToString();
                newEvent.date = (DateTime)row["date"];  //works
                newEvent.startTime = (TimeSpan)row["startTime"];
                newEvent.endTime = (TimeSpan)row["endTime"];
                newEvent.location = row["location"].ToString();
                newEvent.description = row["description"].ToString();
                newEvent.reminderTime = (TimeSpan)row["reminderTime"];

                newEvent.isManagerEvent = (int)row["isManagerEvent"];
                newEvent.attendees = row["attendees"].ToString();
                eventList.Add(newEvent);
            }
            return eventList;  //return the event list
        }

        public static ArrayList getEventListByMonth(string dateStringStart, int userID)
        {
            //Console.WriteLine("dateStart=" + dateStringStart);
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            //string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            //string connStr = "server=127.0.0.1;user=root;database=corona;port=3306;password=;";
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM z_corona_event WHERE userID=@userID AND date LIKE @myDateStart OR (date LIKE @myDateStart AND isManagerEvent=1) ORDER BY date ASC, startTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDateStart", dateStringStart);
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
                Event newEvent = new Event();
                newEvent.eventID = (int)row["eventID"];  //Retrieve eventID to use for editing events... DB side is auto-increment...
                newEvent.userID = (int)row["userID"];  //Retrieve userID = for group project
                newEvent.title = row["title"].ToString();
                newEvent.date = (DateTime)row["date"];  //works
                newEvent.startTime = (TimeSpan)row["startTime"];
                newEvent.endTime = (TimeSpan)row["endTime"];
                newEvent.location = row["location"].ToString();
                newEvent.description = row["description"].ToString();
                newEvent.reminderTime = (TimeSpan)row["reminderTime"];

                newEvent.isManagerEvent = (int)row["isManagerEvent"];
                newEvent.attendees = row["attendees"].ToString();
                eventList.Add(newEvent);
            }
            return eventList;  //return the event list
        }

        public int getEventID()
        {
            return eventID;
        }

        public int getUserID()
        {
            return userID;
        }

        public String getDate()
        {
            dateParsed = date.ToString("MM/dd");
            return dateParsed;
        }

        public String getTitle()
        {
            return title;
        }

        //[getFunction Conversions]
        //CONVERT MYSQL TimeSpan Format (24 HR) to 12HR String Format
        //https://stackoverflow.com/a/10126019  Edited
        #region CONVERT MYSQL 24 HR TimeSpan Format to 12HR String Format
        public String convertTimeSpanToString(TimeSpan timeValue)
        {
            var hours = timeValue.Hours;
            var minutes = timeValue.Minutes;
            var amPmDesignator = "AM";
            var timeValueParsed = "";
            if (hours == 0)
                hours = 12;
            else if (hours == 12)
                amPmDesignator = "PM";
            else if (hours > 12)
            {
                hours -= 12;
                amPmDesignator = "PM";
            }
            if (hours >= 10)
            {
                timeValueParsed = String.Format("{0}:{1:00} {2}", hours, minutes, amPmDesignator);
            }
            else if (hours < 10)
            {
                timeValueParsed = String.Format("{0}:{1:00} {2}", "0" + hours, minutes, amPmDesignator);
            }

            return timeValueParsed;
        }
        #endregion

        public String getStartTime()
        {
            startTimeParsed = convertTimeSpanToString(startTime);
            return startTimeParsed;
        }

        public String getEndTime()
        {
            endTimeParsed = convertTimeSpanToString(endTime);
            return endTimeParsed;
        }

        public String getLocation()
        {
            return location;
        }

        public String getDescription()
        {
            return description;
        }

        public String getReminderTime()
        {
            reminderTimeParsed = convertTimeSpanToString(reminderTime);
            return reminderTimeParsed;
        }

        public int getIsManagerEvent()
        {
            return isManagerEvent;
        }

        public String getAttendees()
        {
            return attendees;
        }

        
        #endregion

        //SEND FUNCTIONS
        #region //SEND FUNCTIONS
        //ADD EVENT TO DB
        #region //ADD EVENT TO DB
        //public void addEvent(int userID, string dateParsed, string title, string startTimeParsed, string endTimeParsed, string location, string description, string reminderTimeParsed)
        public void addEvent()
        {
            //Convert Time Vars
            //Console.WriteLine("Really string 1: " + startTimeParsed);
            //startTimeParsed = convertStringToTimeSpanFormat(startTimeParsed);
            //Console.WriteLine("Really string 2: " + startTimeParsed);
            //endTimeParsed = convertStringToTimeSpanFormat(endTimeParsed);
            //reminderTimeParsed = convertStringToTimeSpanFormat(reminderTimeParsed);

            //Console.WriteLine(userID);
            //Console.WriteLine("DATE SENT \n\n\n"+dateParsed);
            //Console.WriteLine(title);
            //Console.WriteLine(startTimeParsed);
            //Console.WriteLine(endTimeParsed);
            //Console.WriteLine(location);
            //Console.WriteLine(description);
            //Console.WriteLine(reminderTimeParsed);

            //Send SQL Query
            //string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            //string connStr = "server=127.0.0.1;user=root;database=corona;port=3306;password=;";
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //add/alter code for user ID after coding functional login
                string sql = "INSERT INTO z_corona_event (userID, date, title, startTime, endTime, location, description, reminderTime, attendees) VALUES (@userID, @dateParsed, @title, @startTimeParsed, @endTimeParsed, @location, @description, @reminderTimeParsed, @attendeeIDListString)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@dateParsed", dateParsed);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@startTimeParsed", startTimeParsed);
                cmd.Parameters.AddWithValue("@endTimeParsed", endTimeParsed);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@reminderTimeParsed", reminderTimeParsed);

                cmd.Parameters.AddWithValue("@attendeeIDListString", attendeeIDListString);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
        #endregion

        //EDIT EVENT IN DB
        #region //EDIT EVENT IN DB
        public void editEvent()
        {
            //Console.WriteLine(userID);
            //Console.WriteLine("EVENT ID EDITING " + eventID + "\n\n\n");
            //Console.WriteLine(dateParsed);
            //Console.WriteLine(title);
            //Console.WriteLine(startTimeParsed);
            //Console.WriteLine(endTimeParsed);
            //Console.WriteLine(location);
            //Console.WriteLine(description);
            //Console.WriteLine(reminderTimeParsed);

            //Send SQL Query
            //string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            //string connStr = "server=127.0.0.1;user=root;database=corona;port=3306;password=;";
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //add/alter code for user ID after coding functional login
                string sql = "UPDATE z_corona_event SET userID=@userID, title=@title, startTime=@startTimeParsed, endTime=@endTimeParsed, location=@location, description=@description, reminderTime=@reminderTimeParsed, attendees=@attendeeIDListString WHERE eventID=@eventID";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                //cmd.Parameters.AddWithValue("@dateParsed", dateParsed);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@startTimeParsed", startTimeParsed);
                cmd.Parameters.AddWithValue("@endTimeParsed", endTimeParsed);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@reminderTimeParsed", reminderTimeParsed);

                cmd.Parameters.AddWithValue("@attendeeIDListString", attendeeIDListString);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
        #endregion



        //[sendFunction Conversions]
        //CONVERT VSCODE C# DateTime -> MySQL TimeSpan
        #region //CONVERT VSCODE C# DateTime -> MySQL TimeSpan
        public String convertStringToTimeSpanFormat (String timeValue)
        {
            //NOTE: DEFAULT dateTimePicker data HAS leading 0's if hour is <= 10
            String hourString = timeValue.Substring(0, 2);
            int hours = Int32.Parse(hourString);
            String timeValueParsed = timeValue.Substring(2);

            //IF AM
            //Console.WriteLine("D: " + timeValueParsed + "  Length: " + timeValueParsed.Length);
            //FOR ADD EVENT
            if (timeValueParsed.Length == 9)
            {
                if (timeValueParsed[7] == 'A')
                {
                    if (hours == 12)
                    {
                        timeValueParsed = "00" + timeValueParsed;
                    }
                    else
                    {
                        if (hours >= 10)
                        {
                            timeValueParsed = hours + timeValueParsed;
                        }
                        if (hours < 10)
                        {
                            timeValueParsed = "0" + hours + timeValueParsed;
                        }
                    }
                }
                //IF PM
                if (timeValueParsed[7] == 'P')
                {

                    if (hours == 12)
                    {
                        timeValueParsed = "12" + timeValueParsed;
                    }
                    else
                    {
                        hours = hours + 12;
                        timeValueParsed = hours + timeValueParsed;
                    }
                }
                timeValueParsed = timeValueParsed.Substring(0, 8);
            }
            //FOR DELETE EVENT
            if (timeValueParsed.Length == 6)
            {
                if (timeValueParsed[4] == 'A')
                {
                    if (hours == 12)
                    {
                        timeValueParsed = "00" + timeValueParsed;
                    }
                    else
                    {
                        if (hours >= 10)
                        {
                            timeValueParsed = hours + timeValueParsed;
                        }
                        if (hours < 10)
                        {
                            timeValueParsed = "0" + hours + timeValueParsed;
                        }
                    }
                }
                //IF PM
                if (timeValueParsed[4] == 'P')
                {

                    if (hours == 12)
                    {
                        timeValueParsed = "12" + timeValueParsed;
                    }
                    else
                    {
                        hours = hours + 12;
                        timeValueParsed = hours + timeValueParsed;
                    }
                }
                timeValueParsed = timeValueParsed.Substring(0, 5);
                timeValueParsed = timeValueParsed + "%";
                //Console.WriteLine("TIME FOR DELETE:" + timeValueParsed + "\n\n\n\n\n");
            }
            //Console.WriteLine("NEW VALUE: " + timeValueParsed);
            return timeValueParsed;
        }
        #endregion



        #endregion


        //DELETE EVENT
        #region //DELETE EVENT
        public void deleteEvent()
        {
            //Console.WriteLine(userID);
            //Console.WriteLine(dateParsed);
            //Console.WriteLine(title);
            //Console.WriteLine(startTimeParsed);
            //Console.WriteLine(endTimeParsed);
            //Console.WriteLine(location);
            //Console.WriteLine(description);
            //Console.WriteLine(reminderTimeParsed);

            //Send SQL Query
            //string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            //string connStr = "server=127.0.0.1;user=root;database=corona;port=3306;password=;";
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //add/alter code for user ID after coding functional login
                string sql = "DELETE FROM z_corona_event WHERE (userID=@userID) AND (title=@title) AND (startTime LIKE @startTimeParsed) AND (endTime LIKE @endTimeParsed) AND (location=@location) AND (description=@description) AND (reminderTime LIKE @reminderTimeParsed)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                //cmd.Parameters.AddWithValue("@dateParsed", dateParsed);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@startTimeParsed", startTimeParsed);
                cmd.Parameters.AddWithValue("@endTimeParsed", endTimeParsed);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@reminderTimeParsed", reminderTimeParsed);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
        #endregion

    }
}
