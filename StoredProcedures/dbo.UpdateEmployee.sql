USE [ArtsofteTestProject]
GO

/****** Object: SqlProcedure [dbo].[UpdateEmployee] Script Date: 26.12.2022, понедельник 13:36:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[UpdateEmployee]
@p_Id uniqueidentifier,
@p_Name nvarchar(50),
@p_Surname nvarchar(50),
@p_Age int,
@p_Gender nvarchar(50) ,
@out_error_number INT = 0 OUTPUT
AS
BEGIN
BEGIN TRY
	UPDATE [dbo].Employee SET Id=@p_Id,[Name]=@p_Name,Surname=@p_Surname,Age=@p_Age,Gender=@p_Gender 
	WHERE Id=@p_Id
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
