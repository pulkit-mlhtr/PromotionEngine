using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Logic.Interface;
using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void AddPromotionTest()
        {
            var productLogic = Startup.collection.BuildServiceProvider().GetService<IProductLogic>();
            var promotionId = Guid.NewGuid();
            string productId = "D";
            Promotion promotion = new PromotionD(promotionId, productId, 2, 50m, PromoUnit.FlatPrice);
            productLogic.AddStandardPromotion(promotion);
            var productA = productLogic.GetAllProducts().Where(x => x.Id == productId).FirstOrDefault();

            Assert.IsTrue(productA.promos.Any(x => x.PromotionID == promotionId));
        }

        [TestMethod]
        public void ApplyProductPromotionTest()
        {
            var productLogic = Startup.collection.BuildServiceProvider().GetService<IProductLogic>();
            var promotionId = Guid.NewGuid();
            string productId = "D";
            Promotion promotion = new PromotionD(promotionId, productId, 2, 50m, PromoUnit.FlatPrice);
            productLogic.AddStandardPromotion(promotion);

            decimal exceptedPrice = 50m;

            var productD = productLogic.GetAllProducts().Where(x => x.Id == productId).FirstOrDefault();
            decimal actualPrice = productLogic.ApplyProductPromotion(productD, 2, new List<string> { "D" }).Price;

            Assert.AreEqual(exceptedPrice, actualPrice);
        }
    }
}
