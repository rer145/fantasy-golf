-- =============================================
-- Author:		RR
-- Create date: 04/23/2015
-- Description:	Gets a list of users for a particular league
-- =============================================
CREATE PROCEDURE [dbo].[LeagueUser_List]
	@LeagueId int
AS
BEGIN
	SET NOCOUNT ON;

	select
		u.*,
		u.FirstName + ' ' + u.LastName as FullName,
		u.LastName + ', ' + u.FirstName as Name
	from [User] u
	inner join LeagueUser lu on lu.UserId = u.Id
	where
		lu.LeagueId = @LeagueId
		and lu.IsActive = 1
		and u.IsActive = 1
	order by u.LastName
END
