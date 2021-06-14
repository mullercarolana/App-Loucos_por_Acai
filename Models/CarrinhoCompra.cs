using System;
using System.Collections.Generic;
using System.Linq;
using App_Loucos_por_Acai.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App_Loucos_por_Acai.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _contexto;
        public CarrinhoCompra(AppDbContext contexto)
        {
            _contexto = contexto;
        }
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //DEFINE UMA SESSÃO
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //OBTEM UM SERVIÇO DO TIPO DO CONTEXTO
            var contexto = services.GetService<AppDbContext>();

            //OBTEM OU GERA O ID DO CARRINHO - GUID GERA UM IDENTIFICADOR ÚNICO DE 128 BITS
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //ATRIBUI O ID DO CARRINHO NA SESSÃO
            session.SetString("CarrinhoId", carrinhoId);

            //RETORNA O CARRINHO COM O CONTEXTO E O ID ATRIBUIDO OU OBTIDO
            return new CarrinhoCompra(contexto)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            //OBTEM O LANCHE DO CARRINHO
            var carrinhoCompraItem = _contexto.CarrinhoCompraItens.SingleOrDefault(s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

            //SE O CARRINHO FOR NULL - CRIAR UM NOVO CARRINHO
            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _contexto.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else 
            {
                carrinhoCompraItem.Quantidade++;
            }
            _contexto.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _contexto.CarrinhoCompraItens.SingleOrDefault(s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _contexto.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }

            _contexto.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ??
                   (CarrinhoCompraItens = _contexto.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                    .Include(s => s.Lanche)
                    .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _contexto.CarrinhoCompraItens.Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _contexto.CarrinhoCompraItens.RemoveRange(carrinhoItens);

            _contexto.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _contexto.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Select(c => c.Lanche.Preco * c.Quantidade).Sum();

            return total;
        }
    }
}
