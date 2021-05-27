using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SP_Medical_Grup.WebApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }

        [Required(ErrorMessage = "Informe o usuário médico pelo seu ID!")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe a especialidade do médico pelo ID!")]
        public int? IdEspecialidade { get; set; }

        [Required(ErrorMessage = "Informe a clinica do médico pelo ID!")]
        public int? IdClinica { get; set; }

        [Required(ErrorMessage = "Digite o crm do médico!")]
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
