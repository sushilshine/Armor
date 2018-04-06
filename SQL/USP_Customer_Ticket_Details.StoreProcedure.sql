
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.USP_Customer_Ticket_Details'))
   exec('CREATE PROCEDURE [dbo].[USP_Customer_Ticket_Details] AS BEGIN SET NOCOUNT ON; END')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE USP_Customer_Ticket_Details 
	-- Add the parameters for the stored procedure here
	@FirstName VARCHAR (30), 
	@LastName VARCHAR (30),
	@EmailAddress VARCHAR(30),
	@Subject VARCHAR(200),
	@PriorityId int,
	@TicketDescription VARCHAR(200),
	@TicketStatus VARCHAR(200),
	@DateCaptured DATETIME
AS
BEGIN	
	DECLARE 	
	@AlertResponse VARCHAR(200),
	@CustomerId INT,
	@ResponseTime float

	DECLARE @OutputTbl TABLE (CustomerId INT)
	INSERT INTO Customer OUTPUT INSERTED.CustomerId INTO @OutputTbl(CustomerId) values(@FirstName,@LastName,@EmailAddress)
	select @CustomerId = CustomerId from @OutputTbl
	select @ResponseTime = ResponseTime from TicketPriority where PriorityId = @PriorityId		
	SET @AlertResponse = 'You will get response from Support by ' + Convert (varchar, DATEADD(HOUR,CAST(@ResponseTime as int),DATEADD(MINUTE,CAST(PARSENAME(Convert(Decimal(10,2), @ResponseTime),1) AS int),@DateCaptured)))
	INSERT INTO TicketJournal values(@CustomerId, @PriorityId, @Subject, @TicketDescription, @TicketStatus, @DateCaptured, @AlertResponse)
	SELECT @AlertResponse as AlertResponse
END
GO