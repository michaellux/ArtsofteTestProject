USE [ArtsofteTestProject]
GO

/****** Object: SqlProcedure [dbo].[InsertEmployeePlace] Script Date: 26.12.2022, понедельник 13:36:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertEmployeePlace]
@p_Id uniqueidentifier,
@p_EmployeeId uniqueidentifier,
@p_DepartmentId uniqueidentifier,
@p_ProgrammingLanguageId uniqueidentifier,
@out_error_number INT = 0 OUTPUT
AS
BEGIN
BEGIN TRY
	Insert into EmployeePlace (Id,EmployeeId,DepartmentId,ProgrammingLanguageId)
	values(@p_Id,@p_EmployeeId,@p_DepartmentId,@p_ProgrammingLanguageId)
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
