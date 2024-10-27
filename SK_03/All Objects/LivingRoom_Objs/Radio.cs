using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Radio : Sprite
    {
        public int radioWidth, radioHeight;
        public Rectangle radioRec;
        public Vector2 radio_pos;

        public Radio(Texture2D texture)
        {
            radio_pos = new Vector2(2164, 632);
            radioWidth = 121;
            radioHeight = 112;

            radioRec = new Rectangle(2304, 912, radioWidth, radioHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
