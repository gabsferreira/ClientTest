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
        public static void Main(string[] args)
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:52603/api/carrinho/1");

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            TestaGet();
        }

        public static async void TestaGet()
        {
            var url = "http://localhost:52603/api/carrinho/1";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var resposta = await client.GetAsync(url).ConfigureAwait(false);
            
        }

        public static void Teste()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");

            request.Method = "POST";

            WebResponse response = request.GetResponse();
           using (Stream responseStream = response.GetResponseStream()) {
               StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
           }

           Console.WriteLine(conteudo);
            Console.ReadLine();
        }
    }
}
