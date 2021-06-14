using System.Collections.Generic;
using App_Loucos_por_Acai.Context;
using App_Loucos_por_Acai.Models;

namespace App_Loucos_por_Acai.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
