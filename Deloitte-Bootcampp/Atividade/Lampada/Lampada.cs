

public class Lampada
{
    private bool isligada;

    public Lampada()
    {
        this.isligada = false;
    }

    public void Ligar()
    {
        this.isligada = true;
    }

    public void Desligar()
    {
        this.isligada = false;
    }

    public bool EstaLigada()
    {
        return this.isligada;
    }
}