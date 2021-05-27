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
    public class ClassRepository : IClassRepository
    {
        /// <summary>
        /// Objeto de onde vao vir os metodos EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int id, Class classeAtualizada)
        {
            Class classeBuscada = ctx.Classes.Find(id);

            if (classeBuscada.Nome != null)
            {
                classeBuscada.Nome = classeAtualizada.Nome;
            }

            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public Class BuscarPorId(int id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Class novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Class classeBuscado = ctx.Classes.Find(id);

            ctx.Classes.Remove(classeBuscado);

            ctx.SaveChanges();
        }

        public List<Class> Listar()
        {

            return ctx.Classes.ToList();
        }

        public List<Class> ListarPersonagens()
        {
            return ctx.Classes.Include(c => c.Personagens).ToList();
        }
    }
}
