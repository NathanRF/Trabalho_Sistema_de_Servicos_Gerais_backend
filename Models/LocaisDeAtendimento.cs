using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSG_API.Models
{
    public class LocaisDeAtendimento
    {
        private string _estado;
        public string Estado
        {
            get => _estado;
            set => _estado = value;
        }

        private string _cidade;
        public string Cidade
        {
            get => _cidade;
            set => _cidade = value;
        }
    }
}
