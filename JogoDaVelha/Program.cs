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

                string exibirAtual = placar == vencedorX ? "X" : "O";
                if (placar == vencedorX) {
                    jogadorX++;
                    Console.Write(@"
        Jogador (a) ");
                    Console.ResetColor();
                    Console.Write($@"{exibirAtual} (Xis) ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(@"VENCEDOR (A) da partida!");
                }
                else if (placar == vencedorO) {
                    jogadorO++;
                    Console.Write(@"
        Jogador (a) ");
                    Console.ResetColor();
                    Console.Write($@"{exibirAtual} (Bola) ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(@"VENCEDOR (A) da partida!");
                }
                else {
                    jogadorE++;
                    Console.Write(@"
        O jogo terminou ");
                    Console.ResetColor();
                    Console.Write(@"EMPATADO."); 
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                
                Console.WriteLine();
                Console.Write($@"
        === Placar ===
                ");

                Console.Write(@"
        Jogador (a) X: ");
                Console.ResetColor();
                Console.Write($@"{jogadorX}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"
        Jogador (a) O: ");
                Console.ResetColor();
                Console.Write($@"{jogadorO}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"
        Empate: ");
                Console.ResetColor();
                Console.Write($@"{jogadorE}");
                Console.WriteLine();

                while (continuar) {
                    Console.ResetColor();
                    Console.Write(@"
        Deseja continuar jogando? (S/N): ");
                    var repeteGame = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (repeteGame == "N" || repeteGame == "n") {
                        continuar = false;
                        Console.Clear();
                        Console.WriteLine(@"
        ===> Pressione qualquer tecla para fechar. <===");
                        break;
                    }
                    else if (repeteGame == "S" || repeteGame == "s") {
                        continuar = true;
                        Console.Clear();
                        break;
                    }
                    else {
                        Console.WriteLine(@"
        Por favor, digite S para continuar jogando ou N para não.");
                    }
                }
            }
        }

        private static int ProximoJogador(int jogadorVencedor) {
            // Adicionado condição para verificar se jogadorVencedor é -1
            if (jogadorVencedor == -1) {
                return 1;
            }
            else {
                return jogadorVencedor == 1 ? 2 : 1;
            }
        }

        private static void ExecutarJogada(char[] posicaoTabuleiro, int jogadorVencedor) {

            bool jogadaValida = false;
            while (!jogadaValida) {
                Console.Write(@"
        Digite uma posição de 1 a 9 para jogar: ");
                var posicao = Console.ReadLine();

                if (!int.TryParse(posicao, out int posicaoInt)) {
                    Console.WriteLine(@"
        Jogada não válida! Por favor, escolha um número de 1 a 9.");
                    continue;
                }

                if (posicaoInt < 1 || posicaoInt > 9) {
                    Console.WriteLine(@"
        Jogada não válida! Por favor, escolha um número de 1 a 9.");
                    continue;
                }

                if (posicaoTabuleiro[posicaoInt - 1] == 'X' || posicaoTabuleiro[posicaoInt - 1] == 'O') {
                    Console.WriteLine($@"
        Posição {posicao} ocupada, por favor escolha um número disponível de 1 a 9.");
                    continue;
                }

                posicaoTabuleiro[posicaoInt - 1] = jogadorVencedor == 1 ? 'X' : 'O';
                jogadaValida = true;
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
            // Verifica as linhas
            if (posicaoTabuleiro[0] == jogador && posicaoTabuleiro[1] == jogador && posicaoTabuleiro[2] == jogador) {
                return true;
            }
            if (posicaoTabuleiro[3] == jogador && posicaoTabuleiro[4] == jogador && posicaoTabuleiro[5] == jogador) {
                return true;
            }
            if (posicaoTabuleiro[6] == jogador && posicaoTabuleiro[7] == jogador && posicaoTabuleiro[8] == jogador) {
                return true;
            }

            // Verifica as colunas
            if (posicaoTabuleiro[0] == jogador && posicaoTabuleiro[3] == jogador && posicaoTabuleiro[6] == jogador) {
                return true;
            }
            if (posicaoTabuleiro[1] == jogador && posicaoTabuleiro[4] == jogador && posicaoTabuleiro[7] == jogador) {
                return true;
            }
            if (posicaoTabuleiro[2] == jogador && posicaoTabuleiro[5] == jogador && posicaoTabuleiro[8] == jogador) {
                return true;
            }

            // Verifica as diagonais
            if (posicaoTabuleiro[0] == jogador && posicaoTabuleiro[4] == jogador && posicaoTabuleiro[8] == jogador) {
                return true;
            }
            if (posicaoTabuleiro[2] == jogador && posicaoTabuleiro[4] == jogador && posicaoTabuleiro[6] == jogador) {
                    return true;
                }

            return false;
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
        ╔══════════════════════════════╗
        ║ JOGO DA VELHA - SHARP CODERS ║
        ╚══════════════════════════════╝

        Jogador (a): X
        Jogador (a): O ");
            Console.WriteLine(@"
        Escolha um número de 1 a 9, depois aperte enter no teclado.
        ");
            Console.Write(@"
        Jogador (a) ");
            Console.ResetColor();
            Console.Write($@"{(jogadorVencedor == 1 ? "X" : "O")}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@" é a sua vez de jogar.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
        }
    }
}
