using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SP_Medical_Grup.WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage = "O campo cnpj é obrigatório!")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Digite o cnpj correto!")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo RazaoSocial é obrigatório!")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O endereço da clinica é obrigatório!")]
        public string Endereco { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
