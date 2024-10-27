using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Sofa : Sprite
    {
        public int sofaWidth, sofaHeight;
        public Rectangle sofaRec;
        public Vector2 sofa_pos;

        public Sofa(Texture2D texture)
        {
            sofa_pos = new Vector2(2887, 656);
            sofaWidth = 225;
            sofaHeight = 251;

            sofaRec = new Rectangle(3408, 1079, sofaWidth, sofaHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
