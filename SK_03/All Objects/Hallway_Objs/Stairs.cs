using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Stairs : Sprite
    {
        public int stairWidth, stairHeight;
        public Rectangle stairRec;

        public Stairs(Texture2D texture)
        {
            stairWidth = 67;
            stairHeight = 367;

            stairRec = new Rectangle(336, 1313, stairWidth, stairHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
