using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Data.Utils
{
    internal class Utility
    {

        public static string CoffeDirectoryPath()   // Returns the path of the directory where application data will be stored.
        {
            string directoryPath = @"D:\Third Year\Application Development\Program\CW_Cafe\Coffee";  // Define the path to the directory where you want to store your files.
            if (!Directory.Exists(directoryPath))    // If the directory doesn't exist
            {
                Directory.CreateDirectory(directoryPath);  //Create the directory
                return directoryPath;     // Return the path of the directory.
            }
            else
            {
                return directoryPath;   // else return if it is already there
            }
        }

        public static string CoffeeFilePath()
        {
            string directoryPathCreated = CoffeDirectoryPath();   // Calling the method ApplicationDirectoryPath That returns the folder created, and storing it in directoryPathCreated variable
            string filePath = Path.Combine(directoryPathCreated, "Coffee.json");  // Combine the directory path with the file name to get the complete file path.
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }

        public static string AddinDirectoryPath()   // Returns the path of the directory where application data will be stored.
        {
            string directoryPath = @"D:\Third Year\Application Development\Program\CW_Cafe\AddIn";  // Define the path to the directory where you want to store your files.
            if (!Directory.Exists(directoryPath))    // If the directory doesn't exist
            {
                Directory.CreateDirectory(directoryPath);  //Create the directory
                return directoryPath;     // Return the path of the directory.
            }
            else
            {
                return directoryPath;   // else return if it is already there
            }
        }

        public static string AddinFilePath()
        {
            string directoryPathCreated = AddinDirectoryPath();   // Calling the method ApplicationDirectoryPath That returns the folder created, and storing it in directoryPathCreated variable
            string filePath = Path.Combine(directoryPathCreated, "Addin.json");  // Combine the directory path with the file name to get the complete file path.
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }


        
    }
}
