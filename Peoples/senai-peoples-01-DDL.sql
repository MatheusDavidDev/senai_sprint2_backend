CREATE DATABASE M_Peoples;
GO

USE M_Peoples;
GO

CREATE TABLE funcionarios
(
	idFuncionario	INT PRIMARY KEY IDENTITY
	,nome			VARCHAR(200)NOT NULL
	,sobrenome		VARCHAR(200)NOT NULL
	,dataNascimento	DATE NOT NULL
);
GO