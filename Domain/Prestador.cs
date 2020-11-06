namespace SSG_API.Domain
{
    public class Prestador : ApplicationUser
    {
        private string _biografia;
        public string Biografia
        {
            get => _biografia;
            set => _biografia = value?.Trim();
        }
    }
}