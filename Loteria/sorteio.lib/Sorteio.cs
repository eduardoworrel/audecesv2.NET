namespace sorteio.lib;
public class Sorteio
{
    private int idealCount = 6;
    private double ValorPremio {get; set;}
    private List<Jogo> Jogos = new List<Jogo>();
    
    public Sorteio(double valorPremio)
    {
        
        if(valorPremio < 1){
            throw new Exception("Valor de premio inválido");
        }
        ValorPremio = valorPremio;
    }
    public void AddJogo(Jogo jogo)
    {

        if(jogo.NumerosJogados.Count() != 6){
            throw new Exception("Quantidade de números inválida");
        }

        var unicos = jogo.NumerosJogados.Distinct();
        if(unicos.Count() != idealCount){
            throw new Exception("Houve números repetidos");
        }
        
        Jogos.Add(jogo);
    }
    public double getValorPremio()
    {
        return ValorPremio;
    }
    public bool ExisteParticipantes()
    {
        return Jogos.Count() > 0;
    }
}
