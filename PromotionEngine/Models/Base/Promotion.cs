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
        public string UnitOfPromo { get; set; }
        public string ProductId { get; set; }
        public Dictionary<string, int> StandardPromotions { get; set; }
        public decimal PromoPrice { get; set; }
        public int DiscountPercent { get; set; }

        public Promotion(Guid _promID,string productId, int productQuantity, decimal promoPrice, string unitOfPromo)
        {
            this.PromotionID = _promID;
            this.StandardPromotions = new Dictionary<string, int>();
            this.ProductId = productId;
            this.PromoPrice = promoPrice;
            this.UnitOfPromo = unitOfPromo;
            this.ProductQuantity = productQuantity;
        }

        /// <summary>
        /// Contain standard promotion on particular product.
        /// Each product can have only one standard promotion at a time. (Assumption)
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
    }
}
