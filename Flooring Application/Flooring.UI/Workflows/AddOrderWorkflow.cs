using Flooring.BLL;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Flooring.UI.Workflows
{
    public class AddOrderWorkflow
    {
        IConsoleIO io = new ConsoleIO();
        ITaxRepository uo = new TaxListRepository();
        IProductRepository yo = new ProductListRepository();

        FlooringOrder newOrder = new FlooringOrder();
        TaxStateResponse taxStateResponse = new TaxStateResponse();
        

        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();

            Console.WriteLine("Add an order");
            Console.WriteLine("------------------------");
            bool isValidDate = false;
            DateTime orderDate = new DateTime();
            string date1 = "";
            while (isValidDate == false)
            { date1 = io.GetDateFromUser("Please provide a date");

                orderDate = DateTime.ParseExact(date1, "MMddyyyy", CultureInfo.GetCultureInfo("en-us"));

                if (orderDate < DateTime.Today)
                {
                    Console.WriteLine("Date must be after today");
                }
                else
                {
                    isValidDate = true;
                }
            }
            
           // orderNumberResponse =  manager.NextOrderNumber(date1);

            string name = PromptUser("What is your name?");

            while (!name.All(c => Char.IsLetterOrDigit(c) || c == ',' || c == '_' || c == '.') || name.Trim()=="")
            {
                Console.WriteLine("Names must include either letters, numbers, spaces, periods, or commas (or any combonation thereof)");
                name = PromptUser("What is your name?");
            }

            TaxStateResponse taxResponse = uo.LoadTax();
            FlooringTax orderTax = new FlooringTax();
            bool isValidTax = false;
            while (isValidTax == false)
            {
                foreach (FlooringTax tax in taxResponse.TaxRate)
                {
                    Console.WriteLine("  " + (taxResponse.TaxRate.IndexOf(tax) + 1) + ". " + tax.StateAbbreviation);
                }
                string state = PromptUser("Please specify the number of the state you're planning on building in.");
                if (int.TryParse(state, out int nation))
                {
                    if (nation > 0 && nation <= taxResponse.TaxRate.Count)
                    {
                        orderTax = taxResponse.TaxRate[nation - 1];
                        isValidTax = true;
                    }
                }
                else
                {
                    Console.WriteLine("That state isn't in our region yet.");
                }
            }

            List<FlooringProduct> ProductList = yo.LoadProducts();
            FlooringProduct orderProduct = new FlooringProduct();
            bool isValidProduct = false;
            while (isValidProduct == false)
            {
                foreach (FlooringProduct prod in ProductList)
                {
                    Console.Write("  " + (ProductList.IndexOf(prod) + 1) + ". " + prod.ProductType);
                    Console.Write("   Cost per sqft $" + prod.CostPerSquareFoot);
                    Console.Write("   Cost for Labor per sqft $" + prod.LaborCostPerSquareFoot);
                    Console.WriteLine("\n");
                }
                string product = PromptUser("Please specify which product you would like to use.");
                if (int.TryParse(product, out int supply))
                {
                    if (supply > 0 && supply <= ProductList.Count)
                    {
                        orderProduct = ProductList[supply - 1];
                        isValidProduct = true;
                    }
                }
                else
                {
                    Console.WriteLine("That product isn't available yet.");
                }
            }

            //Need to select product, if not (product) then show an error and loop

            string area = PromptUser("What is the square footage of the area you are looking to cover?");
            decimal area1;

            while (decimal.TryParse(area, out area1) && area1 < 100)
            {
                //if (area1 < 100)
                //{
                    Console.WriteLine("You must enter a positive amount above 100");
                    Console.WriteLine("Please enter a valid square footage."); 
                    area = PromptUser("What is the square footage of the area you are looking to cover?");
                //}
                //else
                //{
                //    area = area1.ToString();
                //}
            }

            Console.Clear();

            Console.WriteLine("");
            newOrder.Area = area1;
            newOrder.State = orderTax.StateAbbreviation;
            newOrder.TaxRate = orderTax.TaxRate;
            newOrder.CustomerName = name;
            newOrder.date = orderDate;
            newOrder.ProductType = orderProduct.ProductType;
            newOrder.CostPerSquareFoot = orderProduct.CostPerSquareFoot;
            newOrder.LaborCostPerSquareFoot = orderProduct.LaborCostPerSquareFoot;
            io.DisplayOrderDetails(newOrder);

            bool isSave = false;
            while (isSave == false)
            {
                string place = PromptUser("Would you like to place this order? Please enter yes or no");
                if (place.ToLower() == "yes")
                {
                    AddOrderResponse addResponse = manager.AddOrder(date1, newOrder);
                    isSave = true;
                    // save final to file with approps date
                }
                else if (place.ToLower() == "no")
                {
                    isSave = true;
                    //return to main menu
                }
                else
                {
                    Console.WriteLine("Please enter yes or no");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            string PromptUser(string s)
            {
                Console.WriteLine(s);
                return Console.ReadLine();

            }
        }
    }
}