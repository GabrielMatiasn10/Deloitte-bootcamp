{
    Lampada lampada = new Lampada();
    lampada.Ligar();
    Console.WriteLine("A lâmpada está ligada? " + (lampada.EstaLigada() ? "Sim" : "Não"));
    lampada.Desligar();
    
}