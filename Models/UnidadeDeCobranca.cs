using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSG_API.Models
{
    public class UnidadeDeCobranca
    {
        private string _unidade;

        public string Unidade
        {
            get => _unidade;
            set => _unidade = value;
        }
    }
}
