using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    public class ConsoleIO : IConsoleIO
    {
        public string GetDateFromUser(string prompt)
        {
            string format = "MMddyyyy";
            string result = "";
            bool isValid = false;
            DateTime date = DateTime.Parse("06/01/2013");
            while (isValid == false)
            {
                string dateString = GetStringFromUser(prompt);
                bool validDate = DateTime.TryParse(dateString, CultureInfo.GetCultureInfo("en-us"), DateTimeStyles.NoCurrentDateDefault, out date);
                if (date.Year > 2012)
                {
                    result = date.ToString(format);
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid date");
                }
            }

            return result;
        }

        public string GetStringFromUser(string prompt)
        {
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine();

            return userInput;
        }

        public void DisplayOrderDetails(FlooringOrder order)
        {
            Console.WriteLine($"{order.OrderNumber} | {order.date.ToShortDateString()}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Materials: {Math.Round(order.MaterialCost, 2)}");
            Console.WriteLine($"Labor: {Math.Round(order.LaborCost, 2)}");
            Console.WriteLine($"Tax: {Math.Round(order.Tax, 2)}");
            Console.WriteLine($"Total: {Math.Round(order.Total, 2)}");
        }


        public void DisplayProducts(List<FlooringProduct> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine(item.ProductType);
                Console.WriteLine(item.CostPerSquareFoot);
                Console.WriteLine(item.LaborCostPerSquareFoot);
                Console.WriteLine("");
            }
        }

        //get string from user, 
        //ask user for date, parses it out, get date calls getstring, that validates that makes sure it is a valid date
        //method to display order
    }
}
