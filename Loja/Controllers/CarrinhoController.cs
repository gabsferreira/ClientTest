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
        [HttpGet]
        public Carrinho Busca(long id)
        {
            Carrinho carrinho = new CarrinhoDAO().Busca(id);
            return carrinho;
        }

        [HttpPost]
        public HttpResponseMessage Adiciona([FromBody]string conteudo)
        {
            StringReader StrReader = new StringReader(conteudo);
            XmlSerializer serializer = new XmlSerializer(typeof(Carrinho));
            XmlTextReader XmlReader = new XmlTextReader(StrReader);

            Carrinho objCarrinho = (Carrinho)serializer.Deserialize(XmlReader);
            XmlReader.Close();
            StrReader.Close();

            new CarrinhoDAO().Adiciona(objCarrinho);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

            string uri = Url.Link("DefaultApi", new { controller = "Carrinho", id = objCarrinho.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        [HttpDelete]
        [Route("api/carrinho/{id}/produtos/{produtoId}")]
        public HttpResponseMessage RemoveProduto([FromUri] long id, [FromUri]long produtoId)
        {
            Carrinho carrinho = new CarrinhoDAO().Busca(id);
            carrinho.Remove(produtoId);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
