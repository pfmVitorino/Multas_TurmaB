using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultasB.Models
{
    public class Viaturas
    {



        public int ID { get; set; }

        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        public string NomeDono { get; set; }

        public string MoradaDono { get; set; }

        public string CodPostalDono { get; set; }


        //***********************************
        // lista das multas associadas á Viatura

        public ICollection <Multas>ListaDeMultas { get; set; }


    }
}