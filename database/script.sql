USE master;

CREATE TABLE Escolaridade (
    IdEscolaridade INT, --(chave primária)
    Escolaridade VARCHAR(40)

);

CREATE TABLE HistoricoEscolar (
    IdHistoricoEscolar INT, --(chave primária)
    Formato VARCHAR(4),
    Nome VARCHAR(200)
);

CREATE TABLE Usuario (
    IdUsuario INT, --(chave primária)
    Nome VARCHAR(20),
    Sobrenome VARCHAR(100),
    Email VARCHAR(50),
    DataNascimento DATETIME,
    IdEscolaridade INT --(chave estrangeira para a tabela Escolaridade)
);

CREATE TABLE UsuarioHistoricoEscolar (
    IdUsuarioHistoricoEscolar INT, --(chave primária)
    IdUsuario INT, --(chave estrangeira para a tabela Usuario)
    IdHistoricoEscolar INT --(chave estrangeira para a tabela HistoricoEscolar)
);
