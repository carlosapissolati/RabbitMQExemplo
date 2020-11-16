[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# RabbitMQExemplo

 Um exemplo de como utilizar a Fila RabbitMQ (Consumir e enviar).
 <br />
 Não é necessario realizar a instalação do RabbitMQ na maquina ou utilizar uma imagem do Docker do RabbitMQ.
<br />
 Esse projeto utiliza o RabbitMQ do seguinte site: https://www.cloudamqp.com/ (FREE)
 
## Configuração do Cloudamqp

Criar o cadastro no site: https://www.cloudamqp.com/.

Criar uma Instancia nova de RabbitMQ:

<p align="center">
 <img src="https://github.com/carlosapissolati/RabbitMQExemplo/blob/main/Imagens/1.jpg">
</p>

Informar o nome para instância e seleciona o plano FREE:

<p align="center">
 <img src="https://github.com/carlosapissolati/RabbitMQExemplo/blob/main/Imagens/2.jpg">
</p>

Selecionando a região aonde será hosepdado o serviço de RabbitMQ, selecionar a região de SP para diminuir a latencia:

<p align="center">
 <img src="https://github.com/carlosapissolati/RabbitMQExemplo/blob/main/Imagens/3.jpg">
</p>

Após isso aguardar a criação da instância de RabbitMQ.

## Configuração da aplicação

Entrar na instância de RabbitMQ e Copiar a AMQP URL:

<p align="center">
 <img src="https://github.com/carlosapissolati/RabbitMQExemplo/blob/main/Imagens/4.jpg">
</p>

Abrir o arquivo appsettings.json e alterar o campo URL com o AMQP URL do RabbitMQ conforme a imagem a cima.
<br />
Lembrando que precisar alterar o appsettings.json dentro de cada aplicação Console (Send.ConsoleApp e Worker.Console.App)

<br />
Após a alteração somente executar o projeto Send para enviar a informação para Fila e depois rodar o Worker para consumir a informação da Fila.
