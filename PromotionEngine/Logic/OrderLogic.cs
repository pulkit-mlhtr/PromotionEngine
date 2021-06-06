using PromotionEngine.Dao.Interface;
using PromotionEngine.Logic.Interface;
using PromotionEngine.Models;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private IOrderDao _orderDao;

        public OrderLogic(IOrderDao orderDao)
        {
            _orderDao = orderDao;
        }
        public void AddOrder(Order placedOrder)
        {
            _orderDao.Add(placedOrder);
        }

        public IList<Order> GetAllOrders()
        {
            return _orderDao.GetAll();
        }

        public Order GetOrderById(Guid id)
        {
            return _orderDao.GetOrder(id);
        }
    }
}
