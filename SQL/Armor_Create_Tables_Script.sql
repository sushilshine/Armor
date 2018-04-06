
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customer' AND xtype='U')
BEGIN
	CREATE TABLE Customer (
		CustomerId int NOT NULL PRIMARY KEY IDENTITY(1,1),
		FirstName varchar(30) NOT NULL,
		LastName varchar(30) NOT NULL,
		EmailAddress varchar(30) NOT NULL
	);
END
GO

------------------------------------------------------------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TicketPriority' AND xtype='U')
BEGIN
	CREATE TABLE TicketPriority (
		PriorityId int NOT NULL PRIMARY KEY,
		PriorityType varchar(30) NOT NULL,
		ResponseTime float NOT NULL		
	);
	insert into TicketPriority values(1,'High', 4)
	insert into TicketPriority values(2,'Medium', 24)
	insert into TicketPriority values(3,'Low', 48)
END
GO

-------------------------------------------------------------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TicketJournal' AND xtype='U')
BEGIN
	CREATE TABLE TicketJournal (		
		TicketId int NOT NULL PRIMARY KEY IDENTITY(1,1),
		CustomerId int NOT NULL FOREIGN KEY(CustomerId) REFERENCES Customer(CustomerId),
		PriorityId int FOREIGN KEY(PriorityId) REFERENCES TicketPriority(PriorityId),
		TicketSubject VARCHAR(255) NOT NULL,
		TicketDescription varchar(255) NOT NULL,
		TicketStatus varchar(30),
		DateCaptured Datetime NOT NULL,
		AlertResponse varchar(255)
	);
END
GO

------------------------------------------------------------------------------------------------------------------------