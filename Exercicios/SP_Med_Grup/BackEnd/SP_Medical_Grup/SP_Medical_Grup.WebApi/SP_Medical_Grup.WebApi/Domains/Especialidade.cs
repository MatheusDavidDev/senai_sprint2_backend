using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SP_Medical_Grup.WebApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }

        [Required(ErrorMessage = "Informe a especialidade!")]
        public string TituloEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
