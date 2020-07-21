using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using DataAccessLayer;

// This Class is Isolated based on the Unique Modifications and also for  Business Logic
namespace BusinessLayer
{
    public class ApplicationBusiness
    {
        List<enumCartItem> lstChar;
        private Dictionary<enumCartItem, IPromotion> _dictPromotionCart;
        private IPromotion objPromotion;
        private PromotionDataAccess objDataAccess;

        public ApplicationBusiness()
        {
            if (_dictPromotionCart == null || _dictPromotionCart.Count <=0)
            {   
                /// Design Principles Implemented
                /// RPI - Replace IF By Polimorphism
                /// Factory Pattern (object creation of the class is hidden) 
                /// DI -Dependency Injection (Ecternal entity has to decide the selection )
                /// Builder Pattern ( Implementaion/Constration is same but results diffrent in diffret objects)
                
                 objDataAccess = new PromotionDataAccess();
                _dictPromotionCart = new Dictionary<enumCartItem, IPromotion>();
                _dictPromotionCart.Add(enumCartItem.A, new PromotionA(objDataAccess.GetPromotionData(enumCartItem.A)));
                _dictPromotionCart.Add(enumCartItem.B, new PromotionB(objDataAccess.GetPromotionData(enumCartItem.B)));
                _dictPromotionCart.Add(enumCartItem.C, new PromotionC(objDataAccess.GetPromotionData(enumCartItem.C)));
                _dictPromotionCart.Add(enumCartItem.D, new PromotionD(objDataAccess.GetPromotionData(enumCartItem.D)));
            }
        }

        // Add to cart any type  of product unlimited in any order alsos.
        public void AddtoCart(enumCartItem enumCartItem)
        {
            if (lstChar == null || lstChar.Count ==0)
            {
                lstChar = new List<enumCartItem>();
            }
            lstChar.Add(enumCartItem); 
        }

        // Total cast cost calcualations  in one area and the dta will be seelcted inteh indivisual classes. 
        public int CalcuateCartCost()
        {
            int TotalCost = 0;
            if (lstChar.Count > 0)
            {
                TotalCost = GetTotalCost(enumCartItem.A); /// Calucation only for A Type SKU
                TotalCost += GetTotalCost(enumCartItem.B); /// Calucation only for B Type SKU

                if (lstChar.Contains(enumCartItem.C) && lstChar.Contains(enumCartItem.D)) /// Calucation for C and D Type SKU's
                {
                    int TotalCCount = lstChar.Count(ListItem => ListItem == enumCartItem.C);
                    int TotalDCount = lstChar.Count(ListItem => ListItem == enumCartItem.D);
                    GetTotalCost(enumCartItem.D);
                    if (TotalCCount == TotalDCount)
                    {
                        TotalCost += TotalCCount * objPromotion.PromotionPrice;
                    }
                    else if (TotalCCount > TotalDCount)
                    {
                        TotalCost += TotalDCount * objPromotion.PromotionPrice;
                        GetTotalCost(enumCartItem.C);
                        TotalCost += (TotalCCount - TotalDCount) * objPromotion.UnitPrice;
                    }
                    else
                    {
                        TotalCost += TotalCCount * objPromotion.PromotionPrice;
                        TotalCost += (TotalDCount - TotalCCount) * objPromotion.UnitPrice;
                    }                    
                }
                else
                {
                    TotalCost += GetTotalCost(enumCartItem.C);  /// Calucation only for C Type SKU's
                    TotalCost += GetTotalCost(enumCartItem.D); /// Calucation only for D Type SKU's
                }
            }
            if (lstChar != null && lstChar.Count > 0 )
            {
                lstChar.Clear();
            }

            return TotalCost;
        }

        // Clean and Clear Code Isolation based on the Cart Products.   
        private int GetTotalCost(enumCartItem enumValue)
        {
            _dictPromotionCart.TryGetValue(enumValue, out objPromotion);
            return objPromotion.GetCostPrice(lstChar.Count(ListItem => ListItem == enumValue));
        }
    }
}
