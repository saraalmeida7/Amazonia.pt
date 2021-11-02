using Amazonia.DAL.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Desconto
{
    public class DescontoCombinado : IDesconto
    {
        public decimal PercentualDesconto { get; set; }
        public int LivrosDigitais { get; set; }
        public int LivrosImpressos { get; set; }

        public List<Livro> LivrosCarrinho { get; set; }

        // se tiver pelo menos dois livros do tipo digital e pelo menos 1 impresso => aplicar x% de desconto
        public decimal Aplicar(decimal valorSemDesconto)
        {
            var qtdLivrosImpressos = LivrosCarrinho.Where(x => x.GetType() == typeof(LivroImpresso)).Count();
            var qtdLivrosDigitais = LivrosCarrinho.Where(x => x.GetType() == typeof(LivroDigital)).Count();

            if (qtdLivrosDigitais < LivrosDigitais || qtdLivrosImpressos < LivrosImpressos)
            {
                PercentualDesconto = 0;
            }

            var result = valorSemDesconto - (valorSemDesconto * (PercentualDesconto / 100));
            return result;
        }
    }
}
