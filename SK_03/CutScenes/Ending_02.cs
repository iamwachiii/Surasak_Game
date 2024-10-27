using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03.CutScenes
{
    public class Ending_02 : SceneManage
    {
        public Texture2D ending02_Texture;
        public Vector2 ending02_pos;
        private Texture2D font_end02;
        private Vector2 font_end02_Pos;
        private Rectangle font_end02_Rec;
        private Texture2D font_ending02;
        private Vector2 font_ending02_Pos;
        private Rectangle font_ending02_Rec;
        private float fontAlpha = 0f;
        private float font2Alpha = 0f;
        private const float FADE_SPEED = 0.5f;
        private Game1 game;
        private bool startFade = false;
        private float elapsedTime = 0f;
        private bool switchFonts = false;
        private bool readyToTransition = false;  // เพิ่มตัวแปรควบคุมการเปลี่ยนฉาก
        private KeyboardState previousKeyboardState;

        public Ending_02(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            ending02_pos = new Vector2(0, 0);
            ending02_Texture = game.Content.Load<Texture2D>("story");
            font_end02 = game.Content.Load<Texture2D>("Font_04");
            font_ending02 = game.Content.Load<Texture2D>("Font_04");

            font_end02_Rec = new Rectangle(127, 706, 1658, 334);
            font_end02_Pos = new Vector2(123, 333);
            font_ending02_Rec = new Rectangle(990, 522, 856, 176);
            font_ending02_Pos = new Vector2(537, 398);
            startFade = true;
            previousKeyboardState = Keyboard.GetState();
        }

        public override void Update(GameTime theTime)
        {
            float deltaTime = (float)theTime.ElapsedGameTime.TotalSeconds;
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (startFade && !switchFonts)
            {
                elapsedTime += deltaTime;
                fontAlpha = MathHelper.Clamp(elapsedTime * FADE_SPEED, 0f, 1f);
            }

            // ตรวจสอบการกด spacebar แบบ single press
            if (currentKeyboardState.IsKeyDown(Keys.Space) && previousKeyboardState.IsKeyUp(Keys.Space))
            {
                if (!switchFonts)
                {
                    // การกด spacebar ครั้งแรก - แสดง font_begin01
                    switchFonts = true;
                    elapsedTime = 0f;
                }
                else if (font2Alpha >= 1f)
                {
                    // การกด spacebar ครั้งที่สอง - เปลี่ยนฉาก
                    readyToTransition = true;
                }
            }

            // อัพเดท alpha ของ font_begin01
            if (switchFonts && !readyToTransition)
            {
                elapsedTime += deltaTime;
                font2Alpha = MathHelper.Clamp(elapsedTime * FADE_SPEED, 0f, 1f);
            }

            // เปลี่ยนฉากเมื่อพร้อม
            if (readyToTransition)
            {
                ScreenEvent.Invoke(game.main_menu, new EventArgs());
                game.player.player_pos = new Vector2(0, 535);
                game.player.direction = 1;
                game.gameOver = true;
                return;
            }

            previousKeyboardState = currentKeyboardState;
            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(ending02_Texture, ending02_pos, Color.White);

            if (!switchFonts)
            {
                // แสดง font_2540
                Color fontColor = Color.White * fontAlpha;
                theBatch.Draw(font_end02, font_end02_Pos, font_end02_Rec, fontColor);
            }
            else if (!readyToTransition)  // ไม่แสดง fonts เมื่อพร้อมเปลี่ยนฉาก
            {
                // แสดง font_begin01
                Color font2Color = Color.White * font2Alpha;
                theBatch.Draw(font_ending02, font_ending02_Pos, font_ending02_Rec, font2Color);
            }
        }
    }
}
