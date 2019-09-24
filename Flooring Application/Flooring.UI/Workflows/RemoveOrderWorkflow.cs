using System;
using Flooring.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models.Response;
using Flooring.Models.Interfaces;
using Flooring.BLL;
using System.Globalization;
using Flooring.Data;

namespace Flooring.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        IConsoleIO io = new ConsoleIO();
        ITaxRepository uo = new TaxListRepository();
        IProductRepository yo = new ProductListRepository();

        FlooringOrder newOrder = new FlooringOrder();

        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Remove an order");
            Console.WriteLine("------------------------");
            bool isValidDate = false;
            DateTime orderDate = new DateTime();
            string date1 = "";
            while (isValidDate == false)
            {
                date1 = io.GetDateFromUser("Please provide a date");

                orderDate = DateTime.ParseExact(date1, "MMddyyyy", CultureInfo.GetCultureInfo("en-us"));

                if (orderDate <= DateTime.Today)
                {
                    Console.WriteLine("Date must be later than today");
                }
                else
                {
                    isValidDate = true;
                }
            }

            DisplayOrderResponse response = manager.LoadOrders(date1);

            foreach (FlooringOrder order in response.Orders)
            {
                io.DisplayOrderDetails(order);
            }

            int ordernumber = -1;
            bool isValidNumber = false;
            while (isValidNumber == false)
            {
                string orderstring = io.GetStringFromUser("Please enter an order number.");
                if (!int.TryParse(orderstring, out ordernumber))
                {
                    Console.WriteLine("This did not work, please enter a number");
                }
                else
                {
                    foreach (var item in response.Orders)
                    {
                        if (item.OrderNumber == ordernumber)
                        {
                            newOrder = item;
                        }
                    }
                    isValidNumber = true;
                }
            }

            //if one order = delete entire file
            //if theres more than one order in date, remove the order number from list -> remove with LINQ
            //save list back to file for that date
         
            io.DisplayOrderDetails(newOrder);
            bool isSave = false;
            while (isSave == false)
            {
                string place = PromptUser("Are you entireley sure that you want to remove this order? Choose yes or no.");
                if (place.ToLower() == "yes")
                {
                    DeleteOrderResponse deleteResponse = manager.DeleteOrder(date1, newOrder.OrderNumber);
                    isSave = true;
                    // save final to file with approps date
                }
                else if (place.ToLower() == "no")
                {
                    isSave = true;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public string PromptUser(string s)
        {
            Console.WriteLine(s);
            return Console.ReadLine();

        }
    }
}
