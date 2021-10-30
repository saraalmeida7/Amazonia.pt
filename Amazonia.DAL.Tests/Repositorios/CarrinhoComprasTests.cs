using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorios.Tests
{
    [TestClass()]
    public class CarrinhoComprasTests
    {
        [TestMethod()]
        public void CalcularPrecoTest()
        {
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 10, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 20, Nome = "Impresso 02" },
                new LivroImpresso { Preco = 30, Nome = "Impresso 03" }
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 60M;

            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisTest()
        {
            var livrosFake = new List<Livro>
            {
                new LivroDigital { Preco = 10, Nome = "Digital 01" },
                new LivroDigital { Preco = 20, Nome = "Digital 02" },
                new LivroDigital { Preco = 30, Nome = "Digital 03" }
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 54M;

            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisEImpressosTest()
        {
            var livrosFake = new List<Livro>
            {
                new LivroDigital { Preco = 10, Nome = "Digital 01" },
                new LivroDigital { Preco = 20, Nome = "Digital 02" },
                new LivroDigital { Preco = 30, Nome = "Digital 03" },
                new LivroImpresso { Preco = 10, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 20, Nome = "Impresso 02" },
                new LivroImpresso { Preco = 30, Nome = "Impresso 03" }
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 114M;

            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void AplicarDescontoTest()
        {
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 80M;
            var valorDesconto = 20;
            carrinho.Livros = livrosFake;

            var valorTotalAposDesconto = carrinho.AplicarDesconto(valorDesconto);
          

            Assert.AreEqual(valorEsperado, valorTotalAposDesconto);
        }
    }
}
