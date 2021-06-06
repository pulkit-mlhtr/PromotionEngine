using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System.Collections.Generic;

namespace PromotionEngine.Logic.Interface
{
    public interface IPromotionLogic
    {
        /// <summary>
        /// Get Combo promotions for specific productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        IList<ComboPromotion> GetComboPromotions(string productId);

        /// <summary>
        /// Get Standard promotions for specific productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        IList<Promotion> GetStandardPromotions(string productId);

        /// <summary>
        /// Add product specific promotions
        /// </summary>
        /// <param name="logic"></param>
        void AddStandardPromotion(Promotion logic);

        /// <summary>
        /// Apply promo and calculate product price for the given order quantity
        /// </summary>
        /// <param name="product"></param>
        /// <param name="orderQuantity"></param>
        /// <param name="promo"></param>
        /// <returns></returns>
        decimal ApplyPromo(Product product, int orderQuantity, Promotion promo);

        /// <summary>
        /// Get flat price or percentage discount based on PromoUnit type
        /// </summary>
        /// <param name="promotion"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        decimal GetPrice(Promotion promotion, Product product);
    }
}
