using PromotionEngine.Dao.Repository;
using PromotionEngine.Models.Base;
using System;
using System.Linq;

namespace PromotionEngine.Models.Promotions
{
    public class PromotionA : Promotion
    {
        public PromotionA(Guid promoId, string productId, int productQuantity, decimal promoPrice, PromoUnit unitOfPromo)
            : base(promoId, productId, productQuantity, promoPrice, unitOfPromo)
        {
            //it will load the promotions for the product which gets loaded
            //this will reflect the behaviour of entityframework
            //all the promotions will get loaded along with product info
            StandardPromotions = PromotionList.GetAllStandardPromotions()
                .Where(x => x.ProductId == productId).ToList();

            ComboPromotions = PromotionList.GetAllComboPromotions()
                .Where(x => x.ProductId.Contains(productId)).ToList();
        }
    }
}
