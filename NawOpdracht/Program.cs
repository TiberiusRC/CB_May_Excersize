using System;



namespace NawOpdracht
{
    internal class Program
    {
        static void Main(string[] args)

        {   //Opens the console to ask for user input.
            CollectInfo.InfoConsole();

            // Select a person from Db by ID.
            Console.Write("Enter Person ID to see the details: ");
            SearchPerson.SelectPerson(int.Parse(Console.ReadLine()));

            //Edit a persons age by ID.
            Console.WriteLine("To change Person age , enter ID number followed by new Age: ");
            SearchPerson.UpdatePersonAge(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            // Select a person from Db by ID.
            Console.Write("Enter Person ID to see the details: ");
            SearchPerson.SelectPerson(int.Parse(Console.ReadLine()));


        }
       

    }
}
