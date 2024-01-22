using System;
using System.IO;

namespace PatchLC;

class Program
{
    static void Main(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine(currentDirectory);

        var pluginsToShow = new List<string>();
        
        string[] directories = Directory.GetDirectories(currentDirectory);
        
        for (int i = 0; i < directories.Length; ++i)
        {
            var subFiles = Directory.GetFiles(directories[i]);
            foreach (var subFile in subFiles)
            {
                if (IsFileExtensionOld(subFile))
                {
                    pluginsToShow.Add(Path.GetFileName(directories[i]));
                    break;
                }
            }
        }

        if (pluginsToShow.Count == 0)
        {
            Console.WriteLine("Everything is new!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Following plugins are old: \n");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var plugin in pluginsToShow)
            {
                Console.WriteLine($"- {plugin}");
            }  
            Console.ReadKey();
        }
    }
    
    static bool IsFileExtensionOld(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);

        return fileInfo.Extension.Equals(".old", StringComparison.OrdinalIgnoreCase);
    }
}