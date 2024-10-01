namespace RecepcaoPedidos;

using System;
using System.Collections.Generic;

public enum EstadoPedido
{
    AguardandoProcessamento,
    Cancelado,
    ProcessandoPagamento,
    PagamentoConcluido,
    SeparandoPedido,
    AguardandoEstoque,
    Concluido
}

public class Pedido
{
    public int Id { get; set; }
    public List<ItemPedido> Itens { get; set; }
    public DateTime DataPedido { get; set; }
    public EstadoPedido Estado { get; private set; }
    public decimal Total { get; private set; }

    public Pedido()
    {
        Itens = new List<ItemPedido>();
        DataPedido = DateTime.Now;
        Estado = EstadoPedido.AguardandoProcessamento;
    }

    public void AdicionarItem(ItemPedido item)
    {
        Itens.Add(item);
    }

    public void CalcularTotal()
    {
        Total = 0;
        foreach (var item in Itens)
        {
            Total += item.PrecoTotal;
        }
    }

    public void AplicarDesconto(decimal desconto)
    {
        Total -= desconto;
    }

    public void Cancelar()
    {
        if (Estado == EstadoPedido.AguardandoProcessamento || Estado == EstadoPedido.AguardandoEstoque)
        {
            Estado = EstadoPedido.Cancelado;
            Console.WriteLine("Pedido cancelado com sucesso.");
        }
        else
        {
            Console.WriteLine("Pedido não pode ser cancelado.");
        }
    }

    public void ProcessarPagamento()
    {
        if (Estado == EstadoPedido.AguardandoProcessamento)
        {
            Estado = EstadoPedido.ProcessandoPagamento;
            Console.WriteLine("Processando pagamento...");
        }
        else
        {
            Console.WriteLine("O pedido não está em estado adequado para processar pagamento.");
        }
    }

    public void ConcluirPagamento()
    {
        if (Estado == EstadoPedido.ProcessandoPagamento)
        {
            Estado = EstadoPedido.PagamentoConcluido;
            Console.WriteLine("Pagamento concluído com sucesso.");
        }
        else
        {
            Console.WriteLine("O pedido não está em estado de processamento de pagamento.");
        }
    }
}
