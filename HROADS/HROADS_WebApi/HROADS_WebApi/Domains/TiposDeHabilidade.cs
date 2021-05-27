using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HROADS_WebApi.Domains
{
    public partial class TiposDeHabilidade
    {
        public TiposDeHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipo { get; set; }

        [Required(ErrorMessage = "O nome do Tipo da Habilidade é obrigatorio!")]
        public string Nome { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
