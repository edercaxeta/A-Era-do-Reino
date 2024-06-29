using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


//classe com alguns dialagos do jogo
namespace Assets {
    public class Textos {


        // Messagem Inicial
        public void Texto1() {
            Console.WriteLine(string.Format("\n{0,93}", "Você é um arqueiro destemido em busca de fama, fortuna e glória."));
            Console.WriteLine(string.Format("\n{0,100}", "Ao chegar na vila de Grifinória, você logo se depara com sua primeira aventura."));
            Console.WriteLine(string.Format("\n{0,95}", "Os desafios serão difíceis, então escolha sua arma com sabedoria.\n"));

        }


        // Escolha de armas
        public void Texto2() {
            TypeText("Você Escolheu a Espada");
            Thread.Sleep(1200);
        }

        public void Texto3() {
            TypeText("Você Escolheu o Arco");
            Thread.Sleep(1200);
        }
        public void Texto4() {
            TypeText("Você Escolheu o Machado");
            Thread.Sleep(1200);
        }


        // Escolha de genero
        public void Texto5() {
            TypeText("\nEscolha o Genero do Personagem");
        }

        public void Texto6() {
            TypeText("\nO Genero Escolhido Foi Masculino");
            Thread.Sleep(1200);
        }

        public void Texto7() {
            TypeText("\nO Genero Escolhido Foi Feminino");
            Thread.Sleep(1200);
        }

        public void Texto9() {
            TypeText("\nEscolha o nome do Personagem\n\n\n");
        }

        public void Texto10() {
            Console.WriteLine(string.Format("\n{0,7}", "═════════════════════════════════════════╬══════════════════════════════════╬═══════════════════════════════════════════"));

        }

        //metado texto historia do jogo/ incluindo a funçao de justifiacr o texto
        public static void Texto8() {
            string texto = @"Em um mundo repleto de reinos em conflito e mistérios profundos, onde a honra é  conquistada com a 
lâmina da espada e o silêncio do arco, uma nova lenda está prestes a nascer.Você é Arqueiro, um guerreiro destemido,
em busca de fama, fortuna e glória. Sua jornada épica começa aqui, nesta pequena aldeia. do por um sábio ancião, 
você descobrirá artefatos valiosos e enfrentará inimigos temíveis., No coração da guilda, missões desafiadoras
e contratos lucrativos esperam por você.  Mas cuidado... um vilão misterioso está sempre um passo à sua frente.
Equipe-se com espadas, arcos, lanças e escudos. Poções de cura, resistência e elixires mágicos estarão à sua disposição.
Explore florestas densas, vilas misteriosas, montanhas imponentes e desertos áridos em busca de aventuras. Complete
missões, obtenha recompensas valiosas e influencie o destino do reino através de suas escolhas. Personalize seu Arqueiro
com armas, armaduras, acessórios e habilidades especiais para se adaptar ao seu estilo de jogo. Viaje a pé ou a cavalo,
desbravando áreas inexploradas e enfrentando os desafios que surgirem em seu caminho. 
Repita missões, aumente seu poder e riqueza, e torne-se uma lenda na Era do Reino.";

            int larguraConsole = Console.WindowWidth;
            List<string> linhas = QuebrarTextoEmLinhas(texto, larguraConsole);
            List<string> linhasJustificadas = JustificarLinhas(linhas, larguraConsole);
            ImprimirLinhasCentralizadas(linhasJustificadas, larguraConsole);
        }

        static List<string> QuebrarTextoEmLinhas(string texto, int largura) {
            var linhas = new List<string>();
            var palavras = texto.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var linhaAtual = new StringBuilder();

            foreach (var palavra in palavras) {
                if (linhaAtual.Length + palavra.Length + 1 > largura) {
                    linhas.Add(linhaAtual.ToString());
                    linhaAtual.Clear();
                }
                if (linhaAtual.Length > 0)
                    linhaAtual.Append(' ');
                linhaAtual.Append(palavra);
            }

            if (linhaAtual.Length > 0)
                linhas.Add(linhaAtual.ToString());

            return linhas;
        }

        //metado de justificaçao
        static List<string> JustificarLinhas(List<string> linhas, int largura) {
            var linhasJustificadas = new List<string>();

            foreach (var linha in linhas) {
                if (linha.Length == largura) {
                    linhasJustificadas.Add(linha);
                    continue;
                }

                var palavras = linha.Split(' ');
                if (palavras.Length == 1) {
                    linhasJustificadas.Add(linha);
                    continue;
                }

                int espacosTotais = largura - linha.Replace(" ", "").Length;
                int espacosEntrePalavras = espacosTotais / (palavras.Length - 1);
                int espacosExtras = espacosTotais % (palavras.Length - 1);

                var linhaJustificada = new StringBuilder();
                for (int i = 0; i < palavras.Length - 1; i++) {
                    linhaJustificada.Append(palavras[i]);
                    linhaJustificada.Append(' ', espacosEntrePalavras + (i < espacosExtras ? 1 : 0));
                }
                linhaJustificada.Append(palavras[^1]);

                linhasJustificadas.Add(linhaJustificada.ToString());
            }

            return linhasJustificadas;
        }

        //metado para centraliza texto
        static void ImprimirLinhasCentralizadas(List<string> linhas, int largura) {
            foreach (var linha in linhas) {
                int espacosEsquerda = (largura - linha.Length) / 2;
                TypeText(new string(' ', espacosEsquerda) + linha);
            }
        }


        //metado para realizar a impressao de letra por letra
        private static void TypeText(string text) {
            foreach (char c in text) {
                Console.Write(c);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                while (watch.Elapsed.TotalMilliseconds < 0.95) {
                    // Espera até que 0.5 milissegundo se passe
                }
            }
            Console.WriteLine(); // Adiciona uma nova linha ao final
        }

    }


}



