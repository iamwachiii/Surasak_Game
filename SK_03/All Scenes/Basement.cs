using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using SK_03.All_Objects.Basement;
using SK_03.All_Objects.Room03_Objs;
using SK_03.All_Objects;
using Microsoft.Xna.Framework.Audio;
using SK_03.All_Objects.All_Icon_Guides;

namespace SK_03
{
    public class Basement : SceneManage
    {
        public Texture2D basementTexture;
        public Vector2 basement_pos;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;
        private Stair_Guide stairGuide;
        private Texture2D stairGuideTexture;

        private Blood_Table blood_Table;
        private Texture2D bloodTableTexture;
        private Ghost_1 ghost_1;
        private Texture2D ghost1Texture;
        private Ghost_2 ghost_2;
        private Texture2D ghostPicTexture;
        private Pick_Guide pickGuide;
        private Texture2D pickGuideTexture;

        private Texture2D font_BloodTable;

        private bool bloodTableIsHit = false;

        private bool showBloodTableFont = false;

        private bool showBloodTableGuide = false;

        private Vector2 font_BloodTable_Pos;

        private Rectangle fontRectangle_BloodTable;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 guide_pos;
        private Vector2 doorGuide_pos;
        private Vector2 balcony_Key_pos;
        private Vector2 pickGuide_pos;

        private bool doorIsHit = false;

        private float fontTimer = 0f;
        private const float FONT_DISPLAY_TIME = 1.5f;

        private Ladder ladder;
        private Texture2D ladderTexture;
        private Vector2 ladder_pos;
        private bool ladderIsHit = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle bloodTableHitRec;
        private Rectangle ladderHitRec;
        private Rectangle doorGuideRectangle;
        private Rectangle stairGuideRectangle;
        private Rectangle guideRectangle;

        private SoundEffect openDoorSound;
        private bool eKeyPressed = false;
        public Basement(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            game.player.player_pos = new Vector2(1800, 535);
            basement_pos = new Vector2(0, 0);
            basementTexture = game.Content.Load<Texture2D>("Basement");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");
            ladderTexture = game.Content.Load<Texture2D>("Tiles_basement");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            stairGuideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            pickGuideTexture = game.Content.Load<Texture2D>("Icon");

            bloodTableTexture = game.Content.Load<Texture2D>("Tiles_basement");
            ghost1Texture = game.Content.Load<Texture2D>("Tiles_basement");
            ghostPicTexture = game.Content.Load<Texture2D>("Tiles_basement");

            font_BloodTable = game.Content.Load<Texture2D>("Font_01");

            pickGuide = new Pick_Guide(pickGuideTexture);
            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            stairGuide = new Stair_Guide(stairGuideTexture);
            ladder = new Ladder(ladderTexture);
            blood_Table = new Blood_Table(bloodTableTexture);
            ghost_1 = new Ghost_1(ghost1Texture);
            ghost_2 = new Ghost_2(ghostPicTexture);

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            balcony_Key_pos = new Vector2(1550, 600);

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(basementTexture.Width - door.doorWidth, 255);
            ladder_pos = new Vector2(3375, 460);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(basementTexture.Width - guide.guideWidth, 400);
            guide_pos = ladder_pos + new Vector2(0,600);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);
            ladderHitRec = new Rectangle((int)ladder_pos.X, (int)ladder_pos.Y, ladder.ladderWidth, ladder.ladderHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);

            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

            bloodTableHitRec = new Rectangle((int)blood_Table.bloodTable_pos.X, (int)blood_Table.bloodTable_pos.Y, blood_Table.bloodTableWidth, blood_Table.bloodTableHeight);

            fontRectangle_BloodTable = new Rectangle(0, 741, 263, 55);
        }
        private void ObjectInteract(GameTime theTime)
        {
            //Blood_Table
            bloodTableIsHit = game.player.playerHitRec.Intersects(bloodTableHitRec);
            if (bloodTableIsHit)
            {
                if (!showBloodTableFont)
                {
                    showBloodTableGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showBloodTableGuide = false;
                    showBloodTableFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showBloodTableGuide = false;
                showBloodTableFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showBloodTableFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showBloodTableFont = false;
                }
            }
            guide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
                game.player.player_pos.Y - guideRectangle.Height - 5
            );

            font_BloodTable_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_BloodTable.Width / 2),
                game.player.player_pos.Y - fontRectangle_BloodTable.Height - 5
            );
        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_left) && game.player.direction == 0)
            {
                doorIsHit = true;
                doorGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20
                );
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    ScreenEvent.Invoke(game.room_02, new EventArgs());
                    return;
                }
            }
            else if (game.player.playerHitRec.Intersects(ladderHitRec) && game.player.delayDoor > 0.5)
            {
                ladderIsHit = true;
                game.switch_Scenes = "GoKitchen_room";
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    ScreenEvent.Invoke(game.kitchen_room, new EventArgs());
                    return;
                }
            }
            else
            {
                doorIsHit = false;
                ladderIsHit = false;
                game.switch_Scenes = "default";
            }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightPositions();

            if (game.balcony_Key.isVisible == true)
                game.balcony_Key.Balcony_keyHitRec = new Rectangle((int)balcony_Key_pos.X, (int)balcony_Key_pos.Y, game.balcony_Key.Balcony_keyWidth, game.balcony_Key.Balcony_keyHeight);

            game.player.delayDoor += (float)theTime.ElapsedGameTime.TotalSeconds;
            

            game.Update_camera();

            OpenDoor();
            ObjectInteract(theTime);

            if (game.player.isHitObj == true)
            {
                pickGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - 30,
                    game.player.player_pos.Y - 90);

            }

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            if (game.balcony_Key.isVisible == true)
                theBatch.Draw(game.balcony_KeyTexture, balcony_Key_pos - game.cameraPos, game.balcony_Key.Balcony_keyRec, game.transparentColor);

            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left, game.transparentColor);
            theBatch.Draw(bloodTableTexture, blood_Table.bloodTable_pos - game.cameraPos, blood_Table.bloodTableRec, game.transparentColor);
            theBatch.Draw(ghostPicTexture, ghost_2.ghostPic_pos - game.cameraPos, ghost_2.ghostPicRec, game.transparentColor);
            theBatch.Draw(ghost1Texture, ghost_1.ghost1_pos - game.cameraPos, ghost_1.ghost1Rec, game.transparentColor);
            game.Update_Draw();

        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.balcony_Key.Balcony_keyHitRec) && game.balcony_Key.isVisible == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pickGuideTexture, pickGuide_pos - game.cameraPos, pickGuide.pick_GuideRec, Color.White);
            }
            if (doorIsHit == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (ladderIsHit == true)
            {
                theBatch.Draw(stairGuideTexture, ladder_pos - game.cameraPos, stairGuide.stairGuideRec, Color.White);
            }
            if (showBloodTableGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showBloodTableFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_BloodTable, font_BloodTable_Pos - game.cameraPos, fontRectangle_BloodTable, Color.White);
            }
        }

    }
}
