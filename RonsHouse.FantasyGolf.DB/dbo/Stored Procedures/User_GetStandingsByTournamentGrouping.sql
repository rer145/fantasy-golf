-- =============================================
-- Author:		RR
-- Create date: 02/13/2015
-- Description:	Gets a user's standings for a league grouping
-- Change Log:
--		04/21/2015	RR	Added column alias
-- =============================================
CREATE PROCEDURE [dbo].[User_GetStandingsByTournamentGrouping]
	@TournamentGroupingID int
AS
BEGIN
	SET NOCOUNT ON;

    select
		u.FirstName, u.LastName,
		sum(tr.Winnings) as Winnings
    from [User] u 
    inner join UserPick up on up.UserID = u.ID
    inner join Tournament t on t.ID = up.TournamentID
    inner join LeagueTournamentGrouping ltg on ltg.TournamentID = t.ID
    inner join Golfer g on g.ID = up.GolferID
    inner join TournamentResult tr on tr.TournamentID = t.ID and tr.GolferID = g.ID
    where ltg.TournamentGroupingID = @TournamentGroupingID
    group by u.FirstName, u.LastName
    order by sum(tr.Winnings) desc
    
END
