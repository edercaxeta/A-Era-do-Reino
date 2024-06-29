using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//classe com textos dos NPCs chamadas durante o jogo
namespace Assets {
    public class TextosNPCs {

        //metado texto de escolha com quer falar
        public void VilaInteracao() {
            TypeText("\nChegando à vila você encontra três pessoas importantes:");
            TypeText("\nMentor: Um sábio ancião que oferece conselhos valiosos.");
            TypeText("\nLíder da Guilda: Responsável por oferecer missões e contratos.");
            TypeText("\nComerciante: Vende itens e equipamentos úteis para sua jornada.");


        }

        //metado de dialagos do mentor
        public void MentorInteraction() {
            string[] mentorDialogues =
        {
            "Jovem arqueiro. Sua jornada será longa e árdua, mas estou aqui para guiá-lo.",
            "A paciência e a sabedoria são tão importantes quanto a força e a habilidade, lembre-se disso.",
            "O verdadeiro poder vem da mente e do coração. Não subestime o poder do conhecimento.",
            "Cada desafio é uma oportunidade de crescimento. Aceite-os com coragem e determinação."
        };

            // Escolhe aleatoriamente um índice dentro do tamanho do array de diálogos
            int randomIndex = new Random().Next(mentorDialogues.Length);
            TypeText(mentorDialogues[randomIndex]);
        }

        //metado de escolha qual tipo de porçao comprar do comerciante
        public void MostrarItensComerciante() {
            TypeText("\nItens à venda:");
            // Aqui você pode listar os itens disponíveis para compra
            TypeText("1. Poção de Cura - 50 ouros");
            TypeText("2. Poção de Resistência - 30 ouros");
            // Adicione mais itens conforme necessário
        }


        //metado para realizar a impressao de letra por letra
        private static void TypeText(string text) {
            foreach (char c in text) {
                Console.Write(c);
                Thread.Sleep(1); // Pausa de 1 milissegundos entre cada caractere
            }
            Console.WriteLine(); // Adiciona uma nova linha ao final
        }



    }
}