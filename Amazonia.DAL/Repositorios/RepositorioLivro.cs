using System.Collections.Generic;
using Amazonia.DAL.Entidades;
using System.Linq;

namespace Amazonia.DAL.Repositorios
{
    public class RepositorioLivro : IRepositorio<Livro>
    {

            public List<Livro> ListaLivros { get; set; }

            public RepositorioLivro(){
                ListaLivros = new List<Livro>();

                var livroHistorias = new LivroDigital{Nome = "historias", InformacoesLicenca="Gratuita"};
                var livroTerror = new AudioLivro{Nome = "Terror", DuracaoLivro = 6, FormatoFicheiro = "MP3"};
                var harryPotter = new LivroImpresso{Nome ="Harry Potter"};

                ListaLivros.Add(livroHistorias);
                ListaLivros.Add(livroTerror);
                ListaLivros.Add(harryPotter);

            //   var joao = new Cliente();
            // joao.Nome = "Joao";
            // joao.DataNascimento = new DateTime(1984,05,29);

            // var maria = new Cliente{Nome = "Maria", 
            //     DataNascimento = new DateTime(1950,01,01)};
            // var marta = new Cliente{Nome = "Marta", 
            //     DataNascimento = new DateTime(2021,01,02)};
        
        
            // ListaClientes.Add(joao);
            // ListaClientes.Add(maria);
            //ListaClientes.Add(marta);
        }

        public void Apagar(Livro obj)
        {
            ListaLivros.Remove(obj);
        }

        public Livro Atualizar(string nomeAntigo, string nomeNovo)
        {
           var livroTemporario = ListaLivros.
                                    Where(x => x.Nome == nomeAntigo).FirstOrDefault();
           livroTemporario.Nome = nomeNovo;
                
           return livroTemporario;
        }

        public void Criar(Livro obj)
        {
            ListaLivros.Add(obj);
        }

        public Livro ObterPorNome(string nome)
        {
            var resultado = ListaLivros.
                             Where(x => x.Nome == nome).FirstOrDefault();
            
            return resultado;

        }

        public List<Livro> ObterTodos()
        {
            return ListaLivros;
        }
    }

}