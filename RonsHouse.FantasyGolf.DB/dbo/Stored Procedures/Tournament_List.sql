-- =============================================
-- Author:		RR
-- Create date: 04/23/2015
-- Description:	Gets a list of tournaments for a particular league
-- =============================================
CREATE PROCEDURE Tournament_List
	@LeagueId int
AS
BEGIN
	SET NOCOUNT ON;

	select
		t.*
	from Tournament t
	inner join LeagueTournament lt on lt.TournamentId = t.Id
	where
		lt.LeagueId = @LeagueId
	order by t.BeginsOn
END
