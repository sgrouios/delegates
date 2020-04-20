using System.Collections.Generic;

namespace FileParser {
    public class DataParser {
        

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {

            foreach (List<string> row in data)
            {
                for(int i = 0; i < row.Count; i++)
                {
                    row[i] = row[i].Trim();
                }
            }
            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {

            foreach (List<string> row in data)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    row[i] = row[i].Replace('"', ' ').Trim();
                }
            }

            return data; 
        }

    }
}