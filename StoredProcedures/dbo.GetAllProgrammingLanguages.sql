USE [ArtsofteTestProject]
GO

/****** Object: SqlProcedure [dbo].[GetAllProgrammingLanguages] Script Date: 26.12.2022, понедельник 13:36:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllProgrammingLanguages]
	@out_error_number INT = 0 OUTPUT
AS
BEGIN
BEGIN TRY
	Select * from ProgrammingLanguage
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
