using Loja.DAO;
using Loja.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;

namespace Loja.Controllers
{
    public class CarrinhoController : ApiController
    {
        public HttpResponseMessage Get(long id)
        {
            try
            {
                Carrinho carrinho = new CarrinhoDAO().Busca(id);
                return Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch (KeyNotFoundException)
            {
                var mensagem = string.Format("Carrinho com id {0} não encontrado", id);
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
            }
        }

        public HttpResponseMessage Post([FromBody]Carrinho carrinho)
        {
            new CarrinhoDAO().Adiciona(carrinho);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

            string uri = Url.Link("DefaultApi", new { controller = "Carrinho", id = carrinho.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        [Route("api/carrinho/{id}/produtos/{produtoId}")]
        public HttpResponseMessage Delete([FromUri] long id, [FromUri]long produtoId)
        {
            Carrinho carrinho = new CarrinhoDAO().Busca(id);
            carrinho.Remove(produtoId);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [Route("api/carrinho/{id}/produtos/{produtoId}")]
        public HttpResponseMessage Put([FromBody] Produto produto, [FromUri] long id, [FromUri] long produtoId)
        {
            Carrinho carrinho = new CarrinhoDAO().Busca(id);

            carrinho.Troca(produto);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpPut]
        [Route("api/carrinho/{id}/produtos/{produtoId}/nome")]
        public HttpResponseMessage AlteraNomeProduto([FromBody] Produto produto, [FromUri] long id, [FromUri] long produtoId)
        {
            Carrinho carrinho = new CarrinhoDAO().Busca(id);

            carrinho.TrocaNome(produto);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
