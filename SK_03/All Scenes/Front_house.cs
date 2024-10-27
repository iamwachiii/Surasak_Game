using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SK_03.All_Objects;
using System;

namespace SK_03
{
    public class Front_house : SceneManage
    {
        public Texture2D front_houseTexture;
        public Vector2 front_house_pos;
        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Shrine shrine;
        private Texture2D shrineTexture;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;
        private Guide guide;
        private Texture2D guideTexture;

        private Texture2D font_shrine;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_pos;
        private Vector2 doorGuide_pos;

        private bool doorIsHit = false;
        private bool shrineIsHit = false;

        private bool showShrineGuide = false;
        private bool showShrineFont = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle shrineHitRec;
        private Vector2 fontPosition;

        private float fontTimer = 0f;
        private const float FONT_DISPLAY_TIME = 1.5f;

        private Rectangle fontRectangle;
        private Rectangle guideRectangle;
        private Rectangle doorGuideRectangle;

        private bool eKeyPressed = false;

        private SoundEffect openDoorSound;

        private float fontAlpha = 0f;
        private const float FADE_SPEED = 2f;

        public Front_house(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            front_house_pos = new Vector2(0, 0);
            front_houseTexture = game.Content.Load<Texture2D>("frontHouse");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");
            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D> ("Icon");
            shrineTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");
            font_shrine = game.Content.Load<Texture2D>("Font_01");
            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            shrine = new Shrine(shrineTexture);

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(front_houseTexture.Width - door.doorWidth, 255);

            shrineHitRec = new Rectangle((int)shrine.shrine_pos.X, (int)shrine.shrine_pos.Y,
            shrine.shrineWidth, shrine.shrineHeight);

            fontRectangle = new Rectangle(0, 0, 200, 44); //font rec
            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);
        }
        private void ObjectInteract(GameTime theTime)
        {
            float deltaTime = (float)theTime.ElapsedGameTime.TotalSeconds;

            // Shrine interaction
            shrineIsHit = game.player.playerHitRec.Intersects(shrineHitRec);

            if (shrineIsHit)
            {
                if (!showShrineFont)
                {
                    showShrineGuide = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showShrineGuide = false;
                    showShrineFont = true;
                    fontTimer = 0f;
                    fontAlpha = 0f;
                }
            }
            else
            {
                showShrineGuide = false;
                showShrineFont = false;
                eKeyPressed = false;
                fontAlpha = 0f;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }

            if (showShrineFont)
            {
                fontAlpha = Math.Min(fontAlpha + FADE_SPEED * deltaTime, 1f);
                fontTimer += deltaTime; 
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showShrineFont = false;
                    fontAlpha = 0f;

                }
            }
        }
        private void OpenDoor()
        {
            // Door interaction
            if (game.player.playerHitRec.Intersects(doorHitRec_right) && game.player.direction == 1)
            {
                doorIsHit = true;
                doorGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20
                );
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    openDoorSound.CreateInstance().Play();
                    ScreenEvent.Invoke(game.frontHouse_Scenes, new EventArgs());
                    game.gameOver = true;
                    return;
                }
            }
            else
            {
                doorIsHit = false;
            }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y,
                door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y,
                door.doorWidth, door.doorHeight);

            game.Update_camera();

            OpenDoor();
            ObjectInteract(theTime);


            // Update guide and font positions
            guide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
                game.player.player_pos.Y - guideRectangle.Height - 5
            );

            doorGuide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuideRectangle.Width / 2),
                game.player.player_pos.Y - doorGuideRectangle.Height - 5
            );

            fontPosition = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle.Width / 2),
                game.player.player_pos.Y - fontRectangle.Height - 5
            );

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(doorTexture, door_right_pos - game.cameraPos, door.doorRec_right, Color.White);
            theBatch.Draw(shrineTexture, shrine.shrine_pos - game.cameraPos, shrine.shrineRec, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
            game.Update_Draw();

            if (doorIsHit)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec_right, Color.White);
            }

            if (showShrineGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showShrineFont || fontAlpha > 0f && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_shrine, fontPosition - game.cameraPos, fontRectangle, Color.White * fontAlpha);
            }
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (doorIsHit)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec_right, Color.White);
            }

            if (showShrineGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showShrineFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_shrine, fontPosition - game.cameraPos, fontRectangle, Color.White);
            }
        }
    }
}