using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace NawOpdracht
{
    internal class SearchPerson
    {

        public static void SelectPerson(int Id)             
        {
            using (SqlConnection newConnection = new SqlConnection("Server=MOFOMACHINERC\\TIBERIUSSERVSQL;Database=NawOpdracht;Trusted_Connection=True;ConnectRetryCount=3"))
            {
                SqlCommand selectCommand = new SqlCommand("SELECT Firstname, LastName, Age, Gender FROM Person WHERE Id = " + Id, newConnection);
                selectCommand.Connection.Open();
                SqlDataReader sqlReader;
                try
                {
                    sqlReader = selectCommand.ExecuteReader();
                    if (sqlReader.Read())
                    {
                        Console.WriteLine("FirstName : {0}", sqlReader.GetString(0));
                        Console.WriteLine("Lastname  : {0}", sqlReader.GetString(1));
                        Console.WriteLine("Age       : {0}", sqlReader.GetInt32(2).ToString());
                        Console.WriteLine("Gender    : {0}", sqlReader.GetString(3));                      
                       
                    }
                }
                catch
                {
                    Console.WriteLine("Error occurred while attempting SELECT.");
                }
                selectCommand.Connection.Close();

            }





        }








    }
}
