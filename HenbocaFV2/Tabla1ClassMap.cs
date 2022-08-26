using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenbocaFV2
{
    public class Tabla1ClassMap : ClassMap<Tabla1>
    {
        public Tabla1ClassMap()
        {
            Map(x => x.Fecha).Name("Fecha");
            Map(x => x.Voltaje).Name("Voltaje");
            Map(x => x.Corriente).Name("Corriente_e");
            Map(x => x.Potencia).Name("Potencia");
        }
    }
}
