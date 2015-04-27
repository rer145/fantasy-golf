-- =============================================
-- Author:		RR
-- Create date: 02/05/2014
-- Description:	Displays the user's picks for a tournament
-- Change Log:
--		04/16/2015	RR	Added fields for full name
--		04/23/2015	RR	Filtered out users who didn't participant in that league
-- =============================================
CREATE PROCEDURE [dbo].[UserPick_GetByTournament]
	@TournamentID int
AS
BEGIN
	SET NOCOUNT ON;

	select
		u.FirstName,
		u.LastName,
		g.FirstName,
		g.LastName,
		u.FirstName + ' ' + u.LastName as UserName,
		g.FirstName + ' ' + g.LastName as GolferName
	from [User] u 
	inner join LeagueUser lu on lu.UserId = u.Id
	inner join LeagueTournament lt on lu.LeagueId = lt.LeagueId and lt.TournamentId = @TournamentId
	left outer join UserPick up on up.UserID = u.ID and up.TournamentID = @TournamentID
	left outer join Golfer g on g.ID = up.GolferID
	order by u.LastName, u.FirstName
END
