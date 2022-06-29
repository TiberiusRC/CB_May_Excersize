using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NawOpdracht.Data;
using NawOpdracht.Data.DataObjects;
using NawOpdracht.services;
using Newtonsoft.Json;
using System.Data.SqlClient;


namespace NawOpdracht
{
    internal class Program
    {
        static void Main(string[] args)

        {   //Opens console ta ask for user input.
            // CollectInfo.InfoConsole();

            // Select a person from Db by ID.
            Console.Write("Enter Person ID to see the details: ");
            SearchPerson.SelectPerson(int.Parse(Console.ReadLine()));

            //Edit a persons age.

            
            
        }      
              
    }
}
