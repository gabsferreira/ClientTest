using Loja.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Tests
{
    [TestClass]
    public class TestCarrinhoController
    {
        [TestMethod]
        public void TestaQueAConexaoComOServidorFunciona()
        {
            var controller = new CarrinhoController();

            var resultado = controller.Busca(1);

            Assert.IsNotNull(resultado);
        }
    }
}
