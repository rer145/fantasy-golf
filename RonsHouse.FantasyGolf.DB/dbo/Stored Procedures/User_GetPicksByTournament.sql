-- =============================================
-- Author:		RR
-- Create date: 03/24/2015
-- Description:	Gets a list of the tournaments and the picks made by a user
-- Change Log:
--		04/16/2015	RR	Added Winnings
--		04/17/2015	RR	Added Place and other results
--		04/23/2015	RR	Filtered by LeagueId
--		04/24/2015	RR	Added Id fields for editing
-- =============================================
CREATE PROCEDURE [dbo].[User_GetPicksByTournament]
	@UserId int,
	@LeagueId int
AS
BEGIN
	SET NOCOUNT ON;

    select
		convert(varchar(10), t.BeginsOn, 101) + ' - ' + convert(varchar(10), t.EndsOn, 101) as [Dates],
		t.Name,
		ltrim(rtrim(isnull(g.FirstName,'') + ' ' + isnull(g.LastName,''))) as Pick,
		isnull(tr.Winnings,0) as Winnings,
		isnull(tr.Place,0) as Place,
		isnull(tr.IsTied,0) as IsTied,
		isnull(tr.IsCut,0) as IsCut,
		isnull(tr.IsWithdrawn,0) as IsWithdrawn,
		isnull(tr.IsPlayoff,0) as IsPlayoff,
		isnull(tr.IsDisqualified,0) as IsDisqualified,
		case 
			when isnull(tr.IsDisqualified,0) = 1 then 'DQ'
			when isnull(tr.IsWithdrawn,0) = 1 then 'WD'
			when isnull(tr.IsCut,0) = 1 then 'CUT'
			when isnull(tr.IsPlayoff,0) = 1 then 'P' + convert(varchar, isnull(tr.Place,0))
			when isnull(tr.IsTied,0) = 1 then 'T' + convert(varchar, isnull(tr.Place,0))
			else convert(varchar, isnull(tr.Place,0))
		end as PlaceDisplay,
		t.Id as TournamentId,
		up.UserId as UserId,
		g.Id as GolferId
    from Tournament t 
    inner join LeagueTournament lt on lt.TournamentId = t.Id and lt.LeagueId = @LeagueId
    left outer join UserPick up on up.TournamentId = t.Id and up.UserId = @UserId
    left outer join Golfer g on g.Id = up.GolferId
    left outer join TournamentResult tr on tr.GolferId = g.Id and tr.TournamentId = t.Id
	order by t.BeginsOn
END
