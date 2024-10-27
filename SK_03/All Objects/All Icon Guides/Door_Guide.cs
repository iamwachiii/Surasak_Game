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
    public class Door_Guide : Sprite
    {
        public int doorGuideWidth, doorGuideHeight;
        public Rectangle doorGuideRec_left, doorGuideRec_right;
        public Rectangle doorGuideRec;

        public Door_Guide(Texture2D texture)
        {
            doorGuideWidth = 60;
            doorGuideHeight = 60;

            doorGuideRec_left = new Rectangle(160, 340, doorGuideWidth, doorGuideHeight);
            doorGuideRec_right = new Rectangle(160, 340, doorGuideWidth, doorGuideHeight);
            doorGuideRec = new Rectangle(160, 340, doorGuideWidth, doorGuideHeight);
        }
    }
}
