using Amazonia.DAL.Desconto;
using Amazonia.DAL.Entidades;
using System.Collections.Generic;

namespace Amazonia.DAL.Repositorios{
interface ICarrinhoCompras
{
    decimal CalcularPreco();

    decimal AplicarDesconto(IDesconto tipoDesconto); //TODO: Criar regra Desconto
}
}