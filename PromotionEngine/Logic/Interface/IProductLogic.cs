using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

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
        /// Add combo offers
        /// </summary>
        /// <param name="promo"></param>
        void AddComboPromotion(Promotion promo);

        Promotion GetComboPromotionById(string comboId);

        List<Product> GetAllProducts();

        Product ApplyProductPromotion(Product product, int orderQuantity,IList<string> comboList);
    }
}
