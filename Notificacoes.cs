namespace RecepcaoPedidos;

public class Notificacao
{
    public static void EnviarEmail(string destinatario, string assunto, string mensagem)
    {
        Console.WriteLine($"Email enviado para {destinatario}: {assunto} - {mensagem}");
    }
}
