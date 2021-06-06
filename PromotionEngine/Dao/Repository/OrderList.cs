using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Dao.Repository
{
    /// <summary>
    /// It reflects repository of placed orders for current user
    /// </summary>
    public static class OrderList
    {
        private static IList<Order> placedOrders;

        static OrderList()
        {
            placedOrders = new List<Order>();
        }

        public static Order Get(Guid orderId)
        {
            return placedOrders
                .Where(x => x.OrderID == orderId)
                .FirstOrDefault();
        }

        public static IList<Order> GetAll()
        {
            return placedOrders;
        }

        public static void AddOrder(Order order)
        {
            if (!placedOrders.Any(x => x.OrderID == order.OrderID))
            {
                placedOrders.Add(order);
            }
        }
    }
}
