using PromotionEngine.Dao.Interface;
using PromotionEngine.Dao.Repository;
using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Dao
{
    public class PromotionDao : IPromotionDao
    {
        public IList<ComboPromotion> GetComboPromotions(string productId)
        {
            return PromotionList.GetAllComboPromotions()
                .Where(c => c.ProductId == productId)
                .ToList();
        }

        /// <summary>
        /// Add standard the promotion        
        /// </summary>
        /// <param name="id"></param>
        /// <param name="percentage"></param>
        public void AddStandardPromotion(Promotion promo)
        {
            PromotionList.AddStandardPromo(promo);
        }

        public IList<Promotion> GetStandardPromotions(string productId)
        {
            return PromotionList.GetAllStandardPromotions()
                .Where(c => c.ProductId == productId)
                .ToList();
        }
    }
}
