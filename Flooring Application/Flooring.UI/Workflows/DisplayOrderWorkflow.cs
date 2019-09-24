using Flooring.BLL;
using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Response;
using Flooring.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        IConsoleIO io = new ConsoleIO();

        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();

            Console.WriteLine("Display an order");
            Console.WriteLine("------------------------");
            string date = io.GetDateFromUser("Please provide a date");
            DisplayOrderResponse response = manager.LoadOrders(date);

                foreach (FlooringOrder order in response.Orders)
                {
                    io.DisplayOrderDetails(order);
                }

                //no matter what date, it shows the hardcoded information from the test file

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

            //public void newMethod(DisplayOrderResponse response)
            //{
            //    io.DisplayOrderDetails(response.orderDate);
            //}

            public FlooringOrder LoadOrder(string OrderNumber)
            {
                throw new NotImplementedException();
            }

            public void SaveOrder(FlooringOrder order)
            {
                throw new NotImplementedException();
            }

            public FlooringOrder DisplayOrder(string orderNumber)
            {
                throw new NotImplementedException();
            }
        }
    }
