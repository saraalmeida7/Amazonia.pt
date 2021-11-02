using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades
{
    public class LivroPeriodico : Livro
    {
        public DateTime DataLancamento { get; set; }

        public override Decimal ObterPreco()
        {
            var preco = base.Preco;
            var ativarPromocoes = Convert.ToBoolean(ConfigurationManager.AppSettings["ativarPromocoes"]);

            if (ativarPromocoes)
            {
                var numeroDiasDesconto = ConfigurationManager.AppSettings["numeroDiasDesconto"];
                var numeroDiasDescontoInt = Convert.ToInt32(numeroDiasDesconto);

                //DataLancamento > DateTime.Today.AddDays(numeroMinimoDias)
                if (DataLancamento < DateTime.Today.AddDays(-numeroDiasDescontoInt)) //40 > 2+30
                {
                    var desconto = ConfigurationManager.AppSettings["valorDesconto"];
                    var descontoStr = Convert.ToDecimal(desconto);
                    preco = ((100M - descontoStr) / 100M) * preco; // 100 - 5 = 95 / 100 = 0.95 * preco
                }
            }
               
            return preco;
        }


    }
}
