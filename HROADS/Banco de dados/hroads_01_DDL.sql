CREATE DATABASE SENAI_HROADS_MANHA;
GO

USE SENAI_HROADS_MANHA;
GO

CREATE TABLE TiposDeHabilidades
(
	IdTipo	INT PRIMARY KEY IDENTITY,
	Nome	VARCHAR(150) NOT NULL
);
GO

CREATE TABLE Habilidades
(
	IdHabilidade	INT PRIMARY KEY IDENTITY,
	IdTipo			INT FOREIGN KEY REFERENCES TiposDeHabilidades (IdTipo),
	Nome			VARCHAR(150) NOT NULL
);
GO

CREATE TABLE Classes
(
	IdClasse	INT PRIMARY KEY IDENTITY,
	Nome		VARCHAR(150) NOT NULL
);
GO

CREATE TABLE ClasseHabilidades
(
	IdClasse		INT FOREIGN KEY REFERENCES Classes (IdClasse),
	IdHabilidade	INT FOREIGN KEY REFERENCES Habilidades (IdHabilidade)
);
GO

CREATE TABLE Personagens
(
	IdPersonagem		INT PRIMARY KEY IDENTITY,
	IdClasse			INT FOREIGN KEY REFERENCES Classes (IdClasse),
	Nome				VARCHAR(150) NOT NULL,
	Vida				INT NOT NULL,
	Mana				INT NOT NULL,
	DataDeAtualizacao	DATE NOT NULL,
	DataDeCriacao		DATE NOT NULL
);
GO

CREATE TABLE TiposUsuarios
(
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	Tipo			VARCHAR(150)NOT NULL
);
GO

CREATE TABLE Usuarios
(
	IdUsuario		INT PRIMARY KEY IDENTITY,
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipoUsuario),
	IdPersonagem	INT FOREIGN KEY REFERENCES Personagens(IdPersonagem),
	Email			VARCHAR(200) UNIQUE NOT NULL,
	Senha			VARCHAR(150) NOT NULL
);
GO