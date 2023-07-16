# Introdução ao Entity Framework Core

### O que é um ORM:
- Object relational mapping possibilita consultar e manipular dados de um banco de dados.

### Orientação a objetos vs Modelo relacional:
- **Orientacao a objetos**: Herança, Polimorfismo, Abstração.
- **Modelo relacional**: Repositório de dados, tabelas.

### O que é Entity Framework Core:
- É um produto que desempenha um papel de ORM, e é uma versao melhorada do Entity Framework.
- Nos permite focar apenas nas regras de negócio, evitando escrever SQL na aplicação.
- O Entity Framework Core é multiplataforma.

### Como funciona o EF Core:
- Para realizar leituras, o EF Core utiliza a consulta LINQ e gera os comandos no banco de dados especifico atraves dos providers que se baseiam no ADO.NET.
- Para inserções, o EF Core cria cópias da instância do seu objeto e fica monitorando o estado.

### História do Entity Framework:
- A primeira versão foi em 2008 junto com o LINQ.
- A primeira versão do EF Core foi lançado em 2016.

### Diferenças EF 6 e EF Core:
- EF Core é até 140% mais rápido que sua versão anterior.
- As consultas do EF Core são mais otimizadas.

### Code First:
- Abordagem mais natural para quem utiliza EF Core.
- Não demanda tempo para criar o banco com comandos SQL, e sim cria classes, faz o mapeamento delas através de métodos de extensão
conhecido com fluent api, que é uma forma de fazer o mapeamento utilizando métodos ou data annotations.

### Database First:
- Primeiramente é criado o banco de dados.
- Após isso é escrito as classes que representam o banco de dados manualmente, ou utilizado o scaffold, que realiza a engenharia reversa do code first.

### DbContext:
- Classe principal que interage com o banco de dados.
- Uma mistura dos padrões Unit of Work e Repository.
- Essa classe gera um cache de primeiro nível.
- 3 métodos importantes (OnConfiguring, OnModelCreating, SaveChanges).

### Consulta de dados:
- Quando realizamos uma consulta de dados com o ef, ele fica rastreando nosso objeto em memória, então se eu alterar algum valor, posso passar o comando SaveChanges(), irá atualizar o registro na base de dados. Mas podemos desabilitar o rastreamento utilizando o metodo AsNoTracking().

### Consulta de dados de propriedades de navegaçao:
- Existem três formas de carragar os dados das propriedades de navegação, sendo: Carregamento adiantado (os dados são carregados em uma única consulta), carregamento explícito (os dados são carregados explicitamente em um momento posterior) e carregamento lento (os dados são carregados sob demanda quando a propriedade de navegação é acessada).

### 😎 Autor

Guilherme Ferrari - guile.ferrari@hotmail.com

[![Linkedin Badge](https://img.shields.io/badge/-Guilherme-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-antonio-ferrari/)](https://www.linkedin.com/in/guilherme-antonio-ferrari/)

### 🎯 Contribuição

1. Faça o _fork_ do projeto
2. Crie uma _branch_ para sua modificação (`git checkout -b feature/descricaoFeature`)
3. Faça o _commit_ (`git commit -am 'Add descricaoFeature'`)
4. _Push_ (`git push origin feature/descricaoFeature`)
5. Crie um novo _Pull Request_

### 📝 Licença

MIT.