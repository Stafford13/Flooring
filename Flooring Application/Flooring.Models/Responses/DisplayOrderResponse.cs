using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Response
{
    public class DisplayOrderResponse : Response
    {
        public List<FlooringOrder> Orders { get; set; }
    }
}
