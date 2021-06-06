using PromotionEngine.Models.Base;
using System.Collections.Generic;

namespace PromotionEngine.Logic.Interface
{
    public interface IProductLogic
    {
        /// <summary>
        /// Check if the product has any combo promotion offers
        /// </summary>       
        /// <returns></returns>
        bool CheckComboPromotion(string productId);

        /// <summary>
        /// Check if the product has any promotion offers
        /// </summary>       
        /// <returns></returns>
        bool CheckStandardPromotion(string productId);

        /// <summary>
        /// Add product specific promotion
        /// </summary>
        /// <param name="promo"></param>
        void AddStandardPromotion(Promotion promo);

        /// <summary>
        /// Get Combo Promotions by combo Id
        /// </summary>
        /// <param name="comboId"></param>
        /// <returns></returns>
        Promotion GetComboPromotionById(string comboId);

        /// <summary>
        /// Get all products with promotions
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Check and apply for one promotion on the product.
        /// Standard promotion is prioritized
        /// </summary>
        /// <param name="product"></param>
        /// <param name="orderQuantity"></param>
        /// <param name="comboList"></param>
        /// <returns></returns>
        Product ApplyProductPromotion(Product product, int orderQuantity, IList<string> comboList);
    }
}
