using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Room01_Objs
{
    public class Phakin : Sprite
    {
        public int phakinWidth, phakinHeight;
        public Rectangle phakinRec;
        public Vector2 phakin_pos;

        public Phakin(Texture2D texture)
        {
            phakin_pos = new Vector2(984, 414);
            phakinWidth = 408;
            phakinHeight = 257;

            phakinRec = new Rectangle(2360, 1111, phakinWidth, phakinHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
