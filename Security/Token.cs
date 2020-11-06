namespace SSG_API.Security
{
    public class Token
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
    }
}
