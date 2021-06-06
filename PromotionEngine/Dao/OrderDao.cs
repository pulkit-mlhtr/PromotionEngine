using PromotionEngine.Dao.Interface;
using PromotionEngine.Dao.Repository;
using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Dao
{
    public class OrderDao : IOrderDao
    {
        public IList<Order> GetAll()
        {
            return OrderList.GetAll();
        }

        public Order GetOrder(Guid orderId)
        {
            return OrderList.Get(orderId);
        }

        public void Add(Order placedOrder)
        {
            OrderList.AddOrder(placedOrder);
        }
    }
}
