using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Interfaces
{
    public interface IConsoleIO
    {
        string GetDateFromUser(string prompt);
        void DisplayProducts(List<FlooringProduct> products);
        void DisplayOrderDetails(FlooringOrder order);
        string GetStringFromUser(string prompt);
    }
}
