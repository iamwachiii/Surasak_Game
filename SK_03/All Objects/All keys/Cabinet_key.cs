using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_keys
{
    public class Cabinet_key : Sprite
    {
        public int Cabinet_keyWidth, Cabinet_keyHeight;
        public Rectangle Cabinet_keyRec;
        public Rectangle Cabinet_keyHitRec;
        public Rectangle Cabinet_key_pos;

        public bool isVisible = true;

        public Cabinet_key(Texture2D texture)
        {
            Cabinet_keyWidth = texture.Width / 7;
            Cabinet_keyHeight = texture.Height;

            Cabinet_keyRec = new Rectangle(Cabinet_keyWidth * 6, 0, Cabinet_keyWidth, Cabinet_keyHeight);
            Cabinet_keyHitRec = new Rectangle((int)Cabinet_key_pos.X, (int)Cabinet_key_pos.Y, Cabinet_keyWidth, Cabinet_keyHeight);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
