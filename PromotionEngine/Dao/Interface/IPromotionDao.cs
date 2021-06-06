using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Dao.Interface
{
    public interface IPromotionDao
    {
        IList<ComboPromotion> GetComboPromotions(string productId);
        IList<Promotion> GetStandardPromotions(string productId);
        void AddStandardPromotion(Promotion promo);
    }
}
