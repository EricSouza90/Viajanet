# Viajanet

Passos

1. Instalar docker e rodas os seguintes comandos

docker run -d --hostname rabbit-local --name viajanet-rabbitmq -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=viajanet -e RABBITMQ_DEFAULT_PASS=Viajanet2019! rabbitmq:3-management

docker run -d --name db -p 8091-8094:8091-8094 -p 11210:11210 couchbase

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Viajanet@2019!" -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest

2. Acessos
  SQL:  Server=localhost,1433
        Database=Viajanet
        User ID=sa;
        Password=Viajanet@2019!
        
  Couchbase:  Username=viajanet
              Password=Viajanet2019!
              Bucket=ViajaNet (Bucket deve ser criado manualmente)
  
  RabbitMQ: Hostname=localhost
            Port=5672
            Username=viajanet
            Password=Viajanet2019!

Rodar o script de criação de dados (Poderia estar no Migrations)
Create database Viajanet

Create table DataTracking
(
Id int not null Identity(1,1) Primary Key,
[IP] Varchar(39),
PageName varchar(255),
Browser varchar(255),
PageParameters varchar(255)
);

Executar o Projeto Viajanet.Front e ViajaNet.Web.Api ao mesmo tempo
