using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_Friend_Hearts
{
    public class Waewdao_Heart
    {
        public int Waewdao_HeartWidth, Waewdao_HeartHeight;
        public Rectangle Waewdao_HeartRec;
        public Rectangle Waewdao_HeartHitRec;
        public Rectangle Waewdao_Heart_pos;

        public bool isVisible = true;

        public Waewdao_Heart(Texture2D texture)
        {
            Waewdao_HeartWidth = texture.Width/4; //240
            Waewdao_HeartHeight = texture.Height; //1350 

            Waewdao_HeartRec = new Rectangle(Waewdao_HeartWidth * 2, 0, Waewdao_HeartWidth, Waewdao_HeartHeight);
            Waewdao_HeartHitRec = new Rectangle((int)Waewdao_Heart_pos.X, (int)Waewdao_Heart_pos.Y, Waewdao_HeartWidth, Waewdao_HeartHeight);

        }
    }
}
