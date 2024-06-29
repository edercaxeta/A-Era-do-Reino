using System;

namespace objetos {
    public class Inimigo {
        public string? Nome { get; set; }
        public InimigosEnum TipoInimigo { get; set; }
        public RacaEnum Raca { get; set; }
        public ArmasEnum Armas { get; set; }
        public double Vida { get; set; }
        public double Dano { get; set; }
        public int Nivel { get; set; }

        //metado construto de inimigo
        public Inimigo(InimigosEnum tipoInimigo, RacaEnum raca, ArmasEnum armas, Jogador jogador) {
            Raca = raca;
            Nome = raca.ToString() + " " + tipoInimigo.ToString();
            TipoInimigo = tipoInimigo;
            Armas = armas;

            double multiplicadorDano = 2;
            double multiplicadorDanoTipoInimigo = 2;
            double multiplicadorVida = 2;
            double multiplicadorVidaTipoInimigo = 2;

            //condicional de multiplicar de dano e vida do raca inimigo
            if (raca == RacaEnum.Elfo) {
                multiplicadorDanoTipoInimigo = 1.5;
                multiplicadorVidaTipoInimigo = 1.5;
            }
            //condicional de multiplicar de dano e vida do raca inimigo
            if (raca == RacaEnum.Goblin) {
                multiplicadorDanoTipoInimigo = 1.2;
                multiplicadorVidaTipoInimigo = 1.3;
            }
            //condicional de multiplicar de dano e vida do raca inimigo
            if (raca == RacaEnum.Morto_Vivo) {
                multiplicadorDanoTipoInimigo = 1.9;
                multiplicadorVidaTipoInimigo = 0.9;
            }
            //condicional de multiplicar de dano e vida do raca inimigo
            if (raca == RacaEnum.Humano) {
                multiplicadorDanoTipoInimigo = 1.4;
                multiplicadorVidaTipoInimigo = 1.4;
            }
            //condicional de multiplicar de dano e vida do raca inimigo
            if (raca == RacaEnum.Orc) {
                multiplicadorDanoTipoInimigo = 1.9;
                multiplicadorVidaTipoInimigo = 1.9;
            }


            //condicional de multiplicar de dano e vida das arma
            if (armas == ArmasEnum.Espada) {
                multiplicadorDano = 1.2;
                multiplicadorVida = 1.6;
            }
            //condicional de multiplicar de dano e vida das arma
            if (armas == ArmasEnum.Arco) {
                multiplicadorDano = 1.4;
                multiplicadorVida = 1.3;
            }
            //condicional de multiplicar de dano e vida das arma
            if (armas == ArmasEnum.Machado) {
                multiplicadorDano = 1.4;
                multiplicadorVida = 1.2;
            }

            //condicional de multiplicar de dano Tipo inimigo
            if (tipoInimigo == InimigosEnum.cavaleiro)
                if (armas == ArmasEnum.Machado || armas == ArmasEnum.Arco)
                    multiplicadorDano = 0.8;
            if (tipoInimigo == InimigosEnum.mago)
                if (armas == ArmasEnum.Espada || armas == ArmasEnum.Arco)
                    multiplicadorDano = 0.4;

            Vida = Math.Round(5 * jogador.Nivel * multiplicadorVida * multiplicadorVidaTipoInimigo);
            Dano = Math.Round(2 * jogador.Nivel * multiplicadorDano * multiplicadorDanoTipoInimigo);
            if (Dano <= 0) {
                Dano = 1;
            }
            Nivel = 1;
        }

        //metado de ataque 
        public int Atacar() {
            Random rand = new Random();
            return (int)Math.Round(Dano + rand.NextDouble() * 2);  // Adiciona um pouco de variação no dano
        }

        //metado de consulta se esta vivo
        public bool EstaVivo() {
            return Vida > 0;
        }

        //metado polimorfismo do metado Tostring
        public override string ToString() {
            return $"Nome: {Nome}, Tipo: {TipoInimigo}, Raça: {Raca}, Armas: {Armas}, Vida: {Vida}, Dano: {Dano}, Nivel: {Nivel}";
        }
    }
}
