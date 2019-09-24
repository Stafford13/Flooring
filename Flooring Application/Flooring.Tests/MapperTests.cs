using Flooring.BLL;
using Flooring.Data;
using Flooring.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Tests
{
    [TestFixture]
    public class MapperTests
    {
         [Test]
        public void OrderToStringTests()
        {
            FlooringProduct product = new FlooringProduct
            {
                ProductType = "Wood",
                CostPerSquareFoot = 5.15m,
                LaborCostPerSquareFoot = 4.75m
            };
            FlooringTax tax = new FlooringTax
            {
                TaxRate = 6.25m,
                StateAbbreviation = "OH"
            };
            FlooringOrder order = new FlooringOrder()
            {
                OrderNumber = 1,
                date = new DateTime(2013, 6, 1, 0, 00, 00),
                CustomerName = "Wise",
                TaxRate = tax.TaxRate,
                State = "OH",
                ProductType = product.ProductType,
                Area = 100.00m,
                CostPerSquareFoot = 5.15m,
                LaborCostPerSquareFoot = 4.75m
            };
            string actual = OrderMapper.ToString(order);
            string expected = "1||6/1/2013 12:00:00 AM||Wise||OH||6.25||Wood||100.00||5.15||4.75||515.00||475.00||61.88||1051.88";
            Assert.AreEqual(expected, actual);
        }
        [TestCase("1||6/1/2013 12:00:00 AM||Wise||OH||6.25||Wood||100.00||5.15||4.75||515.00||475.00||61.88||1051.88", 1, "Wise", "OH", 6.25, "Wood", 100.00, 5.15, 4.75, 515.00, 475.00, 61.88, 1051.88)]
        public void OrderFromStringTest(string row, int id, string name, string abbreviation, decimal taxRate, string productType, decimal area, decimal materialCostPerSquareFoot, decimal laborCostPerSquareFoot, decimal materialCost, decimal LaborCost, decimal Tax, decimal Total)
        {
            FlooringOrder actual = OrderMapper.ToOrder(row);
            //FlooringProduct product = new FlooringProduct
            //{
            //    ProductType = productType,
            //    CostPerSquareFoot = materialCostPerSquareFoot,
            //    LaborCostPerSquareFoot = laborCostPerSquareFoot,
            //};
            //FlooringTax tax = new FlooringTax
            //{
            //    TaxRate = taxRate,
            //    StateAbbreviation = abbreviation
            //};
            FlooringOrder expected = new FlooringOrder()
            {
                OrderNumber = id,
                CustomerName = name,
                Area = area,
                TaxRate = taxRate,
                State = abbreviation,
                ProductType = productType,
                CostPerSquareFoot = materialCostPerSquareFoot,
                LaborCostPerSquareFoot = laborCostPerSquareFoot,

            };
            Assert.AreEqual(expected.State, actual.State);
            Assert.AreEqual(expected.TaxRate, actual.TaxRate);
            Assert.AreEqual(expected.ProductType, actual.ProductType);
            Assert.AreEqual(expected.CostPerSquareFoot, actual.CostPerSquareFoot);
            Assert.AreEqual(expected.LaborCostPerSquareFoot, actual.LaborCostPerSquareFoot);
            Assert.AreEqual(expected.OrderNumber, actual.OrderNumber);
            Assert.AreEqual(expected.CustomerName, actual.CustomerName);
            Assert.AreEqual(expected.Area, actual.Area);
            Assert.AreEqual(expected.LaborCost, actual.LaborCost);
            Assert.AreEqual(expected.MaterialCost, actual.MaterialCost);
            Assert.AreEqual(expected.Tax, actual.Tax);
            Assert.AreEqual(expected.Total, actual.Total);
        }
        [TestCase("OH,Ohio,6.25", "OH", "Ohio", 6.25)]
        [TestCase("PA,Pennsylvania,6.75", "PA", "Pennsylvania", 6.75)]
        [TestCase("MI,Michigan,5.75", "MI", "Michigan", 5.75)]
        [TestCase("IN,Indiana,6.00", "IN", "Indiana", 6.00)]
        public void TaxFromStringTest(string row, string abbreviation, string name, decimal taxRate)
        {
            FlooringTax actual = TaxMapper.ToTax(row);
            FlooringTax expected = new FlooringTax
            {
                StateAbbreviation = abbreviation,
                StateName = name,
                TaxRate = taxRate,
            };
            Assert.AreEqual(expected.StateName, actual.StateName);
            Assert.AreEqual(expected.StateAbbreviation, actual.StateAbbreviation);
            Assert.AreEqual(expected.TaxRate, actual.TaxRate);
        }
        [TestCase("Carpet,2.25,2.10","Carpet", 2.25, 2.10)]
        [TestCase("Laminate,1.75,2.10","Laminate", 1.75, 2.10)]
        [TestCase("Tile,3.50,4.15","Tile", 3.50, 4.15)]
        [TestCase("Wood,5.15,4.75","Wood", 5.15, 4.75)]
        public void ProductFromString(string row, string type, decimal matCost, decimal laborCost)
        {
            FlooringProduct actual = ProductMapper.ToProduct(row);
            FlooringProduct expected = new FlooringProduct
            {
                ProductType = type,
                CostPerSquareFoot = matCost,
                LaborCostPerSquareFoot = laborCost,
            };
            Assert.AreEqual(expected.ProductType, actual.ProductType);
            Assert.AreEqual(expected.CostPerSquareFoot, actual.CostPerSquareFoot);
            Assert.AreEqual(expected.LaborCostPerSquareFoot, actual.LaborCostPerSquareFoot);
        }
    }
}
