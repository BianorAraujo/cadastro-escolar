namespace CadastroAPI.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; }  = string.Empty;
        public string Email { get; set; }  = string.Empty;
        public DateTime DataNascimento { get; set; }
        public int IdEscolaridade { get; set; }
    }
}