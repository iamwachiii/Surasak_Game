using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SK_03
{
    public class Item
    {
        public string Name { get; set; }
        public Texture2D Icon { get; set; }

        public Rectangle IconRec { get; set; }
        public Texture2D DetailTexture { get; set; }

        public Rectangle DetailRec { get; set; }
        public bool IsDetailVisible { get; set; } // เพิ่ม property เพื่อจัดการการแสดงรายละเอียด

        public Item(string name, Texture2D icon, Rectangle iconRec, Texture2D detailTexture, Rectangle detailRec)
        {
            Name = name;
            Icon = icon;
            IconRec = iconRec;
            DetailTexture = detailTexture;
            DetailRec = detailRec;
            IsDetailVisible = false; // เริ่มต้นไม่แสดงรายละเอียด
        }
        /*public Item(string name, Rectangle icon, int quantity, Texture2D detailTexture)
        {
            Name = name;
            IconRec = icon;
            Quantity = quantity;
            DetailTexture = detailTexture;
            IsDetailVisible = false; // เริ่มต้นไม่แสดงรายละเอียด
        }*/
    }
}
