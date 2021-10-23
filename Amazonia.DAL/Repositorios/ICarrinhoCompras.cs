using Amazonia.DAL.Entidades;
using System.Collections.Generic;

namespace Amazonia.DAL.Repositorios{
interface ICarrinhoCompras
{
    decimal CalcularPreco(List<Livro> livros);

    decimal AplicarDesconto(int valorDesconto); //TODO: Criar regra Desconto
}
}