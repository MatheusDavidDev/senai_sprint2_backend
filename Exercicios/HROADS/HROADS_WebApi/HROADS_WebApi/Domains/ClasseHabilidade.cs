using System;
using System.Collections.Generic;

#nullable disable

namespace HROADS_WebApi.Domains
{
    public partial class ClasseHabilidade
    {
        public int? IdClasse { get; set; }
        public int? IdHabilidade { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
