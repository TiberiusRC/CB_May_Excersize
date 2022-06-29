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


namespace NawOpdracht
{
    internal class Program
    {
        static void Main(string[] args)

        {   //Opens console ta ask for user input.
            CollectInfo.InfoConsole();

            
            
        }      
              
    }
}
