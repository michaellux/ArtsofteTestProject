USE [ArtsofteTestProject]
GO

/****** Object: SqlProcedure [dbo].[InsertEmployee] Script Date: 26.12.2022, понедельник 13:36:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertEmployee]
@p_Id uniqueidentifier,
@p_Name nvarchar(50),
@p_Surname nvarchar(50),
@p_Age int,
@p_Gender nvarchar(50),
@out_error_number INT = 0 OUTPUT
AS
BEGIN
BEGIN TRY
	Insert into Employee (Id,[Name],Surname,Age,Gender)
	values(@p_Id,@p_Name,@p_Surname,@p_Age,@p_Gender)
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
