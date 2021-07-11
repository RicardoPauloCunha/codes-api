USE InLockGames;
GO

--- Functions Create
--- Function que busca o usuário pelo email ou senha 
CREATE FUNCTION dbo.BuscarUsuario(@email VARCHAR(250), @senha VARCHAR(250))
RETURNS TABLE AS RETURN
SELECT U.Id, U.Email, U.Senha, U.TipoUsuario FROM Usuarios AS U WHERE U.Email = @email AND U.Senha = Senha;
GO

--- Function que busca o jogo pelo id 
CREATE FUNCTION dbo.BuscarJogo(@id int)
RETURNS TABLE AS RETURN
SELECT * FROM Jogos AS J WHERE J.Id = @id;
GO

--- Function que busca o estúdio pelo id
CREATE FUNCTION dbo.BuscarEstudio(@id int)
RETURNS TABLE AS RETURN
SELECT * FROM Estudios E WHERE E.Id = @id;
GO