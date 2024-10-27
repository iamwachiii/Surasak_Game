using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SK_03.All_Objects;
using SK_03.All_Objects.All_Icon_Guides;
using SK_03.All_Objects.Bedroom_Objs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03
{
    public class Bed_room : SceneManage 
    {
        public Texture2D bed_roomTexture;
        public Vector2 bed_room_pos;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;

        private Texture2D font_Bed;

        private bool bedIsHit = false;

        private bool showBedFont = false;

        private bool showBedGuide = false;

        private Vector2 font_Bed_Pos;

        private Rectangle fontRectangle_Bed;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Safe safe;
        private Texture2D safeTexture;
        private Wardrobe wardrobe;
        private Texture2D wardrobeTexture;
        private Bed bed;
        private Texture2D bedTexture;
        private Stair_Guide stairGuide;
        private Texture2D stairGuideTexture;
        private Locker_Guide lockerGuide;
        private Texture2D lockerGuideTexture;
        private Lock_Guide lockGuide;
        private Texture2D lockGuideTexture;
        private Pick_Guide pickGuide;
        private Texture2D pickGuideTexture;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 ladder_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 guide_pos;
        private Vector2 doorGuide_pos;
        private Vector2 lockerGuide_pos;
        private Vector2 room03_Key_pos;
        private Vector2 pickGuide_pos;
        private Vector2 lockGuide_pos;
        private Vector2 paenghom_Heart_pos;

        private bool doorIsHit = false;
        private bool ladderIsHit = false;
        private bool room03IsUnlock = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle bedHitRec;
        private Rectangle ladderHitRec;
        private Rectangle guideRectangle;
        private Rectangle stairGuideRectangle;
        private Rectangle doorGuideRectangle;
        private Rectangle wardrobeHitRec;
        private Rectangle safeHitRec;

        private float fontTimer = 0f;
        private const float FONT_DISPLAY_TIME = 1.5f;

        private SoundEffect openDoorSound;
        private bool eKeyPressed = false;

        public bool safeIsUnlock = false;
        public Bed_room(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            bed_room_pos = new Vector2(0, 0);
            bed_roomTexture = game.Content.Load<Texture2D>("Bed_room");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            stairGuideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            lockerGuideTexture = game.Content.Load<Texture2D>("Icon");
            pickGuideTexture = game.Content.Load<Texture2D>("Icon");
            lockGuideTexture = game.Content.Load<Texture2D>("Icon");

            safeTexture = game.Content.Load<Texture2D>("Tiles_Bed_room");
            bedTexture = game.Content.Load<Texture2D>("Tiles_Bed_room");
            wardrobeTexture = game.Content.Load<Texture2D>("Tiles_Bed_room");

            font_Bed = game.Content.Load<Texture2D>("Font_01");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            lockGuide = new Lock_Guide(lockGuideTexture);
            pickGuide = new Pick_Guide(pickGuideTexture); 
            lockerGuide = new Locker_Guide(lockerGuideTexture);
            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            safe = new Safe(safeTexture);
            bed = new Bed(bedTexture);
            wardrobe = new Wardrobe(wardrobeTexture);
            stairGuide = new Stair_Guide(stairGuideTexture);

            room03_Key_pos = new Vector2(650, 780);
            paenghom_Heart_pos = new Vector2(700, 750);

            door_left_pos = new Vector2(0, 256);
            door_right_pos = new Vector2(bed_roomTexture.Width - door.doorWidth, 256);
            ladder_pos = new Vector2(1450, 450);

            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(bed_roomTexture.Width - guide.guideWidth, 400);
            guide_pos = ladder_pos + new Vector2(0, 200); 

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);
            ladderHitRec = new Rectangle((int)ladder_pos.X, (int)ladder_pos.Y,40, 645);

            bedHitRec = new Rectangle((int)bed.bed_pos.X, (int)bed.bed_pos.Y, bed.bedWidth, bed.bedHeight);
            wardrobeHitRec = new Rectangle((int)wardrobe.wardrobe_pos.X, (int)wardrobe.wardrobe_pos.Y, wardrobe.wardrobeWidth - 150, wardrobe.wardrobeHeight);
            safeHitRec = new Rectangle((int)safe.safe_pos.X + 200, (int)safe.safe_pos.Y, safe.safeWidth - 300 , safe.safeHeight);

            fontRectangle_Bed = new Rectangle(0, 854, 229, 54);

        }
        public void  playerHide()
        {
            if (game.player.playerHitRec.Intersects(wardrobeHitRec) && game.player.playerHitRec.Intersects(doorHitRec_left) == false)// ตรวจสอบการชนกับ lockerHitRec 
            {
                game.player.isHitObj = true;
                lockerGuide_pos = new Vector2(
                   game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                   game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);
                // ตรวจสอบการกดปุ่ม F
                if (game.player.ks.IsKeyDown(Keys.Space) && !game.player.wasFKeyPressed)
                {
                    if (game.player.player_state == "Alive")
                    {
                        game.player.player_state = "Hide";
                    }
                    else
                    {
                        game.player.player_state = "Alive";
                    }
                }

                // เก็บสถานะของการกดปุ่ม F ในรอบก่อนหน้า
                game.player.wasFKeyPressed = game.player.ks.IsKeyDown(Keys.Space);
            }
            else
            {
                // ถ้าไม่ได้ชนกับ locker, รีเซ็ตสถานะการกดปุ่ม F
                game.player.wasFKeyPressed = false;
            }
        }
        private void ObjectInteract(GameTime theTime)
        {

            //safe
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(safeHitRec))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && !eKeyPressed)
                {
                    safeIsUnlock = true;
                }
            }

            //Bed
            bedIsHit = game.player.playerHitRec.Intersects(bedHitRec);
            if (bedIsHit)
            {
                if (!showBedFont)
                {
                    showBedGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showBedGuide = false;
                    showBedFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showBedGuide = false;
                showBedFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showBedFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showBedFont = false;
                }
            }

            guide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
                game.player.player_pos.Y - guideRectangle.Height - 5
            );

            font_Bed_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Bed.Width / 2),
                game.player.player_pos.Y - fontRectangle_Bed.Height - 5
            );
        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_left) && game.player.direction == 0 && game.player.delayDoor > 0.5)
            {
                game.switch_Scenes = "BedToHallway_2";
                doorIsHit = true;
                doorGuide_pos = new Vector2(
                   game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                   game.player.player_pos.Y - doorGuide.doorGuideHeight - 20
               );
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    ScreenEvent.Invoke(game.hallway_2, new EventArgs());
                    return;
                }
            }
            else if (game.player.playerHitRec.Intersects(doorHitRec_right) && game.player.direction == 1 && game.player.delayDoor > 0.5)
            {
                doorIsHit = true;
                doorGuide_pos = new Vector2(
                   game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                   game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    ScreenEvent.Invoke(game.rest_room, new EventArgs());
                    return;
                }
            }
            else if (game.player.playerHitRec.Intersects(ladderHitRec) && game.player.delayDoor > 0.5)
            {
                game.switch_Scenes = "GoRoom_03";
                ladderIsHit = true;
                lockGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);
                if (game.player.hasRoom03Key == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        room03IsUnlock = true;
                    }
                    if (room03IsUnlock == true)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                        {
                            ScreenEvent.Invoke(game.room_03, new EventArgs());
                            return;
                        }
                    }
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

            if (game.room03_Key.isVisible == true)
                game.room03_Key.Room03_keyHitRec = new Rectangle((int)room03_Key_pos.X, (int)room03_Key_pos.Y, game.room03_Key.Room03_keyWidth, game.room03_Key.Room03_keyHeight);

            if (game.paenghom_Heart.isVisible == true)
                game.paenghom_Heart.Paenghom_HeartHitRec = new Rectangle((int)paenghom_Heart_pos.X, (int)paenghom_Heart_pos.Y, game.paenghom_Heart.Paenghom_HeartWidth, game.paenghom_Heart.Paenghom_HeartHeight);

            game.player.delayDoor += (float)theTime.ElapsedGameTime.TotalSeconds;

            game.Update_camera();

            playerHide();
            OpenDoor();
            ObjectInteract(theTime);

            if (game.player.isHitObj == true)
            {
                pickGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - 30,
                    game.player.player_pos.Y - 90);

                lockGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - 30,
                    game.player.player_pos.Y - 90);

            }

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            if (safeIsUnlock == true)
                theBatch.Draw(safeTexture, safe.safe_pos - game.cameraPos, safe.safeOpenRec, game.transparentColor);

            if (game.room03_Key.isVisible == true)
                theBatch.Draw(game.room03_KeyTexture, room03_Key_pos - game.cameraPos, game.room03_Key.Room03_keyRec, game.transparentColor);

            if (game.paenghom_Heart.isVisible == true)
                theBatch.Draw(game.paenghom_HeartTexture, paenghom_Heart_pos - game.cameraPos, game.paenghom_Heart.Paenghom_HeartRec, game.transparentColor);

            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left, game.transparentColor);
            theBatch.Draw(doorTexture, door_right_pos - game.cameraPos, door.doorRec_right, game.transparentColor);

            if (safeIsUnlock == false)
                theBatch.Draw(safeTexture, safe.safe_pos - game.cameraPos, safe.safeRec, game.transparentColor);
           


            theBatch.Draw(bedTexture, bed.bed_pos - game.cameraPos, bed.bedRec, game.transparentColor);
            theBatch.Draw(wardrobeTexture, wardrobe.wardrobe_pos - game.cameraPos, wardrobe.wardrobeRec, game.transparentColor);

          

            game.Update_Draw();
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.room03_Key.Room03_keyHitRec) && game.room03_Key.isVisible == true && safeIsUnlock == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pickGuideTexture, pickGuide_pos - game.cameraPos, pickGuide.pick_GuideRec, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.paenghom_Heart.Paenghom_HeartHitRec) && game.paenghom_Heart.isVisible == true && safeIsUnlock == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pickGuideTexture, pickGuide_pos - game.cameraPos, pickGuide.pick_GuideRec, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(safeHitRec) && game.player.playerHitRec.Intersects(wardrobeHitRec) == false && safeIsUnlock == false && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(lockGuideTexture, lockGuide_pos - game.cameraPos, lockGuide.lock_GuideRec, Color.White);
            }

            if (doorIsHit == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (ladderIsHit == true && room03IsUnlock == false)
            {
                theBatch.Draw(lockGuideTexture, lockGuide_pos - game.cameraPos, lockGuide.lock_GuideRec, Color.White);
            }
            else if (ladderIsHit == true && room03IsUnlock == true)
            {
                theBatch.Draw(stairGuideTexture, ladder_pos - game.cameraPos, stairGuide.stairGuideRec, Color.White);
            }

            if (showBedGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showBedFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_Bed, font_Bed_Pos - game.cameraPos, fontRectangle_Bed, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(wardrobeHitRec) && game.player.player_state == "Alive" && game.player.playerHitRec.Intersects(doorHitRec_left) == false && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(lockerGuideTexture, lockerGuide_pos - game.cameraPos, lockerGuide.lockerGuideRec, Color.White);
            }
        }
    }
}
