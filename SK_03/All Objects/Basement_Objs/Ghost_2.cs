using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Basement
{
    public class Ghost_2 : Sprite
    {
        public int ghostPicWidth, ghostPicHeight;
        public Rectangle ghostPicRec;
        public Vector2 ghostPic_pos;

        public Ghost_2(Texture2D texture)
        {
            ghostPic_pos = new Vector2(1470, 166);

            ghostPicWidth = 345;
            ghostPicHeight = 411;

            ghostPicRec = new Rectangle(336, 679, ghostPicWidth, ghostPicHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
