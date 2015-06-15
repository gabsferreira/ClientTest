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
        static void Main(string[] args)
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            
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
