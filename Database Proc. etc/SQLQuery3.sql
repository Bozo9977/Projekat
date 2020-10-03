-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DodajKontrolnuTackuUceniku] @idUcenika int,
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
		update Rade
		set Kontrolna_tackaId_kontrolne_tacke = @idKontrolneTacke,
			ZaposleniId_zaposlenog = @idZaposlenog,
			UcenikId_ucenika = @idUcenika,
			ocena = @ocena
		set @success = 1;
	END

	--SET NOCOUNT ON;

GO
