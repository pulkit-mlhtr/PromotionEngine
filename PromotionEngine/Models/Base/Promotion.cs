using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Models.Base
{
    public abstract class Promotion
    {
        public Guid PromotionID { get; set; }
        public int ProductQuantity { get; set; }
        public PromoUnit UnitOfPromo { get; set; }
        public string ProductId { get; set; }
        private Dictionary<string, int> StandardPromotions { get; set; }        
        public decimal PromoPrice { get; set; }
        public int DiscountPercent { get; set; }

        public Promotion(Guid _promID,string productId, int productQuantity, decimal promoPrice, PromoUnit unitOfPromo)
        {
            this.PromotionID = _promID;
            this.StandardPromotions = new Dictionary<string, int>();           
            this.ProductId = productId;
            this.PromoPrice = promoPrice;
            this.UnitOfPromo = unitOfPromo;
            this.ProductQuantity = productQuantity;
        }       

        /// <summary>
        /// Contain standard promotion in percentage on a particular product.
        /// Each product can have only one standard promotion at a time. (Assumption)
        /// Only applicable if the product quantity is one
        /// </summary>
        /// <param name="id"></param>
        /// <param name="percentage"></param>
        public void AddStandardPromotion(string productId, int percentage)
        {
            if(!StandardPromotions.ContainsKey(productId))
            {
                StandardPromotions.Add(productId, DiscountPercent);
            }
            else
            {
                throw new InvalidOperationException($"Promotion already present for {productId}.");
            }
        }

        /// <summary>
        /// Update the promotion        
        /// </summary>
        /// <param name="id"></param>
        /// <param name="percentage"></param>
        public void UpdateStandardPromotion(string productId, int percentage)
        {
            if (StandardPromotions.ContainsKey(productId))
            {
                StandardPromotions[productId] = percentage;
            }
            else
            {
                throw new InvalidOperationException($"Promotion already present for {productId}.");
            }
        }

        /// <summary>
        /// Get Standard Promotion List for each product
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,int> GetStandardPromotionList()
        {
            return StandardPromotions;
        }
    }
}
