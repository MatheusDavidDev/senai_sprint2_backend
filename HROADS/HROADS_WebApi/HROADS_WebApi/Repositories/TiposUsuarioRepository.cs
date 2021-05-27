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
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int id, TiposUsuario tiposAtualizado)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            if (tipoBuscado.Tipo != null)
            {
                tipoBuscado.Tipo = tiposAtualizado.Tipo;
            }

            ctx.TiposUsuarios.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTipos)
        {
            ctx.TiposUsuarios.Add(novoTipos);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoBuscado = ctx.TiposUsuarios.Find(id);

            ctx.TiposUsuarios.Remove(tipoBuscado);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }

        public List<TiposUsuario> ListarUsuarios()
        {
            return ctx.TiposUsuarios.Include(t => t.Usuarios).ToList();
        }
    }
}
