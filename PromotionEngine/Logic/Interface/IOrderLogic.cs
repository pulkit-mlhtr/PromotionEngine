using PromotionEngine.Models;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Logic.Interface
{
    public interface IOrderLogic
    {
        /// <summary>
        /// Get all placed orders
        /// </summary>
        /// <returns></returns>
        IList<Order> GetAllOrders();

        /// <summary>
        /// Get order by specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order GetOrderById(Guid id);

        /// <summary>
        /// Add orders to a container for supporting multiple placed orders overview.
        /// </summary>
        /// <param name="placedOrder"></param>
        void AddOrder(Order placedOrder);
    }
}
