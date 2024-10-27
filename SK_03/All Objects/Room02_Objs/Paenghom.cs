using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Room02_Objs
{
    public class Paenghom : Sprite
    {
        public int paenghomWidth, paenghomHeight;
        public Rectangle paenghomRec;
        public Vector2 paenghom_pos;

        public Paenghom(Texture2D texture)
        {
            paenghom_pos = new Vector2(312, 38);
            paenghomWidth = 334;
            paenghomHeight = 654;

            paenghomRec = new Rectangle(2686, 868, paenghomWidth, paenghomHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
