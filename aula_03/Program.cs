using Assets;
using objetos;
using System;

class Program {
    static bool gameRunning = true;

    static void Main() {

        //instanciando Classes
        var audios = new Audio();
        var Decisoes = new Decisoes();
        var Textos = new Textos();
        var TextosNPCs = new TextosNPCs();

        audios.MusicaMenu();

        //Titulo do jogo
        Console.Title = "A Era Do Reino";

        //Selecionando a cor inicial
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();

        //Tela inicial
        Logos.LogoEra();
        Logos.LogoBrasao();
        Decisoes.Start();
        Console.Clear();

        //Tela da Historia do jogo
        Logos.LogoVila();
        Textos.Texto10();
        Textos.Texto8();
        Decisoes.Start();//chama metado de press start
        Console.Clear();

        //Menu Principal
        bool sairDoJogo = false;
        while (!sairDoJogo) {
            Logos.LogoPrincipal();
            Decisoes.MostrarMenu();
            string escolha = Console.ReadLine();

            switch (escolha) {
                case "1":
                    //Opçao New Game
                    Console.Clear();
                    Console.WriteLine("Loading..");
                    Console.Clear();
                    Jogo();//chama metado de iniciar o jog
                    break;
                case "2":
                    //Opçao Opitions
                    Console.Clear();
                    var menu = new Menu();
                    menu.Show(); // Chama o menu de opções
                    Console.Clear(); 
                    break;
                case "3":
                    //Opçao quit game
                    Console.Clear();
                    Console.WriteLine("Saindo do jogo...");
                    Logos.LogoFim();
                    sairDoJogo = true;
                    Decisoes.Start();//chama metado de press start
                    Console.Clear();
                    break;
                default:
                    //opçao invalida
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    break;
            }
        }
    }

    public static void Jogo() {
        //instanciando os objetos
        var Textos = new Textos();
        var Decisoes = new Decisoes();
        var TextosNPCs = new TextosNPCs();

        //tela escolha armas
        Textos.Texto1();
        Logos.Escudo();
        var Arma = Decisoes.EscolhaArmas();
        if (Arma == ArmasEnum.Espada) Textos.Texto2();
        else if (Arma == ArmasEnum.Arco) Textos.Texto3();
        else Textos.Texto4();
        Console.Clear();

        //tela escolha Genero dopersonagem
        Textos.Texto5();
        Logos.LogoPersonagem();
        var Genero = Decisoes.EscolhaGenero();
        if (Genero == GeneroEnum.masculino) Textos.Texto6();
        else Textos.Texto7();
        Console.Clear();

        //Tela escolha o nome do personagem
        Textos.Texto9();
        Logos.LogoNome();
        //instanciando o jogador
        var Jogador = new Jogador(Decisoes.EscolhaNome(), Genero, Arma, 10, 5);
        //instanciando o inimigo
        Random random = new Random();
        var Inimigo = new Inimigo((InimigosEnum)random.Next(0, 3), (RacaEnum)random.Next(0, 5), (ArmasEnum)random.Next(0, 3), Jogador);
        TypeText("Jogador: " + Jogador);
        TypeText("Inimigo: " + Inimigo);
        Console.WriteLine();
        Decisoes.Start();//chama metado de press start
        Console.Clear();

        //Chama a interação de jogo
        InteractionMenu(Jogador);
    }

    static void InteractionMenu(Jogador jogador) {
        //Intanciando Objetos
        var TextoNpc = new TextosNPCs();
        var Decisoes = new Decisoes();

        //Loop de decisão
        while (gameRunning && jogador.EstaVivo()) {
            //Instanciando obeto
            var TextosNPCs = new TextosNPCs();
            Console.Clear();
            //painel de experiencia do jogador
            Console.WriteLine($"\nExperiência Atual: {jogador.GetExperiencia()}                                           Total de Moedas: {jogador.GetOuro()}\n");
           
            //tela de interação do usuario
            Logos.LogoVila();
            TextosNPCs.VilaInteracao();
            TypeText("\nCom quem você deseja falar? (Mentor/Guilda/Comerciante/Treinar/Inicio):");

            string choice = Console.ReadLine().Trim().ToLower();
            //Condiçao de mentor
            if (choice == "mentor") {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"\nExperiência Atual: {jogador.GetExperiencia()}                                           Total de Moedas: {jogador.GetOuro()}\n");
                Console.WriteLine();
                //chama mentado de interaço com mentor/tela mentor
                TextoNpc.MentorInteraction();
                Logos.LogoMago();
                Console.WriteLine();
                Decisoes.Start();//chama metado de press start
            }
            //Condiçao de guilda
            else if (choice == "guilda") {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Logos.LogoGuilda();
                Console.WriteLine();
                //chama interação com mentor
                InteracaoGuilda(jogador);

                Console.WriteLine();
                Decisoes.Start();//chama metado de press start
                Console.SetCursorPosition(0, 0);
                Console.Clear();
                if (!jogador.EstaVivo()) {
                    // Após a derrota, mantenha gameRunning verdadeiro para continuar o loop de interação
                    gameRunning = true;
                    break;
                }
            }
            //Condiçao de Comerciante
            else if (choice == "comerciante") {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                MerchantInteraction(jogador);
            }
            //Condiçao de Treino
            else if (choice == "treinar") {
                Console.Clear();
                Logos.LogoBatalha();

                //intanciano o inimigo para treino
                Random random = new Random();
                var inimigo = new Inimigo((InimigosEnum)random.Next(0, 3), (RacaEnum)random.Next(0, 5), (ArmasEnum)random.Next(0, 3), jogador);
                Batalha(jogador, inimigo);
                if (!jogador.EstaVivo()) {
                    // Após a derrota, mantenha gameRunning verdadeiro para continuar o loop de interação
                    gameRunning = true;
                    break;
                }
                Console.WriteLine();
                Decisoes.Start();//chama metado de press start
                Console.Clear();
            }
            //Condiçao de retorno ao menu inicial
            else if (choice == "inicio") {
                TypeText("Você será redirecionado ao menu Inicial");
                gameRunning = true; // Define como verdadeiro para continuar o jogo
                Console.Clear();
                break;
            }
            //Condiçao de opçao invalida
            else {
                TypeText("Escolha inválida. Tente novamente.");
                Console.Clear();
            }
        }

        //Condição de jogador derrotado
        if (!jogador.EstaVivo()) {
            TypeText("Você foi derrotado e será redirecionado ao menu.");
            gameRunning = true; // Garante que o jogo continue após a derrota
            Console.Clear();
        }
    }

    //metado batalha
    static void Batalha(Jogador jogador, Inimigo inimigo) {
        //instanciando objeto
        var audios = new Audio();
        //aviso de começo de jogo
        TypeText($"O combate entre {jogador.Nome} e {inimigo.Nome} começa!");

        //loop da batalha
        while (jogador.EstaVivo() && inimigo.EstaVivo()) {
            int danoJogador = jogador.Atacar();
            inimigo.Vida -= danoJogador;
            TypeText($"{jogador.Nome} ataca {inimigo.Nome} causando {danoJogador} de dano. Vida restante de {inimigo.Nome}: {inimigo.Vida}");

            //se acaso o usuario ganhe
            if (!inimigo.EstaVivo()) {
                TypeText($"{inimigo.Nome} foi derrotado! {jogador.Nome} venceu!");
                jogador.GanharExperiencia(25);
                int ouroGanho = CalcularOuroGanho();
                jogador.GanharOuro(ouroGanho);
                break;
            }
            
            int danoInimigo = inimigo.Atacar();
            jogador.Vida -= danoInimigo;
            TypeText($"{inimigo.Nome} ataca {jogador.Nome} causando {danoInimigo} de dano. Vida restante de {jogador.Nome}: {jogador.Vida}");

            //condicional de derrota do usuario
            if (!jogador.EstaVivo()) {
                TypeText($"{jogador.Nome} foi derrotado! {inimigo.Nome} venceu!");
                break;
            }

            Thread.Sleep(1000);
        }

        //condicional de reevio ao meno inicial em caso de derrota
        if (!jogador.EstaVivo()) {
            TypeText("Você foi derrotado e será redirecionado ao menu.");
            gameRunning = true; // Permite continuar o jogo após a derrota
        }
    }

    //Metado para sorteio de ganhos de ouro
    static int CalcularOuroGanho() {
        Random rand = new Random();
        int ouroBase = rand.Next(10, 25); // Gera um número aleatório entre 10 e 25
        return ouroBase;
    }


    //metado interação da guilda
    static void InteracaoGuilda(Jogador jogador) {
        var Decisoes = new Decisoes();

        //Escolha de missoes
        TypeText("\nOlá, arqueiro. Tenho várias missões para você. Escolha uma para iniciar:");
        TypeText("\n1. Proteger uma caravana de comerciantes dos ataques dos bandidos.");
        TypeText("\n2. Derrotar um grupo de bandidos que está aterrorizando os arredores.");
        TypeText("\n3. Investigar e eliminar uma criatura misteriosa que foi avistada nas florestas próximas.");

        string choice = "";
        while (true) {
            Console.Write("\nEscolha uma missão (1/2/3): ");
            choice = Console.ReadLine().Trim();
            Console.Clear();

            //Condiçao de missao 1
            if (choice == "1") {
                Logos.LogoGuilda();

                //instanciando missao
                missoes missao = new missoes("Proteger a caravana", "Proteja uma caravana de comerciantes durante sua viagem pelas estradas perigosas.");
                TypeText($"\n   Você escolheu a missão '{missao.Nome}': {missao.Descricao}");
                Console.WriteLine();
                Decisoes.Start();//chama metado de press start

                Console.Clear();
                Logos.LogoBatalha();

                //instanciado inimigo
                Random random = new Random();
                var inimigo = new Inimigo((InimigosEnum)random.Next(0, 3), (RacaEnum)random.Next(0, 5), (ArmasEnum)random.Next(0, 3), jogador);
                Batalha(jogador, inimigo);

                break;
            }

            //condiçao de missao 2
            else if (choice == "2") {
                Logos.LogoBatalha();
                //instanciando missao
                missoes missao = new missoes("Derrotar os bandidos", "Localize e derrote um grupo de bandidos que tem aterrorizado os arredores da vila.");
                TypeText($"\nVocê escolheu a missão '{missao.Nome}': {missao.Descricao}");
                Console.WriteLine();
                Decisoes.Start();//chama metado de press start

                Console.Clear();
                Logos.LogoBatalha();

                //instanciado inimigo
                Random random = new Random();
                var inimigo = new Inimigo((InimigosEnum)random.Next(0, 3), (RacaEnum)random.Next(0, 5), (ArmasEnum)random.Next(0, 3), jogador);
                Batalha(jogador, inimigo);
                break;
            }

            //condição de missao 3
            else if (choice == "3") {
                Logos.LogoBatalha();
                //instanciando missao
                missoes missao = new missoes("Eliminar a criatura misteriosa", "Investigue e elimine uma criatura que está causando problemas nas florestas próximas.");
                TypeText($"\n  Você escolheu a missão '{missao.Nome}': {missao.Descricao}");
                Console.WriteLine();
                Decisoes.Start();//chama metado de press start

                Console.Clear();
                Logos.LogoBatalha();

                //instanciado inimigo
                Random random = new Random();
                var inimigo = new Inimigo((InimigosEnum)random.Next(0, 3), (RacaEnum)random.Next(0, 5), (ArmasEnum)random.Next(0, 3), jogador);
                Batalha(jogador, inimigo);

                break;
            }

            //condição de opção invalida
            else {
                Logos.LogoGuilda();
                TypeText("Escolha inválida. Tente novamente.");
            }
        }
    }


    //metado intaraço com comenciante
    static void MerchantInteraction(Jogador jogador) {
        //instanciando objetos
        var TextosNPCs = new TextosNPCs();
        var Decisoes = new Decisoes();

        //logo comerciante
        Logos.LogoComerciante();
        Console.Write("Resposta --> ");

        //condicional de escolha se quer realizar compra
        string escolha = Console.ReadLine().Trim().ToLower();
        if (escolha == "sim") {
            TextosNPCs.MostrarItensComerciante();

            TypeText("\nEscolha o número do item que deseja comprar (ou 'sair' para voltar):");
            string input = Console.ReadLine().Trim().ToLower();

            //Condicional de sair
            if (input == "sair") {
                TypeText("Saindo da loja.");
                
                return;
            }

            //Condicional de opçao de compras
            if (int.TryParse(input, out int numeroItem)) {
                ComprarItem(numeroItem, jogador);
            }

            //Condicional de opçao invalida
            else {
                TypeText("Opção inválida.");
            }
        }
        //condicional de nao comprar
        else {
            TypeText("Até mais, aventureiro!");
            Decisoes.Start();//chama metado de press start
        }
    }


    //metado de opçao de itens para compra
    static void ComprarItem(int numeroItem, Jogador jogador) {
        var Decisoes = new Decisoes();

        //condiçao de escolaha de item para compra
        switch (numeroItem) {
            case 1:
                //condiçao compra poçao de cura
                if (jogador.Ouro >= 50) {
                    jogador.GanharOuro(-50); // Reduz o ouro do jogador
                                             // Lógica para adicionar a poção de cura ao inventário do jogador, se aplicável
                    TypeText("Você comprou uma Poção de Cura.");
                    Decisoes.Start();//chama metado de press start
                }
                //condiçao nao ter ouro suficiente
                else {
                    TypeText("Você não tem ouro suficiente para comprar este item.");
                    Decisoes.Start();//chama metado de press start
                }
                break;
            case 2:
                //condiçao de poçao de rersistencia
                if (jogador.Ouro >= 30) {
                    jogador.GanharOuro(-30); // Reduz o ouro do jogador
                                             // Lógica para adicionar a poção de resistência ao inventário do jogador, se aplicável
                    TypeText("Você comprou uma Poção de Resistência.");
                    Decisoes.Start();//chama metado de press start
                }
                else {
                    TypeText("Você não tem ouro suficiente para comprar este item.");
                    Decisoes.Start();//chama metado de press start
                }
                break;
            default:
                //condiçao de opçao invalida
                TypeText("Opção inválida.");
                break;
        }
    }

    //metado para realizar a impressao de letra por letra
    static void TypeText(string text) {
        foreach (char c in text) {
            Console.Write(c);
            Thread.Sleep(1); // Pausa de 1 milissegundos entre cada caractere
        }
        Console.WriteLine();
    }
}
