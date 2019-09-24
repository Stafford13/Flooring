using System;
using System.IO;
using Flooring.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data
{
    public class ProductListRepository : IProductRepository
    {
        public List<FlooringProduct> LoadProducts()
        {
            List<FlooringProduct> products = new List<FlooringProduct>();

            StreamReader sr = null;

            try
            {
                sr = new StreamReader("Products.txt");
                sr.ReadLine();
                string row = "";
                while ((row = sr.ReadLine()) != null)
                {
                    FlooringProduct p = ProductMapper.ToProduct(row);
                    products.Add(p);
                }
            }
            catch (FileNotFoundException fileNotFound)
            {
                Console.WriteLine("File was not found");
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            return products;
        }

    }   
}
