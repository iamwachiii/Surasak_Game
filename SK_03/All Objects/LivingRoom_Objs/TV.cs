using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class TV : Sprite
    {
        public int tvWidth, tvHeight;
        public Rectangle tvRec;
        public Vector2 tv_pos;

        public TV(Texture2D texture)
        {
            tv_pos = new Vector2(1834, 490);
            tvWidth = 249;
            tvHeight = 257;

            tvRec = new Rectangle(1928, 767, tvWidth, tvHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
