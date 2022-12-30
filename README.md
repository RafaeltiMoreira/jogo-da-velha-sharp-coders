<h1 align="center"> SHARP CODERS | Projeto Jogo da velha C# - 2022 </h1>

<p align="center">
Formação Desenvolvedor C#, promovido pela Imã Learning Place | Sharp Coders.
</p>

<p align="center">
  <a href="#-tecnologias">Tecnologias</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-teacher">Teacher</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-bootcamp">Bootcamp</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-projeto">Projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#memo-licença">Licença</a>
</p>

<p align="center">
  <img alt="License" src="https://img.shields.io/static/v1?label=license&message=MIT&color=49AA26&labelColor=000000">
</p>

<br>

<p align="center">
  <img alt="calendario da copa" src=".github/preview.png" width="100%">
</p>

## 🚀 Tecnologias

Esse projeto foi desenvolvido com as seguintes tecnologias:

- C#
- Git e Github

## 🎓 Teacher

- Agradeço pela oportunidade de crescimento e ótima didática do prof. Hugo Rafael [![GitHub Badge](https://img.shields.io/badge/-hgrafa-black?style=flat-square&logo=GitHub&logoColor=white&link=https://github.com/hgrafa)](https://github.com/hgrafa) 

## 💻 Bootcamp

- FullStack na [**Ímã learning place**](https://imalearningplace.com) | Sharp Coders 2022
- C# focado em Lógica de Programação e Algoritmos

## #️⃣ = ❎ e 0️⃣ Projeto

Este é um código que implementa um jogo da velha em C#. O jogo consiste em duas pessoas alternando-se para marcar posições em um tabuleiro 3x3 com X (xis) ou O (bola). Aquele que conseguir colocar três de suas marcas em linha (horizontal, vertical ou diagonal) primeiro, é o vencedor. Se não houver mais espaços vazios no tabuleiro e nenhum dos jogadores tiver conseguido vencer, o jogo é considerado empatado.

O código começa declarando algumas constantes que são usadas para indicar o vencedor (vencedorX ou vencedorO) ou o empate (empate). Ele também declara algumas variáveis que são usadas para armazenar o placar do jogo, o jogador atual, o número de vitórias e empates de cada jogador e um indicador se o jogo deve continuar ou não.

O loop principal do jogo (while (continuar)) inclui outro loop que é executado enquanto não houver um vencedor ou empate. Dentro desse loop, o tabuleiro é exibido na tela e a próxima jogada é executada pelo jogador atual. Depois, o placar é verificado novamente para ver se o jogo terminou.

Depois que o jogo termina, o placar é exibido na tela e o usuário é perguntado se deseja continuar jogando. Se a resposta for sim, o loop principal é executado novamente e um novo jogo é iniciado. Se a resposta for não, o loop principal é encerrado e o programa é encerrado.

Algumas outras funções são chamadas ao longo do código, como ExibirInitial(), ExibirTabuleiro(), VerificarVencedor() e ExecutarJogada(). Essas funções realizam tarefas específicas, como exibir o tabuleiro, ler a próxima jogada do usuário, verificar se houve um vencedor ou empate. A função ExecutarJogada() verifica se posição digitada pelo usuário está livre ou ocupada e também verifica se a jogada é válida dentro dos números de 1 a 9.

## :memo: Licença

- Esse projeto está sob a licença MIT

[![PyPI license](https://img.shields.io/pypi/l/ansicolortags.svg)](https://github.com/RafaeltiMoreira/jogo-da-velha-sharp-coders/blob/main/LICENSE)
