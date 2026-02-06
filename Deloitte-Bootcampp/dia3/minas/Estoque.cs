class Estoque
{
    private int id;

    private decimal quantidade;

    public void setQuantidade(decimal pQuantidade)
    {
        this.quantidade = pQuantidade;
    }

    public decimal getQuantidade()
    {
        return this.quantidade;
    }

   public void adicionarEstoque(decimal pQuantidade)
    {
        this.quantidade += pQuantidade;
    }
}