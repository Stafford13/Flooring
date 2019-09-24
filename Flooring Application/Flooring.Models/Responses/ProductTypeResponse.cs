using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Response
{
    public class ProductTypeResponse : Response
    {
        public List<FlooringProduct> flooringProducts { get; set; }
    }
}
