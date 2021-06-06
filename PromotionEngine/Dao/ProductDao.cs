using PromotionEngine.Dao.Interface;
using PromotionEngine.Dao.Repository;
using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Dao
{
    public class ProductDao : IProductDao
    {
        private IPromotionDao _promoDao;

        public ProductDao(IPromotionDao promoDao)
        {
            this._promoDao = promoDao;
        }

        public List<Product> GetAll()
        {
            return ProductList.LoadSkuList();
        }
    }
}
