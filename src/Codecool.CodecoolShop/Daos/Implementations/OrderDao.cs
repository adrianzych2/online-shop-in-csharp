using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class OrderDao : IOrderDao
    {
        private List<Order> _data = new List<Order>();
        private static OrderDao _instance = null;

        public static OrderDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new OrderDao();
            }

            return _instance;
        }

        public List<Order> GetAll()
        {
            return _data;
        }

        public void AddOrder(Order order)
        {
            order.Id = _data.Count + 1;
           _data.Add(order); 
        }

        public void UpdateOrder(Order order)
        {
            var orderToUpdateId = _data.Where(x => x.Id == order.Id).FirstOrDefault().Id;
            _data[orderToUpdateId - 1] = order;
        }
    }
}
