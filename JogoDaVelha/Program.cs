using System;

namespace JogoDaVelha {
    class Program {
        static void Main(string[] args) {

            int placar = 0;
            int vencedorX;
            int vencedorO;
            //char vencedorXText;
            //char vencedorOText;
            bool continuar;
            int jogadorAtual = -1;

            continuar = true;
            while (continuar) {
 
                char[] posicaoTabuleiro =
                { '1','2','3','4','5','6','7','8','9' };

                do {
                    Console.Clear();
                    jogadorAtual = ProximoJogador(jogadorAtual);

                    ExibirInitial(jogadorAtual);
                    MostrarTabuleiro(posicaoTabuleiro);

                    startJogo(posicaoTabuleiro, jogadorAtual);
                    placar = PlacarVencedor(posicaoTabuleiro);

                } while (placar.Equals(0));


                Console.Clear();
                ExibirInitial(jogadorAtual);
                MostrarTabuleiro(posicaoTabuleiro);


                if (placar.Equals(1)) {

                    Console.WriteLine($@"
        Jogador {jogadorAtual} é o vencedor!");
                }

                if (placar.Equals(2)) {

                    Console.WriteLine(@"
        O jogo terminou empatado.");
                }
                Console.WriteLine();
                Console.Write(@"
        Deseja continuar jogando? (S/N): ");
                var repeteGame = Console.ReadLine();
                if (repeteGame == "N" || repeteGame == "n") {
                    continuar = false;
                    Console.Clear();
                }
                else {
                    continuar = true;
                    Console.Clear();
                }
            }
        }

        private static int PlacarVencedor(char[] posicaoTabuleiro) {

            if (JogoVencedor(posicaoTabuleiro)) {
                return 1;
            }
            if (JogoEmpate(posicaoTabuleiro)) {
                return 2;
            }
            else {
                return 0;
            }
        }

        private static bool JogoEmpate(char[] posicaoTabuleiro) {
            return
                posicaoTabuleiro[0] != '1' &&
                posicaoTabuleiro[1] != '2' &&
                posicaoTabuleiro[2] != '3' &&
                posicaoTabuleiro[3] != '4' &&
                posicaoTabuleiro[4] != '5' &&
                posicaoTabuleiro[5] != '6' &&
                posicaoTabuleiro[6] != '7' &&
                posicaoTabuleiro[7] != '8' &&
                posicaoTabuleiro[8] != '9';
        }

        private static bool JogoVencedor(char[] posicaoTabuleiro) {
            if (VerificaPosicao(posicaoTabuleiro, 0, 1, 2)) {
                return true;
            }
            if (VerificaPosicao(posicaoTabuleiro, 3, 4, 5)) {
                return true;
            }
            if (VerificaPosicao(posicaoTabuleiro, 6, 7, 8)) {
                return true;
            }
            if (VerificaPosicao(posicaoTabuleiro, 0, 3, 6)) {
                return true;
            }
            if (VerificaPosicao(posicaoTabuleiro, 1, 4, 7)) {
                return true;
            }
            if (VerificaPosicao(posicaoTabuleiro, 2, 5, 8)) {
                return true;
            }
            if (VerificaPosicao(posicaoTabuleiro, 0, 4, 8)) {
                return true;
            }
            if (VerificaPosicao(posicaoTabuleiro, 2, 4, 6)) {
                return true;
            }
            else {
                return false;
            }
        }

        private static bool VerificaPosicao(char[] verificaJogo, int posicao1, int posicao2, int posicao3) {
            return verificaJogo[posicao1].Equals(verificaJogo[posicao2]) && verificaJogo[posicao2].Equals(verificaJogo[posicao3]);
        }

        private static void startJogo(char[] posicaoTabuleiro, int jogadorAtual) {
            bool mover = true;

            do {
                string opcaoUsuario = Console.ReadLine();

                if (!string.IsNullOrEmpty(opcaoUsuario) &&
                    (opcaoUsuario.Equals("1") ||
                    opcaoUsuario.Equals("2") ||
                    opcaoUsuario.Equals("3") ||
                    opcaoUsuario.Equals("4") ||
                    opcaoUsuario.Equals("5") ||
                    opcaoUsuario.Equals("6") ||
                    opcaoUsuario.Equals("7") ||
                    opcaoUsuario.Equals("8") ||
                    opcaoUsuario.Equals("9"))) {

                    int.TryParse(opcaoUsuario, out var moverJogadorTabuleiro);

                    char jogadorPos = posicaoTabuleiro[moverJogadorTabuleiro - 1];

                    if (jogadorPos.Equals('X') || jogadorPos.Equals('O')) {
                        Console.WriteLine(@"
        Posição selecionada, selecione outra Posição.");
                    }
                    else {
                        posicaoTabuleiro[moverJogadorTabuleiro - 1] = SelecionarJogador(jogadorAtual);
                        mover = false;
                    }
                }
                else {
                    Console.WriteLine(@"
        Opção não válida, favor selecionar outra opção!");
                }
            } while (mover);
        }

        private static char SelecionarJogador(int jogador) {
            if (jogador % 2 == 0) {
                return 'O';
                
            }
            else {
                return 'X';
            }
        }

        static void ExibirInitial(int NumeroJogador) {

            Console.WriteLine($@"
        Sejam bem-vindos (as) ao Jogo da Velha!
            
        Jogador (a) 1: X
        Jogador (a) 2: O

        Jogador (a) {NumeroJogador}, selecione de 1 a 9 no tabuleiro de jogo.
            
            ");
        }

        static void MostrarTabuleiro(char[] posicaoTabuleiro) {
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
        }

        static int ProximoJogador(int jogador) {
            int vencedorO, vencedorX;
            if (jogador.Equals(1)) {
                return 2;
                vencedorO++;
            }
            else {
                return 1;
                vencedorX++;
            }
        }

        //static int JogadorVencedor(int jogador, int vencedorO, int vencedorX, int vencedorOText, int vencedorXText) {
        //    if (jogador.Equals(1)) {
        //        vencedorO++;
        //        vencedorOText = vencedorO.ToString();
        //    }
        //    else {
        //        vencedorX++;
        //    }
        //}
    }
}


