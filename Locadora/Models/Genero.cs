using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Genero
    {
        [Key]
        public int cd_genero { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string ds_nome { get; set; }

        public DateTime dt_criacao { get; set; }
        public bool st_ativo { get; set; }
    }
}
