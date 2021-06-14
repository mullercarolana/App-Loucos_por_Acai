using System.Collections.Generic;
using App_Loucos_por_Acai.Models;

namespace App_Loucos_por_Acai.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches {get; set;}
        public string CategoriaAtual {get; set;}
    }
}
