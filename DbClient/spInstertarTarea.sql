IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'InsertarTarea')
BEGIN
    DROP PROCEDURE InsertarTarea
END
GO
CREATE PROCEDURE InsertarTarea
(
  -- Parametros
  @pUserId int,
  @pUserName varchar(50)
)
AS
BEGIN
 SELECT @pUserId,@pUserName
END
GO