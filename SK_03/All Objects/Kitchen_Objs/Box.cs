using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Box : Sprite
    {
        public int boxWidth, boxHeight;
        public Rectangle boxRec;
        public Vector2 box_pos;

        public Box(Texture2D texture)
        {
            box_pos = new Vector2(440, 822);
            boxWidth = 257;
            boxHeight = 80;

            boxRec = new Rectangle(1312, 1384, boxWidth, boxHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
