using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HROADS_WebApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdPersonagem { get; set; }

        [Required(ErrorMessage = "O email do usuario é obrigatorio!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuario é obrigatorio!")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "A senha precisa ter no minimo 4 digitos")]       
        public string Senha { get; set; }

        public virtual Personagen IdPersonagemNavigation { get; set; }
        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
