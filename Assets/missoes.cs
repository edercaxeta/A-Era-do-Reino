using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Assets {
    public class missoes {
        public int ervas { get; set; } = 0;
        public bool pocaoMago { get; set; } = false;

        public string Nome { get; }
        public string Descricao { get; }

        public missoes(string nome, string descricao) {
            Nome = nome;
            Descricao = descricao;
        }


        //missoes para serem implantadas futuramnte
        /*
        public bool AceitarMissao() {
            Console.WriteLine(" Você Aceita?");
            string resposta = Console.ReadLine();
            if (resposta.ToLower().Contains("aceito")
                && resposta.ToLower().Contains("sim")
                && !resposta.ToLower().Contains("nao aceito")  
                && !resposta.ToLower().Contains("não aceito")
                && !resposta.ToLower().Contains("recuso")
                && !resposta.ToLower().Contains("nao")
                && !resposta.ToLower().Contains("não")
                ) {
                Console.WriteLine("Missão Aceita");
                return true;
            }
            else {
                Console.WriteLine("Missão Negada");
                return false;
            }

        }
        public bool InicioColetaErva() {
            Console.WriteLine("Você envontrou com o grande mago ancião que necessita de suplementos para a produção de uma porção \n");
            Console.WriteLine("magica,");
            Console.WriteLine("Missão: ");
            Console.WriteLine(" Colete dez Ervas ");
            return AceitarMissao();
        }
        public bool FimColetaErva(int qtdErvas) {
            if (qtdErvas == 10)
            {
                Console.WriteLine("Parabéns Você Concluiu a Missão");
                Console.WriteLine("Você Recebeu a Poção do Mago");
                return true;
            }
            else
            {
                Console.WriteLine("Você Ainda Não Concluiu a Missão");
                return false;
            }
        }*/
    }
}
