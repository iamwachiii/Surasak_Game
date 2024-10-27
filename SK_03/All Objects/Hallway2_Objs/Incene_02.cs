using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Hallway2_Objs
{
    public class Incense_02 : Sprite
    {
        public int incense2Width, incense2Height;
        public Rectangle incense2Rec;
        public Vector2 incense2_pos;

        public Incense_02(Texture2D texture)
        {
            incense2_pos = new Vector2(2000, 528);
            incense2Width = 81;
            incense2Height = 128;

            incense2Rec = new Rectangle(639, 64, incense2Width, incense2Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
