using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_keys
{
    public class Hairpin : Sprite
    {
        public int HairpinWidth, HairpinHeight;
        public Rectangle HairpinRec;
        public Rectangle HairpinHitRec;
        public Rectangle Hairpin_pos;

        public bool isVisible = true;

        public Hairpin(Texture2D texture)
        {
            HairpinWidth = texture.Width / 7; //240
            HairpinHeight = texture.Height; //1350 

            HairpinRec = new Rectangle(HairpinWidth * 5, 0, HairpinWidth, HairpinHeight);
            HairpinHitRec = new Rectangle((int)Hairpin_pos.X, (int)Hairpin_pos.Y, HairpinWidth, HairpinHeight);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
