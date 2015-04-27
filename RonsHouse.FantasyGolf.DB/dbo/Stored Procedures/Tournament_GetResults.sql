-- =============================================
-- Author:		RR
-- Create date: 04/16/2015
-- Description:	Gets the results for a tournament by golfer
-- =============================================
CREATE PROCEDURE [dbo].[Tournament_GetResults]
	@TournamentId int
AS
BEGIN
	
	select
		g.FirstName,
		g.LastName,
		tr.Winnings,
		tr.Place,
		tr.IsTied,
		tr.IsWithdrawn,
		tr.IsCut,
		tr.IsDisqualified,
		case 
			when tr.IsDisqualified = 1 then 'DQ'
			when tr.IsWithdrawn = 1 then 'WD'
			when tr.IsCut = 1 then 'CUT'
			when tr.IsPlayoff = 1 then 'P' + convert(varchar, tr.Place)
			when tr.IsTied = 1 then 'T' + convert(varchar, tr.Place)
			else convert(varchar, tr.Place)
		end as PlaceDisplay
	from TournamentResult tr
	inner join Golfer g on g.Id = tr.GolferId
	where
		tr.TournamentId = @TournamentId
	order by tr.Winnings desc, g.LastName, g.FirstName
	
END
