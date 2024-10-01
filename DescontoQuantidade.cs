namespace RecepcaoPedidos;

public class DescontoQuantidade
{
    public static decimal AplicarDesconto(ItemPedido item)
    {
        if (item.Quantidade >= 10)
        {
            return item.Quantidade * 2;
        }
        return 0;
    }
}