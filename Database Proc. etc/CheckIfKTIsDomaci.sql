-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
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
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION CheckIfKTIsDomaci
(
	-- Add the parameters for the function here
	@idKontrolneTacke int
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	-- Declare the return variable here
	--DECLARE @IsDomaci bit	
	
	RETURN (Select Id_kontrolne_tacke from Kontrolna_tacka_Domaci where Id_kontrolne_tacke = @idKontrolneTacke)
END
GO

