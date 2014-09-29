using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Web;


namespace JFMVC.Utils
{


    public class DBConnectionManager
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnectionManager()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "jobfair";
            uid = "root";
            password = "Ningiza";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }



        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:

                        break;

                    case 1045:

                        break;
                }
                return false;
            }
        }



        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                string message = ex.ToString();
                return false;
            }
        }


        public void InsertRow()
        {
            string myInsertQuery = "INSERT INTO Employer (email, address, password, name, contactNumber) VALUES ('giza182@gmail', '111 joburg', '123456789', 'sello', '0113332256')";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
            myCommand.Connection = connection;
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
        }
    }


}