using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Dao.Repository;
using PromotionEngine.Logic.Interface;
using PromotionEngine.Models;
using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PromotionEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Register all the dependencies
            IServiceProvider serviceProvider = Startup.collection.BuildServiceProvider();

            var productLogic = serviceProvider.GetService<IProductLogic>();
            var orderLogic = serviceProvider.GetService<IOrderLogic>();

            List<Product> orderProducts = null;
            Console.WriteLine("Loading Product List ...");
            Thread.Sleep(2000);
            var skuList = productLogic.GetAllProducts();
            Console.WriteLine("Available products to add in the cart");
            foreach (var product in skuList)
            {
                Console.WriteLine(product.Id);
            }

            Console.WriteLine("***************************************************************");
            Console.WriteLine("Info => Multiple products can be added using comma. Ex: A,A,B,D");
            Console.WriteLine("***************************************************************");

            TakeProcessOrderFromUser(productLogic, orderLogic);

        }

        private static void PrintOrder(IOrderLogic orderLogic)
        {
            var placedOrderList = orderLogic.GetAllOrders();

            foreach (var order in placedOrderList)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine($"Order ID : {order.OrderID}");
                Console.WriteLine("---------------------------");
                foreach (var product in order.Products)
                {
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine($"ProductID : {product.Id} | Quantity : {product.Quantity}");
                    Console.WriteLine("---------------------------------------------------------");
                }

                Console.WriteLine("---------------------------");
                Console.WriteLine($"Total Amount : {order.CartValue}");
                Console.WriteLine("---------------------------");
            }
        }

        private static void TakeProcessOrderFromUser(IProductLogic productLogic, IOrderLogic orderLogic)
        {
            IList<Product> orderProducts = null;
            Order order = null;
            IList<string> cart = null;
            Console.WriteLine("Enter the product(s) to add");
            cart = GenerateCart(Console.ReadLine());
            Console.WriteLine("Validating Cart...");
            Thread.Sleep(2000);
            if (ValidateCart(cart.Distinct()))
            {
                Console.WriteLine("Fetching product details...");

                orderProducts = ApplyPromotionsOnCart(productLogic, cart);

                Console.WriteLine("Generating Order and cart amount...");
                Thread.Sleep(3000);
                Console.WriteLine();
                var uniqueItems = orderProducts.ToList();
                order = new Order(uniqueItems);
                order.CartValue = uniqueItems.Sum(x => x.Price);
                orderLogic.AddOrder(order);

                Console.WriteLine("******************************************************");
                Console.WriteLine($"Order ID : {order.OrderID} Amount : {order.CartValue}");
                Console.WriteLine("******************************************************");

                PrintOrder(orderLogic);
            }
            else
            {
                Console.WriteLine("Cart has invalid products !!");
                Environment.Exit(1);
            }
        }

        public static IList<Product> ApplyPromotionsOnCart(IProductLogic productLogic, IList<string> cart)
        {
            List<Product> orderProducts = new List<Product>();

            var productGroup = cart.GroupBy(x => x).Select(y => new { productId = y.Key, Count = y.Count() });

            var productInfo = productGroup.Select(x =>
            new
            {
                ProductDetails = ProductList.GetProductInfo(x.productId),
                OrderQuantity = x.Count
            });

            Console.WriteLine("Applying possible promotions on the cart...");
            Thread.Sleep(3000);

            foreach (var product in productInfo)
            {
                Console.WriteLine($"Product : {product.ProductDetails.Id}: Orignal Price : {product.ProductDetails.Price}");

                var comboList = GeneratePossibleCombo(product.ProductDetails.Id, product.OrderQuantity, cart);

                var updatedProduct = productLogic.ApplyProductPromotion(product.ProductDetails, product.OrderQuantity, comboList);

                updatedProduct.Quantity = product.OrderQuantity;

                if (!orderProducts.Any(x => x.Id == updatedProduct.Id))
                {
                    var newOrder = updatedProduct;
                    orderProducts.Add(newOrder);
                }
            }
            return orderProducts;
        }

        public static IList<string> GenerateCart(string input)
        {
            var cart = input.Split(",").ToList();
            cart.Remove("");

            return cart;
        }

        public static bool ValidateCart(IEnumerable<string> cart)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in cart)
            {
                if (!ProductList.DoesExist(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static IList<string> GeneratePossibleCombo(string productId, int productQuantity, IList<string> cart)
        {
            IList<string> combinations = new List<string>();

            var otherItems = cart.Where(x => x != productId).ToList();

            for (int i = 0; i < otherItems.Count; i++)
            {
                if (productQuantity > 1)
                {
                    if (otherItems[i] != productId && i < productQuantity)
                    {
                        combinations.Add(productId + otherItems[i]);
                        //combinations.Add(otherItems[i] + productId);
                    }
                }
                else
                {
                    combinations.Add(productId + otherItems[i]);
                    //combinations.Add(otherItems[i] + productId);
                }
            }

            return combinations;
        }
    }
}
