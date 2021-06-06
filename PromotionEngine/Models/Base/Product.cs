using System.Collections.Generic;

namespace PromotionEngine.Models.Base
{
    public abstract class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public IList<Promotion> promos;

        public Product(string id, decimal price)
        {
            this.Id = id;
            this.Price = price;
            promos = new List<Promotion>();
        }
    }
}
