using Cafe.Data.Utils;
using Newtonsoft.Json;
using Cafe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Data.Services
{
    public class CoffeeService
    {
        public static void SaveCoffeeToJson(List<Coffee> coffees)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in Utility class in Utils Folder and stores it in the variable filePath.
            string filePath = Utility.CoffeeFilePath();

            // Serialize the list of coffee to JSON format with formatting Indented and store it in Variable jsonData
            string jsonData = JsonConvert.SerializeObject(coffees, Newtonsoft.Json.Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, jsonData);
        }

        public static void InjectSampleCoffeeData()
        {
            // Gets the file path where Add_In data will be stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = Utility.CoffeeFilePath();

            // Read existing data from the file and store it in variable existingData
            var existingData = File.ReadAllText(filePath);

            // If the file is empty, injects a list of sample Add_In data in a object of List<Add_In> called sampleHobbies first and saves it in a Json File by calling method SaveHobbiesToJson.
            if (string.IsNullOrEmpty(existingData))
            {
                List<Coffee> sampleCoffee = new List<Coffee>
            {
                new Coffee { Coffee_Name = "Americano", Coffee_Price=50 },
                new Coffee { Coffee_Name = "Lattee",Coffee_Price=50  },
                new Coffee { Coffee_Name = "Mocca",Coffee_Price=50  },
                new Coffee { Coffee_Name = "Frappuchino",Coffee_Price=50  },
                new Coffee { Coffee_Name = "Cappuchino", Coffee_Price=50 },
                new Coffee { Coffee_Name = "Lungo", Coffee_Price = 50},
                new Coffee { Coffee_Name = "Dopio", Coffee_Price = 50},
                new Coffee { Coffee_Name = "Espresso", Coffee_Price = 50 }
            };
                SaveCoffeeToJson(sampleCoffee); // Save the sample Coffee data to the JSON file by calling SaveCoffeeToJson Method and passing sampleHobbies as it Argument.
            }
        }

        public static List<Coffee> RetrieveCoffeeData()
        {
            // Gets the file path where Add_In data is stored from HobbiesFilePath method
            // in Utility class in Utils Folder and stores it in the variable filePath.
            string filePath = Utility.CoffeeFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); // Read existing JSON data from the file.

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of Add_In objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<Coffee>();
                }
                return JsonConvert.DeserializeObject<List<Coffee>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<Coffee>();
            }
        }

        // Retrieves a specific Add_In by its Id.
        public static Coffee GetCoffeeById(Guid id)
        {
            List<Coffee> coffee = RetrieveCoffeeData(); // Retrieves the list of hobbies and stores it in hobbies object

            // Return the first Add_In with the specified Id.
            return coffee.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Hobbies is equal to the id of parameter that recieves value later on.
        }

        // Edits the name of a specific Add_In.
        public static List<Coffee> EditCoffee(Guid id, string newName, float newPrice)
        {
            // Retrieve the list of hobbies.
            List<Coffee> coffee = RetrieveCoffeeData();
            // Find the Add_In with the specified Id.
            Coffee EditCoffee = coffee.FirstOrDefault(x => x.Id == id);
            // If the Add_In is not found, throw an exception.
            if (EditCoffee == null)
            {
                throw new Exception("Coffee not found");
            }
            // Update the name of the Add_In.
            EditCoffee.Coffee_Name = newName;
            EditCoffee.Coffee_Price = newPrice;
            SaveCoffeeToJson(coffee); // Save the updated list of hobbies to the JSON file by calling method SaveHobbiesToJson
            return coffee;  // Return the updated list of hobbies.
        }
    }


}
