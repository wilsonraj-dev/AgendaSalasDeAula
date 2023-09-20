namespace Reserva.Application.DTOs
{
    public class UsuarioToken
    {
        public bool Autenticado { get; set; }
        public DateTime Expiracao { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
    }
}
