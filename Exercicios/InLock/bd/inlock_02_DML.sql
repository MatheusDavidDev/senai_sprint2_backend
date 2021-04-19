USE InLock_Games_Manha

INSERT INTO Usuarios (titulo, email, senha)
VALUES				 ('Administrador', 'admin@admin.com', 'admin')
					 ,('Cliente', 'cliente@cliente.com', 'cliente');

INSERT INTO Estudios (nomeEstudio)
VALUES				 ('Blizzard')
					  ,('Rockstar Studios')
					  ,('Square Enix');

INSERT INTO Jogos (nomeJogo, descricao, dataLancamento, valor)
VALUES            ('Diablo 3', 'É um jogo que contém bastante ação e é viciante,seja você um novato ou um fã', '2012/05/15', '99')
				  ,('Red Dead Redemption II', 'jogo eletrônico de ação-aventura western', '2018/10/26', '120');
