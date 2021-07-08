using Microsoft.EntityFrameworkCore;
using SP_Medical_Grup.WebApi.Contexts;
using SP_Medical_Grup.WebApi.Domains;
using SP_Medical_Grup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Grup.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedGrupContext ctx = new SpMedGrupContext();

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            if (medicoBuscado != null)
            {
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;

                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;

                medicoBuscado.IdClinica = medicoAtualizado.IdClinica;

                medicoBuscado.Crm = medicoAtualizado.Crm;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
           Medico medicoBuscado = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos
                .Include(m => m.IdEspecialidadeNavigation)

                .Include(m => m.IdUsuarioNavigation)

                .Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    Crm = m.Crm,

                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = m.IdUsuarioNavigation.IdUsuario,
                        Nome = m.IdUsuarioNavigation.Nome
                    },

                    IdEspecialidadeNavigation = new Especialidade
                    {
                        IdEspecialidade = m.IdEspecialidadeNavigation.IdEspecialidade,
                        TituloEspecialidade = m.IdEspecialidadeNavigation.TituloEspecialidade
                    },

                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = m.IdClinicaNavigation.IdClinica,
                        RazaoSocial = m.IdClinicaNavigation.RazaoSocial
                    }

                }).ToList();
        }

    }
}
