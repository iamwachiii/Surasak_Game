using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_Friend_Hearts
{
    public class Arthid_Heart
    {
        public int Arthid_HeartWidth, Arthid_HeartHeight;
        public Rectangle Arthid_HeartRec;
        public Rectangle Arthid_HeartHitRec;
        public Rectangle Arthid_Heart_pos;

        public bool isVisible = true;

        public Arthid_Heart(Texture2D texture)
        {
            Arthid_HeartWidth = texture.Width/4; //240
            Arthid_HeartHeight = texture.Height; //1350 

            Arthid_HeartRec = new Rectangle(Arthid_HeartWidth * 0, 0, Arthid_HeartWidth, Arthid_HeartHeight);
            Arthid_HeartHitRec = new Rectangle((int)Arthid_Heart_pos.X, (int)Arthid_Heart_pos.Y, Arthid_HeartWidth, Arthid_HeartHeight);

        }
    }
}
