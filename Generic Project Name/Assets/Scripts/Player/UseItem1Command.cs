using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Command
{
    public class UseItem1Command : ScriptableObject, IPlayerCommand<Inventory>
    {

        public void Execute(Inventory inventory)
        {
            Item targetItem = null;
            foreach (Item item in inventory.GetItemList())
            {
                if (item.itemType == Item.ItemType.Heart)
                {
                    targetItem = item;
                }
            }
            if (targetItem != null)
            {
                inventory.UseItem(targetItem);
            }
        }
    }
}