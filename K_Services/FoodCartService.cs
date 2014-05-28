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
        List<MenuItemInfo> getFoodCartMenu(FoodCartInfo thisCart)
        {
            // Call something in K_FoodCartManager
            return null;
        }

        List<FoodCartInfo> getFoodCarts()
        {
            // Call something in K_FoodCartManager
            return null;
        }

        List<MenuItemInfo> getMenuItemMatches(string searchParam)
        {
            // Call something in K_FoodCartManager
            return null;
        }

        List<FoodCartInfo> getFoodCartMatches(string searchParam)
        {
            // Call something in K_FoodCartManager
            return null;
        }
    }
}
