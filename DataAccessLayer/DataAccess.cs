using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;

namespace DataAccessLayer
{
    public class PromotionDataAccess
    {
        List<stPromotion> lstPromotion;

        // Read from database
        // Values are hardcoded to speed up the process.
        // We can implement the same from any database like MsSQL/ MySQL/XML/Json/Excel/txt/csv files etc...
        // This Class is Isolated based on the Unique Modifications and also for SRP (SOLID) Single Responsibility Principle 
        
        public stPromotion  GetPromotionData(enumCartItem enumCartItem)
        {
            if (lstPromotion == null || lstPromotion.Count <= 0)
            {
                // Deaign pattern Like Singleton/Factory may be implement to get the same
                lstPromotion = new List<stPromotion>();
                lstPromotion.Add(new stPromotion() { enumCartItem = enumCartItem.A, UnitPrice = 50, DiscountUnits = 3, DiscountedPrice = 130 });
                lstPromotion.Add(new stPromotion() { enumCartItem = enumCartItem.B, UnitPrice = 30, DiscountUnits = 2, DiscountedPrice = 45 });
                lstPromotion.Add(new stPromotion() { enumCartItem = enumCartItem.C, UnitPrice = 20, DiscountUnits = 1, DiscountedPrice = 30 });
                lstPromotion.Add(new stPromotion() { enumCartItem = enumCartItem.D, UnitPrice = 15, DiscountUnits = 1, DiscountedPrice = 30 });
            }

            //based on the search Key as parameter the data will be returned. one by one.
            return  lstPromotion.Find(listItem => listItem.enumCartItem == enumCartItem);
        }
    }
}
