using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Room04_Objs
{
    public class Waewdao : Sprite
    {
        public int waewdaoWidth, waewdaoHeight;
        public Rectangle waewdaoRec;
        public Vector2 waewdao_pos;

        public Waewdao(Texture2D texture)
        {
            waewdao_pos = new Vector2(776, 558);
            waewdaoWidth = 385;
            waewdaoHeight = 168;

            waewdaoRec = new Rectangle(559, 168, waewdaoWidth, waewdaoHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
