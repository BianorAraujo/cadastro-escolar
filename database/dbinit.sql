IF NOT EXISTS (SELECT * FROM master.sys.databases WHERE name = N'ApiEscola')
BEGIN
    CREATE DATABASE ApiEscola;

    PRINT 'Database ApiEscola criada.'
END
ELSE
BEGIN
    PRINT 'Database ApiEscola já existe!'
END
GO


USE ApiEscola;
GO

IF EXISTS (SELECT * FROM SYS.objects WHERE name = 'Escolaridade')
BEGIN    
    DELETE Escolaridade

    PRINT 'Limpando a tabela Escolaridade...'
END
ELSE
BEGIN
    CREATE TABLE Escolaridade (
        IdEscolaridade INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Escolaridade VARCHAR(40) NOT NULL
    );

    PRINT 'Tabela Escolaridade criada.'
END
GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'HistoricoEscolar')
BEGIN 
    CREATE TABLE HistoricoEscolar (
        IdHistoricoEscolar INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        Formato VARCHAR(4),
        Nome VARCHAR(200)
    );

    PRINT 'Tabela HistoricoEscolar criada.'
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

    PRINT 'Tabela Usuario criada.'
END
GO

IF NOT EXISTS (SELECT * FROM SYS.objects WHERE name = 'UsuarioHistoricoEscolar')
BEGIN 
    CREATE TABLE UsuarioHistoricoEscolar (
        IdUsuarioHistoricoEscolar INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
        IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
        IdHistoricoEscolar INT FOREIGN KEY REFERENCES HistoricoEscolar(IdHistoricoEscolar)
    );

    PRINT 'Tabela UsuarioHistoricoEscolar criada.'
END
GO

BEGIN
    INSERT INTO Escolaridade (Escolaridade) VALUES 
    ('Infantil'),
    ('Fundamental'),
    ('Médio'),
    ('Superior')

    PRINT 'Registros inseridos na Tabela Escolaridade.'
END
GO