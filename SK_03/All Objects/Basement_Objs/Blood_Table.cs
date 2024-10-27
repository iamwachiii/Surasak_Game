using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Basement
{
    public class Blood_Table : Sprite
    {
        public int bloodTableWidth, bloodTableHeight;
        public Rectangle bloodTableRec;
        public Vector2 bloodTable_pos;

        public Blood_Table(Texture2D texture)
        {
            bloodTable_pos = new Vector2(2016, 520);

            bloodTableWidth = 475;
            bloodTableHeight = 375;

            bloodTableRec = new Rectangle(775, 1305, bloodTableWidth, bloodTableHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
