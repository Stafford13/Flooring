using System;
using Flooring.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    //
                    //
                    return new OrderManager(new OrderTestRepository());
                case "Production":
                    //
                    //
                    return new OrderManager(new OrderFileRepository(""));
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
