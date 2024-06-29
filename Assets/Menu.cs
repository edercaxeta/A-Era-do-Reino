using Assets;
using System;
using System.Threading;


// classe de options
public class Menu {
    private bool isAudioOn = true;
    private Audio audio;

    public Menu() {
        audio = new Audio();
        audio.MusicaMenu(); // Inicia a música quando o menu é criado
    }

    //painel principal do options
    public void Show() {
        while (true) {
            Console.Clear();
            Console.WriteLine(@"                               ╬═════════════════════════════════════════════════════╬
                               ║                                                     ║
                               ║                    S E T T I N G S                  ║
                               ╬═════════════════════════════════════════════════════╬
                               ║                                                     ║
                               ║ Background Music   [==========       ]              ║
                               ║                                                     ║
                               ║ Sound Effects      [========          ]             ║
                               ║                                                     ║
                               ║ Brightness         [=============     ]             ║
                               ║                                                     ║
                               ║ Vibration          [X]                              ║
                               ║                                                     ║
                               ║ Game Difficulty:  ( Easy ) ( Normal ) ( Hard )      ║
                               ║                                                     ║
                               ║          [ OK ]                   [ DEFAULT ]       ║
                               ╬═════════════════════════════════════════════════════╬
                                    ");

            //painel de esolha
            Console.WriteLine(string.Format("{0,7}", "═════════════════════════════════════════╬══════════════════════════════════╬═══════════════════════════════════════════"));
            Console.WriteLine(string.Format("{0,77}", "║      ║   Menus de Opções         ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.WriteLine(string.Format("{0,77}", "║ Press║     Choice                ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.WriteLine(string.Format("{0,77}", "║  1   ║ Desligar/ligar áudio      ║"));
            Console.WriteLine(string.Format("{0,77}", "║  2   ║ Trocar cor da tela        ║"));
            Console.WriteLine(string.Format("{0,77}", "║  3   ║ Voltar ao jogo            ║"));
            Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
            Console.Write(string.Format("\n{0,45}", "--> "));

            string choice = Console.ReadLine();

            //condicional de escolha opçao 
            switch (choice) {
                case "1":
                    //condiçao ligar/desligar audio
                    Console.Clear();
                    ToggleAudio();
                    break;
                case "2":
                    //condiçao de troca de cora da tela
                    Console.Clear();
                    ChangeScreenColor();
                    break;
                case "3":
                    //condiçao de retornoao menu inicial
                    Console.Clear();
                    return;
                default:
                    //condiçao de opçao invalida
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            // Esperar por 2 segundos antes de voltar ao menu
            Thread.Sleep(100);
        }
    }

    //metado de desligar e liga audio
    public void ToggleAudio() {
        Console.Clear();
        isAudioOn = !isAudioOn;
        if (isAudioOn) {
            audio.MusicaMenu();
            Console.WriteLine("Áudio ligado.");
            Console.Clear();
        }
        else {
            audio.PararMusica();
            Console.WriteLine("Áudio desligado.");
            Console.Clear();
        }
        Console.Clear();
     
    }

    //painel de escolha de cores
    private void ChangeScreenColor() {
        Console.Clear();

        Console.WriteLine(string.Format("{0,7}", "═════════════════════════════════════════╬══════════════════════════════════╬═══════════════════════════════════════════"));
        Console.WriteLine(string.Format("{0,77}", "║      ║   Escolha uma cor         ║"));
        Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
        Console.WriteLine(string.Format("{0,77}", "║ Press║     Choice                ║"));
        Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
        Console.WriteLine(string.Format("{0,77}", "║  1   ║ Vermelho                  ║"));
        Console.WriteLine(string.Format("{0,77}", "║  2   ║ Verde                     ║"));
        Console.WriteLine(string.Format("{0,77}", "║  3   ║ Azul                      ║"));
        Console.WriteLine(string.Format("{0,77}", "║  4   ║ Cinza                     ║"));
        Console.WriteLine(string.Format("{0,77}", "║  5   ║ Preto                     ║"));
        Console.WriteLine(string.Format("{0,77}", "║  6   ║ Branco                    ║"));
        Console.WriteLine(string.Format("{0,77}", "║  7   ║ Amarelo                   ║"));
        Console.WriteLine(string.Format("{0,77}", "║  8   ║ Roxo                      ║"));
        Console.WriteLine(string.Format("{0,77}", "╬══════╬═══════════════════════════╬"));
        Console.Write(string.Format("\n{0,45}", "--> "));

        string colorChoice = Console.ReadLine();

        //condiçao de escolha de cores
        switch (colorChoice) {
            case "1":
                //condiçao para tela vermelha
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "2":
                //condiçao de tela verde
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "3":
                //condiçao de tela azul
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "4":
                //condiçao de tela cinza
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case "5":
                //condiçao de tela preta
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "6":
                //condiçao de tela branca
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case "7":
                //condiçao de tela amarela
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "8":
                //condiçao de tela roxa
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            default:
                //condiçao de opçao invalida
                Console.WriteLine("Opção de cor inválida.");
                break;
        }

        // Limpar a tela para aplicar a cor
        Console.Clear();
        Console.WriteLine("Cor da tela alterada.");

        // Aguarde para que o usuário veja a mensagem antes de retornar ao menu
        Thread.Sleep(1000);

        // Limpar a tela novamente para evitar sujeira ao retornar ao jogo
        Console.Clear();
    }
}
