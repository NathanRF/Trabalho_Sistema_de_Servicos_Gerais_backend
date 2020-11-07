using System;

namespace SSG_API.Domain
{
    public class Prestador
    {
        public Guid Id { get; set; }

        private string _biografia;
        public string Biografia
        {
            get => _biografia;
            set => _biografia = value?.Trim();
        }
        public ApplicationUser User { get; set; }
    }
}