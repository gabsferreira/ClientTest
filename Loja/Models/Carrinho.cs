using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Models
{
    public class Carrinho
    {
        public List<Produto> Produtos { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public long Id { get; set; }

        public Carrinho Adiciona(Produto produto)
        {
            this.Produtos.Add(produto);
            return this;
        }

        public Carrinho Para(string rua, string cidade)
        {
            this.Rua = rua;
            this.Cidade = cidade;
            return this;
        }

        public void Remove(long id)
        {
            foreach (var produto in Produtos)
            {
                if(produto.Id == id)
                {
                    Produtos.Remove(produto);
                }
            }
        }

        public void Troca(Produto produto)
        {
            Remove(produto.Id);
            Adiciona(produto);
        }

        public void TrocaQuantidade(Produto produto)
        {
            foreach (var item in Produtos)
            {
                if(item.Id == produto.Id)
                {
                    item.Quantidade = produto.Quantidade;
                }
            }
        }

    }
}
