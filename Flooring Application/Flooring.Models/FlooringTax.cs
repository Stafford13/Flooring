using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class FlooringTax
    {
        public string StateAbbreviation { get; set; }
        //public string ProductType { get; set; }
        public decimal TaxRate { get; set; }
        public string StateName { get; set; }
    }
}
