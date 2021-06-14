using System.Linq;
using App_Loucos_por_Acai.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App_Loucos_por_Acai.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);

            return View(categorias);
        }
    }
}
