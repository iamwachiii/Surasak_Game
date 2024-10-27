using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03
{
    public class Screwdriver : Sprite
    {
        public int screwdriverWidth, screwdriverHeight;
        public Rectangle screwdriverRec;
        public Vector2 screwdriver_pos;

        public Screwdriver(Texture2D texture)
        {
            screwdriver_pos = new Vector2(417, 879);
            screwdriverWidth = 112;
            screwdriverHeight = 26;

            screwdriverRec = new Rectangle(656, 839, screwdriverWidth, screwdriverHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
