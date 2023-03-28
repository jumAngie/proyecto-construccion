								--- ***** Insumos ****** ----
GO
CREATE OR ALTER PROC Cons.UDP_tbInsumos_Insert
	@insm_Descripcion			NVARCHAR(200), 
	@unim_Id					INT, 
	@user_UsuCreacion			INT,
	@status						INT OUTPUT
AS
BEGIN

	BEGIN TRY
		INSERT INTO Cons.tbInsumos(insm_Descripcion, unim_Id, user_UsuCreacion)
		VALUES					  (@insm_Descripcion, @unim_Id,@user_UsuCreacion);
		SET @status = 1;
	END TRY
	BEGIN CATCH
		SET @status = 0;
	END CATCH;
END
GO
CREATE OR ALTER PROC Cons.UDP_tbInsumos_Update
	@insm_Id					INT,
	@insm_Descripcion			NVARCHAR(200), 
	@unim_Id					INT, 
	@user_UsuModificacion		INT,
	@status						INT OUTPUT
AS
BEGIN	
	BEGIN TRY
		UPDATE Cons.tbInsumos
		SET		insm_Descripcion = @insm_Descripcion,
				unim_Id = @unim_Id,
				user_UsuModificacion = @user_UsuModificacion
		WHERE	insm_Id = @insm_Id
		SET @status = 1;
	END TRY
	BEGIN CATCH
		SET @status = 0;
	END CATCH;
END

GO
CREATE OR ALTER PROC Cons.UDP_tbInsumos_Delete
	@insm_Id					INT,
	@user_UsuModificacion		INT,
	@status						INT OUTPUT
AS
BEGIN	

	BEGIN TRY
	   UPDATE Cons.tbInsumos
	   SET    user_Estado = 0,
			  user_UsuModificacion = @user_UsuModificacion
	   WHERE  insm_Id = @insm_Id
		SET @status = 1;
	END TRY
	BEGIN CATCH
		SET @status = 0;
	END CATCH;

END
GO

