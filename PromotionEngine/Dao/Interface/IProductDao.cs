using PromotionEngine.Models.Base;
using System.Collections.Generic;

namespace PromotionEngine.Dao.Interface
{
    public interface IProductDao
    {
        List<Product> GetAll();
    }
}
