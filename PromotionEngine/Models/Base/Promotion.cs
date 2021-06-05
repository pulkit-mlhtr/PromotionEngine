using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models.Base
{
    public abstract class Promotion
    {
        public Guid PromotionID { get; set; }
        public int ProductQuantity { get; set; }
        public string UnitOfPromoPrice { get; set; }
        public string ProductId { get; set; }
        public static Dictionary<string, int> StandardPromotions { get; set; }
        public decimal PromoPrice { get; set; }
        public int DiscountPercent { get; set; }

        public Promotion(Guid _promID,string productId, int productQuantity, decimal promoPrice, string unitOfPromoPrice)
        {
            this.PromotionID = _promID;
            StandardPromotions = new Dictionary<string, int>();
            this.ProductId = productId;
            this.PromoPrice = promoPrice;
            this.UnitOfPromoPrice = unitOfPromoPrice;
            this.ProductQuantity = productQuantity;
        }

        /// <summary>
        /// Contain all promotions which is common for all products
        /// </summary>
        /// <param name="id"></param>
        /// <param name="percentage"></param>
        public void AddStandardPromotion(string id, int percentage)
        {
            if(!StandardPromotions.ContainsKey(id))
            {
                StandardPromotions.Add(id, DiscountPercent);
            }
            else
            {
                throw new InvalidOperationException("")
            }
        }
    }
}
