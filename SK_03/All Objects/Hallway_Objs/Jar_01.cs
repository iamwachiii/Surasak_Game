using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Jar_01 : Sprite
    {
        public int jarWidth, jarHeight;
        public Rectangle jarRec;
        public Vector2 jar_pos;

        public Jar_01(Texture2D texture)
        {
            jar_pos = new Vector2(1232, 552);
            jarWidth = 81;
            jarHeight = 104;

            jarRec = new Rectangle(1032, 128, jarWidth, jarHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
