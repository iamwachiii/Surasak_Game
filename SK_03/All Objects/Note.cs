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
    public class Note : Sprite
    {
        public int noteWidth, noteHeight;
        public Rectangle noteRec;
        public Vector2 note_pos;

        public Note(Texture2D texture)
        {
            noteWidth = 64;
            noteHeight = 80;

            noteRec = new Rectangle(800, 144, noteWidth, noteHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}