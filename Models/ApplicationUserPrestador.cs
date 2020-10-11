using Microsoft.AspNetCore.Identity;

namespace APIProdutos.Models
{
    public class ApplicationUserPrestador : ApplicationUser
    {
        private string _biografia;
        public string Biografia
        {
            get => _biografia;
            set => _biografia = value?.Trim();
        }
    }
}