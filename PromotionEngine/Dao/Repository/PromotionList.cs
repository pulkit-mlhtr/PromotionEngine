using PromotionEngine.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Dao.Repository
{
    public static class PromotionList
    {
        private static IList<Promotion> ComboPromotions;

        static PromotionList()
        {
            ComboPromotions = new List<Promotion>();
        }

       
        public static void LoadComboPromotions()
        {
            ComboPromotions.Add("CD", 30);
        }

        /// <summary>
        /// Provide list of promotion on combination of products.
        /// By default, one-one quantity of each production is considered ()Assumption
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string,decimal> GetAllComboPromotions()
        {
            return ComboPromotions;
        }

        /// <summary>
        /// Add Combo promotion of two products
        /// By default, one-one quantity of each product is considered (Assumption)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, decimal> AddComboPromo()
        {
            return ComboPromotions;
        }
    }
}
