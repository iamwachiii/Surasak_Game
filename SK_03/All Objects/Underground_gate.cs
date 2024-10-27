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
    public class Underground_gate : Sprite
    {
        public int Underground_gateWidth, Underground_gateHeight;
        public Rectangle Underground_gateRec;



        public Underground_gate(Texture2D texture)
        {


            Underground_gateWidth = 457;
            Underground_gateHeight = 49;

            Underground_gateRec = new Rectangle(16, 1391, Underground_gateWidth, Underground_gateHeight);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
