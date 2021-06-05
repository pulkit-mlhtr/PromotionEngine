using PromotionEngine.Models.Base;
using PromotionEngine.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Models.Base
{
    /// <summary>
    /// Represents as database list of items available for adding in the cart
    /// </summary>
    public static class ProductList
    {
        private static List<Product> SkuList;
        static ProductList()
        {
            SkuList = new List<Product>();           
        }

        /// <summary>
        /// SKU list will have unique products (Assumption)
        /// Load the product list and return the list.
        /// </summary>
        public static List<Product> LoadSkuList()
        {
            SkuList.Add(new ProductA("A", 50m));
            SkuList.Add(new ProductB("B", 30m));
            SkuList.Add(new ProductC("C", 20m));
            SkuList.Add(new ProductD("D", 15m));

            return SkuList;
        }

        /// <summary>
        /// Validate the user input while adding to cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DoesExist(this string id)
        {
            return SkuList.Any(p => p.Id == id);
        }

        /// <summary>
        /// Return product if found else return null
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Product GetProductInfo(string Id)
        {
            return SkuList.FirstOrDefault(x => x.Id == Id);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>

        public static void AddProduct(Product product)
        {
            if(!DoesExist(product.Id))
            {
                SkuList.Add(product);
            }
            else
            {
                throw new InvalidOperationException($"{product.Id} already exists !!");
            }
        }

        /// <summary>
        /// Update the price of exisitng product
        /// </summary>
        /// <param name="product"></param>
        public static void UpdateProduct(Product product)
        {
            if (DoesExist(product.Id))
            {
                var _product = SkuList.FirstOrDefault(x => x.Id == product.Id);
                if (_product != null) _product.Price = product.Price;
            }
            else
            {
                throw new InvalidOperationException($"{product.Id} not found !!");
            }
        }
    }
}
