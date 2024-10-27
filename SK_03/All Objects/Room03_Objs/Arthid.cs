using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Room03_Objs
{
    public class Arthid : Sprite
    {
        public int arthidWidth, arthidHeight;
        public Rectangle arthidRec;
        public Vector2 arthid_pos;

        public Arthid(Texture2D texture)
        {
            arthid_pos = new Vector2(400, 38);
            arthidWidth = 145;
            arthidHeight = 580;

            arthidRec = new Rectangle(256, 61, arthidWidth, arthidHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
