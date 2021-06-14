using System.Collections.Generic;
using App_Loucos_por_Acai.Models;

namespace App_Loucos_por_Acai.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
