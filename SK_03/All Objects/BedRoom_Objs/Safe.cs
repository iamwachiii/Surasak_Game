using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Bedroom_Objs
{
    public class Safe : Sprite
    {
        public int safeWidth, safeHeight;
        public int safeOpenWidth, safeOpenHeight;
        public Rectangle safeRec;
        public Rectangle safeOpenRec;
        public Vector2 safe_pos;

        public Safe(Texture2D texture)
        {
            safe_pos = new Vector2(631, 615);
            safeWidth = 272;
            safeHeight = 280;

            safeOpenWidth = 480;
            safeOpenHeight = 282;

            safeRec = new Rectangle(1024, 655, safeWidth, safeHeight);
            safeOpenRec = new Rectangle(1520, 1206, safeOpenWidth, safeOpenHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
