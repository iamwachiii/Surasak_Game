using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.RestRoom_Objs
{
    public class Toilet : Sprite
    {
        public int toiletWidth, toiletHeight;
        public Rectangle toiletRec;
        public Vector2 toilet_pos;

        public Toilet(Texture2D texture)
        {
            toilet_pos = new Vector2(888, 565);

            toiletWidth = 192;
            toiletHeight = 339;

            toiletRec = new Rectangle(800, 824, toiletWidth, toiletHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
