-- =============================================
-- Author:		RR
-- Create date: 03/18/2015
-- Description:	Sets or updates a user's pick for a tournament
-- Change Log:
--		04/16/2015	RR	Added change log tracking
-- =============================================
CREATE PROCEDURE [dbo].[UserPick_Set]
	@TournamentId int,
	@UserId int,
	@GolferId int,
	@Override bit = 1
AS
BEGIN
	SET NOCOUNT ON;

    
    declare @BeginsOn datetime
    select @BeginsOn = BeginsOn from Tournament where Id = @TournamentId
    
    if @Override = 0 begin
		if getdate() > @BeginsOn begin
			raiserror('The tournament has already started, no picks can be set without an admin override.', 16, 1)
		end
    end
    
    if exists (select * from UserPick where UserId = @UserId and TournamentId = @TournamentId) begin
    
		update UserPick set
			GolferId = @GolferId,
			CreatedOn = getdate()
		where TournamentId = @TournamentId and UserId = @UserId
		
    end else begin
    
		insert into UserPick (TournamentId, UserId, GolferId)
		values (@TournamentId, @UserId, @GolferId)
    
    end
    
    insert into UserPickChangeLog (UserId, TournamentId, GolferId)
	values (@UserId, @TournamentId, @GolferId)
    
END
