namespace Amazonia.DAL.Entidades{
public class AudioLivro : Livro
{
    public string FormatoFicheiro { get; set; }

    public int DuracaoLivro { get; set; }

    public override string ToString() {
        return base.ToString() + $" Formato Ficheiro: {FormatoFicheiro} => Duracao: {DuracaoLivro}";
    }
}
}