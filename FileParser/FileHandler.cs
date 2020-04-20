using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FileParser {
    public class FileHandler {

        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {
            
            List<string> lines = new List<string>();
            try
            {
                StreamReader reader = new StreamReader(filePath);

                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("File could not be found");
                Console.ReadLine();
            }

            return lines;
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {

            string write = "";
            foreach(List<string> list in rows)
            {
                //iterate through every list stored
                foreach(string str in list)
                {
                    //iterate through every string stored in lists
                    if (list.ElementAt(list.Count - 1) != str)
                    {
                        write += str + delimeter;
                    }
                    else
                        write += str + "\n";            
                }
            }

            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.Write(write);
            }
        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimiter) {
            
            List<List<string>> result = new List<List<string>>();
            List<List<string>> parsedList = new List<List<string>>();
            string[] split;

            foreach (string line in data)
            {
                parsedList.Add(new List<string>());
                split = line.Split(delimiter);

                foreach (string newLine in split)
                {
                    parsedList[parsedList.Count - 1].Add(newLine);
                }
            }
            
            return parsedList;
           
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {

            List<List<string>> parsedList = new List<List<string>>();
            string[] split;
            char delimiter = ',';

            foreach(string line in data)
            {
                parsedList.Add(new List<string>());
                split = line.Split(delimiter);

                foreach(string newLine in split)
                {
                    parsedList[parsedList.Count - 1].Add(newLine);
                }
            }
            return parsedList;
        }
    }
}