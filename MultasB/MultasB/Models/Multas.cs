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

        [Display(Name ="Local da Multa")]
        public string LocalDaMulta { get; set; }
        [Display(Name = "Valor da Multa")]
        public decimal ValorMulta { get; set; }
        [Display(Name = "Data da Multa")]
        public DateTime DataDaMulta { get; set; }


        // ************************************************
        // criação das chaves forasteiras
        // ************************************************


        // FK para Viaturas 
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; } // Base de dados

        public virtual Viaturas Viatura { get; set; } // C#

        //  FK para Condutor

        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; } // Base de dados

        public virtual Condutores Condutor { get; set; } // C#


        //  FK para Condutor

        [ForeignKey("Agente")]
        public int AgenteFK { get; set; } // Base de dados

        public virtual Agentes Agente { get; set; } // C#









    }
}