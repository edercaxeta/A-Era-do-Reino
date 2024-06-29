using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//classe NPC
namespace objetos {
    internal class Npc {
       
            public string? Nome { get; set; }
            public NpcEnum TipoNpc { get; set; }
           
            //metado construtor
            public Npc(string nome, NpcEnum tipoNpc) {
                Nome = nome;
                TipoNpc = tipoNpc;
            }
   
    }
}
