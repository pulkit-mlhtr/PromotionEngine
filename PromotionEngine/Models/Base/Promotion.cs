using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Models.Base
{
    public abstract class Promotion
    {
        public Guid PromotionID { get; set; }
        public int ProductQuantity { get; set; }
        public PromoUnit UnitOfPromo { get; set; }
        public string ProductId { get; set; }
        public IList<Promotion> StandardPromotions { get; set; }
        public IList<ComboPromotion> ComboPromotions { get; set; }
        public decimal PromoPrice { get; set; }
        public int DiscountPercent { get; set; }

        public Promotion(Guid _promID, string productId, int productQuantity, decimal promoPrice, PromoUnit unitOfPromo)
        {
            this.PromotionID = _promID;
            this.StandardPromotions = new List<Promotion>();
            this.ComboPromotions = new List<ComboPromotion>();
            this.ProductId = productId;
            this.PromoPrice = promoPrice;
            this.UnitOfPromo = unitOfPromo;
            this.ProductQuantity = productQuantity;
        }
    }
}
