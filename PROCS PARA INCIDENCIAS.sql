CREATE OR ALTER PROC Cons.UDP_tbIncidencias_Insert
		@cons_Id INT,
		@inci_Descripcion NVARCHAR(MAX),
		@user_UsuCreacion INT,
		@status						INT OUTPUT
AS
BEGIN
BEGIN TRY
	INSERT INTO Cons.tbIncidencia(cons_Id, inci_Descripcion, user_UsuCreacion)
	VALUES  (@cons_Id, @inci_Descripcion, @user_UsuCreacion);
	SET @status = 1;
END TRY
BEGIN CATCH
	SET @status = 0;
END CATCH;
END

GO
CREATE OR ALTER PROC Cons.UDP_tbIncidencias_Update
		@inci_Id	INT,
		@inci_Descripcion NVARCHAR(MAX),
		@user_UsuModificacion INT,
		@status						INT OUTPUT
AS
BEGIN
BEGIN TRY
	UPDATE Cons.tbIncidencia
		SET inci_Descripcion = @inci_Descripcion,
			user_UsuModificacion = @user_UsuModificacion,
			inci_FechaModificacion = GETDATE()
	WHERE	inci_Id = @inci_Id
	SET @status = 1;
END TRY
BEGIN CATCH
	SET @status = 0;
END CATCH;
END

go

CREATE OR ALTER PROC Gral.UDP_tbIncidencias_Delete
	@inci_Id					INT,
	@user_UsuModificacion		INT,
	@status						INT OUTPUT
AS
BEGIN	

	BEGIN TRY
	   UPDATE Cons.tbIncidencia
	   SET    user_Estado = 0,
			  user_UsuModificacion = @user_UsuModificacion,
			  inci_FechaModificacion = GETDATE()
	   WHERE  inci_Id = @inci_Id
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
	@user_UsuModificacion		INT,
	@status						INT OUTPUT
AS
BEGIN	
	BEGIN TRY
		UPDATE Cons.tbInsumos
		SET		insm_Descripcion = @insm_Descripcion,
				user_UsuModificacion = @user_UsuModificacion
		WHERE	insm_Id = @insm_Id
		SET @status = 1;
	END TRY
	BEGIN CATCH
		SET @status = 0;
	END CATCH;
END
