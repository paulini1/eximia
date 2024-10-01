namespace RecepcaoPedidos;

public enum TipoPagamento
{
    Pix,
    Cartao
}

public class Pagamento
{
    public TipoPagamento Tipo { get; set; }
    public int Parcelas { get; set; }

    public Pagamento(TipoPagamento tipo, int parcelas = 1)
    {
        Tipo = tipo;
        Parcelas = parcelas;
    }

    public decimal ProcessarPagamento(Pedido pedido)
    {
        if (Tipo == TipoPagamento.Pix)
        {
            Console.WriteLine("Aplicando desconto de 5% para pagamento via Pix.");
            return pedido.Total * 0.05m; // Desconto de 5% para pagamento à vista
        }
        else if (Tipo == TipoPagamento.Cartao)
        {
            Console.WriteLine($"Pagamento parcelado em {Parcelas}x no cartão.");
        }
        return 0;
    }
}

