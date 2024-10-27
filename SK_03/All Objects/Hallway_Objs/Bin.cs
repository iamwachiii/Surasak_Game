using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Bin : Sprite
    {
        public int binWidth, binHeight;
        public Rectangle binRec;
        public Vector2 bin_pos;

        public Bin(Texture2D texture)
        {
            bin_pos = new Vector2(3231, 760);
            binWidth = 210;
            binHeight = 144;

            binRec = new Rectangle(1391, 864, binWidth, binHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }

}
