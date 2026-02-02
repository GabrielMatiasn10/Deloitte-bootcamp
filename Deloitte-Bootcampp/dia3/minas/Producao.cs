using System.Data;

class Producao
{
    private int id;
    private string codigoMina;
    private DataSetDateTime data;

   decimal getVolume()
    {
        return this.Volume;
    }

    decimal setVolume()
    {
        return this.Volume;
    }

    //getters e setters


    public int refinarMinerio(MissingMemberException pMinerio, Refinamento refinamento)
    {
        if (refinamento == Refinamento.Baixo)
        {
            return 90;
        }
        else if (refinamento == Refinamento.Medio)
        {
            return 95;
        }
        else if (refinamento == Refinamento.Alto)
        {
            return 99;
        }
        else
        {
            return 0;
        }
    }



    void refinarMinerio()
    {
        Console.WriteLine("Produção registrada com sucesso.");
    }

    int quantidadeFinalRefinamento()
    {
        return ;
    }
}