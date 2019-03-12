using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVParser
{
    class Program
    {
        public static void Main()
        {

            List<ThirdImport> third = new List<ThirdImport>();
            List<SecondImport> second = new List<SecondImport>();
            List<FirstImport> first = new List<FirstImport>();

            using (FileStream filestream = new FileStream("Third.csv", FileMode.Open))
            {
                CsvReader csv = new CsvReader(filestream, new CsvReaderParameters() { HasHeaderRow = false });

                while (csv.ReadLine())
                {
                    try
                    {
                        ThirdImport import = ThirdImport.FromElements(csv.GetCurrentRowValues());
                        if (import != null)
                        {
                            third.Add(import);
                        }
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }

            using (FileStream filestream = new FileStream("Second.csv", FileMode.Open))
            {
                CsvReader csv = new CsvReader(filestream, new CsvReaderParameters() { HasHeaderRow = false });

                while (csv.ReadLine())
                {
                    try
                    {
                        SecondImport import = SecondImport.FromElements(csv.GetCurrentRowValues());
                        if (import != null)
                        {
                            second.Add(import);
                        }
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }

            using (FileStream filestream = new FileStream("First.csv", FileMode.Open))
            {
                CsvReader csv = new CsvReader(filestream, new CsvReaderParameters() { HasHeaderRow = false });

                while (csv.ReadLine())
                {
                    try
                    {
                        FirstImport import = FirstImport.FromElements(csv.GetCurrentRowValues());
                        if (import != null)
                        {
                            first.Add(import);
                        }
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }

            for (int i = 0; i < third.Count; i++)
            {
                foreach (SecondImport import in second.Where(x => x.Value2 == third[i].Value2))
                {
                    import.Value1 = third[i].Value1;
                }
            }

            for (int i = 0; i < third.Count; i++)
            {
                foreach (FirstImport import in first.Where(x => x.Value2 == third[i].Value2))
                {
                    import.Value1 = third[i].Value1;
                }
            }

            var newfile = new StringBuilder();

            foreach (SecondImport import in second)
            {
                string fr = import.Value2;
                string sc = import.Value1;
                string th = import.Value3;
                string newLine = $"{fr},{sc},{ }";
                newfile.AppendLine(newLine);
            }
            File.WriteAllText("Second.csv", newfile.ToString());

            newfile = new StringBuilder();

            foreach (FirstImport import in first)
            {
                string fr = import.Value2;
                string sc = import.Value1;
                string th = import.Value3;
                string fourth = import.Value4;
                string fifth = import.Value5;
                string newLine = $"{fr},{sc},{th},{fourth},{fifth}";
                newfile.AppendLine(newLine);
            }
            File.WriteAllText("First.csv", newfile.ToString());
        }
    }
}

