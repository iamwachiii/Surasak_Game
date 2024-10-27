using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.LivingRoom_Objs
{
    public class Cabinet : Sprite
    {
        public int CabinetWidth, CabinetHeight;
        public Rectangle CabinetOpenRec;
        public Rectangle CabinetHitRec;
        public Vector2 Cabinet_pos;

        public Cabinet(Texture2D texture)
        {
            Cabinet_pos = new Vector2(1288, 463);
            CabinetWidth = 233;
            CabinetHeight = 161;

            CabinetOpenRec = new Rectangle(2831, 1319, CabinetWidth, CabinetHeight);
            CabinetHitRec = new Rectangle(0,0, CabinetWidth,CabinetHeight);
        }
    }
}
