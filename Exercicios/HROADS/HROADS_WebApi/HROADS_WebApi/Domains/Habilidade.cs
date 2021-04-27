using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HROADS_WebApi.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public int? IdTipo { get; set; }

        [Required(ErrorMessage = "O nome da Habilidade é obrigatorio!")]
        public string Nome { get; set; }

        public virtual TiposDeHabilidade IdTipoNavigation { get; set; }
    }
}
