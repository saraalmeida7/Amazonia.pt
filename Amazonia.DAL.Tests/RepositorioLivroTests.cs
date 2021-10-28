using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;
using Amazonia.DAL.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Tests
{
    [TestClass]
    public class RepositorioLivroTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void DeveCriarumObjetoTipoRepositorioLivros()
        {
            //Arrange
            RepositorioLivro repositorio;

            //Act
            repositorio = new RepositorioLivro();

            //Assert
            Assert.IsNotNull(repositorio);

        }

        [TestMethod]
        public void DeveCriarumaListaDeLivrosNoObjetoTipoRepositorioLivros()
        {
            //Arrange
            RepositorioLivro repositorio;
            List<Livro> livros;
            var minElementos = 1;

            //Act
            repositorio = new RepositorioLivro();
            livros = repositorio.ObterTodos();
            var quantidadeLivrosNoRepositorio = livros.Count;

            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            Assert.IsTrue(quantidadeLivrosNoRepositorio >= minElementos);

        }

        [Ignore]
        [TestMethod] //todo: modificar este teste quando a action estiver ok
        public void devecriarumalistadelivrosnoobjetotiporepositoriolivroscomfalha()
        {
            //arrange
            RepositorioLivro repositorio;
            List<Livro> livros;
            var quantidadeelementos = 4;

            //act
            repositorio = new RepositorioLivro();
            livros = repositorio.ObterTodos();
            var quantidadelivrosnorepositorio = livros.Count;

            //assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            //assert.istrue(quantidadelivrosnorepositorio >= minelementos);
            Assert.AreEqual(quantidadelivrosnorepositorio, quantidadeelementos);
        }

        [TestMethod]
        public void DeveApagarUmLivroDaLista()
        {
            var repo = new RepositorioLivro();
            var livros = repo.ObterTodos();
            var livrosApagar = livros.FirstOrDefault();

            var livrosInicialmente = livros.Count;
            repo.Apagar(livrosApagar);
            var livrosDepoisDeApagar = livros.Count;

            Assert.IsTrue(livrosInicialmente > livrosDepoisDeApagar);

        }

#if !DEBUG
        [Ignore]
#endif
        [TestMethod] 
        [ExpectedException(typeof(AmazoniaException))]
        public void DeveGerarExceptionQuandoTentaApagarLivroInexistente()
        {
            var repo = new RepositorioLivro();
            var livros = repo.ObterTodos();
            var livroInexistente = new LivroDigital();

            var livrosInicialmente = livros.Count;
            repo.Apagar(livroInexistente);
            var livrosDepoisDeApagar = livros.Count;

            Assert.IsTrue(livrosInicialmente > livrosDepoisDeApagar);

        }
    }
}
