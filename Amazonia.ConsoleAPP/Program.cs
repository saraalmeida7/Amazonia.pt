using System;
using Amazonia.DAL;
using Amazonia.DAL.Repositorios;

namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consulta do Database");

            var repo = new RepositorioCliente();
            var listaClientes = repo.ObterTodos();

            foreach (var cliente in listaClientes)
            {
                System.Console.WriteLine(cliente);
            }

            Console.WriteLine("Criacao de novos clientes no Database");

            do{
                var novoCliente = new Cliente();
                Console.WriteLine("Informe o nome");
                novoCliente.Nome = Console.ReadLine();
                repo.Criar(novoCliente);
                Console.WriteLine($"{novoCliente.Nome} Criado");
            } while(
                Console.ReadKey().Key != ConsoleKey.Tab
                );

            var listaClientesNovoseAntigos = repo.ObterTodos();

            foreach (var cliente in listaClientesNovoseAntigos)
            {
                System.Console.WriteLine(cliente);
            }
        }
    }
}
