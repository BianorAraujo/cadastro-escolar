--CREATE DATABASE ApiEscola;

USE ApiEscola;

--DROP TABLE UsuarioHistoricoEscolar
--DROP TABLE Usuario
--DROP TABLE HistoricoEscolar
--DROP TABLE Escolaridade

CREATE TABLE Escolaridade (
    IdEscolaridade INT IDENTITY(1,1) PRIMARY KEY,
    Escolaridade VARCHAR(40)
);

CREATE TABLE HistoricoEscolar (
    IdHistoricoEscolar INT IDENTITY(1,1) PRIMARY KEY,
    Formato VARCHAR(4),
    Nome VARCHAR(200)
);

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(20),
    Sobrenome VARCHAR(100),
    Email VARCHAR(50),
    DataNascimento DATETIME,
    IdEscolaridade INT FOREIGN KEY REFERENCES Escolaridade(IdEscolaridade)
);

CREATE TABLE UsuarioHistoricoEscolar (
    IdUsuarioHistoricoEscolar INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
    IdHistoricoEscolar INT FOREIGN KEY REFERENCES HistoricoEscolar(IdHistoricoEscolar)
);