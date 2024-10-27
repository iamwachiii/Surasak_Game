using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Calendar : Sprite
    {
        public int calendarWidth, calendarHeight;
        public Rectangle calendarRec;
        public Vector2 calendar_pos;

        public Calendar(Texture2D texture)
        {
            calendar_pos = new Vector2(1288, 463);
            calendarWidth = 121;
            calendarHeight = 185;

            calendarRec = new Rectangle(1872, 1327, calendarWidth, calendarHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
