-- =============================================
-- Author:		RR
-- Create date: 04/21/2015
-- Description:	Adds or edits a golfer
-- Change Log:
--		04/23/2015	RR	Added field for TourId
-- =============================================
CREATE PROCEDURE [dbo].[Golfer_Save]
	@FirstName varchar(50),
	@LastName varchar(50),
	@TourId int
AS
BEGIN
	SET NOCOUNT ON;

    if not exists (select * from Golfer where FirstName = @FirstName and LastName = @LastName and TourId = @TourId) begin
    
		insert into Golfer (FirstName, LastName, TourId)
		values (@FirstName, @LastName, @TourId)
    
    end
END
