-- =============================================
-- Author:		RR
-- Create date: 04/23/2015
-- Description:	Gets the tournament groupings for a league
-- =============================================
CREATE PROCEDURE TournamentGrouping_List
	@LeagueId int
AS
BEGIN
	SET NOCOUNT ON;

	select *
	from TournamentGrouping
	where
		LeagueId = @LeagueId
		and IsActive = 1
	order by DisplayOrder
END
