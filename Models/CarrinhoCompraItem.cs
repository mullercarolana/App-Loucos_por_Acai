using System.ComponentModel.DataAnnotations;

namespace App_Loucos_por_Acai.Models
{
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set;}
        public Lanche Lanche { get; set;}
        public int Quantidade {get; set;}
        [StringLength(200)]
        public string CarrinhoCompraId { get; set;}
    }
}
