using System;

namespace SSG_API.Models
{
    public class ServicoPrestadoModel
    {
        public Guid Servico { get; set; }
        public Guid Prestador { get; set; }
        public Guid Unidade { get; set; }
        public double Preco { get; set; }
    }
}
