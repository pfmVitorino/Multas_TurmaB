using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultasB.Models
{
    public class Agentes
    {
        [Key] // identificação do atributo como primary key
        public int ID { get; set; }

        [Required (ErrorMessage ="O Nome é de preenchimento obrigatório")]
        [StringLength(50,ErrorMessage ="O {0} deve ter, no máximo, {1} caracteres")]
        [RegularExpression("ZÍÉÂÁ][a-z]+[a-záéíóúàèìòùâêîôûäëïöüãõç]+ [A-ZÍÉÂÁ][a-z]+[a-záéíóúàèìòùâêîôûäëïöüãõç]+(( | '|-| dos | da | de | e | d')[A-ZÍÉÂÁ][a-z] +[a-záéíóúàèìòùâêîôûäëïöüãõç]+[A-ZÍÉÂÁ][a-z]+[a-záéíóúàèìòùâêîôûäëïöüãõç]+){1, 3}",
            ErrorMessage ="O {0} so pode conter letras. Cada palavra deve começar por maiúscula.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A esquadra é de preenchimento obrigatório")]
        [StringLength(20, ErrorMessage = "A {0} deve ter, no máximo, {1} caracteres")]
        [RegularExpression("ZÍÉÂÁ][a-z]+[a-záéíóúàèìòùâêîôûäëïöüãõç]+ [A-ZÍÉÂÁ][a-z]+[a-záéíóúàèìòùâêîôûäëïöüãõç]+(( | '|-| dos | da | de | e | d')[A-ZÍÉÂÁ][a-z] +[a-záéíóúàèìòùâêîôûäëïöüãõç]+[A-ZÍÉÂÁ][a-z]+[a-záéíóúàèìòùâêîôûäëïöüãõç]+){1, 3}",
            ErrorMessage = "A {0} so pode conter letras. Cada palavra deve começar por maiúscula.")]
        public string Esquadra { get; set; }

        
        public string Fotografia { get; set; }

        /// <summary>
        /// lista das multas associadas ao Agente
        /// </summary>

        public ICollection<Multas> ListaDeMultas { get; set; }
    }
}