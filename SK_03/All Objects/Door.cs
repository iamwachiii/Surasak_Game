using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03
{
    public class Door : Sprite
    {
        public int doorWidth, doorHeight;
        public Rectangle doorRec_left, doorRec_right;
        public Vector2 door_pos;


        public Door(Texture2D texture)
        {

            door_pos = new Vector2(100, 100);
            doorWidth = 54;
            doorHeight = 648;

            doorRec_left = new Rectangle(1129 - doorWidth, 0, doorWidth, doorHeight);
            doorRec_right = new Rectangle(1129, 0, doorWidth, doorHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
       
    }
}
