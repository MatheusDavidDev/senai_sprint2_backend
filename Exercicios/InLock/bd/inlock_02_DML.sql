USE InLock_Games_Manha

INSERT INTO Usuarios (titulo, email, senha)
VALUES				 ('Administrador', 'admin@admin.com', 'admin')
					 ,('Cliente', 'cliente@cliente.com', 'cliente');

INSERT INTO Estudios (nomeEstudio)
VALUES				 ('Blizzard')
					  ,('Rockstar Studios')
					  ,('Square Enix');

INSERT INTO Jogos (nomeJogo, descricao, dataLancamento, valor)
VALUES            ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante,seja voc� um novato ou um f�', '2012/05/15', '99')
				  ,('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western', '2018/10/26', '120');
