using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Menu_Icon
{
    public class Start_Guide : Sprite
    {
        public int startGuideWidth, startGuideHeight;
        public Rectangle startGuideRec_left, startGuideRec_right;
        public Rectangle startGuideRec;

        public Start_Guide(Texture2D texture)
        {
            startGuideWidth = 300;
            startGuideHeight = 110;

            //startGuideRec_left = new Rectangle(168, 104, startGuideWidth, startGuideHeight);
            //startGuideRec_right = new Rectangle(168, 104, startGuideWidth, startGuideHeight);
            startGuideRec = new Rectangle(0, 291, startGuideWidth, startGuideHeight);
        }
    }
}
