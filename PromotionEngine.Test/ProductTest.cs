using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Models.Base;
using PromotionEngine.Models.Products;
using PromotionEngine.Models.Promotions;
using System;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void AddPromotionTest()
        {
            Product product = new ProductA("A", 50m);

            product.AddPromotion(
                new PromotionA(Guid.NewGuid(), product.Id,3, 40, PromoUnit.Percentage));

            Assert.IsTrue(product.promos.Count > 0);            
        }
    }
}
