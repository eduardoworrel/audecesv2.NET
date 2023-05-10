namespace consoleapp.lib;
public class Trafego
{
    
    public static List<Voo> defineHorariosDeAterrisagem(List<Voo> voosDesteAeroporto)
    {
        var listaFinal = new List<Voo>();

        var voosDoMaisRecente = voosDesteAeroporto.OrderBy(e => e.PreferenciaDePouso).ToArray();
        
        for(var i = 0; i < voosDoMaisRecente.Count(); i++)
        {
            var vooEmQuestao = voosDoMaisRecente[i];
            if(i == 0)
            {
                vooEmQuestao.PousoAlocado = vooEmQuestao.PreferenciaDePouso;
            }else
            {
                var vooAnterior = voosDoMaisRecente[i - 1];
                AlocaVoo(vooEmQuestao, vooAnterior);
            }
            
        }
        return listaFinal;

    }
    private static void AlocaVoo(Voo vooEmQuestao, Voo vooAnterior)
    {
        
        var possuiConflito = estaConflitando(vooEmQuestao, vooAnterior);
        if(!possuiConflito)
        {
            vooEmQuestao.PousoAlocado = vooEmQuestao.PreferenciaDePouso;
        }else{
             int valorQueFalta = ObtemDistanciaParaResolverConflito(vooEmQuestao, vooAnterior);
            var dataHoraValida = vooEmQuestao.PreferenciaDePouso.AddMinutes(valorQueFalta);
            vooEmQuestao.PousoAlocado = dataHoraValida;
        }
       
    }
    public static int ObtemDistanciaParaResolverConflito(Voo principal, Voo comparado)
    {
        
        int minutosDeDiferencaSeguro = 20;

        var distancia = comparado.PousoAlocado - principal.PreferenciaDePouso ?? new TimeSpan(0);
        
        var minutosConflitantes = distancia.TotalMinutes;

        return (int) Math.Ceiling(minutosDeDiferencaSeguro - minutosConflitantes);
        
    }
    public static bool estaConflitando(Voo principal, Voo comparado)
    {
        int minutosDeDiferencaSeguro = 20;

        var min = principal.PreferenciaDePouso.AddMinutes(-minutosDeDiferencaSeguro);
        var max = principal.PreferenciaDePouso.AddMinutes(minutosDeDiferencaSeguro);
        
        if(comparado.PousoAlocado == null){
            return false;
        }

        if(comparado.PousoAlocado >= min
            && comparado.PousoAlocado <= max )
        {
            return true;
        }
        return false;
    }

}
