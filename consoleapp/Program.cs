using consoleapp.lib;

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

    var voosAlocados = Trafego.defineHorariosDeAterrisagem(voosDesteAeroporto);

