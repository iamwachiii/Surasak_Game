using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Switch_living_room : Sprite
    {
        public int switchWidth, switchHeight;
        public Rectangle switchRec;
        public Vector2 switch_pos;

        public Switch_living_room(Texture2D texture)
        {
            switch_pos = new Vector2(320, 520);
            switchWidth = 57;
            switchHeight = 88;

            switchRec = new Rectangle(32, 1216, switchWidth, switchHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
