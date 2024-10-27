using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Pot : Sprite
    {
        public int potWidth, potHeight;
        public Rectangle potRec;
        public Vector2 pot_pos;

        public Pot(Texture2D texture)
        {
            pot_pos = new Vector2(1565, 504);
            potWidth = 153;
            potHeight = 112;

            potRec = new Rectangle(1080, 1192, potWidth, potHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
