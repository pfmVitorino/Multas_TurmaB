using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultasB.Models
{
    public class Agentes
    {
        public Agentes() {

            ListaDeMultas = new HashSet<Multas>();

        }


        [Key] // identificação do atributo como primary key
        public int ID { get; set; }

        [Required]
       
        public string Nome { get; set; }

        [Required]
       
        public string Esquadra { get; set; }

        
        public string Fotografia { get; set; }

        /// <summary>
        /// lista das multas associadas ao Agente
        /// </summary>

        public virtual ICollection<Multas> ListaDeMultas { get; set; }
        // este termo ´virtual´vai ativar a funcionalidade de ´lazy loading´
    }
}