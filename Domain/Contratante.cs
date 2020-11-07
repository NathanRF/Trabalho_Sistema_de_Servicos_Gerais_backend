using System;

namespace SSG_API.Domain
{
    public class Contratante
    {
        public Guid Id { get; set; }
        public ApplicationUser User { get; set; }
    }
}