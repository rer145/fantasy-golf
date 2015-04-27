-- =============================================
-- Author:		RR
-- Create date: 04/16/2015
-- Description:	Sets or updates a tournament result record
-- =============================================
CREATE PROCEDURE [dbo].[TournamentResult_Set]
	@TournamentId int,
	@GolferId int,
	@Place int = 0,
	@Winnings money = 0,
	@IsCut bit = 0,
	@IsTied bit = 0,
	@IsWithdrawn bit = 0,
	@IsDisqualified bit = 0,
	@IsPlayoff bit = 0
AS
BEGIN
	SET NOCOUNT ON;

    
    if exists (select * from TournamentResult where GolferId = @GolferId and TournamentId = @TournamentId) begin
    
		update TournamentResult set
			TournamentId = @TournamentId,
			GolferId = @GolferId,
			Place = @Place,
			Winnings = @Winnings,
			IsCut = @IsCut,
			IsTied = @IsTied,
			IsWithdrawn = @IsWithdrawn,
			IsDisqualified = @IsDisqualified,
			IsPlayoff = @IsPlayoff
		where TournamentId = @TournamentId and GolferId = @GolferId
    
    end else begin
    
		insert into TournamentResult (TournamentId, GolferId, Place, Winnings, IsCut, IsTied, IsWithdrawn, IsDisqualified, IsPlayoff)
		values (@TournamentId, @GolferId, @Place, @Winnings, @IsCut, @IsTied, @IsWithdrawn, @IsDisqualified, @IsPlayoff)
    
    end
    
END
