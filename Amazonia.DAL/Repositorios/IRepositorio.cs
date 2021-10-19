using System.Collections.Generic;

namespace Amazonia.DAL.Repositorios
{

    //A interface é um contrato
    //Obriga todas as classes que implementam a ter no minimo estes emtodos
    interface IRepositorio<T>{
        void Criar(T obj);
        T ObterPorNome(string Nome);
        List<T> ObterTodos();
        T Atualizar(T obj);
        void Apagar();
    } 

}