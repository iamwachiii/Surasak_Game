using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.All_Objects
{
    public class Sink : Sprite
    {
        public int sinkWidth, sinkHeight;
        public Rectangle sinkRec;
        public Vector2 sink_pos;

        public Sink(Texture2D texture)
        {

            sink_pos = new Vector2(952, 520);
            sinkWidth = 329;
            sinkHeight = 383;

            sinkRec = new Rectangle(40, 304, sinkWidth, sinkHeight);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
