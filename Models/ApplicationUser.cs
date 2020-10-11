using Microsoft.AspNetCore.Identity;

namespace APIProdutos.Models
{
    public class ApplicationUser : IdentityUser
    {
        private string _nomeCompleto;
        public string NomeCompleto
        {
            get => _nomeCompleto;
            set => _nomeCompleto = value?.Trim();
        }

        private string _endereco;
        public string Endereco
        {
            get => _endereco;
            set => _endereco = value?.Trim();
        }

        private string _telefone;
        public string Telefone
        {
            get => _telefone;
            set => _telefone = value?.Trim();
        }

        private string _linkFoto;
        public string LinkFoto
        {
            get => _linkFoto;
            set => _linkFoto = value?.Trim();
        }
    }
}