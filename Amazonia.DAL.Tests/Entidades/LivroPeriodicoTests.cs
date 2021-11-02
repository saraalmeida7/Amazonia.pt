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
    public class LivroPeriodicoTests
    {
        [TestMethod()]
        public void DeveObterParametrosPorConfiguraçãoTest()
        {
            var livroExemplo = new LivroPeriodico {
                Preco = 100,
                DataLancamento = DateTime.Today
            };

            var precoObtido = livroExemplo.ObterPreco();

            Assert.IsTrue(precoObtido > 0);
            
        }


        [TestMethod()]
        public void DeveObterPrecoLivroCom20DiasTest()
        {
            var livroExemplo = new LivroPeriodico
            {
                Preco = 100,
                DataLancamento = DateTime.Today.AddDays(-35)
            };

            var precoObtido = livroExemplo.ObterPreco();

            Assert.AreEqual(precoObtido, 100);

        }
    }

}