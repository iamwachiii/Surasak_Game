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
    public class Locker_Guide : Sprite
    { 
        public int lockerGuideWidth, lockerGuideHeight;
        public Rectangle lockerGuideRec_left, lockerGuideRec_right;
        public Rectangle lockerGuideRec;

        public Locker_Guide(Texture2D texture)
        {
            lockerGuideWidth = 60;
            lockerGuideHeight = 56;

            lockerGuideRec_left = new Rectangle(160, 184, lockerGuideWidth, lockerGuideHeight);
            lockerGuideRec_right = new Rectangle(160, 184, lockerGuideWidth, lockerGuideHeight);
            lockerGuideRec = new Rectangle(160, 184, lockerGuideWidth, lockerGuideHeight);
        }
    }
}
