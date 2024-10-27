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
        public Rectangle noteHitRec;
        public Vector2 note_pos;
        public bool isVisible = true;

        public Note(Texture2D texture)
        {

            noteWidth = texture.Width;
            noteHeight = texture.Height;

            noteRec = new Rectangle(0, 0, noteWidth, noteHeight);
            noteHitRec = new Rectangle((int)note_pos.X, (int)note_pos.Y, noteWidth, noteHeight);
        }    
    }
}