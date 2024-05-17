SQL Server 2012 and Microsoft Visual Studio 2019 were used to build the application.

*** Database Instructions ***
- Create an empty database in SQL Server instance called "InventoryDB".
- Change connection string inside Web.config file to your local SQL Server instance targeting the last database created.
- Run the following commands in Package Manager Console:
	* Enable-Migrations
	* Add-Migration Initial
	* Update-Database
- Once migration is created, go to SSMS, select "InventoryDB" database, expand "Tables", expand "Purchase", expand "Keys", double click foreign key and select "Modify", finally in "Table Designer" section modify "INSERT and UPDATE specification" delete rule to "Cascade".
- Do the same last instruction with "Sale" table foreign key.