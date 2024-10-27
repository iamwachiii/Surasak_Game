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
    public class Stair_Guide : Sprite
    {
        public int stairGuideWidth, stairGuideHeight;
        public Rectangle stairGuideRec_left, stairGuideRec_right;
        public Rectangle stairGuideRec;

        public Stair_Guide(Texture2D texture)
        {
            stairGuideWidth = 76;
            stairGuideHeight = 68;

            stairGuideRec_left = new Rectangle(164, 168, stairGuideWidth, stairGuideHeight);
            stairGuideRec_right = new Rectangle(164, 168, stairGuideWidth, stairGuideHeight);
            stairGuideRec = new Rectangle(164, 168, stairGuideWidth, stairGuideHeight);
        }
    }
}
