# Cadastro Escolar
Aplicação para cadastro de usuários e seus históricos escolares.
Desenvolvida para validação técnica.


## Tecnologias

* Angular 16
* Angular Material
* .NET 6.0
* Dapper
* SQL Server
* Docker


## Como iniciar

Para iniciar o projeto você precisa ter instalado o Docker CLI ou Docker Desktop [https://www.docker.com](https://www.docker.com)

Clone o repositório e entre no diretório onde foi clonado.

Execute o seguinte comando:
```
docker-compose -f compose.yaml up --build -d
```

Acessar a aplicação web:
```
http://localhost:4200
```

Acessar a API:
```
http://localhost:5047/swagger/
```



## Imagens

### Home

<div align="center">
  <img src="./img/home.png">
</div>


### Cadastrar

<div align="center">
  <img src="./img/cadastro.png">
</div>


### Editar

<div align="center">
  <img src="./img/editar.png">
</div>


### Histórico

<div align="center">
  <img src="./img/historico.png">
</div>
