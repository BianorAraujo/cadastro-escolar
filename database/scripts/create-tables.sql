IF NOT EXISTS (SELECT * FROM master.sys.databases WHERE name = N'ApiEscola')
BEGIN
    CREATE DATABASE ApiEscola;
END
GO


USE ApiEscola;
GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'Escolaridade')
BEGIN    
    CREATE TABLE Escolaridade (
    IdEscolaridade INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Escolaridade VARCHAR(40) NOT NULL
);
END
GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'HistoricoEscolar')
BEGIN 
    CREATE TABLE HistoricoEscolar (
        IdHistoricoEscolar INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Formato VARCHAR(4),
        Nome VARCHAR(200)
    );
END
GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'Usuario')
BEGIN 
    CREATE TABLE Usuario (
        IdUsuario INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Nome VARCHAR(20) NOT NULL,
        Sobrenome VARCHAR(100) NOT NULL,
        Email VARCHAR(50) NOT NULL,
        DataNascimento DATETIME NOT NULL,
        IdEscolaridade INT FOREIGN KEY REFERENCES Escolaridade(IdEscolaridade)
    );
END
GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'UsuarioHistoricoEscolar')
BEGIN 
    CREATE TABLE UsuarioHistoricoEscolar (
        IdUsuarioHistoricoEscolar INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
        IdHistoricoEscolar INT FOREIGN KEY REFERENCES HistoricoEscolar(IdHistoricoEscolar)
    );
END
GO