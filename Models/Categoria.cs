using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace App_Loucos_por_Acai.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [StringLength(100)] //Data Annotation - VARCHAR CategoriaNome
        public string CategoriaNome { get; set; }
        public List<Lanche> Lanches { get; set; }
    }
}
