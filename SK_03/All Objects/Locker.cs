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
    public class Locker : Sprite
    {
        public int LockerWidth, LockerHeight;
        public Rectangle LockerRec;
        //public Rectangle LockerHitRec;
        //public Vector2 Locker_pos;

        public Locker(Texture2D texture)
        {

            LockerWidth = 258;
            LockerHeight = 161;

            LockerRec = new Rectangle(1919, 1120, LockerWidth, LockerHeight);
            //LockerHitRec = new Rectangle((int)Locker_pos.X, (int)Locker_pos.Y, LockerWidth, LockerHeight);
        }

        public override void Update(GameTime gameTime)
        {         
            base.Update(gameTime);
        }     

    }
}
