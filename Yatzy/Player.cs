using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class Player
    {
        public List<Category> CategoriesLeft { get; set; }

        public Player()
        {
            CategoriesLeft = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
        }
        public int TakeTurn()
        {
            return 0;
        }

        public void RemoveUsedCategory(Category category)
        {
            CategoriesLeft.Remove(category);
        }
    }
}