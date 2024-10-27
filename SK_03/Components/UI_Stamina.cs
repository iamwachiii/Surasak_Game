using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.Components
{
    public class UI_Stamina : Sprite
    {
        public float stamina;
        public int frameWidth, frameHeight;
        public Rectangle staminaRecInside, staminaRecBlank;


        public UI_Stamina(Texture2D texture)
        {            
            frameWidth = texture.Width;
            frameHeight = texture.Height;
            stamina = frameWidth - 5 ;
            staminaRecInside = new Rectangle(0, 0, frameWidth - 4, frameHeight / 2);
            staminaRecBlank = new Rectangle(0, 64, frameWidth - 10, frameHeight / 2);

        }

        public override void Update(GameTime gameTime)
        {

        }
    }


}
