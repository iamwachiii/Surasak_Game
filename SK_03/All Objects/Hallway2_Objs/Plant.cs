using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Hallway2_Objs
{
    public class Plant : Sprite
    {
        public int plantWidth, plantHeight;
        public Rectangle plantRec;
        public Vector2 plant_pos;

        public Plant(Texture2D texture)
        {
            plant_pos = new Vector2(3222, 599);
            plantWidth = 257;
            plantHeight = 304;

            plantRec = new Rectangle(888, 127, plantWidth, plantHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
