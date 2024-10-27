using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Basement
{
    public class Ghost_1 : Sprite
    {
        public int ghost1Width, ghost1Height;
        public Rectangle ghost1Rec;
        public Vector2 ghost1_pos;

        public Ghost_1(Texture2D texture)
        {
            ghost1_pos = new Vector2(1504, 512);

            ghost1Width = 268;
            ghost1Height = 385;

            ghost1Rec = new Rectangle(2742, 1295, ghost1Width, ghost1Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
