namespace Amazonia.DAL.Entidades{
public class LivroImpresso : Livro
{
    public int QuantidadePaginas { get; set; }

    public Dimensoes Dimensoes { get; set; }

    public override string ToString(){
        return $"Nome: {Nome}";
    }
}
}