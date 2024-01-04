namespace CadastroAPI.Entities
{
    public class NivelEscolar
    {
        public int IdEscolaridade { get; set; }
        public string Escolaridade { get; set; } = string.Empty;

        protected NivelEscolar() {}

        public NivelEscolar(string escolaridade)
        {
            Escolaridade = escolaridade;
        }
    }
}