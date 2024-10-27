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
        public Rectangle safeRec;
        public Vector2 safe_pos;

        public Safe(Texture2D texture)
        {
            safe_pos = new Vector2(631, 615);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
