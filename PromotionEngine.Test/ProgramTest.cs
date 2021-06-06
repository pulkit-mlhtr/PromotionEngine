using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Dao.Repository;
using PromotionEngine.Logic.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void ValidateCart_ValidTest()
        {
            ProductList.LoadSkuList();
            List<string> products = new List<string> { "A", "B", "C" };

            Assert.IsTrue(Program.ValidateCart(products));

        }

        [TestMethod]
        public void ValidateCart_InValidTest()
        {
            ProductList.LoadSkuList();
            List<string> products = new List<string> { "A", "B", "E" };

            Assert.IsFalse(Program.ValidateCart(products));

        }

        [TestMethod]
        public void GeneratePossibleComboTest()
        {
            IList<string> cart = new List<string> { "A", "A", "B", "C" };

            var expectedOutput = new List<string> { "AB", "BA", "AC", "CA" };

            var actualOutput = Program.GeneratePossibleCombo("A", 2, cart);

            Assert.IsFalse(actualOutput.Any(x => !expectedOutput.Contains(x)));
        }

        [TestMethod]
        public void GenerateCartTest()
        {
            string userInput = "A,A,A,B,B,C,D";

            var expectedOutput = userInput.Replace(",", "").Length;

            var actualOutput = Program.GenerateCart(userInput).Count;

            Assert.AreEqual(actualOutput, expectedOutput);
        }

        [TestMethod]
        public void ApplyPromotionsOnCartTest()
        {
            ProductList.LoadSkuList();
            PromotionList.GetAllComboPromotions();
            PromotionList.GetAllStandardPromotions();
            var productLogic = Startup.collection.BuildServiceProvider().GetService<IProductLogic>();
            productLogic.GetAllProducts();
            decimal expectedCartValue = 370m;
            IList<string> cart = new List<string> { "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C" };

            decimal actualCartValue = Program.ApplyPromotionsOnCart(productLogic, cart).Sum(x => x.Price);

            Assert.AreEqual(expectedCartValue, actualCartValue);
        }
    }
}
