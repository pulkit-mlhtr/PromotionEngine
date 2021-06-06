using PromotionEngine.Dao.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Dao
{
    public class ProductDao
    {
        private IPromotionDao _promoDao;

        public ProductDao(IPromotionDao promoDao)
        {
            this._promoDao = promoDao;
        }
    }
}
