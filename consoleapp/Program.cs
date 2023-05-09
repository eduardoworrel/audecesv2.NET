
var voosDesteAeroporto = new List<Voo>()
{
    new Voo{
        Name = "Boing 876",
        PreferenciaDePouso = DateTime.Now.AddHours(4),
    },
    new Voo{
        Name = "Air Bus 9000",
        PreferenciaDePouso = DateTime.Now.AddHours(5),
    },
    
    new Voo{
        Name = "Air Taxi 9001",
        PreferenciaDePouso = DateTime.Now.AddHours(8),
    },
};

var voosAlocados = defineHorariosDeAterrisagem(voosDesteAeroporto);



int minutosDeDiferencaSeguro = 20;

static void defineHorariosDeAterrisagem(List<Voo> voosDesteAeroporto)
{
    var voosDoMaisRecente = voosDesteAeroporto.OrderBy(e => e.PreferenciaDePouso);
    for(var i = 0; i < voosDoMaisRecente.Count() ; i++)
    {
        var vooEmQuestao = voosDoMaisRecente[i];
        var vooAnterior = voosDoMaisRecente[i - 1];
        
        var naoConflitou = false;
        var possuiConflito = false;
        while(!naoConflitou){
            //modificar a preferencia de voo do voo em questão
         possuiConflito = estaConflitando(vooEmQuestao, vooSeguinte);
         if(!possuiConflito){
            naoConflitou = true;
         }
        }

        if(!possuiConflito)
        {
            vooEmQuestao.PousoAlocado = vooEmQuestao.PreferenciaDePouso;
        }
    }

}

static bool estaConflitando(Voo principal, Voo comparado)
{
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