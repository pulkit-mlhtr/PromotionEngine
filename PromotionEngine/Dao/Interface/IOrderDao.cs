﻿using PromotionEngine.Models;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Dao.Interface
{
    public interface IOrderDao
    {
        IList<Order> GetAll();

        Order GetOrder(Guid id);

        void Add(Order placedOrder);
    }
}
