using System;

namespace SSG_API.Domain
{
    public class Servico
    {
        public Guid Id { get; set; }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => _nome = value?.Trim().ToUpper();
        }

        private string _descricaoServico;
        public string DescricaoServico
        {
            get => _descricaoServico;
            set => _descricaoServico = value?.Trim();
        }


    }
}