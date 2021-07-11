USE InLockGames;
GO

--- Lista todos os Usuários
SELECT Id, Email, Senha, TipoUsuario FROM Usuarios;

--- Lista todos os Estúdios
SELECT Id, Nome FROM Estudios;

--- Lista todos os Jogos
SELECT Id, Nome, Descricao, CONVERT(VARCHAR, DataLancamento, 106) AS DataLancamento, Valor, EstudioId FROM Jogos;

--- Lista todos os Jogos e seu Estúdios
SELECT J.Id, J.Nome, J.Descricao, CONVERT(VARCHAR, J.DataLancamento, 106) AS DataLancamento, J.Valor, J.EstudioId, E.Id, E.Nome FROM Jogos AS J 
INNER JOIN Estudios AS E 
ON J.EstudioId = E.Id;

--- Lista Estúdios e seus Jogos mesmo sem nenhuma referencia
SELECT E.Id, E.Nome, J.Id, J.Nome FROM Estudios AS E 
FULL OUTER JOIN Jogos AS J 
ON E.Id = J.EstudioId;

SELECT Id, Nome, Descricao, DataLancamento, Valor, EstudioId FROM Jogos WHERE EstudioId = 2;

--- Function Execute
--- Busca um Usuário por email e senha;
SELECT * FROM BuscarUsuario('cliente@cliente.com', 'cliente');

--- Busca um Jogo pelo id
SELECT * FROM BuscarJogo(1);

--- Busca um Estúdio pelo id
SELECT * FROM BuscarEstudio(2);
