using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Room01_Objs
{
    public class Incense : Sprite
    {
        public int incenseWidth, incenseHeight;
        public Rectangle incenseRec;
        public Vector2 incense_pos;

        public Incense(Texture2D texture)
        {
            incense_pos = new Vector2(1650, 609);
            incenseWidth = 266;
            incenseHeight = 290;

            incenseRec = new Rectangle(2031, 1390, incenseWidth, incenseHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
