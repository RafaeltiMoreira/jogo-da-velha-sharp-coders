using System;
using System.Linq;

namespace JogoDaVelha {
    class Program {
        private const int vencedorX = 1;
        private const int vencedorO = 2;
        private const int empate = 3;

        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Green;

            int placar = 0;
            bool continuar;
            int jogadorVencedor = -1;
            int jogadorX = 0;
            int jogadorO = 0;
            int jogadorE = 0;

            continuar = true;
            while (continuar) {
                char[] posicaoTabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                do {
                    Console.Clear();
                    jogadorVencedor = ProximoJogador(jogadorVencedor);

                    ExibirInitial(jogadorVencedor);
                    ExibirTabuleiro(posicaoTabuleiro);

                    ExecutarJogada(posicaoTabuleiro, jogadorVencedor);
                    placar = VerificarVencedor(posicaoTabuleiro);

                } while (placar == 0);

                Console.Clear();
                ExibirInitial(jogadorVencedor);
                ExibirTabuleiro(posicaoTabuleiro);

                Console.ForegroundColor = ConsoleColor.White;
                string exibirAtual = placar == vencedorX ? "X" : "O";
                if (placar == vencedorX) {
                    jogadorX++;
                    Console.WriteLine($@"
        Jogador (a) {exibirAtual} é o vencedor (a)!");
                }
                else if (placar == vencedorO) {
                    jogadorO++;
                    Console.WriteLine($@"
        Jogador (a) {exibirAtual} é o vencedor (a)!"); 
                }
                else {
                    jogadorE++;
                    Console.WriteLine(@"
        O jogo terminou empatado."); 
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write($@"
        === Placar ===
                
        Jogador(a) X: {jogadorX}
        Jogador(a) O: {jogadorO}
        Empate: {jogadorE}
        
        Deseja continuar jogando? (S/N): ");
                var repeteGame = Console.ReadLine();
                if (repeteGame == "N" || repeteGame == "n") {
                    continuar = false;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@"
        ===> Pressione qualquer tecla para fechar. <===");
                }
                else {
                    continuar = true;
                    Console.Clear();
                }
            }
        }

        private static int VerificarVencedor(char[] posicaoTabuleiro) {
            if (VerificarVitoria(posicaoTabuleiro, 'X')) {
                return vencedorX;
            }
            if (VerificarVitoria(posicaoTabuleiro, 'O')) {
                return vencedorO;
            }
            if (VerificarEmpate(posicaoTabuleiro)) {
                return empate;
            }
            else {
                return 0;
            }
        }

        private static bool VerificarEmpate(char[] posicaoTabuleiro) {
            return !VerificarVitoria(posicaoTabuleiro, 'X') && !VerificarVitoria(posicaoTabuleiro, 'O') && !posicaoTabuleiro.Any(p => p != 'X' && p != 'O');
        }

        private static bool VerificarVitoria(char[] posicaoTabuleiro, char jogador) {
            return (posicaoTabuleiro[0] == jogador && posicaoTabuleiro[1] == jogador && posicaoTabuleiro[2] == jogador) ||
                   (posicaoTabuleiro[3] == jogador && posicaoTabuleiro[4] == jogador && posicaoTabuleiro[5] == jogador) ||
                   (posicaoTabuleiro[6] == jogador && posicaoTabuleiro[7] == jogador && posicaoTabuleiro[8] == jogador) ||
                   (posicaoTabuleiro[0] == jogador && posicaoTabuleiro[3] == jogador && posicaoTabuleiro[6] == jogador) ||
                   (posicaoTabuleiro[1] == jogador && posicaoTabuleiro[4] == jogador && posicaoTabuleiro[7] == jogador) ||
                   (posicaoTabuleiro[2] == jogador && posicaoTabuleiro[5] == jogador && posicaoTabuleiro[8] == jogador) ||
                   (posicaoTabuleiro[0] == jogador && posicaoTabuleiro[4] == jogador && posicaoTabuleiro[8] == jogador) ||
                   (posicaoTabuleiro[2] == jogador && posicaoTabuleiro[4] == jogador && posicaoTabuleiro[6] == jogador);
        }

        private static void ExecutarJogada(char[] posicaoTabuleiro, int jogadorVencedor) {
            Console.Write(@"
        Digite uma posição de 1 a 9: ");
            var posicao = Console.ReadLine();

            if (!int.TryParse(posicao, out int posicaoInt)) {
                Console.WriteLine(@"
        Posição não válida!");
                return;
            }

            if (posicaoInt < 1 || posicaoInt > 9) {
                Console.WriteLine(@"
        Posição não válida!");
                return;
            }

            if (posicaoTabuleiro[posicaoInt - 1] != 'X' && posicaoTabuleiro[posicaoInt - 1] != 'O') {
                posicaoTabuleiro[posicaoInt - 1] = jogadorVencedor == 1 ? 'X' : 'O';
            }
            else {
                Console.WriteLine(@"
        Posição ocupada!");
            }
        }

        private static void ExibirTabuleiro(char[] posicaoTabuleiro) {
            Console.WriteLine();
            Console.WriteLine($@"
              |     |     
           {posicaoTabuleiro[0]}  |  {posicaoTabuleiro[1]}  |  {posicaoTabuleiro[2]}  
         _____|_____|_____
              |     |     
           {posicaoTabuleiro[3]}  |  {posicaoTabuleiro[4]}  |  {posicaoTabuleiro[5]}  
         _____|_____|_____
              |     |     
           {posicaoTabuleiro[6]}  |  {posicaoTabuleiro[7]}  |  {posicaoTabuleiro[8]}  
              |     |     
            ");
            Console.WriteLine();
        }

        private static void ExibirInitial(int jogadorVencedor) {
            Console.WriteLine();
            Console.WriteLine(@"
        JOGO DA VELHA - SHARP CODERS");
            Console.WriteLine();
            Console.WriteLine($@"
        Jogador (a) disponível: {(jogadorVencedor == 1 ? "X" : "O")}");
            Console.WriteLine();
        }

        private static int ProximoJogador(int jogadorVencedor) {
            if (jogadorVencedor == 1) {
                return 2;
            }
            else {
                return 1;
            }
        }
    }
}