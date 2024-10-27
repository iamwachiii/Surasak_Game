using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_Friend_Hearts
{
    public class Paenghom_Heart
    {
        public int Paenghom_HeartWidth, Paenghom_HeartHeight;
        public Rectangle Paenghom_HeartRec;
        public Rectangle Paenghom_HeartHitRec;
        public Rectangle Paenghom_Heart_pos;

        public bool isVisible = true;

        public Paenghom_Heart(Texture2D texture)
        {
            Paenghom_HeartWidth = texture.Width/4; //240
            Paenghom_HeartHeight = texture.Height; //1350 

            Paenghom_HeartRec = new Rectangle(Paenghom_HeartWidth * 3, 0, Paenghom_HeartWidth, Paenghom_HeartHeight);
            Paenghom_HeartHitRec = new Rectangle((int)Paenghom_Heart_pos.X, (int)Paenghom_Heart_pos.Y, Paenghom_HeartWidth, Paenghom_HeartHeight);

        }
    }
}
