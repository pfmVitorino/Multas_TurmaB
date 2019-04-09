using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MultasB.Models
{
    public class Multas
    {

        [Key]
        public int ID { get; set; }

        public string Infracao { get; set; }

        public string LocalDaMulta { get; set; }

        public decimal ValorMulta { get; set; }

        public DateTime DataDaMulta { get; set; }


        // ************************************************
        // criação das chaves forasteiras
        // ************************************************


        // FK para Viaturas 
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; } // Base de dados

        public Viaturas Viatura { get; set; } // C#

        //  FK para Condutor

        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; } // Base de dados

        public Condutores Condutor { get; set; } // C#


        //  FK para Condutor

        [ForeignKey("Agente")]
        public int AgenteFK { get; set; } // Base de dados

        public Agentes Agente { get; set; } // C#









    }
}