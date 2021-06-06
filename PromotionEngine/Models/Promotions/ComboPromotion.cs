using PromotionEngine.Models.Base;
using System;

namespace PromotionEngine.Models.Promotions
{
    public class ComboPromotion : Promotion
    {
        public ComboPromotion(Guid promoId, string productId, int productQuantity, decimal promoPrice, PromoUnit unitOfPromo)
             : base(promoId, productId, productQuantity, promoPrice, unitOfPromo)
        {

        }
    }
}
