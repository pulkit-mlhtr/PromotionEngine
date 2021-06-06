using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Dao.Interface
{
    public interface IProductDao
    {
        List<Product> GetAll();
    }
}
