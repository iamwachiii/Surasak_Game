using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects.Bedroom_Objs
{
    public class Wardrobe : Sprite
    {
        public int wardrobeWidth, wardrobeHeight;
        public Rectangle wardrobeRec;
        public Vector2 wardrobe_pos;

        public Wardrobe(Texture2D texture)
        {
            wardrobe_pos = new Vector2(95, 214);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
