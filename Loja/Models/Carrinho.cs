using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            if (this.Produtos == null) this.Produtos = new List<Produto>();

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
            Produto produto = Produtos.FirstOrDefault(p => p.Id == id);

            Produtos.Remove(produto);
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
