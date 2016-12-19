/***************************************************************************************************
Author:			Bobby Augspurger
Create date:	12/18/2016
Description:	Get string message stored in table.

Usage:			1. Hello World Coding Test
Changes:		MM/DD/YYYY Full Name. Change 1 description
****************************************************************************************************/
CREATE PROCEDURE [dbo].[MessageGet](
	@IsDeleted BIT = NULL,
	@MessageID INT = NULL
)
AS
	SELECT 
		MessageID,
		MessageString,
		IsDeleted,
		CreatedDate,
		ModifiedDate
	FROM
		dbo.[Message]
	WHERE
		((@MessageID is null) OR (MessageID = @MessageID))
		AND ((@IsDeleted is null) OR (IsDeleted = @IsDeleted))
GO