using RecepcaoPedidos;
class Program
{
    static void Main(string[] args)
    {
        Produto p1 = new Produto("Produto A", 100m);
        Produto p2 = new Produto("Produto B", 50m);

        Pedido pedido = new Pedido();
        pedido.AdicionarItem(new ItemPedido(p1, 5));
        pedido.AdicionarItem(new ItemPedido(p2, 12));
        
        pedido.CalcularTotal();
        
        // Aplicar descontos
        foreach (var item in pedido.Itens)
        {
            var descontoQuantidade = DescontoQuantidade.AplicarDesconto(item);
            pedido.AplicarDesconto(descontoQuantidade);
        }

        var descontoSazonal = DescontoSazonal.AplicarDesconto(pedido);
        pedido.AplicarDesconto(descontoSazonal);

        Console.WriteLine($"Total do pedido: {pedido.Total}");

        // Processamento de pagamento
        pedido.ProcessarPagamento();
        Pagamento pagamento = new Pagamento(TipoPagamento.Cartao);
        var descontoPagamento = pagamento.ProcessarPagamento(pedido);
        pedido.AplicarDesconto(descontoPagamento);
        
        pedido.ConcluirPagamento();

        // Notificação
        Notificacao.EnviarEmail("cliente@exemplo.com", "Seu pedido foi realizado", "Detalhes do pedido...");
    }
}
