using sorteio.lib;

namespace sorteio.test;

public class TestSorteio
{

    [TestCase(90000000)]
    [TestCase(90000)]
    [TestCase(9)]
    public void TestSorteioEhIniciadoComValor(double valor)
    {
        Assert.DoesNotThrow(()=>{
            var sorteio = new Sorteio(valor);
            var premio = sorteio.getValorPremio();
            Assert.Positive(premio);
            Assert.NotZero(premio);
            Assert.AreEqual(premio, valor);
        });
    }
    
    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(-10000000)]
    public void TestSorteioEhIniciadoComValorNaoNegativo(double valor)
    {
        Assert.Catch(()=>{
            var sorteio = new Sorteio(valor);
        });
    }

    [Test]
    public void TestSorteioEhCapazDeReceberJogos()
    {
        var sorteio = new Sorteio(10);
        
        Assert.False(sorteio.ExisteParticipantes());
        
        sorteio.AddJogo(new Jogo(){
            CpfJogador = "222222222",
            NumerosJogados = new int[] {1,2,3,4,5,6}
        });

        Assert.True(sorteio.ExisteParticipantes());
        
    }
    [Test]
    public void TestSorteioNaoPermiteJogosComNumerosDuplicados()
    {
        var sorteio = new Sorteio(10);
        Assert.DoesNotThrow(()=>{

            sorteio.AddJogo(new Jogo(){
                CpfJogador = "222222222",
                NumerosJogados = new int[] {1,2,3,4,5,6}
            });

        });
        Assert.Catch(()=>{

            sorteio.AddJogo(new Jogo(){
                CpfJogador = "222222222",
                NumerosJogados = new int[] {1,1,3,4,5,6}
            });

        });
        
    }
    [Test]
    public void TestSorteioNaoPermiteJogosDifderentesDe6Numeros()
    {
        var sorteio = new Sorteio(10);
        Assert.DoesNotThrow(()=>{

            sorteio.AddJogo(new Jogo(){
                CpfJogador = "222222222",
                NumerosJogados = new int[] {1,2,3,4,5,6}
            });
        });
        Assert.Catch(()=>{

            sorteio.AddJogo(new Jogo(){
                CpfJogador = "222222222",
                NumerosJogados = new int[] {1,3,4,5,6}
            });

        });
        
    }
}