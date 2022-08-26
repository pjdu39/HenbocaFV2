﻿using CsvHelper;
using System.Globalization;
using System.Linq;
using System.IO;
using HenbocaFV2;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

#region Lectura

var records = new List<Tabla1>();
var path = @"C:\\Celena\\CSV_de_pruebas.csv";

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