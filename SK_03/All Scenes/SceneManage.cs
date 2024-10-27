using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03
{
    public class SceneManage
    {
        protected EventHandler ScreenEvent; public SceneManage(EventHandler theScreenEvent) { ScreenEvent = theScreenEvent; }
        public virtual void Update(GameTime theTime) { }
        public virtual void Draw(SpriteBatch theBatch) { }
    }
}
