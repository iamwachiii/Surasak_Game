using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Fridge : Sprite
    {
        public int fridgeWidth, fridgeHeight;
        public Rectangle fridgeRec;
        public Vector2 fridge_pos;

        public Fridge(Texture2D texture)
        {
            fridge_pos = new Vector2(2320, 270);
            fridgeWidth = 321;
            fridgeHeight = 633;

            fridgeRec = new Rectangle(1256, 711, fridgeWidth, fridgeHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
