using PromotionEngine.Dao.Interface;
using PromotionEngine.Logic.Interface;
using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Logic
{
    public class ProductLogic : IProductLogic
    {
        private IPromotionLogic _promoLogic;
        private IProductDao _productDao;

        public ProductLogic(IPromotionLogic promoLogic, IProductDao productDao)
        {
            _promoLogic = promoLogic;
            _productDao = productDao;
        }

        public bool CheckComboPromotion(string productId)
        {
            return _promoLogic.GetComboPromotions(productId).Any();
        }

        public bool CheckStandardPromotion(string productId)
        {
            return _promoLogic.GetStandardPromotions(productId).Any();
        }

        public void AddPromotion(Promotion promo)
        {
            _promoLogic.AddStandardPromotion(promo);
        }

        public void AddStandardPromotion(Promotion promo)
        {
            throw new NotImplementedException();
        }

        public void AddComboPromotion(Promotion promo)
        {
            throw new NotImplementedException();
        }

        public Promotion GetComboPromotionById(string comboId)
        {
            return _promoLogic.GetComboPromotions(comboId).First();
        }

        public List<Product> GetAllProducts()
        {
            var products = _productDao.GetAll();

            foreach (var product in products)
            {
                product.promos = _promoLogic.GetStandardPromotions(product.Id);
            }

            return products;
        }

        public Product ApplyProductPromotion(Product product, int orderQuantity, IList<string> comboList)
        {
            decimal discountPrice = 0m;

            if (CheckStandardPromotion(product.Id))
            {
                foreach (var promo in product.promos)
                {
                    if (promo.ProductQuantity == orderQuantity)
                    {
                        product.Price = promo.PromoPrice;
                    }
                    else if (promo.ProductQuantity > orderQuantity)
                    {
                        product.Price = orderQuantity * product.Price;
                    }
                    else if (promo.ProductQuantity < orderQuantity)
                    {
                        product.Price = _promoLogic.ApplyPromo(product, orderQuantity, promo);
                    }
                }
            }
            else
            {
                if(comboList.Any(x=>CheckComboPromotion(x)))
                {
                    return ApplyComboPromotion(product, orderQuantity, comboList);
                }                
            }


            return product;
        }

        private Product ApplyComboPromotion(Product product, int orderQuantity, IList<string> comboList)
        {
            decimal calculatedPrice = 0;

            foreach (var combo in comboList)
            {
                if (CheckComboPromotion(combo))
                {
                    product.Id = combo;
                    calculatedPrice += GetPrice(GetComboPromotionById(combo), product);
                }
            }

            if (orderQuantity > comboList.Count)
            {
                calculatedPrice += (orderQuantity - comboList.Count) * product.Price;
            }

            product.Price = calculatedPrice;

            return product;
        }

        private static decimal GetPrice(Promotion promotion, Product product)
        {
            return promotion.UnitOfPromo == PromoUnit.FlatPrice
                ? promotion.PromoPrice
                : promotion.DiscountPercent > 0 && promotion.UnitOfPromo == PromoUnit.Percentage ?
                product.Price * (promotion.DiscountPercent / 100)
                : product.Price;
        }
    }
}
