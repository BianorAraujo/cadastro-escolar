# cadastro-escolar
App criada para validação técnica na empresa Confitec


docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Password123' -p 1433:1433 --name azuresqledge -d -v sqlvolume:/var/opt/mssql mcr.microsoft.com/azure-sql-edge