using Loja.DAO;
using Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Loja.Controllers
{
    public class CarrinhoController : ApiController
    {
        [HttpGet]
        public Carrinho Busca(long id)
        {
            Carrinho carrinho = new CarrinhoDAO().Busca(id);
            return carrinho;
        }
    }
}
