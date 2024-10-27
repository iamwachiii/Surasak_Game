using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Table_living_room : Sprite
    {
        public int table1Width, table1Height;
        public Rectangle table1Rec;
        public Vector2 table1_pos;

        public Table_living_room(Texture2D texture)
        {
            table1_pos = new Vector2(2448, 656);
            table1Width = 241;
            table1Height = 249;

            table1Rec = new Rectangle(2304, 1032, table1Width, table1Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
