using System;
using System.Collections.Generic;

namespace FileParser {

    public delegate List<List<string>> Parser(List<List<string>> data);
    public class CsvHandler {
        
        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler) {
            //read file
            FileHandler fh = new FileHandler();
            List<string> read = fh.ReadFile(readFile);
            List<List<string>> formatted = fh.ParseCsv(read);

            //Remove white-spaces/quotes/hashes
            dataHandler.Invoke(formatted);

            //write file
            fh.WriteFile(writeFile, ',', formatted);
        }

        public void ProcessAndCapitalise(string readFile, string writeFile, Parser parse)
        {
            //read file
            FileHandler fh = new FileHandler();
            List<string> read = fh.ReadFile(readFile);
            List<List<string>> formatted = fh.ParseCsv(read);

            //Remove white-spaces/quotes/hashes/capitalise data
            parse.Invoke(formatted);

            //write file
            fh.WriteFile(writeFile, ',', formatted);

        }

    }
}