using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Amazonia.DAL.Utils.Tests
{
    [TestClass()]
    public class ExemploTests
    {
        [Ignore]
        [TestMethod()]
        public void ObterValorDoConfigTest()
        {
            var valorEsperado = "lida do app.config dos testes";

            var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");

            Assert.AreEqual(valorEsperado, valorObtidoPeloMetodo);
        }
    }
}