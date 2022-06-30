using System; 
using System.Data.SqlClient;
 

namespace NawOpdracht
{
    internal class SearchPerson
    {
        //Method to show a Person by ID
        public static void SelectPerson(int Id)             
        {
            using (SqlConnection newConnection = new SqlConnection("Data Source=MOFOMACHINERC\\TIBERIUSSERVSQL;Database=NawOpdracht;Trusted_Connection=True;ConnectRetryCount=3"))
            {
                SqlCommand selectCommand = new SqlCommand("SELECT Firstname, LastName, Age, Gender FROM Naw.Person WHERE Id = " + Id, newConnection);
                selectCommand.Connection.Open();
                SqlDataReader sqlReader;
                try
                {
                    sqlReader = selectCommand.ExecuteReader();
                    if (sqlReader.Read())
                    {
                        Console.WriteLine();
                        Console.WriteLine($"FirstName : {sqlReader.GetString(0)}");
                        Console.WriteLine($"Lastname  : {sqlReader.GetString(1)}");
                        Console.WriteLine($"Age       : {sqlReader.GetInt32(2).ToString()}");
                        Console.WriteLine($"Gender    : {sqlReader.GetString(3)}");
                        Console.WriteLine();

                    }
                }
                catch
                {                    
                    Console.WriteLine("Error occurred while attempting SELECT from Table");
                }
                selectCommand.Connection.Close();

            }         
       
        }
        //Method to change a Persons Age by ID
        public static void UpdatePersonAge(int Id,int Age)
        {
            using (SqlConnection newConnection = new SqlConnection("Data Source=MOFOMACHINERC\\TIBERIUSSERVSQL;Database=NawOpdracht;Trusted_Connection=True;ConnectRetryCount=3"))
            {
                SqlCommand selectCommand = new SqlCommand($"UPDATE Naw.Person SET Age ={+Age} WHERE Id = {+Id}", newConnection);
                selectCommand.Connection.Open();
                Console.WriteLine();
                Console.WriteLine($"New age is {Age}!");
                Console.WriteLine();
                SqlDataReader sqlReader;
                sqlReader = selectCommand.ExecuteReader();                

                selectCommand.Connection.Close();

            }
        }

    }
}
