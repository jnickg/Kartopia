using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace K_Services
{
    public class FoodCartService : IFoodCartService
    {
        List<FoodCartInfo> _foodCarts = new List<FoodCartInfo>();

        public FoodCartService()
        {

        }

        public FoodCartService(List<FoodCartInfo> carts)
        {
            this._foodCarts = carts;
        }

        public List<MenuItemInfo> getFoodCartMenu(FoodCartInfo thisCart)
        {
            // Call something in K_FoodCartManager
            return null;
        }

        public List<FoodCartInfo> getFoodCarts()
        {
            return _foodCarts;
        }

        public List<MenuItemInfo> getMenuItemMatches(string searchParam)
        {
            List<MenuItemInfo> rtn = new List<MenuItemInfo>();
            foreach (FoodCartInfo fci in _foodCarts)
            {
                foreach (MenuItemInfo mii in fci.menuItems)
                {
                    if (mii.name.Contains(searchParam))
                    {
                        rtn.Add(mii);
                    }
                }
            }
            return rtn;
        }

        public List<FoodCartInfo> getFoodCartMatches(string searchParam)
        {
            // Call something in K_FoodCartManager
            return null;
        }
    }
}
