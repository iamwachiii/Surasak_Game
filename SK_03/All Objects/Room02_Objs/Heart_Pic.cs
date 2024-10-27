using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Room02_Objs
{
    public class Heart_Pic : Sprite
    {
        public int heartPicWidth, heartPicHeight;
        public Rectangle heartPicRec;
        public Vector2 heartPic_pos;

        public Heart_Pic(Texture2D texture)
        {
            heartPic_pos = new Vector2(902, 286);
            heartPicWidth = 344;
            heartPicHeight = 352;

            heartPicRec = new Rectangle(2016, 320, heartPicWidth, heartPicHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
