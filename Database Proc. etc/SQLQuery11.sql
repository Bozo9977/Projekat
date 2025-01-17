USE [OsnovnaSkola]
GO
/****** Object:  UserDefinedFunction [dbo].[GetKontrolnuTackuAndRadeForZaposleniAndKT]    Script Date: 15-Jun-20 12:16:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[GetKontrolnuTackuAndRadeForZaposleniAndKontrolnaTacka]
(
	@idZaposlenog int,
	@idKontrolneTacke int
)
RETURNS 
@OutputTable TABLE 
(
	Id_kontrolne_tacke int, zadatak varchar(100), ocena smallint, UcenikId_ucenika int, ZaposleniId_zaposlenog int
)
AS
BEGIN
	insert into @OutputTable
	select Id_kontrolne_tacke, zadatak, ocena, UcenikId_ucenika, R.ZaposleniId_zaposlenog from [Kontrolna_tacka] as KT
			inner join
			Rade as R on KT.Id_kontrolne_tacke = R.Kontrolna_tackaId_kontrolne_tacke
			where R.ZaposleniId_zaposlenog = @idZaposlenog and KT.Id_kontrolne_tacke = @idKontrolneTacke
			
	
	RETURN 
END
