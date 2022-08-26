using CsvHelper;
using System.Globalization;
using System.Linq;
using System.IO;
using HenbocaFV2;
using CsvHelper.Configuration;

#region Lectura

var records = new List<Tabla1>();
var path = @"C:\\Celena\\CSV_de_pruebas.csv";

using (var streamReader = new StreamReader(path))
{
    var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };

    using (var csvReader = new CsvReader(streamReader, config))
    {
        records = csvReader.GetRecords<Tabla1>().ToList();
    }
}

#endregion

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
        csvWriter.WriteRecords(records);
    }
}

#endregion