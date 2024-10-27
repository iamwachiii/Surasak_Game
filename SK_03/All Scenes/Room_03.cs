using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SK_03.All_Objects;
using SK_03.All_Objects.Room03_Objs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03
{
    public class Room_03 : SceneManage
    {
        public Texture2D room_03Texture;
        public Vector2 room_03_pos;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Arthid arthid;
        private Texture2D arthidTexture;
        private Ghost_3 ghost3;
        private Texture2D ghost01Texture;
        private Texture2D ladderTexture;
        private StairDown_Guide stairDownGuide;
        private Texture2D stairDownGuideTexture;

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
        private Vector2 ladder_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 guide_pos;

        private bool doorIsHit = false;
        private bool ladderIsHit = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle ladderHitRec;
        private Rectangle ladderRec;
        private Rectangle stairDownGuideRectangle;
        public Room_03(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            room_03_pos = new Vector2(0, 0);
            room_03Texture = game.Content.Load<Texture2D>("Room_03");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            stairDownGuideTexture = game.Content.Load<Texture2D>("Icon_3");

            ghost01Texture = game.Content.Load<Texture2D>("Tiles_Room_03");
            arthidTexture = game.Content.Load<Texture2D>("Tiles_Room_03");
            ladderTexture = game.Content.Load<Texture2D>("Tiles_Room_03");

            noteTexture = game.Content.Load<Texture2D>("Tiles_note");
            noteGuideTexture = game.Content.Load<Texture2D>("Note_Guide");
            noteFont = game.Content.Load<Texture2D>("Font_01");

            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            ghost3 = new Ghost_3(ghost01Texture);
            arthid = new Arthid(arthidTexture);
            stairDownGuide = new StairDown_Guide(stairDownGuideTexture);
            note = new Note(noteTexture);

            //Console.WriteLine("w = " + living_roomTexture.Width);
            door_left_pos = new Vector2(0, 256);
            door_right_pos = new Vector2(room_03Texture.Width - door.doorWidth, 256);
            ladder_pos = new Vector2(850, 800);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(room_03Texture.Width - guide.guideWidth, 400);
            guide_pos = ladder_pos + new Vector2(90, 0); 

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);

            ladderRec = new Rectangle(1150, 376, 257, 130);
            ladderHitRec = new Rectangle((int)ladder_pos.X, (int)ladder_pos.Y, 257, 130);

            note.note_pos = new Vector2(100, 550);
            noteHitRec = new Rectangle((int)note.note_pos.X, (int)note.note_pos.Y, note.noteWidth, note.noteHeight);
            noteGuideRec = new Rectangle(0, 0, 1920, 1080);
        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(ladderHitRec) && game.player.delayDoor > 0.5)
            {
                game.switch_Scenes = "Room_03ToBed";
                ladderIsHit = true;
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    ScreenEvent.Invoke(game.bed_Room, new EventArgs());
                    return;
                }
            }

            else
            {
                ladderIsHit = false;
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

            game.player.delayDoor += (float)theTime.ElapsedGameTime.TotalSeconds;

            game.Update_camera();
            NoteInteract(theTime);
            OpenDoor();

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(ladderTexture, ladder_pos - game.cameraPos, ladderRec, game.transparentColor);
            theBatch.Draw(ghost01Texture, ghost3.ghost01_pos - game.cameraPos, ghost3.ghost01Rec, game.transparentColor);
            theBatch.Draw(arthidTexture, arthid.arthid_pos - game.cameraPos, arthid.arthidRec, game.transparentColor);
            theBatch.Draw(noteTexture, note.note_pos - game.cameraPos, note.noteRec, game.transparentColor);
            game.Update_Draw();

       
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (ladderIsHit == true)
                theBatch.Draw(stairDownGuideTexture, guide_pos - game.cameraPos, stairDownGuide.stairDownGuideRec, Color.White);
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
