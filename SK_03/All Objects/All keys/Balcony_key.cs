using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_keys
{
    public class Balcony_key : Sprite
    {
        public int Balcony_keyWidth, Balcony_keyHeight;
        public Rectangle Balcony_keyRec;
        public Rectangle Balcony_keyHitRec;
        public Rectangle Balcony_key_pos;

        public bool isVisible = true;

        public Balcony_key(Texture2D texture)
        {
            Balcony_keyHeight = texture.Height;

            Balcony_keyRec = new Rectangle(Balcony_keyWidth * 4, 0, Balcony_keyWidth, Balcony_keyHeight);
            Balcony_keyHitRec = new Rectangle((int)Balcony_key_pos.X, (int)Balcony_key_pos.Y, Balcony_keyWidth, Balcony_keyHeight);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
