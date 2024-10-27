using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_keys
{
    public class Bedroom_Key : Sprite
    {
        public int Bedroom_KeyWidth, Bedroom_KeyHeight;
        public Rectangle Bedroom_KeyRec;
        public Rectangle Bedroom_KeyHitRec;
        public Rectangle Bedroom_Key_pos;

        public bool isVisible = true;

        public Bedroom_Key(Texture2D texture)
        {
            Bedroom_KeyWidth = texture.Width / 7;
            Bedroom_KeyHeight = texture.Height;

            Bedroom_KeyRec = new Rectangle(Bedroom_KeyWidth * 1, 0, Bedroom_KeyWidth, Bedroom_KeyHeight);
            Bedroom_KeyHitRec = new Rectangle((int)Bedroom_Key_pos.X, (int)Bedroom_Key_pos.Y, Bedroom_KeyWidth, Bedroom_KeyHeight);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
