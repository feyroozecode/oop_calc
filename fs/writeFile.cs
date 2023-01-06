
using System.IO;

namespace Fs
{
    /* write tesxt and save it to .csv file  
      @filePath : relateive file path
      @datas : string of array of array of strings
    */
    class WriteFile{
        public WriteFile(String filePath, string[][] datas){
            try
            {
                // using StreamWrite for write a new data to the csv file
                // AppendText from File add new text without delete previous datas in the file
                using (StreamWriter writer = File.AppendText(filePath)) {
                    for (int i = 0; i < datas.Count(); i++)
                    {    
                        string[] item = datas[i];
                        string line = string.Join(" = ", item);  // separate a expr and value with =
                        writer.WriteLine(line);
                    }
                    Console.WriteLine("File in "+ filePath+ " saved successfully");
                }      
            }
            catch (System.Exception)
            {
                new Exception("Erreur d'ecriture");
            }
        }

    }
}
