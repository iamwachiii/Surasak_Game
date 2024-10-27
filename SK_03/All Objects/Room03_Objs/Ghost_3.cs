using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Room03_Objs
{
    public class Ghost_3 : Sprite
    {
        public int ghost01Width, ghost01Height;
        public Rectangle ghost01Rec;
        public Vector2 ghost01_pos;

        public Ghost_3(Texture2D texture)
        {
            ghost01_pos = new Vector2(1576, 625);
            ghost01Width = 193;
            ghost01Height = 270;

            ghost01Rec = new Rectangle(743, 320, ghost01Width, ghost01Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
