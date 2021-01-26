CREATE DATABASE AGENDA
USE AGENDA
CREATE TABLE Contacto(
ContactoId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
NombreContacto VARCHAR(30) NOT NULL,
TelefonoContacto VARCHAR(10),
TipoContacto SMALLINT NOT NULL,
SexoContacto SMALLINT NOT NULL,
ContactoActivo BIT NOT NULL
);

INSERT INTO Contacto VALUES ('Pedro','7471939212',1,1,0)

SELECT NombreContacto, TipoContacto FROM Contacto

ALTER PROCEDURE SP_CONTACTOS
@Opcion INT, @ContactoId INT = NULL, @NombreContacto VARCHAR(30) = NULL, @TelefonoContacto VARCHAR(10) = NULL, @TipoContacto SMALLINT = NULL, @Sexocontacto SMALLINT = NULL,
@ContactoActivo BIT = NULL
AS
BEGIN
	IF(@Opcion = 1)
	BEGIN
		SELECT * FROM Contacto
	END;
	IF(@Opcion = 2)
	BEGIN
		INSERT INTO Contacto(NombreContacto, TelefonoContacto,TipoContacto,SexoContacto,ContactoActivo) 
			VALUES(@NombreContacto, @TelefonoContacto, @TipoContacto, @Sexocontacto, @ContactoActivo)
	END;
	IF(@Opcion = 3)
	BEGIN
		UPDATE Contacto
		SET
		NombreContacto = @NombreContacto,
		TelefonoContacto =@TelefonoContacto,
		TipoContacto = @TipoContacto,
		SexoContacto = @Sexocontacto,
		ContactoActivo = @ContactoActivo
		WHERE
		ContactoId = @ContactoId
	END;
	IF (@Opcion = 4)
	BEGIN
		DELETE Contacto WHERE ContactoId = @ContactoId
	END;
END;
				

EXEC SP_CONTACTOS 1
EXEC SP_CONTACTOS 2,0,'Pedro','7471925741',0,0,1
EXEC SP_CONTACTOS 4,1