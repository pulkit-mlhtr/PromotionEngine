using PromotionEngine.Models.Base;
using PromotionEngine.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Dao.Repository
{
    public static class PromotionList
    {
        private static IList<ComboPromotion> ComboPromotions;
        private static IList<Promotion> StandardPromotions;

        static PromotionList()
        {
            ComboPromotions = new List<ComboPromotion>();
            StandardPromotions = new List<Promotion>();
            LoadComboPromotions();
            LoadStandardPromotions();
        }


        private static void LoadComboPromotions()
        {
            ComboPromotions.Add(new ComboPromotion(Guid.NewGuid(), "CD", 1, 30, PromoUnit.FlatPrice));
        }

        private static void LoadStandardPromotions()
        {
            StandardPromotions.Add(new PromotionC(Guid.NewGuid(), "A", 3, 130, PromoUnit.FlatPrice));
            StandardPromotions.Add(new PromotionB(Guid.NewGuid(), "B", 2, 45, PromoUnit.FlatPrice));
        }

        /// <summary>
        /// Provide list of promotion on combination of products.
        /// By default, one-one quantity of each production is considered (Assumption)
        /// </summary>
        /// <returns></returns>
        public static IList<ComboPromotion> GetAllComboPromotions()
        {
            return ComboPromotions;
        }

        /// <summary>
        /// Provide list of promotion on combination of products.
        /// By default, one-one quantity of each production is considered (Assumption)
        /// </summary>
        /// <returns></returns>
        public static IList<Promotion> GetAllStandardPromotions()
        {

            return StandardPromotions;
        }

        /// <summary>
        /// Add Combo promotion of two products
        /// By default, one-one quantity of each product is considered (Assumption)
        /// </summary>
        /// <returns></returns>
        public static void AddComboPromo(ComboPromotion promo)
        {
            if (!ComboPromotions.Any(x => x.ProductId == promo.ProductId))
            {
                ComboPromotions.Add(promo);
            }
        }

        /// <summary>
        /// Add standard promotion of a products
        /// </summary>
        /// <returns></returns>
        public static void AddStandardPromo(Promotion promo)
        {
            if (!StandardPromotions.Any(x => x.ProductId == promo.ProductId))
            {
                StandardPromotions.Add(promo);
            }
        }
    }
}
