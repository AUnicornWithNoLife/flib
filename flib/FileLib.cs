using System;
using System.Collections.Generic;
using System.IO;

namespace flib
{
    public class FileLib
    {
        public static string[]? OpenArray(string filePath) //opens the file and loads it into an array
        {
            string[]? data = null;

            CheckDir(filePath);

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    List<string> linesList = new List<string>();
                    string? line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != null)
                            linesList.Add(line);
                    }

                    data = linesList.ToArray();
                }
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
            catch (IOException ex)
            {
                return null;
            }

            return data;
        }

        public static string? Open(string filePath) // opens a file
        {
            string? data = null;

            CheckDir(filePath);

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    data = reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
            catch (IOException ex)
            {
                return null;
            }

            return data;
        }

        public static byte[]? OpenBytes(string filePath) //opens a file as a arraqy of bites
        {
            // nom nom

            CheckDir(filePath);

            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
            catch (IOException ex)
            {
                return null;
            }
        }

        public static void SaveBytes(string filePath, byte[] data) // i gives you the bites back <3
        {
            CheckDir(filePath);

            File.WriteAllBytes(filePath, data);
        }

        public static void Save(string filePath, string data) // creates a file and saves the string to the file
        {
            CheckDir(filePath);

            using (StreamWriter reader = new StreamWriter(filePath))
            {
                reader.WriteLine(data);
            }
        }

        public static void SaveArray(string filePath, string[] data) // creates a file and saves the array to the file
        {
            CheckDir(filePath);

            using (StreamWriter reader = new StreamWriter(filePath))
            {
                foreach (string dataSingle in data)
                {
                    reader.WriteLine(dataSingle);
                }
            }
        }

        public static void Append(string filePath, string data, bool newline = false) // changes the contents of the file
        {
            CheckDir(filePath);

            using (StreamWriter outputFile = new StreamWriter(filePath, true))
            {
                if (newline)
                    outputFile.WriteLine(data);
                else
                    outputFile.Write(data);
            }
        }

        public static void AppendArray(string filePath, string[] data) // changes the contents of the array in a file
        {
            CheckDir(filePath);

            using (StreamWriter outputFile = new StreamWriter(filePath, true))
                foreach (string dat in data)
                    outputFile.WriteLine(dat);
        }

        public static void CheckDir(string fname)
        {
            string? dir = Path.GetDirectoryName(fname);

            if (dir != null)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
        }
    }
}