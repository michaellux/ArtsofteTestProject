USE [ArtsofteTestProject]
GO

/****** Object: SqlProcedure [dbo].[DeleteEmployeePlace] Script Date: 26.12.2022, понедельник 13:35:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteEmployeePlace]
    @p_Id uniqueidentifier,
	@out_error_number INT = 0 OUTPUT
AS
BEGIN
BEGIN TRY
	Delete from EmployeePlace
    WHERE Id=(SELECT Id FROM EmployeePlace WHERE Id=@p_Id)
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
