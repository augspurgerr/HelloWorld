CREATE PROCEDURE [dbo].[MessageInsert] (
	@MessageString VARCHAR(128),
	@CreatedDate DATETIME
)
AS
	INSERT INTO 
		dbo.[Message] (MessageString, CreatedDate)
	VALUES 
		(@MessageString, @CreatedDate);

	SELECT SCOPE_IDENTITY()
GO


	