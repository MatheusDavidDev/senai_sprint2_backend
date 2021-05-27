using HROADS_WebApi.Contexts;
using HROADS_WebApi.Domains;
using HROADS_WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HROADS_WebApi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int id, Personagen personagemAtualizada)
        {
            Personagen personagemBuscado = ctx.Personagens.Find(id);

            if (personagemBuscado.Nome != null)
            {
                personagemBuscado.IdClasse = personagemAtualizada.IdClasse;
                personagemBuscado.Nome = personagemAtualizada.Nome;
                personagemBuscado.Vida = personagemAtualizada.Vida;
                personagemBuscado.Mana = personagemAtualizada.Mana;
                personagemBuscado.DataDeAtualizacao = personagemAtualizada.DataDeAtualizacao = DateTime.Now;

            }

            ctx.Personagens.Update(personagemBuscado);

            ctx.SaveChanges();
        }

        public Personagen BuscarPorId(int id)
        {
            return ctx.Personagens.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Cadastrar(Personagen novoPersonagem)
        {
            ctx.Personagens.Add(novoPersonagem);

            novoPersonagem.DataDeAtualizacao = DateTime.Now;
            novoPersonagem.DataDeCriacao = DateTime.Now;

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagen personagemBuscado = ctx.Personagens.Find(id);

            ctx.Personagens.Remove(personagemBuscado);

            ctx.SaveChanges();
        }

        public List<Personagen> Listar()
        {
            return ctx.Personagens.ToList();
        }

        public List<Personagen> ListarUsuarios()
        {
            return ctx.Personagens.Include(p => p.Usuarios).ToList();
        }
    }
}