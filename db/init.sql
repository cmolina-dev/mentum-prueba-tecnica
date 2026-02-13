-- Crear la base de datos
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MentumDB')
BEGIN
    CREATE DATABASE MentumDB;
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Clientes')
BEGIN
    CREATE TABLE Clientes (
        Id INT PRIMARY KEY IDENTITY(1,1),
        NombreCompleto NVARCHAR(200) NOT NULL,
        Direccion NVARCHAR(500) NOT NULL,
        Telefono NVARCHAR(20) NOT NULL,
        FechaCreacion DATETIME2 NOT NULL DEFAULT GETDATE()
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Contactos')
BEGIN
    CREATE TABLE Contactos (
        Id INT PRIMARY KEY IDENTITY(1,1),
        NombreCompleto NVARCHAR(200) NOT NULL,
        Direccion NVARCHAR(500) NOT NULL,
        Telefono NVARCHAR(20) NOT NULL,
        ClienteId INT NOT NULL,
        CONSTRAINT FK_Contactos_Clientes FOREIGN KEY (ClienteId) 
            REFERENCES Clientes(Id) ON DELETE CASCADE
    );
END


-- Insertar datos de prueba
IF NOT EXISTS (SELECT * FROM Clientes)
BEGIN
    -- Insertar clientes de prueba
    INSERT INTO Clientes (NombreCompleto, Direccion, Telefono, FechaCreacion)
    VALUES 
        ('Juan Pérez', 'Calle 123 #45-67', '3001234567', DATEADD(DAY, -30, GETDATE())),
        ('María García', 'Carrera 45 #12-34', '3009876543', DATEADD(DAY, -25, GETDATE())),
        ('Carlos Rodríguez', 'Avenida 68 #23-45', '3005551234', DATEADD(DAY, -20, GETDATE())),
        ('Ana Martínez', 'Calle 50 #34-56', '3007778888', DATEADD(DAY, -15, GETDATE())),
        ('Luis Hernández', 'Carrera 7 #89-12', '3002223333', DATEADD(DAY, -10, GETDATE()));

    -- Insertar contactos de prueba
    INSERT INTO Contactos (NombreCompleto, Direccion, Telefono, ClienteId)
    VALUES 
        -- Contactos para Juan Pérez (ClienteId = 1)
        ('Carlos Pérez', 'Calle 123 #45-67', '3001111111', 1),
        ('Carmen Pérez', 'Calle 123 #45-67', '3002222222', 1),
        
        -- Contactos para María García (ClienteId = 2)
        ('Carlos García', 'Carrera 45 #12-34', '3003333333', 2),
        
        -- Contactos para Carlos Rodríguez (ClienteId = 3)
        ('Carlota Rodríguez', 'Avenida 68 #23-45', '3004444444', 3),
        ('Carolina Rodríguez', 'Avenida 68 #23-45', '3005555555', 3),
        ('Carla Rodríguez', 'Avenida 68 #23-45', '3006666666', 3),        
        ('Pedro Martínez', 'Calle 50 #34-56', '3007777777', 4);
    
END
