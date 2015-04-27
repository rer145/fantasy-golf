-- =============================================
-- Author:		RR
-- Create date: 03/18/2015
-- Description:	Syncs a golfer from a remote source
-- =============================================
CREATE PROCEDURE Golfer_Sync
	@RemoteId uniqueidentifier,
	@FirstName varchar(50),
	@LastName varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

    if exists (select * from Golfer where SportsDataApiId = @RemoteId) begin
    
		update Golfer set 
			FirstName = @FirstName,
			LastName = @LastName
		where SportsDataApiId = @RemoteId
    
    end else begin
    
		insert into Golfer (FirstName, LastName, SportsDataApiId)
		values (@FirstName, @LastName, @RemoteId)
    
    end
END
