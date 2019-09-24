using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class TaxMapper
    {
        public static FlooringTax ToTax(string row)
        {
            FlooringTax t = new FlooringTax();
            string[] fields = row.Split(',');

            t.StateAbbreviation = fields[0];
            t.StateName = fields[1];
            t.TaxRate = decimal.Parse(fields[2]);

            return t;
        }
        //from a string to a tax, don't modify the file
    }
}
