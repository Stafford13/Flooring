using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class OrderMapper
    {
        public static string ToString(FlooringOrder order)
        {
            string format = "0.00";
            return $"{order.OrderNumber}||{order.date}||{order.CustomerName}||{order.State}||{order.TaxRate.ToString(format)}||{order.ProductType}||{order.Area}||{order.CostPerSquareFoot.ToString(format)}||{order.LaborCostPerSquareFoot.ToString(format)}||{order.MaterialCost.ToString(format)}||{order.LaborCost.ToString(format)}||{order.Tax.ToString(format)}||{order.Total.ToString(format)}";
        }

        public static FlooringOrder ToOrder(string row)
        {
            FlooringOrder o = new FlooringOrder();
            string[] fields = row.Split(new string[] { "||" }, StringSplitOptions.None);

            o.OrderNumber = int.Parse(fields[0]);
            o.date = DateTime.Parse(fields[1]);
            o.CustomerName = fields[2];
            o.State = fields[3];
            o.TaxRate = decimal.Parse(fields[4]);
            o.ProductType = fields[5];
            o.Area = decimal.Parse(fields[6]);
            o.CostPerSquareFoot = decimal.Parse(fields[7]);
            o.LaborCostPerSquareFoot = decimal.Parse(fields[8]);
            o.MaterialCost = decimal.Parse(fields[9]);
            o.LaborCost = decimal.Parse(fields[10]);
            //o.Tax = decimal.Parse(fields[11]);
            o.Total = decimal.Parse(fields[11]);
            
            return o;
        }

        //internal static char toStringCSV(FlooringOrder orders)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
