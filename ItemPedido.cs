namespace RecepcaoPedidos;

public class ItemPedido
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoTotal => Produto.Preco * Quantidade;

    public ItemPedido(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }
}