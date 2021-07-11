USE InLockGames;
GO

--- Lista todos os Usu�rios
SELECT Id, Email, Senha, TipoUsuario FROM Usuarios;

--- Lista todos os Est�dios
SELECT Id, Nome FROM Estudios;

--- Lista todos os Jogos
SELECT Id, Nome, Descricao, CONVERT(VARCHAR, DataLancamento, 106) AS DataLancamento, Valor, EstudioId FROM Jogos;

--- Lista todos os Jogos e seu Est�dios
SELECT J.Id, J.Nome, J.Descricao, CONVERT(VARCHAR, J.DataLancamento, 106) AS DataLancamento, J.Valor, J.EstudioId, E.Id, E.Nome FROM Jogos AS J 
INNER JOIN Estudios AS E 
ON J.EstudioId = E.Id;

--- Lista Est�dios e seus Jogos mesmo sem nenhuma referencia
SELECT E.Id, E.Nome, J.Id, J.Nome FROM Estudios AS E 
FULL OUTER JOIN Jogos AS J 
ON E.Id = J.EstudioId;

SELECT Id, Nome, Descricao, DataLancamento, Valor, EstudioId FROM Jogos WHERE EstudioId = 2;

--- Function Execute
--- Busca um Usu�rio por email e senha;
SELECT * FROM BuscarUsuario('cliente@cliente.com', 'cliente');

--- Busca um Jogo pelo id
SELECT * FROM BuscarJogo(1);

--- Busca um Est�dio pelo id
SELECT * FROM BuscarEstudio(2);
