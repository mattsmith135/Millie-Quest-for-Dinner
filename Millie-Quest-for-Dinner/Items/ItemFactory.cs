using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{
    /// <summary>
    /// Implements the factory method. Creates enemy objects without exposing the 
    /// instantiation logic to the client. 
    /// </summary>
    public class ItemFactory
    {
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public ItemFactory()
        {
            // populating dictionary
            _items.Add("poop", new Dinner());
            _items.Add("django", new Django()); 
        }

        /// <summary>
        /// Creates an item based on the itemName string passed into the function. 
        /// It creates the enemy using the _items dictionary
        /// </summary>
        /// <param name="itemName">Name of item you want to create</param>
        /// <returns>Item corresponding to key passed in</returns>
        public Item createItem(string itemName)
        {
            itemName = itemName.ToLower();

            Item item = _items[itemName]; 

            if (item == null)
            {
                return null;
            } else
            {
                return item; 
            }


        }
    }

    
}
