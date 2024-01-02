namespace CadastroAPI.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; }  = string.Empty;
        public string Email { get; set; }  = string.Empty;
        public DateTime DataNascimento { get; set; }
        public int IdEscolaridade { get; set; }

        protected Usuario() {}

        public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento, int idEscolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            IdEscolaridade = idEscolaridade;
        }
    }
}