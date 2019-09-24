using Flooring.Models;
using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class OrderFileRepository : IRepository
    {
        //protected List<FlooringOrder> orders;
        //private readonly string FILENAME;

        public OrderFileRepository(string filename)
        {
            //FILENAME = filename;
            //LoadOrders(filename);
        }

        private int nextOrderNumber(List<FlooringOrder> orders)
        {
            int id = 0;
            foreach (FlooringOrder order in orders)
            {
                if (order.OrderNumber > id)
                {
                    id = order.OrderNumber;
                }
            }
            id = id + 1;
            return id;
        }

        // CREATE
        public void Create(string datestring, FlooringOrder newOrder)
        {
            string filepath = $"Orders_{datestring}.txt";
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
            }
            List<FlooringOrder> orders = LoadOrders(datestring);
            newOrder.OrderNumber = nextOrderNumber(orders);
            orders.Add(newOrder);
            SaveOrders(orders, datestring);
            //return newOrder;
        }

        // READALL
        //public List<FlooringOrder> ReadAll()
        //{
        //    return orders;
        //}

        // READBY
        public FlooringOrder ReadByOrder(string datestring, int id)
        {
            var orders = LoadOrders(datestring);
            foreach (FlooringOrder order in orders)
            {
                if (order.OrderNumber == id)
                {
                    return order;
                }
            }
            return null;
        }
        // UPDATE
        public void Update(string datestring, FlooringOrder newOrder)
        {
            var orders = LoadOrders(datestring);
            // Loop until find the index, and modify way
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderNumber == newOrder.OrderNumber)
                {
                    orders[i] = newOrder;
                    break;
                }
                
            }
            SaveOrders(orders, datestring);
            //int index = _orders.FindIndex((FlooringOrder c) => c.Id == id);
            //if (index >= 0)
            //{
            //    _orders[index] = newFlooringOrderInfo;
            //}


        }
        // DELETE
        public void Delete(string datestring, int orderNumber)
        {
            var orders = LoadOrders(datestring);
            orders.RemoveAll((FlooringOrder orderInfo) => orderInfo.OrderNumber == orderNumber);
            SaveOrders(orders, datestring);
        }

        /// <summary>
        /// Saving to a text file what is in a order list
        /// </summary>
        private void SaveOrders(List<FlooringOrder> orders, string datestring)
        {
            string filepath = $"Orders_{datestring}.txt";
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(filepath);
                sw.WriteLine("OrderNumber||date||CustomerName||State||TaxRate||ProductType||Area||CostPerSquareFoot||LaborCostPerSquareFoot||MaterialCost||LaborCost||Tax||Total");

                foreach (FlooringOrder order in orders)
                {
                    sw.WriteLine(OrderMapper.ToString(order));
                    sw.Flush();
                }

            }
            //catch (Exception e)
            //{
            //    Console.WriteLine("Something went wrong");
            //}
            finally
            {
                if (sw != null) sw.Close();
            }

        }

        public List<FlooringOrder> LoadOrders(string datestring)
        {
            string filepath = $"Orders_{datestring}.txt";
            List<FlooringOrder> orders = new List<FlooringOrder>();

            StreamReader sr = null;

            try
            {
                sr = new StreamReader(filepath);
                string row = "";
                sr.ReadLine();
                while ((row = sr.ReadLine()) != null)
                {
                    orders.Add(OrderMapper.ToOrder(row));
                }
            }
            catch (FileNotFoundException fileNotFound)
            {
                Console.WriteLine("File was not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            return orders;
        }
        

    }
}

