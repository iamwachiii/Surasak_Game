using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using SK_03.All_Objects;
using Microsoft.Xna.Framework.Audio;
using SK_03.All_Objects.All_Icon_Guides;

namespace SK_03
{
    public class Hallway : SceneManage
    {
        public Texture2D hallwayTexture;
        public Vector2 hallway_pos;

        private Stair_Guide stairGuide;
        private Texture2D stairGuideTexture;
        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;
        private Candle candle;
        private Texture2D candleTexture;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Stairs stair;
        private Texture2D stairTexture;
        private Chair_hallway chair_Hallway;
        private Texture2D chairTexture1;
        private Jar_01 jar_01;
        private Texture2D jarTexture1;
        private Picture_hallway picture_hallway;
        private Texture2D pictureTexture1;
        private Bin bin;
        private Texture2D binTexture;
        private Lock_Guide lock_Guide;
        private Texture2D lock_GuideTexture;
        private Pick_Guide pickGuide;
        private Texture2D pickGuideTexture;

        private Texture2D font_Jar01;
        private Texture2D font_Chair;

        private Texture2D noteGuideTexture;
        private Texture2D noteFont;

        private bool jar01IsHit = false;
        private bool chairIsHit = false;
        private bool binIsHit = false;

        private bool showJar01Font = false;
        private bool showChairFont = false;

        private bool showJar01Guide = false;
        private bool showChairGuide = false;

        private Vector2 font_Jar01_Pos;
        private Vector2 font_Chair_Pos;

        private Rectangle fontRectangle_Jar01;
        private Rectangle fontRectangle_Chair;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 doorGuide_pos;
        
        private Vector2 guide_pos_note;
        private Vector2 bedroom_Key_pos;
        private Vector2 pickGuide_pos;
        
        private Vector2 guide_pos;
        private Vector2 stair_pos;
        private bool doorLeftIsHit, doorRightIsHit = false;
        private bool stairIsHit = false;

        private float fontTimer = 0f;
        private const float FONT_DISPLAY_TIME = 1.5f;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle jar01HitRec, chairHitRec, binHitRec;
        private Rectangle guideRectangle;
        private Rectangle stairHitRec;
        private Rectangle stairGuideRectangle;
        private Rectangle doorGuideRectangle;
        private Rectangle lock_GuideRec;
        private Vector2 noteGuidePosition;
        private Rectangle noteGuideRec;

        private bool showNoteInteractGuide = false;
        private bool showNoteContent = false;

        private SoundEffect openDoorSound;
        private bool eKeyPressed = false;
        private bool spaceBarPressed = false;

        private float fontAlpha = 0f;
        private float noteGuideAlpha = 0f;
        private float noteFontAlpha = 0f;
        private const float FADE_SPEED = 2f;
        private const float NOTE_FADE_SPEED = 2f;
        public Hallway(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            hallway_pos = new Vector2(0, 0);
            hallwayTexture = game.Content.Load<Texture2D>("Hallway");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            stairGuideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            lock_GuideTexture = game.Content.Load<Texture2D>("Icon");
            pickGuideTexture = game.Content.Load<Texture2D>("Icon");

            chairTexture1 = game.Content.Load<Texture2D>("Tiles_hallway");
            jarTexture1 = game.Content.Load<Texture2D>("Tiles_hallway");
            pictureTexture1 = game.Content.Load<Texture2D>("Tiles_hallway");
            binTexture = game.Content.Load<Texture2D>("Tiles_hallway");
            stairTexture = game.Content.Load<Texture2D>("Tiles_hallway");
            noteGuideTexture = game.Content.Load<Texture2D>("Note_Guide");
            noteFont = game.Content.Load<Texture2D>("Font_01");

            font_Jar01 = game.Content.Load<Texture2D>("Font_01");
            font_Chair = game.Content.Load<Texture2D>("Font_01");
            candleTexture = game.Content.Load<Texture2D>("Candle");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            door = new Door(doorTexture);
            lock_Guide = new Lock_Guide(doorGuideTexture);
            guide = new Guide(guideTexture);
            stairGuide = new Stair_Guide(stairGuideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            pickGuide = new Pick_Guide(pickGuideTexture);

            chair_Hallway = new Chair_hallway(chairTexture1);
            jar_01 = new Jar_01(jarTexture1);
            picture_hallway = new Picture_hallway(pictureTexture1);
            bin = new Bin(binTexture);
            stair = new Stairs(stairTexture);
            candle = new Candle(game,candleTexture, new Vector2(1450, 418));

            bedroom_Key_pos = new Vector2(3565, 590);

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(hallwayTexture.Width - door.doorWidth, 255);
            stair_pos = new Vector2(2903, 454);

            guide_pos = stair_pos + new Vector2(0, 0); 
            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);
            lock_GuideRec = new Rectangle(161, 259, lock_Guide.lock_GuideWidth, lock_Guide.lock_GuideHeight);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);
            stairHitRec = new Rectangle((int)stair_pos.X, (int)stair_pos.Y, 171, 447);

            jar01HitRec = new Rectangle((int)jar_01.jar_pos.X, (int)jar_01.jar_pos.Y, jar_01.jarWidth, jar_01.jarHeight);
            chairHitRec = new Rectangle((int)chair_Hallway.chair_pos.X, (int)chair_Hallway.chair_pos.Y, chair_Hallway.chairWidth, chair_Hallway.chairHeight);
            binHitRec = new Rectangle((int)bin.bin_pos.X, (int)bin.bin_pos.Y, bin.binWidth, bin.binHeight);

            fontRectangle_Jar01 = new Rectangle(0, 539, 240, 98);
            fontRectangle_Chair = new Rectangle(0, 446, 235, 98);
            
            candle.candle_pos = new Vector2(1450, 418);
            noteGuideRec = new Rectangle(0, 0, 1920, 1080);


        }
        private void ObjectInteract(GameTime theTime)
        {
            //Jar01
            jar01IsHit = game.player.playerHitRec.Intersects(jar01HitRec);
            if (jar01IsHit)
            {
                if (!showJar01Font)
                {
                    showJar01Guide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showJar01Guide = false;
                    showJar01Font = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showJar01Guide = false;
                showJar01Font = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                eKeyPressed = false;
            }
            if (showJar01Font)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showJar01Font = false;
                }
            }

            //Chair
            chairIsHit = game.player.playerHitRec.Intersects(chairHitRec);
            if (chairIsHit)
            {
                if (!showChairFont)
                {
                    showChairGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showChairGuide = false;
                    showChairFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showChairGuide = false;
                showChairFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                eKeyPressed = false;
            }
            if (showChairFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showChairFont = false;
                }
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                eKeyPressed = false;
            }

            guide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
                game.player.player_pos.Y - guideRectangle.Height - 5
            );

            font_Jar01_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Jar01.Width / 2),
                game.player.player_pos.Y - fontRectangle_Jar01.Height - 5
            );
            font_Chair_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Chair.Width / 2),
                game.player.player_pos.Y - fontRectangle_Chair.Height - 5
            );
        }
        private void NoteInteract(GameTime theTime)
        {
            float deltaTime = (float)theTime.ElapsedGameTime.TotalSeconds;

            binIsHit = game.player.playerHitRec.Intersects(binHitRec);

            if (binIsHit)
            {
                if (!showNoteContent)
                {
                    showNoteInteractGuide = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && !spaceBarPressed)
                {
                    spaceBarPressed = true;
                    showNoteInteractGuide = false;
                    showNoteContent = !showNoteContent;
                }
            }
            else
            {
                showNoteInteractGuide = false;
                showNoteContent = false;
                spaceBarPressed = false;
                noteGuideAlpha = MathHelper.Max(noteGuideAlpha - NOTE_FADE_SPEED * deltaTime, 0f);
                noteFontAlpha = MathHelper.Max(noteFontAlpha - NOTE_FADE_SPEED * deltaTime, 0f);
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                spaceBarPressed = false;
            }

            // Handle fade effects
            if (showNoteContent)
            {
                noteGuideAlpha = MathHelper.Min(noteGuideAlpha + NOTE_FADE_SPEED * deltaTime, 1f);
                noteFontAlpha = MathHelper.Min(noteFontAlpha + NOTE_FADE_SPEED * deltaTime, 1f);
            }
            else if (!showNoteInteractGuide)
            {
                noteGuideAlpha = MathHelper.Max(noteGuideAlpha - NOTE_FADE_SPEED * deltaTime, 0f);
                noteFontAlpha = MathHelper.Max(noteFontAlpha - NOTE_FADE_SPEED * deltaTime, 0f);
            }
        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_left) && game.player.direction == 0)
            {
                doorLeftIsHit = true;
                doorGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    candle.CleanupLight();
                    ScreenEvent.Invoke(game.living_room, new EventArgs());
                    return;
                }
            }
            else if (game.player.playerHitRec.Intersects(doorHitRec_right) && game.player.direction == 1)
            {
                doorRightIsHit = true;
                doorGuide_pos = new Vector2(
                            game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                            game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    candle.CleanupLight();
                    ScreenEvent.Invoke(game.kitchen_room, new EventArgs());
                    return;
                }


            }
            else if (game.player.playerHitRec.Intersects(stairHitRec) && game.player.direction == 1)
            {
                game.switch_Scenes = "GoHallway_2";
                stairIsHit = true;
                if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                {
                    ScreenEvent.Invoke(game.hallway_2, new EventArgs());
                    return;
                }
            }
            else
            {
                doorLeftIsHit = false;
                doorRightIsHit = false;
                stairIsHit = false;
                game.switch_Scenes = "default";
            }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightPositions();
            candle.InitializeCandleLight();

            if (game.bedroom_Key.isVisible == true)
                game.bedroom_Key.Bedroom_KeyHitRec = new Rectangle((int)bedroom_Key_pos.X, (int)bedroom_Key_pos.Y, game.bedroom_Key.Bedroom_KeyWidth, game.bedroom_Key.Bedroom_KeyHeight);

            game.Update_camera();

            OpenDoor();
            NoteInteract(theTime);
            ObjectInteract(theTime);

            if (game.player.isHitObj == true)
            {
                pickGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - 30,
                    game.player.player_pos.Y - 90);

            }
            candle.Update(theTime);
            noteGuidePosition = new Vector2(0, 0);

            base.Update(theTime);
        }       
        public override void Draw(SpriteBatch theBatch)
        {
            if (game.bedroom_Key.isVisible == true)
                theBatch.Draw(game.bedroom_KeyTexture, bedroom_Key_pos - game.cameraPos, game.bedroom_Key.Bedroom_KeyRec, game.transparentColor);
            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left, game.transparentColor);
            theBatch.Draw(doorTexture, door_right_pos - game.cameraPos, door.doorRec_right, game.transparentColor);
            theBatch.Draw(chairTexture1, chair_Hallway.chair_pos - game.cameraPos, chair_Hallway.chairRec, game.transparentColor);
            theBatch.Draw(jarTexture1, jar_01.jar_pos - game.cameraPos, jar_01.jarRec, game.transparentColor);
            theBatch.Draw(pictureTexture1, picture_hallway.picture1_pos - game.cameraPos, picture_hallway.picture1Rec, game.transparentColor);
            theBatch.Draw(binTexture, bin.bin_pos - game.cameraPos, bin.binRec, game.transparentColor);

            theBatch.Draw(candleTexture, candle.candle_pos - game.cameraPos, candle.sourceRectangle, game.transparentColor);

            game.Update_Draw();

        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.bedroom_Key.Bedroom_KeyHitRec) && game.bedroom_Key.isVisible == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pickGuideTexture, pickGuide_pos - game.cameraPos, pickGuide.pick_GuideRec, Color.White);
            }
            if (doorLeftIsHit == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }

            else if (doorRightIsHit == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (stairIsHit == true)
            {
                theBatch.Draw(stairGuideTexture, stair_pos - game.cameraPos, stairGuide.stairGuideRec, Color.White);
            }


            if (showJar01Guide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }
            if (showChairGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showJar01Font && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_Jar01, font_Jar01_Pos - game.cameraPos, fontRectangle_Jar01, Color.White);
            }
            if (showChairFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_Chair, font_Chair_Pos - game.cameraPos, fontRectangle_Chair, Color.White);
            }
            if (showNoteInteractGuide)
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (noteGuideAlpha > 0f)
            {
                theBatch.Draw(noteGuideTexture, noteGuidePosition, noteGuideRec, Color.White * noteGuideAlpha);
            }

            if (noteFontAlpha > 0f)
            {
                theBatch.Draw(noteFont, new Vector2(670, 415), new Rectangle(357, 29, 622, 290), Color.White * noteFontAlpha);
            }
        }

    }

}
