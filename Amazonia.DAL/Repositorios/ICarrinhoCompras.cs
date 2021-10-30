using Amazonia.DAL.Entidades;
using System.Collections.Generic;

namespace Amazonia.DAL.Repositorios{
interface ICarrinhoCompras
{
    decimal CalcularPreco();

    decimal AplicarDesconto(decimal valorDesconto); //TODO: Criar regra Desconto
}
}