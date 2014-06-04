using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace K_FoodCartManager
{
    public class FCMtest
    {
        public static void Main(String[] args)
        {
            List<String> found;
            MenusAndKartInfo testing = new MenusAndKartInfo();
            found = testing.getMatch("hamburger");
            Debug.Assert(found.Count != 0, "Found item when it shouldn't.");
            Debug.Assert(testing.verifyItem("wine"), "Should not have verified item.");
            found = testing.getMatch("CHEESEBURGER");
            Debug.Assert(found.Count == 2, "Should have found two items.");
            foreach (string item in found)
            {
                Debug.Assert(testing.verifyItem(item), "Should have verified item");
            }
            found = testing.getMenu();
            Debug.Assert(found.Count == 5, "Returned incorrect amount items"); 
            foreach (string item in found)
            {
                Debug.Assert(testing.verifyItem(item), "Should have verified item");
            }

      
            
           

            
            

        }
    }
}
