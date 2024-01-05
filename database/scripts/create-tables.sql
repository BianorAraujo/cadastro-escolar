USE ApiEscola;
GO

CREATE TABLE Escolaridade (
    IdEscolaridade INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Escolaridade VARCHAR(40) NOT NULL
);
GO

CREATE TABLE HistoricoEscolar (
    IdHistoricoEscolar INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Formato VARCHAR(4),
    Nome VARCHAR(200)
);
GO

CREATE TABLE Usuario (
    IdUsuario INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(20) NOT NULL,
    Sobrenome VARCHAR(100) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    DataNascimento DATETIME NOT NULL,
    IdEscolaridade INT FOREIGN KEY REFERENCES Escolaridade(IdEscolaridade)
);
GO

CREATE TABLE UsuarioHistoricoEscolar (
    IdUsuarioHistoricoEscolar INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
    IdHistoricoEscolar INT FOREIGN KEY REFERENCES HistoricoEscolar(IdHistoricoEscolar)
);
GO