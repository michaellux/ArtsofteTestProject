USE [ArtsofteTestProject]
GO

/****** Object: SqlProcedure [dbo].[UpdateEmployeePlace] Script Date: 26.12.2022, понедельник 13:37:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployeePlace]
@p_Id uniqueidentifier,
@p_EmployeeId uniqueidentifier,
@p_DepartmentId uniqueidentifier,
@p_ProgrammingLanguageId uniqueidentifier,
@out_error_number INT = 0 OUTPUT
AS
BEGIN
BEGIN TRY
	UPDATE [dbo].EmployeePlace SET Id=@p_Id,EmployeeId=@p_EmployeeId,DepartmentId=@p_DepartmentId,ProgrammingLanguageId=@p_ProgrammingLanguageId 
	WHERE Id=@p_Id
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
