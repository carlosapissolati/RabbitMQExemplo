<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]


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



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/carlosapissolati/RabbitMQExemplo.svg?style=flat-square
[contributors-url]: https://github.com/carlosapissolati/RabbitMQExemplo/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/carlosapissolati/RabbitMQExemplo.svg?style=flat-square
[forks-url]: https://github.com/carlosapissolati/RabbitMQExemplo/network/members
[stars-shield]: https://img.shields.io/github/stars/carlosapissolati/RabbitMQExemplo.svg?style=flat-square
[stars-url]: https://github.com/carlosapissolati/RabbitMQExemplo/stargazers
[issues-shield]: https://img.shields.io/github/issues/carlosapissolati/RabbitMQExemplo.svg?style=flat-square
[issues-url]: https://github.com/carlosapissolati/RabbitMQExemplo/issues
[license-shield]: https://img.shields.io/github/license/carlosapissolati/RabbitMQExemplo.svg?style=flat-square
[product-screenshot]: images/screenshot.png
