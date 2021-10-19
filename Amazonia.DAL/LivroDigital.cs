namespace Amazonia.DAL{
public class LivroDigital : Livro
{
    public int TamanhoEmMB { get; set; }

    public string FormatoFicheiro { get; set; } // PDF, DOC, EPUB...

    public string InformacoesLicenca { get; set; }

    public override decimal ObterPreco(){
        return base.ObterPreco() * 0.90M;
    }

}
}