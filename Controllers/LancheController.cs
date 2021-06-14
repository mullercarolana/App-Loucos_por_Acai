using System.Collections.Generic;
using System.Linq;
using App_Loucos_por_Acai.Models;
using App_Loucos_por_Acai.Repositories;
using App_Loucos_por_Acai.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App_Loucos_por_Acai.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoria = "Todos os Açaís";
            }
            else
            {
                if (string.Equals("Pequeno", _categoria, System.StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Pequeno")).OrderBy(l => l.Nome);
                }
                else if (string.Equals("Médio", _categoria, System.StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Médio")).OrderBy(l => l.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals("Grande")).OrderBy(l => l.Nome);
                }

                categoriaAtual = _categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(lanchesListViewModel);
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Lanche> lanches;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(p => p.LancheId);
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(p => p.Nome.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel { Lanches = lanches, CategoriaAtual = "Todos os Tamanhos Procurados"});
        }
    }
}
