using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    #region Documentation
    /// <summary>
    /// Class which wraps a CSV file and provides access to each row, and the fields within each row.
    /// Call ReadLine() before reading the first line values, it returns false when the end of the file is reached.
    /// </summary>
    #endregion
    public class CsvReader : IDisposable
    {
        #region Constructors

        public CsvReader(Stream content, CsvReaderParameters parameters)
        {
            Reader = new StreamReader(content);

            Initialize(parameters);
        }

        #endregion

        #region Properties

        private TextReader Reader { get; set; }
        private string[] FieldNames { get; set; }
        private Dictionary<string, int> FieldNameToIndex { get; set; }
        private string CurrentLine { get; set; }
        private string[] CurrentLineParts { get; set; }

        public CsvReaderParameters Parameters { get; private set; }

        #endregion

        #region Public methods

        public bool ReadLine()
        {
            CurrentLine = Reader.ReadLine();

            if (CurrentLine == null)
            {
                CurrentLineParts = null;
                return false;
            }
            else
            {
                CurrentLineParts = CurrentLine.Split(Parameters.Delimiters);
                return true;
            }
        }

        public string[] GetCurrentRowValues()
        {
            return CurrentLineParts;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Reader != null)
                {
                    Reader.Dispose();
                    Reader = null;
                }
            }
        }

        #endregion

        #region Private methods

        private void Initialize(CsvReaderParameters parameters)
        {
            if (parameters == null)
                parameters = new CsvReaderParameters();

            Parameters = parameters;

            if (Parameters.HasHeaderRow)
            {
                if (ReadLine())
                    ReadFieldNameIndexes();

                // Restore initial state
                CurrentLineParts = null;
                CurrentLine = null;
            }
        }

        private void ReadFieldNameIndexes()
        {
            if (CurrentLineParts == null)
                return;

            FieldNames = CurrentLineParts;
            FieldNameToIndex = new Dictionary<string, int>();

            for (int i = 0; i < CurrentLineParts.Length; i++)
            {
                FieldNameToIndex[CurrentLineParts[i]] = i;
            }
        }

        #endregion

    }
}
