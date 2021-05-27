using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SP_Medical_Grup.WebApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Informe o usuário Paciente pelo seu ID!")]
        public int? IdUsuario { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        /*[Required(ErrorMessage = "Informe o Telefone do paciente!")]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "Digite o telefone correto!")]*/
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o RG do paciente!")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Digite o RG correto!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Informe o CPF do paciente!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Digite o CPF correto!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O endereço do paciente é obrigatório!")]
        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
