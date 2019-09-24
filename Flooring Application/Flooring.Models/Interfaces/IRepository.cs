using System;
using System.Collections.Generic;
using Flooring.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Interfaces
{
    public interface IRepository
    {
        //R
        List<FlooringOrder> LoadOrders(string datestring);
        FlooringOrder ReadByOrder(string datestring, int id);
        //CRUD
        //create order
        void Create(string datestring, FlooringOrder newOrder);
        //update order
        void Update(string datestring, FlooringOrder newOrder);
        //delete order
        void Delete(string datestring, int orderNumber);
    }
}
