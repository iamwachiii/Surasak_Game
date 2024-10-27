using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace SK_03.CutScenes
{
    public class Begin : SceneManage
    {
        public Texture2D beginTexture;
        public Vector2 begin_pos;
        private Texture2D font_2540;
        private Vector2 font_2540_Pos;
        private Rectangle font_2540_Rec;
        private Texture2D font_begin01;
        private Vector2 font_begin01_Pos;
        private Rectangle font_begin01_Rec;
        private Texture2D font_begin02;
        private Vector2 font_begin02_Pos;
        private Rectangle font_begin02_Rec;
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

        public Begin(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            begin_pos = new Vector2(0, 0);
            beginTexture = game.Content.Load<Texture2D>("story");
            font_2540 = game.Content.Load<Texture2D>("Font_02");
            font_begin01 = game.Content.Load<Texture2D>("Font_02");
            font_begin02 = game.Content.Load<Texture2D>("Font_02");
            font_2540_Rec = new Rectangle(70, 16, 569, 115);
            font_2540_Pos = new Vector2(700, 425);
            font_begin01_Rec = new Rectangle(70, 164, 1560, 275);
            font_begin01_Pos = new Vector2(170, 160);
            font_begin02_Rec = new Rectangle(69, 431, 1777, 324);
            font_begin02_Pos = new Vector2(74, 526);
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
                ScreenEvent.Invoke(game.front_house, new EventArgs());
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
            theBatch.Draw(beginTexture, begin_pos, Color.White);

            if (!switchFonts)
            {
                // แสดง font_2540
                Color fontColor = Color.White * fontAlpha;
                theBatch.Draw(font_2540, font_2540_Pos, font_2540_Rec, fontColor);
            }
            else if (!readyToTransition)  // ไม่แสดง fonts เมื่อพร้อมเปลี่ยนฉาก
            {
                // แสดง font_begin01
                Color font2Color = Color.White * font2Alpha;
                theBatch.Draw(font_begin01, font_begin01_Pos, font_begin01_Rec, font2Color);

                if (showFont3)
                {
                    // แสดง font_begin02
                    Color font3Color = Color.White * font3Alpha;
                    theBatch.Draw(font_begin02, font_begin02_Pos, font_begin02_Rec, font3Color);
                }
            }
        }
    }
}