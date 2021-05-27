USE InLock_Games_Manha
GO

INSERT INTO TipoUsuarios (titulo)
VALUES					 ('Administrador')
						,('Cliente');
GO

INSERT INTO Usuarios (idTipoUsuario, email, senha)
VALUES				 (1, 'admin@admin.com', 'admin')
					,(2, 'cliente@cliente.com', 'cliente');
GO

INSERT INTO Estudios (nomeEstudio)
VALUES				 ('Blizzard')
					,('Rockstar Studios')
					,('Square Enix');
GO

INSERT INTO Jogos (nomeJogo, descricao, dataLancamento, idEstudio, valor)
VALUES            ('Diablo 3', 'É um jogo que contém bastante ação e é viciante,seja você um novato ou um fã', '2012/05/15', 1, '99')
				 ,('Red Dead Redemption II', 'jogo eletrônico de ação-aventura western', '2018/10/26', 2, '120');
GO



