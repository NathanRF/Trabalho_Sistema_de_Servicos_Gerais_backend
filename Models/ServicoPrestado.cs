using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSG_API.Models
{
    public class ServicoPrestado
    {
        private double _preco;
        public double Preco
        {
            get => _preco;
            set => _preco = value;
        }
    }
}
