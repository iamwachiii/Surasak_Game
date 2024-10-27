using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Hallway_key : Sprite
    {
        public int Hallway_keyWidth, Hallway_keyHeight;
        public Rectangle Hallway_keyRec;
        public Rectangle Hallway_keyHitRec;
        public Rectangle Hallway_key_pos;

        public bool isVisible = true;

        public Hallway_key(Texture2D texture)
        {
            Hallway_keyHeight = texture.Height;

            Hallway_keyRec = new Rectangle(Hallway_keyWidth * 0 , 0, Hallway_keyWidth, Hallway_keyHeight);
            Hallway_keyHitRec = new Rectangle((int)Hallway_key_pos.X, (int)Hallway_key_pos.Y, Hallway_keyWidth, Hallway_keyHeight);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
