using System;

namespace SSG_API.Domain
{
    public class ServicoPrestado
    {
        public Guid Id { get; set; }
        public Servico Servico { get; set; }
        public Prestador Prestador { get; set; }
        public UnidadeDeCobranca Unidade { get; set; }

        private double _preco;
        public double Preco
        {
            get => _preco;
            set => _preco = value;
        }
    }
}
