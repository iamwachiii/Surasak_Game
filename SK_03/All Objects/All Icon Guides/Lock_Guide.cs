using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SK_03.All_Objects.All_Icon_Guides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Lock_Guide : Sprite
    {
        public int lock_GuideWidth, lock_GuideHeight;
        public Rectangle lock_GuideRec;

        public Lock_Guide(Texture2D texture)
        {
            lock_GuideWidth = 107;
            lock_GuideHeight = 59;
            lock_GuideRec = new Rectangle(161, 259, lock_GuideWidth, lock_GuideHeight);

        }
    }
}
