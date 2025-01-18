using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStateMachine
{
    public static class Helper
    {
        public static string[] LoadFile(string path)
        {

            try
            {
                if (Directory.Exists(path))
                {
                    string[] files;
                    files = Directory.GetFiles(path, "*.game");
                    string[] fileNames = new string[files.Length];
                    for (int i = 0; i < files.Length; i++)
                    {
                        fileNames[i] = Path.GetFileName(files[i]);
                    }
                    return fileNames;
                }
                else
                {
                    Console.WriteLine("The specified directory does not exist.");
                    return new string[0];
                }

            }
            catch (DirectoryNotFoundException e)
            {

                Console.WriteLine($"Error: {e.Message}");
                return new string[0];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return new string[0];
            }

        }
    }
}
