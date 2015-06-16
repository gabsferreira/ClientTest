using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    class Program
    {
        [Test]
        public void TestaQueAConexaoComOServidorFunciona()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:52603/api/carrinho");

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Assert.IsTrue(conteudo.Contains("Rua Vergueiro 3185"));
        }
    }
}
