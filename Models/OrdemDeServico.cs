using System;
using System.Globalization;

namespace SSG_API.Models
{
    public class OrdemDeServico
    {
        private DateTime _data;
        public string DataPrestacao
        {
            get => string.Format("{0}/{1}/{2} {3}", _data.Day, _data.Month, _data.Year, _data.TimeOfDay);
            set => _data = DateTime.Parse(value, CultureInfo.CreateSpecificCulture("pt-BR")); // formato: DD/MM/AAAA hh:mm:ss
        }
        private string _categoriaServico;
        public string CategoriaServico
        {
            get => _categoriaServico;
            set => _categoriaServico = value?.Trim().ToUpper();
        }

        private string _descricaoServico;
        public string DescricaoServico
        {
            get => _descricaoServico;
            set => _descricaoServico = value?.Trim();
        }
    }
}