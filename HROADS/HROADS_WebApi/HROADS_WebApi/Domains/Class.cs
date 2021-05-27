using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HROADS_WebApi.Domains
{
    public partial class Class
    {
        public Class()
        {
            Personagens = new HashSet<Personagen>();
        }

        public int IdClasse { get; set; }

        [Required(ErrorMessage = "O nome da classe é obrigatorio!")]
        public string Nome { get; set; }

        public virtual ICollection<Personagen> Personagens { get; set; }
    }
}
