
SELECT
    Nome,
    Email,
    CASE
        WHEN DATEDIFF(YEAR, DataNascimento, GETDATE()) <= 20 THEN 'Até 20 anos'
        WHEN DATEDIFF(YEAR, DataNascimento, GETDATE()) > 20 AND DATEDIFF(YEAR, DataNascimento, GETDATE()) <= 50 THEN 'De 20 a 50 anos'
        ELSE 'Acima de 50 anos'
    END AS FaixaEtaria
FROM
    Usuario u
    INNER JOIN Escolaridade e ON u.IdEscolaridade = e.IdEscolaridade
WHERE
    e.Escolaridade = 'Superior'
ORDER BY DataNascimento DESC