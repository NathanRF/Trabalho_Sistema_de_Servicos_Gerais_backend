namespace SSG_API.Models
{
    public class Servico
    {
        private string _categoriaServico;
        public string CategoriaServico
        {
            get => _categoriaServico;
            set => _categoriaServico = value?.Trim().ToUpper();
        }

        private string _descricaoServico;
        public string DescricaoServico
        {
            get => _descricaoServico;
            set => _descricaoServico = value?.Trim();
        }
    }
}