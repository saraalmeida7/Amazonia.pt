using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Desconto;
using System.Configuration;

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
            var carrinho = new CarrinhoCompras { Livros = livrosFake };

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
            var carrinho = new CarrinhoCompras { Livros = livrosFake };

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
            var carrinho = new CarrinhoCompras { Livros = livrosFake };

            var valorEsperado = 114M;

            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [Ignore]
        [TestMethod()]
        public void AplicarDescontoTest()
        {
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras { Livros = livrosFake };

            var valorEsperado = 80M;
            var valorDesconto = 20;
            carrinho.Livros = livrosFake;

            var valorTotalAposDesconto = carrinho.AplicarDesconto(null); //nulo apenas para exemplo
          

            Assert.AreEqual(valorEsperado, valorTotalAposDesconto);
        }
        
        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualTest()
        {
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };


            var carrinho = new CarrinhoCompras { Livros = livrosFake };

            var valorEsperado = 80M;
            IDesconto desconto = new DescontoPercentual { PercentualDesconto = 20 };
  

            var valorTotalAposDesconto = carrinho.AplicarDesconto(desconto); 

            Assert.AreEqual(valorEsperado, valorTotalAposDesconto);
        }

        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualEDescontoCombinadoParaComparacaoTest()
        {
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" }
            };


            var carrinho = new CarrinhoCompras { Livros = livrosFake };

            IDesconto descontoPercentual = new DescontoPercentual { PercentualDesconto = 20 };
            var valorTotalAposDescontoPercentual = carrinho.AplicarDesconto(descontoPercentual);


            IDesconto descontoCombinado = new DescontoCombinado { PercentualDesconto = 20, LivrosCarrinho = livrosFake, LivrosDigitais = 1, LivrosImpressos = 2 };
            var valorTotalAposDescontoCombinado = carrinho.AplicarDesconto(descontoCombinado); 
        }

        [TestMethod()]
        public void AplicarDescontoAPartirConfigTest()
        {
            var livrosFake = new List<Livro>
            {
                new LivroImpresso { Preco = 60, Nome = "Impresso 01" },
                new LivroImpresso { Preco = 40, Nome = "Impresso 02" },
                new LivroDigital { Preco = 100, Nome = "Digital 01"}
            };


            var carrinho = new CarrinhoCompras { Livros = livrosFake };

            IDesconto desconto;

            var condicao = ConfigurationManager.AppSettings["RegraDescontoValida"] == "Percentual"; ; //Introducao à dependencia / Dependencia Inversa / Dependency Inversion
            
            if (condicao)
            {
                desconto = new DescontoPercentual
                {
                    PercentualDesconto = 10
                };
            }
            else
            {
                desconto = new DescontoCombinado
                {
                    PercentualDesconto = 20,
                    LivrosCarrinho = livrosFake,
                    LivrosDigitais = 1,
                    LivrosImpressos = 2
                };
            }


            var valorTotalAposDesconto = carrinho.AplicarDesconto(desconto);

            //Assert 
            if (condicao)
            {
                Assert.AreEqual(171, valorTotalAposDesconto);
            }
            else
            {
                Assert.AreEqual(152, valorTotalAposDesconto);
            }

        }

    }
}
