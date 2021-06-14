using System.Collections.Generic;
using App_Loucos_por_Acai;
using App_Loucos_por_Acai.Models;

namespace App_Loucos_por_Acai.Repositories
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }

        Lanche GetLancheById(int lancheId);
    }
}
