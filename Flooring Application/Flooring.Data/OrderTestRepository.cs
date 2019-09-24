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
    public class OrderTestRepository : IRepository
    {
        private static FlooringOrder _order = new FlooringOrder
        {
            OrderNumber = 1,
            date = new DateTime(2013, 2, 1),
            CustomerName = "Acme",
            Area = 100,
            State = "OH",
            ProductType = "Wood",
            CostPerSquareFoot = 5.15m,
            LaborCostPerSquareFoot = 6m,
        };

        public void Create(string datestring, FlooringOrder newOrder)
        {
            List<FlooringOrder> orders = LoadOrders(datestring);
            orders.Add(newOrder);
            SaveOrder(orders, datestring);
        }

        public void Delete(string datestring, int orderNumber)
        {
            var orders = LoadOrders(datestring);
            orders.RemoveAll((FlooringOrder orderInfo) => orderInfo.OrderNumber == orderNumber);
            SaveOrder(orders, datestring);
        }

        public List<FlooringOrder> LoadOrders(string date)
        {
            List<FlooringOrder> orders = new List<FlooringOrder>();
            orders.Add(_order);
            return orders;
        }

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
            SaveOrder(orders, datestring);
        }

        private void SaveOrder(List<FlooringOrder> order, string date)
        {
            string filepath = $"Orders_{date}.txt";
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(filepath);
                sw.WriteLine("OrderNumber||date||CustomerName||State||TaxRate||ProductType||Area||CostPerSquareFoot||LaborCostPerSquareFoot||MaterialCost||LaborCost||Tax||Total");

                foreach (FlooringOrder Order in order)
                {
                    sw.WriteLine(OrderMapper.ToString(Order));
                    sw.Flush();
                }
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
}
