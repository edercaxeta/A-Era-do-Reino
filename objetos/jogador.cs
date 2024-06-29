using System;


//classe jogador
namespace objetos {
    public class Jogador {
        public string? Nome { get; set; }
        public GeneroEnum GeneroPersonagem { get; set; }
        public ArmasEnum Armas { get; set; }
        public double Vida { get; set; }
        public int Ouro { get; set; }
        public double Dano { get; set; }
        public int Nivel { get; set; }
        public int Experiencia { get; set; }
        public int ExperienciaParaSubirNivel { get; set; }


        //Metado construtor de Jogador
        public Jogador(string nome, GeneroEnum generoPersonagem, ArmasEnum armas, double vida, double dano) {
            Nome = nome;
            GeneroPersonagem = generoPersonagem;
            Armas = armas;
            Vida = vida;
            Dano = dano;
            Ouro = 0;
            Nivel = 1;
            Experiencia = 0;
            ExperienciaParaSubirNivel = 100;
        }

        //Metado atacar de jogador
        public int Atacar() {
            Random rand = new Random();
            return (int)Math.Round(Dano + rand.NextDouble() * 2);  // Adiciona um pouco de variação no dano
        }

        //metado para ganho de experiencia de jogador
        public void GanharExperiencia(int experiencia) {
            Experiencia += experiencia;
            //condiçao de experiencia 
            if (Experiencia >= ExperienciaParaSubirNivel) {
                Nivel++;
                Experiencia = Experiencia - ExperienciaParaSubirNivel;
                ExperienciaParaSubirNivel *= 2; // Próximo nível requer o dobro de experiência
                Console.WriteLine($"{Nome} subiu para o nível {Nivel}!");
            }
        }

        //metado para ganho de ouro de jogador
        public void GanharOuro(int quantidade) {
            Ouro += quantidade;
            Console.WriteLine($"{Nome} ganhou {quantidade} de ouro!");
        }

        //metado get de experiencia
        public int GetExperiencia() {
            return Experiencia;
        }

        //metado get de Ouro
        public int GetOuro() {
            return Ouro;
        }

        //metado consulta se estar vivo o jogador
        public bool EstaVivo() {
            return Vida > 0;
        }

        //metado polimorfismo do metado Tostring
        public override string ToString() {
            return $"Nome: {Nome}, Genero: {GeneroPersonagem}, Armas: {Armas}, Vida: {Vida}, Dano: {Dano}, Ouro: {Ouro}, Nivel: {Nivel}, Experiencia: {Experiencia}, ExperienciaParaSubirNivel: {ExperienciaParaSubirNivel}";
        }
    }
}
