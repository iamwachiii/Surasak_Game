using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_keys
{
    public class Basement_key : Sprite
    {
        public int Basement_keyWidth, Basement_keyHeight;
        public Rectangle Basement_keyRec;
        public Rectangle Basement_keyHitRec;
        public Rectangle Basement_key_pos;

        public bool isVisible = true;

        public Basement_key(Texture2D texture)
        {
            Basement_keyHeight = texture.Height; ; //1350 

            Basement_keyRec = new Rectangle(Basement_keyWidth * 2, 0, Basement_keyWidth, Basement_keyHeight);
            Basement_keyHitRec = new Rectangle((int)Basement_key_pos.X, (int)Basement_key_pos.Y, Basement_keyWidth, Basement_keyHeight);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
