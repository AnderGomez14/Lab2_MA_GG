IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'InsertarTarea')
BEGIN
    DROP PROCEDURE InsertarTarea
END
GO
CREATE PROCEDURE InsertarTarea
(@descripcion NVARCHAR(50), @codasig NVARCHAR(50), @hestimadas INT, @explotacion BIT, @tipotarea NVARCHAR(50), @codigo NVARCHAR(50))
AS
BEGIN
    INSERT INTO TareasGenericas (codigo,descripcion,codAsig,hestimadas,explotacion,tipotarea) VALUES (@codigo,@descripcion,@codasig,@hestimadas,@explotacion,@tipotarea)
END
GO
