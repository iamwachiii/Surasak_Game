using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SK_03.All_Objects.Room01_Objs;
using SK_03.All_Objects;
using Microsoft.Xna.Framework.Audio;
using SK_03.All_Objects.All_Icon_Guides;

namespace SK_03
{
    public class Room_01 : SceneManage
    {
        public Texture2D room_01Texture;
        public Vector2 room_01_pos;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Phakin phakin;
        private Texture2D phakinTexture;
        private Incense incense;
        private Texture2D incenseTexture;
        private Pick_Guide pickGuide;
        private Texture2D pickGuideTexture;
        private Candle candle;
        private Texture2D candleTexture;
        private Vector2 guide_pos;

        private Note note;
        private Texture2D noteTexture;
        private Texture2D noteGuideTexture;
        private Texture2D noteFont;
        private bool noteIsHit = false;
        private bool showNoteInteractGuide = false;
        private bool showNoteContent = false;
        private Vector2 noteGuidePosition;
        private Rectangle noteGuideRec;
        private bool spaceBarPressed = false;
        private Rectangle noteHitRec;

        private float fontAlpha = 0f;
        private float noteGuideAlpha = 0f;
        private float noteFontAlpha = 0f;
        private const float FADE_SPEED = 2f;
        private const float NOTE_FADE_SPEED = 2f;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 doorGuide_pos;
        private Vector2 pickGuide_pos;
        private Rectangle candleHitRec_1, candleHitRec_2;
        private Vector2 candle2_pos;

        private Pick_Guide pickGuide;
        private Texture2D pickGuideTexture;
        private Vector2 pickGuide_pos;
        private Vector2 cabinet_Key_pos;

        private Rectangle guideRectangle;
        private Rectangle doorGuideRectangle;

        private SoundEffect openDoorSound;
        private bool doorIsHit = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        public Room_01(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;

            if (game.player.direction == 0)
                game.player.player_pos = new Vector2(game.bg_width, 535);
            else if (game.player.direction == 1)
                game.player.player_pos = new Vector2(0, 535);

            room_01_pos = new Vector2(0, 0);
            room_01Texture = game.Content.Load<Texture2D>("Room_01");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            pickGuideTexture = game.Content.Load<Texture2D>("Icon");

            phakinTexture = game.Content.Load<Texture2D>("Tiles_Room_01");
            incenseTexture = game.Content.Load<Texture2D>("Tiles_Room_01");
            candleTexture = game.Content.Load<Texture2D>("Candle");
            noteTexture = game.Content.Load<Texture2D>("Tiles_note");
            noteGuideTexture = game.Content.Load<Texture2D>("Note_Guide");
            noteFont = game.Content.Load<Texture2D>("Font_01");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            pickGuide = new Pick_Guide(pickGuideTexture);
            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            phakin = new Phakin(phakinTexture);
            incense = new Incense(incenseTexture);
            candle = new Candle(game, candleTexture, new Vector2(550, 568));
            note = new Note(noteTexture);

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(room_01Texture.Width - door.doorWidth, 255);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(room_01Texture.Width - guide.guideWidth, 400);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);

            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

            note.note_pos = new Vector2(1500, 550);
            noteHitRec = new Rectangle((int)note.note_pos.X, (int)note.note_pos.Y, note.noteWidth, note.noteHeight);
            noteGuideRec = new Rectangle(0, 0, 1920, 1080);

            cabinet_Key_pos = new Vector2(1170, 550);
            candle.candle_pos = new Vector2(550, 568);
        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_left) && game.player.direction == 0 && game.player.delayDoor > 0.5)
            {
                game.switch_Scenes = "Room_01ToHallway_2";
                doorIsHit = true;
                doorGuide_pos = new Vector2(
                   game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                   game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    candle.CleanupLight();
                    ScreenEvent.Invoke(game.hallway_2, new EventArgs());
                    return;
                }
            }
            else
            {
                doorIsHit = false;
                game.switch_Scenes = "default";

            }
        }
        private void NoteInteract(GameTime theTime)
        {
            float deltaTime = (float)theTime.ElapsedGameTime.TotalSeconds;

            noteIsHit = game.player.playerHitRec.Intersects(noteHitRec);

            if (noteIsHit)
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
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightRoom();
            candle.InitializeCandleLight();

            game.player.delayDoor += (float)theTime.ElapsedGameTime.TotalSeconds;

            game.Update_camera();

            OpenDoor();
            NoteInteract(theTime);

            candle.Update(theTime);

            candleHitRec_2 = new Rectangle((int)candle2_pos.X, (int)candle2_pos.Y, candle.candleWidth, candle.candleHeight);

            if (game.player.playerHitRec.Intersects(candleHitRec_2))
            {

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    candle.ExtinguideCandle();
                    Console.WriteLine("lll");
                }
            }
            noteGuidePosition = new Vector2(0, 0);

            if (game.cabinet_Key.isVisible == true)
                game.cabinet_Key.Cabinet_keyHitRec = new Rectangle((int)cabinet_Key_pos.X, (int)cabinet_Key_pos.Y, game.cabinet_Key.Cabinet_keyWidth, game.cabinet_Key.Cabinet_keyHeight);

            if (game.player.isHitObj == true)
            {
                pickGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - 30,
                    game.player.player_pos.Y - 90);

            }
            guide_pos = new Vector2(
               game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
               game.player.player_pos.Y - guideRectangle.Height - 5
           );
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            if (game.cabinet_Key.isVisible == true)
                theBatch.Draw(game.cabinet_KeyTexture, cabinet_Key_pos - game.cameraPos, game.cabinet_Key.Cabinet_keyRec, game.transparentColor);

            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left, game.transparentColor);
            theBatch.Draw(phakinTexture, phakin.phakin_pos - game.cameraPos, phakin.phakinRec, game.transparentColor);
            theBatch.Draw(incenseTexture, incense.incense_pos - game.cameraPos, incense.incenseRec, Color.White);

            theBatch.Draw(candleTexture, candle.candle_pos - game.cameraPos, candle.sourceRectangle, game.transparentColor);
            theBatch.Draw(noteTexture, note.note_pos - game.cameraPos, note.noteRec, game.transparentColor);

            game.Update_Draw();
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (doorIsHit == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, game.transparentColor);
            }
            if (showNoteInteractGuide)
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.cabinet_Key.Cabinet_keyHitRec) && game.cabinet_Key.isVisible == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pickGuideTexture, pickGuide_pos - game.cameraPos, pickGuide.pick_GuideRec, game.transparentColor);
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
