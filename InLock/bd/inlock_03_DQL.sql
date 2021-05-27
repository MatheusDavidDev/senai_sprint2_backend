USE InLock_Games_Manha
GO

SELECT * FROM Usuarios;

SELECT * FROM Estudios;

SELECT * FROM Jogos;

SELECT nomeJogo AS Jogos, Estudios.nomeEstudio AS Estudios FROM Jogos
RIGHT JOIN Estudios
ON Jogos.idEstudio = Estudios.idEstudio;

SELECT nomeEstudio AS Estudios, Jogos.nomeJogo AS Jogos FROM Estudios
LEFT JOIN Jogos
ON Estudios.idEstudio = Jogos.idEstudio;

SELECT TipoUsuarios.titulo, email FROM Usuarios
INNER JOIN TipoUsuarios
ON Usuarios.idTipoUsuario = TipoUsuarios.idTipoUsuario
WHERE email = 'cliente@cliente.com' AND senha = 'cliente';

SELECT idJogo AS IdDoJogo, Estudios.nomeEstudio AS Estudio, nomeJogo AS Nome, descricao AS Descrição, dataLancamento AS DataDeLançamento, valor AS ValorDoJogo FROM Jogos
INNER JOIN Estudios
ON Jogos.idEstudio = Estudios.idEstudio
WHERE idJogo = 2;

SELECT nomeEstudio AS Nome 
FROM Estudios
WHERE idEstudio = 2;





