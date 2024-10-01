namespace RecepcaoPedidos;

public class DescontoSazonal
{
    public static decimal AplicarDesconto(Pedido pedido)
    {
        if (pedido.DataPedido.Month == 12) 
        {
            return pedido.Total * 0.10m; 
        }
        return 0;
    }
}
