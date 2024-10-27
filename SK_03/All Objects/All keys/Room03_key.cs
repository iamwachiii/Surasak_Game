using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Room03_key : Sprite
    {
        public int Room03_keyWidth, Room03_keyHeight;
        public Rectangle Room03_keyRec;
        public Rectangle Room03_keyHitRec;
        public Rectangle Room03_key_pos;

        public bool isVisible = true;

        public Room03_key(Texture2D texture)
        {
            Room03_keyWidth = texture.Width / 7;
            Room03_keyHeight = texture.Height;

            Room03_keyRec = new Rectangle(Room03_keyWidth * 3, 0, Room03_keyWidth, Room03_keyHeight);
            Room03_keyHitRec = new Rectangle((int)Room03_key_pos.X, (int)Room03_key_pos.Y, Room03_keyWidth, Room03_keyHeight);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
