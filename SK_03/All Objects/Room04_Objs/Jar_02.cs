using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Room04_Objs
{
    public class Jar_02 : Sprite
    {
        public int jar2Width, jar2Height;
        public Rectangle jar2Rec;
        public Vector2 jar2_pos;

        public Jar_02(Texture2D texture)
        {
            jar2_pos = new Vector2(1304, 792);

            jar2Width = 64;
            jar2Height = 104;

            jar2Rec = new Rectangle(48, 400, jar2Width, jar2Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
