using System;

namespace SSG_API.Domain
{
    public class UnidadeDeCobranca
    {
        public Guid Id { get; set; }

        private string _unidade;

        public string Unidade
        {
            get => _unidade;
            set => _unidade = value;
        }
    }
}
