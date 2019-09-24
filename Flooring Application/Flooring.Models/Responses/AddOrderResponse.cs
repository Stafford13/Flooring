using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Response
{
    public class AddOrderResponse : Response
    {
       public FlooringOrder Order { get; set; }
    }
}
