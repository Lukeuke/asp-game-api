# GuessWord Server
GuessWord Server is a API made in ASP.NET, which provides: 
- User login/registration with JWT authentication,
- ORM MSSQL Database,
- Entity Framework

>  This API takes word from other api, and user has to guess the word, its simmilar to game called "Wordle"

## Installation

```bash
git clone https://github.com/Lukeuke/asp-game-api.git
```

- Go to <em> ./Application </em> folder

### Run with docker

still not supporting fully dockerized run, because of DataBase

```bash
docker build -t guesswordapi .
```

```bash
docker run -p 8080:80 guesswordapi
```

### Run with dotnet
- Change connection string to your DataBase
- Create Db called "GuessWordDb"

```bash
dotnet ef database update
```

- if there are not migrations just add one
```bash
dotnet ef migrations add <name_of_migration>
```
- and then update Db
- after this you can run this application
```bash
dotnet run
```

## Endpoints
![Endpoints.](./pics/endpoint.png "endpoints")

## Authors
- [@Lukeuke](https://www.github.com/Lukeuke)
