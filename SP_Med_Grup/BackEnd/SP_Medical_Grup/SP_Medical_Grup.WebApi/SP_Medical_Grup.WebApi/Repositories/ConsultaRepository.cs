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
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedGrupContext ctx = new SpMedGrupContext();

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            if (consultaBuscada != null)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;

                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;

                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            novaConsulta.Situacao = "Aguardando confirmação do agendamento";

            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Confirmação(int id, string status)
        {
            Consulta consultaBuscada = ctx.Consultas
                .Include(c => c.IdMedicoNavigation)
                .Include(c => c.IdPacienteNavigation)
                .FirstOrDefault(c => c.IdConsulta == id);

            switch (status)
            {
                case "1":
                    consultaBuscada.Situacao = "Agendada";
                    break;

                case "2":
                    consultaBuscada.Situacao = "Realizada";
                    break;

                default:
                    consultaBuscada.Situacao = consultaBuscada.Situacao;
                    break;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas
                .Include(c => c.IdMedicoNavigation)

                .Include(c => c.IdPacienteNavigation)

                .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)

                .Include(c => c.IdPacienteNavigation.IdUsuarioNavigation)

                .Include(c => c.IdMedicoNavigation.IdUsuarioNavigation)

                .Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    Situacao = c.Situacao,
                    Descricao = c.Descricao,

                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        Crm = c.IdMedicoNavigation.Crm,

                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario,
                            Nome = c.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                        },

                        IdEspecialidadeNavigation = new Especialidade
                        {
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                            TituloEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.TituloEspecialidade,
                        },
                    },

                    IdPacienteNavigation = new Paciente
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,

                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario,
                            Nome = c.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                        },
                    },

                }).ToList();

        }

        public List<Consulta> ListarMinhasConsultas(int id)
        {

            return ctx.Consultas
                .Include(c => c.IdMedicoNavigation)

                .Include(c => c.IdPacienteNavigation)

                .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)

                .Include(c => c.IdPacienteNavigation.IdUsuarioNavigation)

                .Include(c => c.IdMedicoNavigation.IdUsuarioNavigation)

                .Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    DataConsulta = c.DataConsulta,
                    Situacao = c.Situacao,
                    Descricao = c.Descricao,

                    IdMedicoNavigation = new Medico
                    {
                        IdMedico = c.IdMedicoNavigation.IdMedico,
                        IdUsuario = c.IdMedicoNavigation.IdUsuario,
                        Crm = c.IdMedicoNavigation.Crm,

                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario,
                            Nome = c.IdMedicoNavigation.IdUsuarioNavigation.Nome,
                        },

                        IdEspecialidadeNavigation = new Especialidade
                        {
                            IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                            TituloEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.TituloEspecialidade,
                        },
                    },

                    IdPacienteNavigation = new Paciente
                    {
                        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                        IdUsuario = c.IdPacienteNavigation.IdUsuario,

                        IdUsuarioNavigation = new Usuario
                        {
                            IdUsuario = c.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario,
                            Nome = c.IdPacienteNavigation.IdUsuarioNavigation.Nome,
                        },
                    },

                }).Where(c => c.IdPacienteNavigation.IdUsuario == id || c.IdMedicoNavigation.IdUsuario == id).ToList();
                
        }

        public void Prontuario(int id, string descricao)
        {
            Consulta consultaBuscada = BuscarPorId(id);

            if (consultaBuscada != null)
            {
                consultaBuscada.Descricao = descricao;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }
    }
}
