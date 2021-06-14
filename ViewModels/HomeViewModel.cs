using System.Collections.Generic;
using App_Loucos_por_Acai.Models;

namespace App_Loucos_por_Acai.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
