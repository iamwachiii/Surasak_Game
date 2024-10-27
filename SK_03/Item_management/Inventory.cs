using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SK_03
{
    public class Inventory
    {
        // รายการของไอเทมทั้งหมดใน Inventory
        public List<Item> Items { get; private set; }

        public Inventory()
        {
            Items = new List<Item>();
        }

        // เมธอดสำหรับการเพิ่มไอเทม
        public void AddItem(Item item)
        {
          
            if (Items.Count >= 50)
            {
                //Console.WriteLine("Inventory is full!");
                return;
            }

            var existingItem = Items.FirstOrDefault(i => i.Name == item.Name);
            if (existingItem == null)
            {
                Items.Add(item);
            }

        }

        // เมธอดสำหรับการลบไอเทม
        public void RemoveItem(string itemName)
        {
            var item = Items.FirstOrDefault(i => i.Name == itemName);
            Items.Remove(item);
        }
    }
}
