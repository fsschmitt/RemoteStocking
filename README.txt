::::README::::

Project developed by:

Felipe de Souza Schmitt - 080509160
José Pedro Marques - 080509087

To run correctly this project you need:

1. Create in your system a MSMQ private queue named "stockbroker”.

2. Create the Database required options:
	2.1 Create the database manually

		2.1.1 Create a Database for Server: A database implemented in SQLServer 2010 Express and named 'ServerDB' must
		exist. The database should have a table named 'StockTransaction' with the following columns:

		NumTransaction(PK, int, not null)
		IDTransaction(nvarchar(50), not null)
		IDClient(int, not null)
		Email(nvarchar(50), not null)
		Quantity(int, not null)
		ShareType(nvarchar(50), not null)
		ActionType(bit, not null)
		TransactionTime(datetime, not null)
		Rate(float, not null)
		Executed(bit, not null)
		Currency(nvarchar(50), not null)


		2.1.2. Create a Database for StockBroker: A database implemented in SQLServer 2010 EXpress and named 'StockBrokerDB' must
		exist. The database should have a table named 'StockTransaction' with the following columns:

		NumTransaction(PK, int, not null)
		IDTransaction(nvarchar(50), not null)
		IDClient(int, not null)
		Email(nvarchar(50), not null)
		Quantity(int, not null)
		ShareType(nvarchar(50), not null)
		ActionType(bit, not null)
		TransactionTime(datetime, not null)
		Rate(float, not null)
		Executed(bit, not null)
		Currency(nvarchar(50), not null)

	2.2 Use the SQLServer 2010 Express restore database system using the files ServerDB and StockBrokerDB on the root of this folder.
		Note: If you are having problems restoring the databases, please try to set permissions as Administrator to all users.

NOTE: The pictures ServerDB.JPG and StockBroker.JPG demonstrate the final database structure on SQL Server.

3. At Server and StockBroker App.Config change the field "connectionString="Data Source=" to the correct server name of your computer.

4. Running options:

	4.1 Run without debugging the project at /RemoteStocking/RemoteStocking.sln with Visual Studio (RECOMMENDED due to web site deployment)

	4.2 Run separately:
		4.2.1 Run Server as Administrator at /RemoteStocking/Server/bin/Debug/Server.exe
		4.2.2 Run StockBroker as Administrator at /RemoteStocking/StockBroker/bin/Debug/StockBroker.exe
		4.2.3 Run Client as Administrator at /RemoteStocking/Client/bin/Debug/Client.exe
		4.2.4 Start Visual Studio, select WebSite project, right-click and select View in Browser (Ctrl+Shift +W) to create the ASP.NET Development Server and deploy the WebSite into it.