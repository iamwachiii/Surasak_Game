using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_Friend_Hearts
{
    public class Phakin_Heart
    {
        public int Phakin_HeartWidth, Phakin_HeartHeight;
        public Rectangle Phakin_HeartRec;
        public Rectangle Phakin_HeartHitRec;
        public Rectangle Phakin_Heart_pos;

        public bool isVisible = true;

        public Phakin_Heart(Texture2D texture)
        {
            Phakin_HeartWidth = texture.Width/4; //240
            Phakin_HeartHeight = texture.Height; //1350 

            Phakin_HeartRec = new Rectangle(Phakin_HeartWidth * 1, 0, Phakin_HeartWidth, Phakin_HeartHeight);
            Phakin_HeartHitRec = new Rectangle((int)Phakin_Heart_pos.X, (int)Phakin_Heart_pos.Y, Phakin_HeartWidth, Phakin_HeartHeight);

        }
    }
}
