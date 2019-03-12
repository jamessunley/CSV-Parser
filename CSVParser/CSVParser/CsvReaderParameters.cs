using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    public class CsvReaderParameters
    {
        private char DefaultDelimiter = ',';

        public CsvReaderParameters()
        {
            Delimiters = new char[] { DefaultDelimiter };
            HasHeaderRow = true;
        }

        public char[] Delimiters { get; set; }
        public bool HasHeaderRow { get; set; }
    }
}
