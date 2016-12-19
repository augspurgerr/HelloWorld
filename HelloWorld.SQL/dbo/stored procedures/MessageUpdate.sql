CREATE PROCEDURE [dbo].[MessageUpdate] (
	@MessageID INT,
	@MessageString VARCHAR(128),
	@IsDeleted BIT,
	@ModifiedDate DATETIME
)
AS
	UPDATE dbo.[Message]
	SET
		MessageString = @MessageString,
		IsDeleted = @IsDeleted,
		ModifiedDate = @ModifiedDate
	WHERE
		MessageID = @MessageID
GO