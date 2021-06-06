using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Test
{
    [TestClass]
    public class ExtensionTest
    {
        [TestMethod]
        public void ToReverseTest()
        {
            string input = "CD";
            string expected = "DC";
            string actual = input.ToReverse();

            Assert.AreEqual(expected, actual);
        }
    }
}
