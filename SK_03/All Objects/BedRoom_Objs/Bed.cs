using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Bedroom_Objs
{
    public class Bed : Sprite
    {
        public int bedWidth, bedHeight;
        public Rectangle bedRec;
        public Vector2 bed_pos;

        public Bed(Texture2D texture)
        {
            bed_pos = new Vector2(1800, 478);
            bedWidth = 644;
            bedHeight = 419;

            bedRec = new Rectangle(29, 1119, bedWidth, bedHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
