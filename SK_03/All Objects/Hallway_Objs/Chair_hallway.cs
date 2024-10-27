using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Chair_hallway : Sprite
    {
        public int chairWidth, chairHeight;
        public Rectangle chairRec;
        public Vector2 chair_pos;

        public Chair_hallway(Texture2D texture)
        {
            chair_pos = new Vector2(937, 623);
            chairWidth = 185;
            chairHeight = 281;

            chairRec = new Rectangle(1328, 335, chairWidth, chairHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
