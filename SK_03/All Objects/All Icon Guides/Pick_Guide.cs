using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.All_Icon_Guides
{
    public class Pick_Guide : Sprite
    {
        public int pick_GuideWidth, pick_GuideHeight;
        public Rectangle pick_GuideRec;

        public Pick_Guide(Texture2D texture)
        {
            pick_GuideWidth = 65;
            pick_GuideHeight = 84;
            pick_GuideRec = new Rectangle(0,0, pick_GuideWidth,pick_GuideHeight);

        }
    }
}
