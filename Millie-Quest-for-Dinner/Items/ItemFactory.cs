using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie_Quest_for_Dinner
{ 
    public class ItemFactory
    {
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public ItemFactory()
        {
            _items.Add("poop", new Dinner());
            _items.Add("django", new Django()); 
        }

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
