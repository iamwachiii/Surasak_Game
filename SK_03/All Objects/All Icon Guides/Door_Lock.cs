using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Door_Lock : Sprite
    {
        public int doorLockWidth, doorLockHeight;
        public Rectangle doorLockRec_left, doorLockRec_right;
        public Rectangle doorLockRec;

        public Door_Lock(Texture2D texture)
        {
            doorLockWidth = 44;
            doorLockHeight = 56;

            doorLockRec_left = new Rectangle(164, 260, doorLockWidth, doorLockHeight);
            doorLockRec_right = new Rectangle(164, 260, doorLockWidth, doorLockHeight);
            doorLockRec = new Rectangle(164, 260, doorLockWidth, doorLockHeight);
        }
    }
}
