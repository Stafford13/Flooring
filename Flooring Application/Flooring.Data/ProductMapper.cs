using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class ProductMapper
    {
        public static FlooringProduct ToProduct(string row)
        {
            FlooringProduct p = new FlooringProduct();
            string[] fields = row.Split(',');

            p.ProductType = fields[0];
            p.CostPerSquareFoot = decimal.Parse(fields[1]);
            p.LaborCostPerSquareFoot = decimal.Parse(fields[2]);

            return p;
        }
        //from a string to a product, don't modify the file
    }
}
