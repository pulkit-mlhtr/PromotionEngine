using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Test
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void UpdateStandardPromotionTest()
        {
            Promotion promotion = new PromotionA(Guid.NewGuid(), "A", 1, 30m, "Rs");
            var newPrice = 10;
            promotion.UpdateStandardPromotion("A", 10);
            Assert.AreEqual(promotion.StandardPromotions["A"], newPrice);
        }
    }
}
