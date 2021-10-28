using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades.Tests
{
    [TestClass()]
    public class ClienteTests
    {
        [TestMethod()]
        public void NifEstavalidoTest()
        {
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "269234950";

            var nifValido = cliente.NifEstavalido();

            Assert.IsTrue(nifValido);
        }


        [TestMethod()]
        public void DeveInvalirNifMaiorDoQue9Digitos()
        {
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "26923495";

            var nifInvalido = !cliente.NifEstavalido();

            Assert.IsTrue(nifInvalido);
        }
    }
}