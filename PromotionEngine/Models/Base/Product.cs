using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Models.Base
{
    public abstract class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public List<Promotion> promos;

        public Product(string id, decimal price)
        {
            this.Id = id;
            this.Price = price;
            promos = new List<Promotion>();
        }

        public void AddPromotion(Promotion promo)
        {
            if(!promos.Contains(promo))
            {
                promos.Add(promo);
            }            
        }

        /// <summary>
        /// Check if the product has any promotion offers
        /// </summary>       
        /// <returns></returns>
        public bool CheckComboPromotion(string productId)
        {
            return Promotion.ComboPromotions.Any(x => x.Key.Equals(productId));
        }
    }
}
