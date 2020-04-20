using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParser;

namespace Delegate_Exercise {
    
    
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

            //remove #
            dataHandler(formatted);

            //remove white-spaces
            dataHandler(formatted);

            //remove ""
            dataHandler(formatted);

            //write file
            fh.WriteFile(writeFile, ',', formatted);
        }

        public void ProcessAndCapitalise(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> parse)
        {
            //read file
            FileHandler fh = new FileHandler();
            List<string> read = fh.ReadFile(readFile);
            List<List<string>> formatted = fh.ParseCsv(read);

            //RemoveHashes
            parse(formatted);

            //Remove white-spaces
            parse(formatted);

            //Remove ""
            parse(formatted);

            //Capitalise
            parse(formatted);

            //write file
            fh.WriteFile(writeFile, ',', formatted);

        }

    }
}