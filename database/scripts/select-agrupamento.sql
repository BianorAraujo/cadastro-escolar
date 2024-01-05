
SELECT
    Nome,
    Email,
    CASE
        WHEN DATEDIFF(YEAR, DataNascimento, GETDATE()) <= 20 THEN 'X'
        WHEN DATEDIFF(YEAR, DataNascimento, GETDATE()) > 20 AND DATEDIFF(YEAR, DataNascimento, GETDATE()) <= 50 THEN ''
        ELSE ''
    END AS 'Ate 20 anos',
    CASE
        WHEN DATEDIFF(YEAR, DataNascimento, GETDATE()) <= 20 THEN ''
        WHEN DATEDIFF(YEAR, DataNascimento, GETDATE()) > 20 AND DATEDIFF(YEAR, DataNascimento, GETDATE()) <= 50 THEN 'X'
        ELSE ''
    END AS 'Entre 20 e 50',
    CASE
        WHEN DATEDIFF(YEAR, DataNascimento, GETDATE()) <= 20 THEN ''
        WHEN DATEDIFF(YEAR, DataNascimento, GETDATE()) > 20 AND DATEDIFF(YEAR, DataNascimento, GETDATE()) <= 50 THEN ''
        ELSE 'X'
    END AS 'Acima de 50'
FROM
    Usuario u
    INNER JOIN Escolaridade e ON u.IdEscolaridade = e.IdEscolaridade
WHERE
    e.Escolaridade = 'Superior' 
ORDER BY DataNascimento DESC