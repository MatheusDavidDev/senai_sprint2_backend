using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SP_Medical_Grup.WebApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "Informe o id do paciente!")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "Informe o id do médico!")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "Informe a data ta consulta!")]
        public DateTime DataConsulta { get; set; }
        public string Situacao { get; set; }

        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
       
    }
}
