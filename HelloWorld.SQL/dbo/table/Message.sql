/***************************************************************************************************
Author:			Bobby Augspurger
Create date:	12/18/2016
Description:	Store Messages.

Usage:			1. Hello World Coding Test
Changes:		MM/DD/YYYY Full Name. Change 1 description
****************************************************************************************************/
CREATE TABLE [dbo].[Message]
(
	MessageID INT NOT NULL IDENTITY(1,1),
	MessageString VARCHAR(128) NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT(0),
	CreatedDate DATETIME NOT NULL,
	ModifiedDate DATETIME NULL,
	CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
	(
		[MessageID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
