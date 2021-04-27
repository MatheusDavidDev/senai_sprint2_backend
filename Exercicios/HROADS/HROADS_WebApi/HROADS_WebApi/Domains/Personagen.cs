using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HROADS_WebApi.Domains
{
    public partial class Personagen
    {
        public Personagen()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }

        [Required(ErrorMessage = "O nome do personagem é obrigatorio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de Vida do seu personagem")]
        public int Vida { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de Mana do seu personagem")]
        public int Mana { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataDeAtualizacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataDeCriacao { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
