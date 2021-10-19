namespace Amazonia.DAL{
public class Dimensoes
{
    //Altura em Centimetros
    public float Altura { get; set; }

    //Largura em centimetros
    public float Largura { get; set; }

    //Profundidade em Centimetros
    public float Profundidade { get; set; }

    //Peso em gramas
    public float Peso { get; set; }

    public float Volume => Largura * Altura * Profundidade;

}
}