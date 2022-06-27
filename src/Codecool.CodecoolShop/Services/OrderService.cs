using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.JsonRepository;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class OrderService
    {
        private readonly IOrderDao _orderDao;
        private readonly OrderToJson _orderToJson;

        public OrderService(IOrderDao orderDao)
        {
            _orderDao = orderDao;
            _orderToJson = new OrderToJson();
        }

        public Order GetOrder(int Id)
        {
            return _orderDao.GetAll().Where(x => x.Id == Id).FirstOrDefault();
        }

        public void AddOrder(Order order)
        {
            _orderDao.AddOrder(order);
        }

        public Order MakeNewOrder(UserData userData, Dictionary<Product,int> productsList)
        {
            var order = new Order(DateTime.Now);
            order.PaymentStatus = PaymentStatusEnum.Unpaid;
            order.UserData = userData;
            order.MakeOrderDetails(productsList);
            return order;
        }

        public void UpdateOrder(Order order)
        {
            _orderDao.UpdateOrder(order);
        }

        public void SaveToJson(Order order)
        {
            _orderToJson.Save(order);
        }

    }
}
