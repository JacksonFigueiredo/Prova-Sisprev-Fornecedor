# Prova-Sisprev-Fornecedor

Bloco 1
Neste bloco é avaliado:
•	C# Rest Web Api
o	Utilização do Entity Framework
o	Utilização do ASP.NET Core para criação de Web Api com Swagger;
o	Utilização do padrão de projeto Repository
o	Utilização do padrão de projeto Dependency Injection
o	Utilização do padrão de projeto Inversion of Control
o	Utilização do padrão de projeto CQRS
o	Utilização do padrão DDD
Perspectivas da avaliação:
•	Completude da tarefa;
•	Acurácia da solução;
•	Qualidade do código;
•	Clareza de leitura;
•	Testes de software automáticos.





Tarefas – Bloco 1

1.	Abra a solução SistemaCompras presente na pasta Prova.SISPREV;

2.	O projeto Prova.SISPREV consiste em uma API simples para os objetos Produto e SolicitacaoCompra. Para objeto Produto já existe uma controller com métodos já implementados. Sua tarefa é evoluir, seguindo os padrões existentes na solução, o objeto de SolicitacaoCompra


3.	A entidade SolicitacaoCompra no domínio, já está implementada, adicione método necessário de forma a garantir que as seguintes regras de negócio sejam validadas: 2,0 

a.	Se o Total Geral for maior que 50000 a condição de pagamento deve ser 30 dias.
b.	O total de itens de compra deve ser maior que 0.

4.	Crie a interface que contém o método RegistrarCompra do repositório para SolicitacaoCompra; 0,5 

5.	Crie o repositório da entidade SolicitacaoCompra; 1 

6.	Usando o comando do EntityFramework gere as migrações para a entidade recém-criada; 1,5 

7.	Aplique as migrações recém-criadas utilizando o comando do EntityFramework. 0,5 
 
8.	No projeto SistemaCompras.Application, utilizando o padrão CQRS, será necessário criar classes e interfaces do comando, são elas: 2,0 

a.	RegistrarCompraCommand
b.	RegistrarCompraCommandHandler 

9.	No projeto SistemaCompras.API, crie a controller de SolicitacaoCompra 1,0 

10.	Crie o método necessário utilizando o command criado no projeto SistemaCompras.Application. 1,5 
