using System;
using Flooring.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using System.IO;
using Flooring.Models.Response;

namespace Flooring.Data
{
    public class TaxListRepository : ITaxRepository
    {
        public TaxStateResponse LoadTax()
        {
            TaxStateResponse response = new TaxStateResponse();
            List<FlooringTax> taxes = new List<FlooringTax>();

            StreamReader sr = null;

            try
            {
                sr = new StreamReader("Taxes.txt");
                sr.ReadLine();
                string row = "";
                while ((row = sr.ReadLine()) != null)
                {
                    FlooringTax t = TaxMapper.ToTax(row);
                    taxes.Add(t);
                }
                if (taxes.Count > 0)
                {
                    response.Success = true;
                    response.TaxRate = taxes;
                }
            }
            catch (FileNotFoundException fileNotFound)
            {
                response.Success = false;
                response.Message = "File was not found";
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            return response;
        }
    }
}
