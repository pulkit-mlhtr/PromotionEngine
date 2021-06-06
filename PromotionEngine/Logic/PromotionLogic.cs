using PromotionEngine.Dao.Interface;
using PromotionEngine.Logic.Interface;
using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Logic
{
    public class PromotionLogic : IPromotionLogic
    {
        private IPromotionDao _promoDao;

        public PromotionLogic(IPromotionDao promoDao)
        {
            _promoDao = promoDao;
        }

        public void AddStandardPromotion(Promotion promo)
        {
            _promoDao.AddStandardPromotion(promo);
        }

        public IList<ComboPromotion> GetComboPromotions(string productId)
        {
            return _promoDao.GetComboPromotions(productId);
        }

        public IList<Promotion> GetStandardPromotions(string productId)
        {
            return _promoDao.GetStandardPromotions(productId);
        }       

        public decimal ApplyPromo(Product product, int orderQuantity, Promotion promo)
        {
            decimal price = 0m;

            while (promo.ProductQuantity < orderQuantity)
            {
                price += promo.PromoPrice;
                orderQuantity = orderQuantity - promo.ProductQuantity;
            };

            price += orderQuantity * product.Price;

            return price;
        }        
    }
}
