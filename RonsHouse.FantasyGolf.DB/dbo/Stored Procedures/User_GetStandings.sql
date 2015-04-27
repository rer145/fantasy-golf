-- =============================================
-- Author:		RR
-- Create date: 02/04/2015
-- Description:	Gets a user's standings
-- Change Log:
--		04/16/2015	RR	Added alias to Winnings column
--		04/23/2015	RR	Added option to select which league to get the standings
-- =============================================
CREATE PROCEDURE [dbo].[User_GetStandings]
	@LeagueId int
AS
BEGIN
	SET NOCOUNT ON;

    select
		u.FirstName, u.LastName,
		sum(tr.Winnings) as Winnings
    from [User] u 
    inner join LeagueUser lu on lu.UserId = u.Id
    inner join League l on l.Id = lu.LeagueId
    inner join UserPick up on up.UserID = u.ID
    inner join Tournament t on t.ID = up.TournamentID
    inner join LeagueTournament lt on lt.TournamentId = t.Id
    inner join Golfer g on g.ID = up.GolferID
    inner join TournamentResult tr on tr.TournamentID = t.ID and tr.GolferID = g.ID
    where
		l.Id = @LeagueId
		and lu.LeagueId = @LeagueId
		and lt.LeagueId = @LeagueId
    group by u.FirstName, u.LastName
    order by sum(tr.Winnings) desc
    
END
