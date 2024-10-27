using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK_03.All_Objects.Bedroom_Objs;

namespace SK_03.All_Objects.RestRoom_Objs
{
    public class Bathtub : Sprite
    {
        public int bathtubWidth, bathtubHeight;
        public Rectangle bathtubRec;
        public Vector2 bathtub_pos;

        public Bathtub(Texture2D texture)
        {
            bathtub_pos = new Vector2(1335, 153);

            bathtubWidth = 587;
            bathtubHeight = 758;

            bathtubRec = new Rectangle(88, 443, bathtubWidth, bathtubHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
