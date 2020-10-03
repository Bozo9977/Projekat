-- ================================================
-- Template generated from Template Explorer using:
-- Create Multi-Statement Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
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
CREATE FUNCTION [dbo].[GetKontrolnuTackuAndRadeForZaposleniAndKT]
(
	@idZaposlenog int,
	@idKontrolneTacke int
)
RETURNS 
@OutputTable TABLE 
(
	Id_kontrolne_tacke int, zadatak varchar(100), ocena smallint, UcenikId_ucenika int
)
AS
BEGIN
	insert into @OutputTable
	select Id_kontrolne_tacke, zadatak, ocena, UcenikId_ucenika from [Kontrolna_tacka] as KT
			inner join
			Rade as R on KT.Id_kontrolne_tacke = R.Kontrolna_tackaId_kontrolne_tacke
			where R.ZaposleniId_zaposlenog = @idZaposlenog and KT.Id_kontrolne_tacke = @idKontrolneTacke
			
	
	RETURN 
END
GO