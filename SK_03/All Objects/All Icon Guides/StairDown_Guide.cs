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
    public class StairDown_Guide : Sprite
    {
        public int stairDownGuideWidth, stairDownGuideHeight;
        public Rectangle stairDownGuideRec_left, stairDownGuideRec_right;
        public Rectangle stairDownGuideRec;

        public StairDown_Guide(Texture2D texture)
        {
            stairDownGuideWidth = 76;
            stairDownGuideHeight = 72;

            stairDownGuideRec_left = new Rectangle(164, 4, stairDownGuideWidth, stairDownGuideHeight);
            stairDownGuideRec_right = new Rectangle(164, 4, stairDownGuideWidth, stairDownGuideHeight);
            stairDownGuideRec = new Rectangle(164, 4, stairDownGuideWidth, stairDownGuideHeight);
        }
    }
}
