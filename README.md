# Practice_Projects_Notes

### Overview of changes that where made to complete the assignment.

* 27-06-2022

		Instead of LocalDB i Changed the database to an already existing and empty server stored locally.
		(Named MOFOMACHINERC\\TIBERIUSSERVSQL)
    
		To use this solution on your own system change the appsettings.json back to the original server:
			(localdb)\mssqllocaldb
---

		Was recieving 
			"Inner Exception 1:
			SqlException: Invalid object name 'Naw.Address'." Error .
      
		Added { Database.EnsureCreated(); } to the dbContext constructor,
		in MainDbContext.cs this resolved the issue.    
        
---

* 28-06-2022

		Added Do-while loops te repeat several questions for string input.
    > Off the record request by CTO ^
    
		Added a method to check if input is a valid string   : StringCheck().
    
---

* 29-06-2022

		Made all user input to loop if input is incorrect.
    
		Moved all User input files to a seperate class to clean up Program.cs
    > Off the record request by CTO ^
    
		Added a class for Database query's
        
		Started to make Db query to retrieve a person.
    > Did have some trouble with using the existing variable for connection , made seperate SqlConnections for the query's
    
---

* 30-06-2-22

    Finished making methods and both query's to retrieve and change a Person in the Persons Table by ID
    > Had to change the connection string from 'Server' to 'Data Source' ^
    
    Returned the connectionstrings back to their original state (localDb)
    
    After some more testing , finished the assignment.
    
---
