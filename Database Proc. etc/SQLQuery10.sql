USE [OsnovnaSkola]
GO
/****** Object:  StoredProcedure [dbo].[DodajKontrolnuTackuUceniku]    Script Date: 14-Jun-20 11:43:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DodajKontrolnuTackuUceniku] @idUcenika int,
													@idZaposlenog int,
													@idKontrolneTacke int,
													@ocena smallint,
													@success bit output
	-- Add the parameters for the stored procedure here
	
AS
	Set @success = 0;
	if not exists (Select * from Rade where UcenikId_ucenika = @idUcenika 
										and ZaposleniId_zaposlenog = @idZaposlenog
										and Kontrolna_tackaId_kontrolne_tacke = @idKontrolneTacke)
	BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
		insert into Rade (Kontrolna_tackaId_kontrolne_tacke,
							ZaposleniId_zaposlenog,
							UcenikId_ucenika,
							ocena)
					Values (@idKontrolneTacke,
							@idZaposlenog,
							@idUcenika,
							@ocena);
		set @success = 1;
	END ELSE
	
	BEGIN
		
		set @success = 1;
	END

	--SET NOCOUNT ON;

