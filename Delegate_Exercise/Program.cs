using System;
using System.Collections.Generic;
using System.IO;
using FileParser;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            List<string> data = new List<string>();
            string readFile = Path.GetFullPath(@"..\..\..\..\") + "/DataFiles/data.csv";
            string writeFile = Path.GetFullPath(@"..\..\..\..\") + "/DataFiles/processed_data.csv";

            FileHandler fh = new FileHandler();
            DataParser dp = new DataParser();
            CsvHandler cs = new CsvHandler();

            Console.WriteLine("Enter 1 to ProcessCSV or 2 to ProcessCSV AND capitalise data (optional)\n\nRemember: Only Option 1 will create a compatible file for the tests");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //ProcessCSV
                    Func<List<List<string>>, List<List<string>>> dataHandler = new Func<List<List<string>>, List<List<string>>>(dp.StripWhiteSpace);
                    dataHandler += dp.StripQuotes;
                    dataHandler += RemoveHashes;
                    cs.ProcessCsv(readFile, writeFile, dataHandler);
                    Console.WriteLine("DataFiles/processed_data.csv file created");
                    Console.Read();
                    break;
                case "2":             
                    //Process and Capitalise - using Parser type
                    Parser parse = new Parser(RemoveHashes);
                    parse += dp.StripWhiteSpace;
                    parse += dp.StripQuotes;
                    parse += CapitaliseData;
                    cs.ProcessAndCapitalise(readFile, writeFile, parse.Invoke);
                    Console.WriteLine("DataFiles/processed_data.csv file created");
                    Console.Read();
                    break;
                default:
                    break;
            }

        }

        public static List<List<string>> RemoveHashes(List<List<string>> data)
        {
            foreach (var row in data)
            {
                for (var index = 0; index < row.Count; index++)
                {
                    if (row[index][0] == '#')
                        row[index] = row[index].Remove(0, 1);

                }
            }
            return data;
        }

        public static List<List<string>> CapitaliseData(List<List<string>> data)
        {
            //Capitalise data
            foreach (List<string> list in data)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = list[i].ToUpper();
                }
            }
            return data;
        }
    }
}
