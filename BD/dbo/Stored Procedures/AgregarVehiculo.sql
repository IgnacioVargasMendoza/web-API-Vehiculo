-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AgregarVehiculo
    @Id AS uniqueidentifier,
    @IdModelo AS uniqueidentifier,
    @Placa AS varchar(max),
    @Color AS varchar(max),
    @Anio AS int,
    @Precio AS decimal(18,0),
    @CorreoPropietario AS varchar(max),
    @TelefonoPropietario AS varchar(max)
AS
BEGIN
    BEGIN TRANSACTION --Garantiza que ambas transacciones se ejecuten. Si una falla, la otra no se ejecuta. Insert y Select
    INSERT INTO Vehiculo
    (
        Id,
        IdModelo,
        Placa,
        Color,
        Anio,
        Precio,
        CorreoPropietario,
        TelefonoPropietario
    )
    VALUES
    (
        @Id,
        @IdModelo,
        @Placa,
        @Color,
        @Anio,
        @Precio,
        @CorreoPropietario,
        @TelefonoPropietario
    )
    SELECT @Id AS Id
    COMMIT TRANSACTION
END