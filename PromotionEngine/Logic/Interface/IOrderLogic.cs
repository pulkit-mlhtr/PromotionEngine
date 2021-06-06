using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Logic.Interface
{
    public interface IOrderLogic
    {
        IList<Order> GetAllOrders();

        Order GetOrderById(Guid id);

        void AddOrder(Order placedOrder);
    }
}
