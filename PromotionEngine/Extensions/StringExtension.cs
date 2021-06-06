using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Extensions
{
    public static class StringExtension
    {
        public static string ToReverse(this string str)
        {
            int Length = str.Length - 1;
            string reverse = "";

            while (Length >= 0)
            {
                reverse = reverse + str[Length];
                Length--;
            }

            return reverse;
        }
    }
}
