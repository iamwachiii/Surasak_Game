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
    public class FrontHouse_Scenes : SceneManage
    {
        public Texture2D frontHouse_ScenesTexture;
        public Vector2 frontHouse_Scenes_pos;
        private Texture2D font_surasak01;
        private Vector2 font_surasak01_Pos;
        private Rectangle font_surasak01_Rec;
        private Texture2D font_surasak02;
        private Vector2 font_surasak02_Pos;
        private Rectangle font_surasak02_Rec;
        private Texture2D font_surasak03;
        private Vector2 font_surasak03_Pos;
        private Rectangle font_surasak03_Rec;
        private float fontAlpha = 0f;
        private float font2Alpha = 0f;
        private float font3Alpha = 0f;
        private const float FADE_SPEED = 0.5f;
        private Game1 game;
        private bool startFade = false;
        private float elapsedTime = 0f;
        private bool switchFonts = false;
        private bool showFont3 = false;
        private bool readyToTransition = false;  // เพิ่มตัวแปรควบคุมการเปลี่ยนฉาก
        private KeyboardState previousKeyboardState;

        public FrontHouse_Scenes(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            frontHouse_Scenes_pos = new Vector2(0, 0);
            frontHouse_ScenesTexture = game.Content.Load<Texture2D>("story");
            font_surasak01 = game.Content.Load<Texture2D>("Font_03");
            font_surasak02 = game.Content.Load<Texture2D>("Font_03");
            font_surasak03 = game.Content.Load<Texture2D>("Font_03");

            font_surasak01_Rec = new Rectangle(84, 36, 1764, 252);
            font_surasak01_Pos = new Vector2(93, 389);

            font_surasak02_Rec = new Rectangle(64, 339, 1736, 272);
            font_surasak02_Pos = new Vector2(77, 177);

            font_surasak03_Rec = new Rectangle(91, 675, 1742, 180);
            font_surasak03_Pos = new Vector2(95, 613);
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
                else if (!showFont3 && font2Alpha >= 1f)
                {
                    // การกด spacebar ครั้งที่สอง - แสดง font_begin02
                    showFont3 = true;
                    elapsedTime = 0f;
                }
                else if (showFont3 && font3Alpha >= 1f)
                {
                    // การกด spacebar ครั้งที่สาม - เปลี่ยนฉาก
                    readyToTransition = true;
                }
            }

            // อัพเดท alpha ของ font_begin01
            if (switchFonts && !showFont3)
            {
                elapsedTime += deltaTime;
                font2Alpha = MathHelper.Clamp(elapsedTime * FADE_SPEED, 0f, 1f);
            }

            // อัพเดท alpha ของ font_begin02
            if (showFont3 && !readyToTransition)
            {
                elapsedTime += deltaTime;
                font3Alpha = MathHelper.Clamp(elapsedTime * FADE_SPEED, 0f, 1f);
            }

            // เปลี่ยนฉากเมื่อพร้อม
            if (readyToTransition)
            {
                ScreenEvent.Invoke(game.living_room, new EventArgs());
                game.player.player_pos = new Vector2(0, 535);
                game.player.direction = 1;
                game.gameOver = false;
                return;
            }

            previousKeyboardState = currentKeyboardState;
            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(frontHouse_ScenesTexture, frontHouse_Scenes_pos, Color.White);

            if (!switchFonts)
            {
                Color fontColor = Color.White * fontAlpha;
                theBatch.Draw(font_surasak01, font_surasak01_Pos, font_surasak01_Rec, fontColor);
            }
            else if (!readyToTransition)
            {
                Color font2Color = Color.White * font2Alpha;
                theBatch.Draw(font_surasak02, font_surasak02_Pos, font_surasak02_Rec, font2Color);

                if (showFont3)
                {
                    Color font3Color = Color.White * font3Alpha;
                    theBatch.Draw(font_surasak03, font_surasak03_Pos, font_surasak03_Rec, font3Color);
                }
            }
        }
    }
}
