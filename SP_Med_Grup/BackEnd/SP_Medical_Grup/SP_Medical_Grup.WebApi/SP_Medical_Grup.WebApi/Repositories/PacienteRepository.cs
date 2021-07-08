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
    public class PacienteRepository : IPacienteRepository
    {
        SpMedGrupContext ctx = new SpMedGrupContext();

        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            if (pacienteBuscado != null)
            {
                pacienteBuscado.IdUsuario = pacienteAtualizado.IdUsuario;

                pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;

                pacienteAtualizado.Telefone = pacienteAtualizado.Telefone;

                pacienteAtualizado.Rg = pacienteAtualizado.Rg;

                pacienteAtualizado.Cpf = pacienteAtualizado.Cpf;

                pacienteAtualizado.Endereco = pacienteBuscado.Endereco;
            }

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pacientes.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes
                .Include(p => p.IdUsuarioNavigation)
                .Select(p => new Paciente
                {
                    IdPaciente = p.IdPaciente,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    Endereco = p.Endereco,

                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        Nome = p.IdUsuarioNavigation.Nome
                    }
                }).ToList();
        }
    }
}
