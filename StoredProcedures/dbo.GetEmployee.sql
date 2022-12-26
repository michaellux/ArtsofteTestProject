USE [ArtsofteTestProject]
GO

/****** Object: SqlProcedure [dbo].[GetEmployee] Script Date: 26.12.2022, понедельник 13:36:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployee]
    @p_Id uniqueidentifier,
	@out_error_number INT = 0 OUTPUT
AS
BEGIN
BEGIN TRY
	Select * from Employee 
    WHERE Id=(SELECT Id FROM Employee WHERE Id=@p_Id)
END TRY
BEGIN CATCH
	SELECT @out_error_number=ERROR_NUMBER()
END CATCH
END
