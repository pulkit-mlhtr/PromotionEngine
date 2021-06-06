using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Logic.Interface;
using PromotionEngine.Models.Base;
using PromotionEngine.Models.Products;
using PromotionEngine.Models.Promotions;
using System;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void ApplyPromoTest()
        {
            var promotionLogic = Startup.collection.BuildServiceProvider().GetService<IPromotionLogic>();
           
            var product = new ProductA("A", 50);
            var promotion = new PromotionA(Guid.NewGuid(), "A", 2, 70, PromoUnit.FlatPrice);

            decimal expectedPrice = 190m;
            decimal actualPrice = promotionLogic.ApplyPromo(product, 5, promotion);

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void GetPrice_FlatPriceTest()
        {
            var promotionLogic = Startup.collection.BuildServiceProvider().GetService<IPromotionLogic>();

            var product = new ProductA("A", 50);
            var promotion = new PromotionA(Guid.NewGuid(), "A", 2, 70, PromoUnit.FlatPrice);

            decimal expectedPrice = 70m;
            decimal actualPrice = promotionLogic.GetPrice(promotion,product);

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void GetPrice_PercentageTest()
        {
            var promotionLogic = Startup.collection.BuildServiceProvider().GetService<IPromotionLogic>();

            var product = new ProductA("A", 50);
            var promotion = new PromotionA(Guid.NewGuid(), "A", 2, 10, PromoUnit.Percentage);

            decimal expectedPrice = 45m;
            decimal actualPrice = promotionLogic.GetPrice(promotion, product);

            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}
