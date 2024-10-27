using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Mirror_living_room : Sprite
    {
        public int mirror1Width, mirror1Height;
        public Rectangle mirror1Rec;
        public Vector2 mirror1_pos;

        public Mirror_living_room(Texture2D texture)
        {
            mirror1_pos = new Vector2(830, 192);
            mirror1Width = 275;
            mirror1Height = 416;

            mirror1Rec = new Rectangle(3039, 256, mirror1Width, mirror1Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }

}
