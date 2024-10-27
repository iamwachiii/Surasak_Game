using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Picture_hallway : Sprite
    {
        public int picture1Width, picture1Height;
        public Rectangle picture1Rec;
        public Vector2 picture1_pos;

        public Picture_hallway(Texture2D texture)
        {
            picture1_pos = new Vector2(1249, 128);
            picture1Width = 336;
            picture1Height = 400;

            picture1Rec = new Rectangle(335, 270, picture1Width, picture1Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
