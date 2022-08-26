using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenbocaFV2
{
    public class Tabla1
    {
        [Format("MM/dd/yyyy HH:mm:ss:fff")]
        public DateTime Fecha { get; set; }

        public decimal? Voltaje { get; set; }

        public decimal? Corriente { get; set; }

        public decimal? Potencia { get; set; }
    }
}
