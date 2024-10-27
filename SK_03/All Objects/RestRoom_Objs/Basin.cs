using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.RestRoom_Objs
{
    public class Basin : Sprite
    {
        public int basinWidth, basinHeight;
        public Rectangle basinRec;
        public Vector2 basin_pos;

        public Basin(Texture2D texture)
        {
            basin_pos = new Vector2(384, 566);

            basinWidth = 346;
            basinHeight = 338;

            basinRec = new Rectangle(1127, 814, basinWidth, basinHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
