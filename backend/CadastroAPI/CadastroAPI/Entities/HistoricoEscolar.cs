namespace CadastroAPI.Entities
{
    public class HistoricoEscolar
    {
        public int IdHistoricoEscolar { get; set; }
        public string Formato { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;

        protected HistoricoEscolar() {}

        public HistoricoEscolar(string formato, string nome)
        {
            Formato = formato;
            Nome = nome;
        }
    }
}