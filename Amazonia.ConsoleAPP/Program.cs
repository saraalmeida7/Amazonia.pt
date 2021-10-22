using System;
using Amazonia.DAL;
using Amazonia.DAL.Repositorios;
using Amazonia.DAL.Entidades;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consulta do Database");

            var repoLivro = new RepositorioLivro();
            var todosLivros = repoLivro.ObterTodos();

            foreach(var item in todosLivros){
                System.Console.WriteLine(item);
            }

            repoLivro.Criar(new LivroImpresso{Nome = "contos Infantis"});

            foreach(var item in todosLivros){
                System.Console.WriteLine(item);
            }

            repoLivro.Apagar(todosLivros.Find(x => x.Nome == "historias"));
            repoLivro.Atualizar("Terror", "MuitoTerror");

            foreach(var item in todosLivros){
                System.Console.WriteLine(item);
            }

            // var repo = new RepositorioCliente();
            // //var listaClientes = repo.ObterTodos();

            // var listaClientes = repo.ObterTodosQueComecemPor("J");

            // foreach (var cliente in listaClientes)
            // {
            //     System.Console.WriteLine(cliente);
            // }

            // var listaClientesAdultos = repo.ObterTodosQueTenhamPeloMenos18Anos();
            // foreach(var item in listaClientesAdultos)
            // {
            //     System.Console.WriteLine(item);
            // }

            //  var listagemTotal = repo.ObterTodos();

            // var joao = repo.ObterPorNome("Joao");
            // System.Console.WriteLine(joao);
            // System.Console.WriteLine($"Database contem: {listagemTotal.Count}");

            // repo.Apagar(joao);

            // System.Console.WriteLine($"Database contem: {listagemTotal.Count}");

            // var clienteNovo = repo.Atualizar(joao.Nome, )

        //     Console.WriteLine("Criacao de novos clientes no Database");

        //     do{
        //         var novoCliente = new Cliente();
        //         Console.WriteLine("Informe o nome");
        //         novoCliente.Nome = Console.ReadLine();
        //         repo.Criar(novoCliente);
        //         Console.WriteLine($"{novoCliente.Nome} Criado");
        //     } while(
        //         Console.ReadKey().Key != ConsoleKey.Tab
        //         );

        //     var listaClientesNovoseAntigos = repo.ObterTodos();

        //     foreach (var cliente in listaClientesNovoseAntigos)
        //     {
        //         System.Console.WriteLine(cliente);
        //     }
         }
    }
}
