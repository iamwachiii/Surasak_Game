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
    public class Guide : Sprite
    {
        public int guideWidth, guideHeight;
        public Rectangle guideRec_left, guideRec_right;
        public Rectangle guideRec;

        public Guide(Texture2D texture)
        {
            guideWidth = 56;
            guideHeight = 52;

            guideRec_left = new Rectangle(168, 104, guideWidth, guideHeight);
            guideRec_right = new Rectangle(168, 104, guideWidth, guideHeight);
            guideRec = new Rectangle(168, 104, guideWidth, guideHeight);
        }
    }
}
