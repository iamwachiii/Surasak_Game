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
    public class Exit_Guide : Sprite
    {
        public int exitGuideWidth, exitGuideHeight;
        public Rectangle exitGuideRec_left, exitGuideRec_right;
        public Rectangle exitGuideRec;

        public Exit_Guide(Texture2D texture)
        {
            exitGuideWidth = 200;
            exitGuideHeight = 60;

            //startGuideRec_left = new Rectangle(168, 104, startGuideWidth, startGuideHeight);
            //startGuideRec_right = new Rectangle(168, 104, startGuideWidth, startGuideHeight);
            exitGuideRec = new Rectangle(0, 740, exitGuideWidth, exitGuideHeight);
        }
    }
}
