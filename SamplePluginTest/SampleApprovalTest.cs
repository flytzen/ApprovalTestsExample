using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePluginTest
{
    using System.IO;
    using System.Reflection;

    using ApprovalTests.Reporters;

    using CsvHelper;

    using SamplePlugin;

    using Xunit;

    [UseReporter(typeof(DiffReporter))]
    public class SampleApprovalTests
    {
        [Fact]
        public void TestSampleConversion()
        {
            var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SamplePluginTest.SampleInput.txt");
            var converter = new Converter();
            var output = converter.Convert(inputStream);


            using (var writer = new StringWriter())
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.WriteRecords(output);
                //writer.Flush();
                var result = writer.ToString();
                ApprovalTests.Approvals.Verify(result);
            }
        }
    }
}
