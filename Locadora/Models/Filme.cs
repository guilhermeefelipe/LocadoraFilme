using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Filme
    {
        [Key]
        public int cd_filme { get; set; }
        [Required(ErrorMessage = "Informe o Nome")]
        public string ds_nome { get; set; }
        [Required(ErrorMessage = "Informe a Data de Criação")]
        public DateTime dt_criacao { get; set; }
        public bool st_ativo { get; set; }
        public virtual List<Genero> Generos { get; set; }
        [NotMapped]
        public SelectListItem ids { get; set; }
    }
}
