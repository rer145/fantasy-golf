-- =============================================
-- Author:		RR
-- Create date: 02/09/2015
-- Description:	Gets a user's standings for a tournament
-- =============================================
CREATE PROCEDURE [dbo].[User_GetStandingsByTournament]
	@TournamentID int
AS
BEGIN
	SET NOCOUNT ON;

    select
		u.FirstName, u.LastName,
		sum(tr.Winnings)
    from [User] u 
    inner join UserPick up on up.UserID = u.ID
    inner join Tournament t on t.ID = up.TournamentID
    inner join Golfer g on g.ID = up.GolferID
    inner join TournamentResult tr on tr.TournamentID = t.ID and tr.GolferID = g.ID
    where up.TournamentID = @TournamentID
    group by u.FirstName, u.LastName
    order by sum(tr.Winnings) desc
    
END
