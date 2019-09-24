using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Response;
using NUnit.Framework;
using System.Collections.Generic;
using Flooring.BLL;
using System;

namespace Flooring.Tests
{
    [TestFixture]
    public class BLLTests
    {
        OrderManager manager = OrderManagerFactory.Create();
        public static FlooringOrder theOrder = new FlooringOrder
        {
            OrderNumber = 2,
            date = new DateTime(2013, 2, 1),
            CustomerName = "RED",
            Area = 100,
            State = "PA",
            ProductType = "Wood",
            CostPerSquareFoot = 5.15m,
            LaborCostPerSquareFoot = 6m,
        };
        [TestCase("02012013", true)]
        public void LoadOrdersTest(string FILENAME, bool expectedResult)
        {
            DisplayOrderResponse response = manager.LoadOrders(FILENAME);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("02012013", true)]
        public void AddOrderResponseTest(string datestring, bool expectedResult)
        {
            AddOrderResponse response = manager.AddOrder(datestring, theOrder);
            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("02012013", true)]
        public void EditOrderResponseTest(string datestring, bool expectedResult)
        {
            EditOrderResponse response = manager.EditOrder(datestring, theOrder);
            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("02012013", 1, true)]
        public void DeleteOrderResponseTest(string datestring, int orderNumber, bool expectedResult)
        {
            DeleteOrderResponse response = manager.DeleteOrder(datestring, orderNumber);
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}

