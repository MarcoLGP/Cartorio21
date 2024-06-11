# Projeto desafio Cartório21

### .NET 4.8

## Introdução
Este é um projeto desafio, em 5 dias desenvolver uma aplicação que seguisse os requisitos e regras de negócios propostos.

## Aplicação
Planejando a solução, optei pela arquitetura de 3 camadas, visando a escalabilidade e modularidade que ela oferece, seguindo as boas práticas dessa arquitetura, em resumo é possível fazer testes isolados de regras de negócios e reaproveitar a solução para outros projetos, como por exemplo utilizar a camada de negócio (Business) e de base de dados (Database) em uma web api apenas substituindo a camada UI que foi desenvolvida em Windows Forms como requisitado, por um projeto Web Api, reaproveitando toda regra de negócio desenvolvida na camada business.

## Camada Database
A camada database foi pensada em isolar a conexão com o banco e realizar as operações de mais baixo nível, ela foi pensada nessa forma para que caso mude o banco de dados da aplicação o tempo de adaptação seja otimizado.

## Camada Business
A camada business é a camada lógica da aplicação, onde estão os validadores e principais funcionalidades da regra de negócio. 
Também nessa camada há os serviços que fazem toda parte de processamento das regras de negócio e trato com o banco de dados.

## Camada UI
Essa é a camada cliente da aplicação, onde fará a apresentação de toda regra de negócio para o exterior, a idéia é que seja possível qualquer projeto compatível com .NET 4.8 consumir a camada business, não só este específico desenvolvido em Windows Forms.

## Importador XML
Essa funcionlidade segue o layout do XML (XML encaminhado no desafio) serializado automaticamente pelo xsd.exe oferecido pelo pacote de desenvolvimento .NET, e também pelo validador da camada business, caso o protocolo do titulo já esteja cadastrado na base de dados, é oferecido ao usuário a opção de atualizar o título na base com os dados do XML, caso haja um erro durante o processo é feito um rollback e a operação é cancelada.

## Configuração do banco de dados
Ao iniciar e a aplicação não encontrar na memória a string de conexão do banco de dados é exibida a janela de configurações para que o usuário forneça, após fornecida ela será salva na memória da aplicação e o usuário não precisará fornecer ela novamente enquanto não houver erros de conexão.

## Considerações finais
Dentro do prazo estabelecido dei o meu empenho máximo em tornar não só a aplicação funcional mas a arquitetura, tendo em vista a minha capacidade técnica atual.

## Desafio

Cartório de Protesto (o cliente)
- Cartório21 é o nome do cliente.
O problema
- O cartório precisa importar os títulos diariamente para o sistema.
- Esses títulos são importados de um arquivo XML.
O arquivo XML é composto pelos dados básicos do título, NumeroTitulo,
NomeDevedor, DocumentoDevedor, NomeApresentante,
DocumentoApresentante, NomeCredor, DocumentoCredor, NumeroTitulo,
ValorTitulo, DataEmissão, EspécieTitulo.
- Visando melhorar o processo interno, o Tabelião do cartório decidiu contratar a
empresa para desenvolver um sistema que importe os títulos do arquivo XML de
forma automática e armazene-os em um banco de dados.
- Ao inserir esses dados no sistema, é necessário acrescentar mais 3 informações
no título.
o Protocolo: Código único do cartório (número inteiro com 7 posições)
o Data de Apresentação: Data que o título foi apresentado no cartório
o Valor das custas: Valor cobrado pelos serviços cartorários, que nesse
caso será de 10% do Valor do título.

- O Tabelião tem a necessidade de visualizar cada um, caso necessário editar e se
preciso for excluir o título da base.
Solução proposta
- Construir um sistema que importe os títulos do arquivo XML e armazene os dados
no banco de dados, já com os campos Protocolo, DataApresentacao e
ValorCustas, lembrando que será necessário fazer o cálculo do valor das custas
do cartório.
- O sistema deverá mostrar os títulos importados em um DataGridView, e dar a
opção de visualizar os dados do título em uma tela, editar e excluir.
Arquivos necessários

Requisitos
- Use .Net 4.x
- O sistema deverá ser desenvolvido utilizando Windows Forms.
- O banco de dados deverá ser o SqlServer.
- Faça um README explicando a solução proposta, adicione o arquivo backup
(.bak) do banco de dados da solução.
- Siga o que considera boas práticas de programação.

## Links
<a href="https://drive.google.com/file/d/1E21LCagGrukqhdm5tNtFAE46Q1uyEWU_/view">Instalador da aplicação</a>
<a href="https://drive.google.com/file/d/12QbQFYb3nKtBEr0XGNRlJ8agxJrmNqsb/view">XML</a>

### O amor é paciente, o amor é bondoso. Não inveja, não se vangloria, não se orgulha. Não maltrata, não procura seus interesses, não se ira facilmente, não guarda rancor. O amor não se alegra com a injustiça, mas se alegra com a verdade. Tudo sofre, tudo crê, tudo espera, tudo suporta.
### Coríntios 13:4-7
