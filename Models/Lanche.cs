using System.ComponentModel.DataAnnotations;

namespace App_Loucos_por_Acai.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        public int CategoriaId { get; set; }
        [StringLength(100)] //Data Annotation - VARCHAR Nome
        public string Nome { get; set; }
        [StringLength(250)] //Data Annotation - VARCHAR Descricao
        public string DescricaoComplementos { get; set; }
        public decimal Preco { get; set; }
        public bool IsLanchePreferido { get; set;}
        public bool EmEstoque { get; set;}
        public virtual Categoria Categoria { get; set; }
    }
}
