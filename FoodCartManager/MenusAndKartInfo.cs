// George Nicol
// CS 300 - LNG430
//
// Here is a simple console application that searchs a file in the system line by line
// for the text entered by the user (as prompted)
// Be sure to change the path to match where you put "myfile"
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace K_FoodCartManager                     // not really sure if this is supposed to match the main project or sub project
{

    public class MenusAndKartInfo                      // yes, I know you spell Food Cart with a C and not a K. But we have a theme going here....
    {
        /// <summary>
        /// this path to the menu and food cart data needs to be filled in.
        /// </summary>
        private readonly string kartpath = "menu.txt";
        private readonly int cartData = 0;


        /// <summary>
        /// Matches search term
        /// </summary>
        /// <param name="SearchTerm"></param>
        /// <returns></returns>
        public List<string> getMatch(string SearchTerm)
        {
            List<string> matches = new List<string>();
            if (File.Exists(kartpath))
            {
                foreach (string line in File.ReadLines(kartpath))
                {
                    if (cartData < line.IndexOf(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        matches.Add(line);
                    }
                }
            }
            return matches;
        }

        public List<string> getMenu()
        {
            List<string> matches = new List<string>();
            if (File.Exists(kartpath))
            {
                foreach (string line in File.ReadLines(kartpath))
                {
                    matches.Add(line);
                }
            }
            return matches;
        }
        /// <summary>
        /// Verifies that the full and complete line matches in the file.
        /// </summary>
        /// <param name="SearchTerm"></param>
        /// <returns></returns>
        public bool verifyItem(string SearchTerm)
        {
            bool searchResult = false;
            if (File.Exists(kartpath))
            {
                foreach (string line in File.ReadLines(kartpath))
                {
                    if (line.Equals(SearchTerm))
                        searchResult = true;
                }
            }
            return searchResult;
        }


    }
}