using CsvHelper;
using System.Globalization;
using System.Linq;
using System.IO;
using HenbocaFV2;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

#region Lectura

var records = new List<Tabla1>();
var path = @"C:\\Users\\celen\\ownCloud\\Proyectos\\Henboca PV\\Prototipo La Rioja\\Ensayos 2022\\Registrador\\PRUEBAVS.csv";

using (var streamReader = new StreamReader(path))
{
    var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };

    using (var csvReader = new CsvReader(streamReader, config))
    {
        csvReader.Context.RegisterClassMap<Tabla1ClassMap>();

        var options = new TypeConverterOptions { Formats = new[] { "MM/dd/yyyy HH:mm:ss:fff" } };
        csvReader.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

        records = csvReader.GetRecords<Tabla1>().ToList();
    }
}

#endregion

int Ns = 14;
decimal? P_MPP_STC = 460; //[W]

foreach (var r in records)
{
    r.Potencia = r.Voltaje * r.Corriente;
}

#region Escritura

using (var streamWriter = new StreamWriter(path))
{
    var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };

    using (var csvWriter = new CsvWriter(streamWriter, config))
    {
        csvWriter.Context.RegisterClassMap<Tabla1ClassMap>();

        var options = new TypeConverterOptions { Formats = new[] { "MM/dd/yyyy HH:mm:ss:fff" } };
        csvWriter.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

        csvWriter.WriteRecords(records);
    }
}

#endregion