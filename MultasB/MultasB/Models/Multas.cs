using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultasB.Models
{
    public class Multas
    {


        public int Id { get; set; }

        public DateTime DataMulta { get; set; }

        public decimal ValorMulta  { get; set; }

        public string Descricao { get; set; }



    }
}