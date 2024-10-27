using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Shrine : Sprite
    {
        public int shrineWidth, shrineHeight;
        public Rectangle shrineRec;
        public Vector2 shrine_pos;

        //เจ้าที่
        public Shrine(Texture2D texture)
        {

            shrine_pos = new Vector2(2080, 330);
            shrineWidth = 276;
            shrineHeight = 577;

            shrineRec = new Rectangle(1286, 1103, shrineWidth, shrineHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
