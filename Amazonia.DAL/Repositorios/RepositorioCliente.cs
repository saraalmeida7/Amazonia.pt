using System;
using System.Collections.Generic;
using System.Linq;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;

namespace Amazonia.DAL.Repositorios
{
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        private List<Cliente> ListaClientes;

        public RepositorioCliente(){
            ListaClientes = new List<Cliente>();

            var joao = new Cliente();
            joao.Nome = "Joao";
            joao.DataNascimento = new DateTime(1984,05,29);

            var maria = new Cliente{Nome = "Maria", 
                DataNascimento = new DateTime(1950,01,01)};
            var marta = new Cliente{Nome = "Marta", 
                DataNascimento = new DateTime(2021,01,02)};
        
        
            ListaClientes.Add(joao);
            ListaClientes.Add(maria);
            ListaClientes.Add(marta);
        }

        public void Apagar(Cliente obj)
        {
               if(obj == null)
                    throw new Exception("Ops");
                else
                     System.Console.WriteLine("Valor do objeto ["+obj+"]");

            try{
                System.Console.WriteLine("A apagar: "+obj);
                ListaClientes.Remove(obj);
            }
            catch(System.Exception){
                System.Console.WriteLine("Ops, não conheco essa pessoa");
            }
        }

         public Cliente Atualizar(string nomeAntigo, string nomeNovo)
        {
            var clienteTemporario = ObterPorNome(nomeAntigo);
            clienteTemporario.Nome = nomeNovo;

            return clienteTemporario;
        }

        public void Criar(Cliente obj)
        {
            ListaClientes.Add(obj);
        }

        public Cliente ObterPorNome(string Nome)
        {
            System.Console.WriteLine("ObterPorNome");
            return ListaClientes.Where(x => x.Nome == Nome)
                                .OrderByDescending(x => x.Idade)
                                .FirstOrDefault();
        }

        public List<Cliente> ObterTodos()
        {
            return ListaClientes;
        }

        public List<Cliente> ObterTodosQueComecemPor(string comeco) {
            System.Console.WriteLine("ObterTodosQueComecemPor");
             var resultado = ListaClientes
                            .Where(x => x.Nome.StartsWith(comeco))
                            .ToList();
            return resultado;
        }

          public List<Cliente> ObterTodosQueTenhamPeloMenos18Anos() {
            System.Console.WriteLine("ObterTodosQueTenhamPeloMenos18Anos");
             var resultado = ListaClientes
                            .Where(x => x.Idade >= 18)
                            .ToList();
            return resultado;
        }

        public List<Cliente> ObterTodosQueTenhamPeloMenos18AnosENomeComecePor (string comeco) {
             System.Console.WriteLine("ObterTodosQueTenhamPeloMenos18AnosENomeComecePor");
             var resultado = ListaClientes
                            .Where(
                                    x => x.Idade >= 18 && x.Nome.StartsWith(comeco)
                                  )
                            .ToList();
            return resultado;
        }

        public List<String> ObterNomeDeTodosQueTenhamPeloMenos18AnosENomeComecePor(string comeco) {
             
             System.Console.WriteLine("ObterNomeDeTodosQueTenhamPeloMenos18AnosENomeComecePor");
             var resultado = ListaClientes
                            .Where(
                                    x => x.Idade >= 18 && x.Nome.StartsWith(comeco)
                                  )
                            .Select(x => x.Nome)
                            .ToList();
            return resultado;
        }

        public void GerarRelatorio(IImpressora impressora)
        {
            impressora.Imprimir();
        }
    }

}