using Amazonia.DAL.Desconto;
using Amazonia.DAL.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Repositorios
{
    public class CarrinhoCompras : ICarrinhoCompras
    {
        public Cliente Cliente { get; set; }

        public List<Livro> Livros { get; set; }

        //public decimal AplicarDesconto(decimal valorDesconto)
        //{
        //    var fatorDesconto = 100M - valorDesconto/100;
        //    var valorCalculado = Livros.Sum(x => x.ObterPreco());
        //    var valorComDesconto = valorCalculado * fatorDesconto;


        //    return valorComDesconto;
        //}

        public decimal AplicarDesconto(IDesconto tipoDesconto)
        {
            var valorCalculado = Livros.Sum(x => x.ObterPreco());
            var valorComDesconto = tipoDesconto.Aplicar(valorCalculado);

            return valorComDesconto;
        }

        public decimal CalcularPreco()
        {
            var valorCalculado = 0M;

            //foreach(var item in livros)
            //{
            //    valorCalculado += item.ObterPreco();
            //}  

            valorCalculado = Livros.Sum(x => x.ObterPreco());

            return valorCalculado;
        }
    }
}
