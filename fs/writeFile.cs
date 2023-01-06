
using System.IO;

namespace Fs
{
    // write a csv file to save 
    class WriteFile{
        public WriteFile(String filePath, string[][] datas){
            try
            {
                // Streamwriter for write a new data to the csv 
                // AppendText from File add new text without delete previous datas in the file
                using (StreamWriter writer = File.AppendText(filePath)) {
                    for (int i = 0; i < datas.Count(); i++)
                    {    
                        string[] item = datas[i];
                        string line = string.Join(" = ", item);
                        writer.WriteLine(line);
                    }
                    //Console.WriteLine("File in "+ filePath+ " saved successfully");
                }      
            }
            catch (System.Exception)
            {
                new Exception("Erreur d'ecriture");
            }
        }

    }
}