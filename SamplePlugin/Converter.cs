using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePlugin
{
    using System.IO;

    using CsvHelper;

    public class Converter
    {
        public IReadOnlyList<Item> Convert(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var csvReader = new CsvReader(reader);
                return csvReader.GetRecords<Item>().ToList();
            }
        }
    }

    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
