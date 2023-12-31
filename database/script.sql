USE ApiEscola;

CREATE TABLE Escolaridade (
    IdEscolaridade INT NOT NULL PRIMARY KEY,
    Escolaridade VARCHAR(40)
);

CREATE TABLE HistoricoEscolar (
    IdHistoricoEscolar INT NOT NULL PRIMARY KEY,
    Formato VARCHAR(4),
    Nome VARCHAR(200)
);

CREATE TABLE Usuario (
    IdUsuario INT NOT NULL PRIMARY KEY,
    Nome VARCHAR(20),
    Sobrenome VARCHAR(100),
    Email VARCHAR(50),
    DataNascimento DATETIME,
    IdEscolaridade INT FOREIGN KEY REFERENCES Escolaridade(IdEscolaridade)
);

CREATE TABLE UsuarioHistoricoEscolar (
    IdUsuarioHistoricoEscolar INT NOT NULL PRIMARY KEY,
    IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
    IdHistoricoEscolar INT FOREIGN KEY REFERENCES HistoricoEscolar(IdHistoricoEscolar)
);