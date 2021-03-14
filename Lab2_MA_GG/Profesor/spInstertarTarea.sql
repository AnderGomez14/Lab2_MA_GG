IF EXISTS(SELECT 1 FROM sys.procedures WHERE Name = 'InsertarTarea')
BEGIN
    DROP PROCEDURE InsertarTarea
END
GO
CREATE PROCEDURE InsertarTarea
(
  @Codigo nvarchar(50),
  @Descripcion nvarchar(50),
  @CodAsig nvarchar(50),
  @HEstimadas int,
  @Explotacion bit,
  @TipoTarea nvarchar(50)
)
AS
BEGIN
    INSERT INTO TareasGenericas (Codigo,Descripcion,CodAsig,HEstimadas,Explotacion,TipoTarea) VALUES (@Codigo,@Descripcion,@CodAsig,@HEstimadas,@Explotacion,@TipoTarea)
END
GO