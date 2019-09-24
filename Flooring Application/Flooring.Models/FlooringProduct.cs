using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class FlooringProduct
    {
        public string ProductType { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
    }
}
