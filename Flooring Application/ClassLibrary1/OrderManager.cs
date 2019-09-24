using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Response;
using Flooring.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public class OrderManager
    {
        private List<FlooringOrder> orders = new List<FlooringOrder>();
        private ITaxRepository _taxRepo = new TaxListRepository();
        private IProductRepository _productRepo = new ProductListRepository();
        private IRepository _orderRepository;

        public OrderManager(IRepository displayOrderRepository)
        {
            _orderRepository = displayOrderRepository;

        }

        //public List<FlooringProduct> GetProducts()
        //{
        //    List<FlooringProduct> products = _productRepo.LoadProducts();
        //    return products;
        //}

        public DisplayOrderResponse LoadOrders(string FILENAME)
        {
            DisplayOrderResponse response = new DisplayOrderResponse();

            response.Orders = _orderRepository.LoadOrders(FILENAME);

            if (response.Orders.Count == 0)
            {
                response.Success = false;
                response.Message = "get help!";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public AddOrderResponse AddOrder(string datestring, FlooringOrder newOrder)
        {
            AddOrderResponse response = new AddOrderResponse();
            try
            {
                _orderRepository.Create(datestring, newOrder);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;

            }
            response.Success = true;
            response.Order = newOrder;
            return response;
        }

        public EditOrderResponse EditOrder(string datestring, FlooringOrder newOrder)
        {
            EditOrderResponse response = new EditOrderResponse();
            try
            {
                _orderRepository.Update(datestring, newOrder);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            response.Success = true;
            response.newOrder = newOrder;
            return response;
        }

        public DeleteOrderResponse DeleteOrder(string datestring, int orderNumber)
        {
            DeleteOrderResponse response = new DeleteOrderResponse();
            try
            {
                _orderRepository.Delete(datestring, orderNumber);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            response.Success = true;
            response.OrderNumber= orderNumber;
            return response;
        }
    }
}

