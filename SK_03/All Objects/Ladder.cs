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
    public class Ladder : Sprite
    {
        public int ladderWidth, ladderHeight;
        public Rectangle ladderRec;
        public Vector2 ladder_pos;


        public Ladder(Texture2D texture)
        {

            ladder_pos = new Vector2(100, 100);
            ladderWidth = 40; //240
            ladderHeight = 645; //1350 

            ladderRec = new Rectangle(460, 705, ladderWidth, ladderHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
