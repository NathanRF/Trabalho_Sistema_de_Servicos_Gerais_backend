using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSG_API.Models
{
    public class LocaisDeAtendimentoModel
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid Prestador { get; set; }
    }
}
