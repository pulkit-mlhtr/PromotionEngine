using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Logic.Interface
{
    public interface IPromotionLogic
    {
        IList<ComboPromotion> GetComboPromotions(string productId);
        IList<Promotion> GetStandardPromotions(string productId);
        void AddStandardPromotion(Promotion logic);
        decimal ApplyPromo(Product product, int orderQuantity, Promotion promo);
    }
}
