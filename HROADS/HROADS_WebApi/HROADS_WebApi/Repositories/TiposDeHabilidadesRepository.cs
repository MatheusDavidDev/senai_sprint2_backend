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
    public class TiposDeHabilidadesRepository : ITiposDeHabilidadesRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int id, TiposDeHabilidade tipoAtualizado)
        {
            TiposDeHabilidade tipoBuscado = ctx.TiposDeHabilidades.Find(id);

            if (tipoBuscado.Nome != null)
            {
                tipoBuscado.Nome = tipoAtualizado.Nome;
            }

            ctx.TiposDeHabilidades.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public TiposDeHabilidade BuscarPorId(int id)
        {
            return ctx.TiposDeHabilidades.FirstOrDefault(t => t.IdTipo == id);
        }

        public void Cadastrar(TiposDeHabilidade novoTipo)
        {
            ctx.TiposDeHabilidades.Add(novoTipo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposDeHabilidade tipoBuscado = ctx.TiposDeHabilidades.Find(id);

            ctx.TiposDeHabilidades.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public List<TiposDeHabilidade> Listar()
        {
            return ctx.TiposDeHabilidades.ToList();
        }

        public List<TiposDeHabilidade> ListarHabilidades()
        {
            return ctx.TiposDeHabilidades.Include(t => t.Habilidades).ToList();
        }
    }
}
