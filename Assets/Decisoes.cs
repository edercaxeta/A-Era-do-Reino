using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using objetos;
using System;


//classe destina a menus de decisoes
namespace Assets {
    public class Decisoes {
        public bool Decisao1() {
            return true;
        }

        //metado de menu inicial
        public static void MostrarMenu() {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format("{0,7}", "═════════════════════════════════════════╬══════════════════════════════════╬═══════════════════════════════════════════"));
            Console.WriteLine(string.Format("{0,77}", "║      ║        Welcome            ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.WriteLine(string.Format("{0,77}", "║ Press║     Choice                ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.WriteLine(string.Format("{0,77}", "║  1   ║ New Game                  ║"));
            Console.WriteLine(string.Format("{0,77}", "║  2   ║ Options                   ║"));
            Console.WriteLine(string.Format("{0,77}", "║  3   ║ Quit Game                 ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.Write(string.Format("\n{0,45}", "--> "));

        }


        //metado de esclha de armas
        public ArmasEnum EscolhaArmas() {
        Saida:
            Console.WriteLine(string.Format("\n{0,7}", "═════════════════════════════════════════╬══════════════════════════════════╬═══════════════════════════════════════════"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.WriteLine(string.Format("{0,77}", "║      ║   Escolha Sua Arma        ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.WriteLine(string.Format("{0,77}", "║      ║   1 - Espada              ║"));
            Console.WriteLine(string.Format("{0,77}", "║      ║   2 - Machado             ║"));
            Console.WriteLine(string.Format("{0,77}", "║      ║   3 - Arco                ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.Write(string.Format("\n{0,40}", "Escolha:"));

            string escolha = Console.ReadLine();
            switch (escolha) {
                case "1":
                    return ArmasEnum.Espada;
                case "2":
                    return ArmasEnum.Machado;
                case "3":
                    return ArmasEnum.Arco;
                default:
                    Console.Clear();
                    goto Saida;
            }
        }

        //metado de escolha de genero de personagem
        public GeneroEnum EscolhaGenero() {
        Saida:
            Console.WriteLine(string.Format("\n{0,7}", "═════════════════════════════════════════╬══════════════════════════════════╬═══════════════════════════════════════════"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.WriteLine(string.Format("{0,77}", "║  Escolha o Genero do Personagem  ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.WriteLine(string.Format("{0,77}", "║      ║   1 - Masculino           ║"));
            Console.WriteLine(string.Format("{0,77}", "║      ║   2 - Feminino            ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.Write(string.Format("\n{0,40}", "Escolha:"));
            string escolha = Console.ReadLine();
            switch (escolha) {
                case "1":
                    return GeneroEnum.masculino;
                case "2":
                    return GeneroEnum.feminino;
                default:
                    Console.Clear();
                    goto Saida;
            }

        }

        //metado de menu escolha de nome do personagem
        public static string EscolhaNome() {
            while (true) {
                
                Console.WriteLine(string.Format("\n{0,7}", "═════════════════════════════════════════╬══════════════════════════════════╬═══════════════════════════════════════════"));
                Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
                Console.WriteLine(string.Format("{0,77}", "║      ║   Digite Seu Nome         ║"));
                Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
                Console.Write(string.Format("\n{0,40}", "---->:"));

                string escolha = Console.ReadLine();

                if (escolha.Length > 30) {
                    Console.WriteLine("Nome inválido. Deve ter no máximo 30 caracteres.");
                    System.Threading.Thread.Sleep(300); // Espera 2 segundos antes de tentar novamente
                    continue;
                }

                if (!Regex.IsMatch(escolha, @"^[a-zA-Z\s]+$")) {
                    Console.Clear();
                    Console.WriteLine("Nome inválido. Deve conter apenas letras e espaços.");
                    System.Threading.Thread.Sleep(300); // Espera 2 segundos antes de tentar novamente
                    continue;
                }

                // Nome válido
                return escolha;
            }
        }

        //metado do botao de press star
        public void Start() {
            bool isVisible = true;
            ConsoleKeyInfo keyInfo;

            // Define a quantidade de tempo em milissegundos para o texto piscar
            int blinkInterval = 500;

            // Limpa a tela do console e esconde o cursor
            //Console.Clear();
            Console.CursorVisible = false;

            //Console.WriteLine("Pressione Enter para continuar...");

            // Calcula a posição para colocar o texto na última linha
            int lastLine = Console.WindowHeight - 2;
            int centerPosition = (Console.WindowWidth - "Press Start".Length) / 2;

            while (true) {
                // Alterna a visibilidade do texto
                if (isVisible) {
                    Console.SetCursorPosition(centerPosition, lastLine);
                    Console.Write("Press Start");
                }
                else {
                    Console.SetCursorPosition(centerPosition, lastLine);
                    Console.Write(new string(' ', "Press Start".Length)); // Espaços para "apagar" o texto
                }

                // Alterna o estado de visibilidade
                isVisible = !isVisible;

                // Espera pelo intervalo de piscada
                Thread.Sleep(blinkInterval);

                // Verifica se uma tecla foi pressionada
                if (Console.KeyAvailable) {
                    keyInfo = Console.ReadKey(true);
                    // Se for a tecla Enter, sai do loop
                    if (keyInfo.Key == ConsoleKey.Enter) {
                        break;
                    }
                }
            }

            // Restaura o cursor visível antes de sair
            Console.CursorVisible = true;
        }

    }
}
