using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Locacao
    {
        [Key]
        public int cd_locacao { get; set; }
        public virtual List<Filme> ListaFilmes { get; set; }

        public string cpf { get; set; }
        public DateTime dt_locacao { get; set; }
    }
}
