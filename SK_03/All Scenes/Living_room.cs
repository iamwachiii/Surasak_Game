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
using SK_03.All_Objects;
using Microsoft.Xna.Framework.Audio;
using SK_03.All_Objects.All_Icon_Guides;
using SK_03.All_Objects.LivingRoom_Objs;
using SK_03.Sound;

namespace SK_03
{
    public class Living_room : SceneManage
    {
        public Texture2D living_roomTexture;
        public Vector2 living_room_pos;
        private Game1 game;
        private Door door;
        private Texture2D doorTexture;

        private Guide guide;
        private Texture2D guideTexture;
        private Locker_Guide lockerGuide;
        private Texture2D lockerGuideTexture;
        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;
        private Door_Lock doorLock;
        private Texture2D doorLockTexture;

        private Switch_living_room switch_Living_Room;
        private Texture2D switchTexture;
        private TV tv;
        private Texture2D tvTexture;
        private Mirror_living_room mirror1;
        private Texture2D mirrorTexture1;
        private Calendar calendar;
        private Texture2D calendarTexture;
        private Radio radio;
        private Texture2D radioTexture;
        private Table_living_room table1;
        private Texture2D tableTexture1;
        private Sofa sofa;
        private Texture2D sofaTexture;
        private Lock_Guide lock_Guide;
        private Texture2D lock_GuideTexture;
        private Pick_Guide pick_Guide;
        private Texture2D pick_GuideTexture;
        private Cabinet cabinet;
        private Texture2D cabinetTexture;

        private Texture2D font_switch;
        private Texture2D font_tv;
        private Texture2D font_mirror1;
        private Texture2D font_calendar;
        private Texture2D font_radio;
        private Texture2D font_table1;
        private Texture2D font_sofa;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_pos;
        private Vector2 guide_pos_locker;
        private Vector2 lock_Guide_pos;
        private Vector2 doorGuide_pos;
        private Vector2 doorLocker_pos;

        private bool doorLeftIsHit, doorRightIsHit = false;
        private bool switchIsHit = false;
        private bool tvIsHit = false;
        private bool mirrorIsHit = false;
        private bool calendarIsHit = false;
        private bool tableIsHit = false;
        private bool sofaIsHit = false;

        private bool showSwitchFont = false;
        private bool showTvFont = false;
        private bool showMirrorFont = false;
        private bool showCalendarFont = false;
        private bool showTableFont = false;
        private bool showSofaFont = false;

        private bool showSwitchGuide = false;
        private bool showTvGuide = false;
        private bool showMirrorGuide = false;
        private bool showCalendarGuide = false;
        private bool showTableGuide = false;
        private bool showSofaGuide = false;

        private Vector2 font_Switch_Pos;
        private Vector2 font_Tv_Pos;
        private Vector2 font_Mirror1_Pos;
        private Vector2 font_Calendar_Pos;
        private Vector2 font_Table1_Pos;
        private Vector2 font_Sofa_Pos;
        private Vector2 lock_Guided_pos;
        private Vector2 hallway_Key_pos;
        private Vector2 basement_Key_pos;
        private Vector2 phakin_Heart_pos;
        private Vector2 cabinet_pos;

        private Rectangle fontRectangle_Switch;
        private Rectangle fontRectangle_Tv;
        private Rectangle fontRectangle_Mirror1;
        private Rectangle fontRectangle_Calendar;
        private Rectangle fontRectangle_Table1;
        private Rectangle fontRectangle_Sofa;


        private Vector2 locker_pos;
        private Vector2 pick_Guide_pos;

        private SoundEffect openDoorSound;

        private float fontTimer = 0f;
        private const float FONT_DISPLAY_TIME = 1.5f;

        private Rectangle switchHitRec, tvHitRec, mirrorHitRec, calendarHitRec, tableHitRec, sofaHitRec;
        private Rectangle doorHitRec_left ,doorHitRec_right;
        private Rectangle LockerHitRec;
        private Rectangle guideRectangle;
        private Rectangle lockerGuideRectangle;
        private Rectangle doorGuideRectangle;

        private bool eKeyPressed = false;
        private bool front_houseIsUnlock = false;
        private bool hallwayIsUnlock = false;
        public bool cabinetIsUnlock = false;
        public Living_room(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            living_room_pos = new Vector2(0,0);
            living_roomTexture = game.Content.Load<Texture2D>("Long_Living_room");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            lockerGuideTexture = game.Content.Load<Texture2D>("Icon");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            lock_GuideTexture = game.Content.Load<Texture2D>("Icon");
            pick_GuideTexture = game.Content.Load<Texture2D>("Icon");

            switchTexture = game.Content.Load<Texture2D>("Tiles_Long_Living_room");
            tvTexture = game.Content.Load<Texture2D>("Tiles_Long_Living_room");
            mirrorTexture1 = game.Content.Load<Texture2D>("Tiles_Long_Living_room");
            calendarTexture = game.Content.Load<Texture2D>("Tiles_Long_Living_room");
            radioTexture = game.Content.Load<Texture2D>("Tiles_Long_Living_room");
            tableTexture1 = game.Content.Load<Texture2D>("Tiles_Long_Living_room");
            sofaTexture = game.Content.Load<Texture2D>("Tiles_Long_Living_room");
            cabinetTexture = game.Content.Load<Texture2D>("Tiles_Long_Living_room");

            font_switch = game.Content.Load<Texture2D>("Font_01");
            font_tv = game.Content.Load<Texture2D>("Font_01");
            font_mirror1 = game.Content.Load<Texture2D>("Font_01");
            font_calendar = game.Content.Load<Texture2D>("Font_01");
            font_radio = game.Content.Load<Texture2D>("Font_01");
            font_table1 = game.Content.Load<Texture2D>("Font_01");
            font_sofa = game.Content.Load<Texture2D>("Font_01");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            locker_pos = new Vector2(1823, 744);
            cabinet_pos = new Vector2(1823 - 315, 744);

            cabinet = new Cabinet(cabinetTexture);
            pick_Guide = new Pick_Guide(pick_GuideTexture);
            lock_Guide = new Lock_Guide(doorGuideTexture);
            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            lockerGuide = new Locker_Guide(lockerGuideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            switch_Living_Room = new Switch_living_room(switchTexture);
            tv = new TV(tvTexture);
            mirror1 = new Mirror_living_room(mirrorTexture1);
            calendar = new Calendar(calendarTexture);
            radio = new Radio(radioTexture);
            table1 = new Table_living_room(tableTexture1);
            sofa = new Sofa(sofaTexture);

            door_right_pos = new Vector2(living_roomTexture.Width - door.doorWidth, 255);
            hallway_Key_pos = new Vector2(1655, 500);
            basement_Key_pos = new Vector2(1669, 820);
            phakin_Heart_pos = new Vector2(1600, 790);

            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            lockerGuideRectangle = new Rectangle(0, 0, lockerGuide.lockerGuideWidth , lockerGuide.lockerGuideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);
            LockerHitRec = new Rectangle((int)locker_pos.X + 100, (int)locker_pos.Y, 25, 161);
            cabinet.CabinetHitRec = new Rectangle((int)cabinet_pos.X, (int)cabinet_pos.Y, cabinet.CabinetWidth,cabinet.CabinetHeight);

            switchHitRec = new Rectangle((int)switch_Living_Room.switch_pos.X, (int)switch_Living_Room.switch_pos.Y, switch_Living_Room.switchWidth, switch_Living_Room.switchHeight);
            tvHitRec = new Rectangle((int)tv.tv_pos.X, (int)tv.tv_pos.Y, tv.tvWidth, tv.tvHeight);
            mirrorHitRec = new Rectangle((int)mirror1.mirror1_pos.X, (int)mirror1.mirror1_pos.Y, mirror1.mirror1Width, mirror1.mirror1Height);
            calendarHitRec = new Rectangle((int)calendar.calendar_pos.X, (int)calendar.calendar_pos.Y, calendar.calendarWidth, calendar.calendarHeight);
            tableHitRec = new Rectangle((int)table1.table1_pos.X, (int)table1.table1_pos.Y, table1.table1Width, table1.table1Height);
            sofaHitRec = new Rectangle((int)sofa.sofa_pos.X, (int)sofa.sofa_pos.Y, sofa.sofaWidth, sofa.sofaHeight);

            fontRectangle_Switch = new Rectangle(0, 51, 184, 48);
            fontRectangle_Tv = new Rectangle(0, 238, 326, 70);
            fontRectangle_Mirror1 = new Rectangle(0, 98, 196, 49);
            fontRectangle_Calendar = new Rectangle(18, 143, 232, 102);
            fontRectangle_Table1 = new Rectangle(0, 304, 241, 64);
            fontRectangle_Sofa = new Rectangle(0, 364, 240, 87);

        }
        public void playerHide()
        {
            if (game.player.playerHitRec.Intersects(LockerHitRec))// ตรวจสอบการชนกับ lockerHitRec 
            {
                game.player.isHitObj = true;
                // ตรวจสอบการกดปุ่ม F
                if (game.player.ks.IsKeyDown(Keys.Space) && !game.player.wasFKeyPressed)
                {
                    if (game.player.player_state == "Alive")
                    {
                        game.player.player_state = "Hide";
                        game.sound.In_HideInstance.Play();
                    }
                    else
                    {
                        game.player.player_state = "Alive";
                        game.sound.Out_HideInstance.Play();

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
            //Switch
            switchIsHit = game.player.playerHitRec.Intersects(switchHitRec);
            if (switchIsHit)
            {
                    if (!showSwitchFont)
                    {
                        showSwitchGuide = true;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                    {
                        eKeyPressed = true;
                        showSwitchGuide = false;
                        showSwitchFont = true;
                        fontTimer = 0f;
                    }
            }
            else
            {
                showSwitchGuide = false;
                showSwitchFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showSwitchFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showSwitchFont = false;
                }
            }

            //tv
            tvIsHit = game.player.playerHitRec.Intersects(tvHitRec);
            if (tvIsHit)
            {
                if (!showTvFont)
                {
                    showTvGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showTvGuide = false;
                    showTvFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showTvGuide = false;
                showTvFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showTvFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showTvFont = false;
                }
            }

            //Mirror
            mirrorIsHit = game.player.playerHitRec.Intersects(mirrorHitRec);
            if (mirrorIsHit)
            {
                if (!showMirrorFont)
                {
                    showMirrorGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showMirrorGuide = false;
                    showMirrorFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showMirrorGuide = false;
                showMirrorFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showMirrorFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showMirrorFont = false;
                }
            }

            //Calendar
            calendarIsHit = game.player.playerHitRec.Intersects(calendarHitRec);
            if (calendarIsHit)
            {
                if (!showCalendarFont)
                {
                    showCalendarGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showCalendarGuide = false;
                    showCalendarFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showCalendarGuide = false;
                showCalendarFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showCalendarFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showCalendarFont = false;
                }
            }

            //Table
            tableIsHit = game.player.playerHitRec.Intersects(tableHitRec);
            if (tableIsHit)
            {
                if (!showTableFont)
                {
                    showTableGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showTableGuide = false;
                    showTableFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showTableGuide = false;
                showTableFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showTableFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showTableFont = false;
                }
            }

            //Sofa
            sofaIsHit = game.player.playerHitRec.Intersects(sofaHitRec);
            if (sofaIsHit)
            {
                if (!showSofaFont)
                {
                    showSofaGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showSofaGuide = false;
                    showSofaFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showSofaGuide = false;
                showSofaFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showSofaFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showSofaFont = false;
                }
            }

            guide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
                game.player.player_pos.Y - guideRectangle.Height - 5
            );

            font_Switch_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Switch.Width / 2),
                game.player.player_pos.Y - fontRectangle_Switch.Height - 5
            );
            font_Tv_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Tv.Width / 2),
                game.player.player_pos.Y - fontRectangle_Tv.Height - 5
            );
            font_Mirror1_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Mirror1.Width / 2),
                game.player.player_pos.Y - fontRectangle_Mirror1.Height - 5
            );
            font_Calendar_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Calendar.Width / 2),
                game.player.player_pos.Y - fontRectangle_Calendar.Height - 5
            );
            font_Table1_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Table1.Width / 2),
                game.player.player_pos.Y - fontRectangle_Table1.Height - 5
            );
            font_Sofa_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Sofa.Width / 2),
                game.player.player_pos.Y - fontRectangle_Sofa.Height - 5
            );
        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_left) && game.player.direction == 0)
            {
                doorLeftIsHit = true;
                lock_Guide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);
                if (game.player.isEndGame == true) front_houseIsUnlock = true;

                if (front_houseIsUnlock == true)
                {
                    doorGuide_pos = new Vector2(
                        game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                        game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                    if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                    {
                        openDoorSound.CreateInstance().Play();
                        ScreenEvent.Invoke(game.front_house, new EventArgs());
                        return;
                    }
                }
            }
            else if (game.player.playerHitRec.Intersects(doorHitRec_right) && game.player.direction == 1)
            {
                doorRightIsHit = true;
                lock_Guide_pos = new Vector2(
                   game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                   game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);
                if (game.player.hasHallwayKey == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        hallwayIsUnlock = true;
                    }

                    if (hallwayIsUnlock == true)
                    {
                        doorGuide_pos = new Vector2(
                            game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                            game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                        if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                        {
                            openDoorSound.CreateInstance().Play();
                            ScreenEvent.Invoke(game.hallway, new EventArgs());
                            return;
                        }
                    }
                }

            }
            else if (game.player.playerHitRec.Intersects(cabinet.CabinetHitRec))
            {
                game.player.isHitObj = true;
                lock_Guide_pos = new Vector2(
                   game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                   game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);
                if (game.player.hasCabinetKey == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        cabinetIsUnlock = true;
                    }

                    if (cabinetIsUnlock == true)
                    {
                        pick_Guide_pos = new Vector2(
                            game.player.player_pos.X + (game.player.frameWidth / 2) - 30,
                            game.player.player_pos.Y - 90);

                     
                    }
                }

            }
            else
            {
                doorLeftIsHit = false;
                doorRightIsHit = false;
            }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightPositions();

            if (game.hallway_Key.isVisible == true)
                game.hallway_Key.Hallway_keyHitRec = new Rectangle((int)hallway_Key_pos.X, (int)hallway_Key_pos.Y, game.hallway_Key.Hallway_keyWidth, game.hallway_Key.Hallway_keyHeight);

            if (cabinetIsUnlock == true)
            {
                if (game.basement_Key.isVisible == true)
                    game.basement_Key.Basement_keyHitRec = new Rectangle((int)basement_Key_pos.X, (int)basement_Key_pos.Y, game.basement_Key.Basement_keyWidth, game.basement_Key.Basement_keyHeight);

                if (game.phakin_Heart.isVisible == true)
                    game.phakin_Heart.Phakin_HeartHitRec = new Rectangle((int)phakin_Heart_pos.X, (int)phakin_Heart_pos.Y, game.phakin_Heart.Phakin_HeartWidth, game.phakin_Heart.Phakin_HeartHeight);             
            }

            playerHide();
            game.Update_camera();

            if (game.player.isHitObj == true)
            {
                pick_Guide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - 30,
                    game.player.player_pos.Y - 90);

                guide_pos_locker = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - 30,
                    game.player.player_pos.Y - 75);
            }

            OpenDoor();
            ObjectInteract(theTime);
            
            base.Update(theTime);
        }   
        public override void Draw(SpriteBatch theBatch) 
        {
            if (cabinetIsUnlock == true)
            {
                theBatch.Draw(cabinetTexture, cabinet_pos - game.cameraPos, cabinet.CabinetOpenRec, game.transparentColor);
            }

            if (game.hallway_Key.isVisible == true)
                theBatch.Draw(game.hallway_KeyTexture, hallway_Key_pos - game.cameraPos, game.hallway_Key.Hallway_keyRec, game.transparentColor);

            if (game.basement_Key.isVisible == true && cabinetIsUnlock == true)
                theBatch.Draw(game.basement_KeyTexure, basement_Key_pos - game.cameraPos, game.basement_Key.Basement_keyRec, game.transparentColor);

            if (game.phakin_Heart.isVisible == true && cabinetIsUnlock == true)
                theBatch.Draw(game.phakin_HeartTexture, phakin_Heart_pos - game.cameraPos, game.phakin_Heart.Phakin_HeartRec, game.transparentColor);

            theBatch.Draw(game.lockerTexture, locker_pos - game.cameraPos, game.locker.LockerRec, game.transparentColor);
            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left,game.transparentColor);
            theBatch.Draw(doorTexture, door_right_pos - game.cameraPos, door.doorRec_right, game.transparentColor);
            theBatch.Draw(switchTexture, switch_Living_Room.switch_pos - game.cameraPos, switch_Living_Room.switchRec, game.transparentColor);
            theBatch.Draw(tvTexture, tv.tv_pos - game.cameraPos, tv.tvRec, game.transparentColor);
            theBatch.Draw(mirrorTexture1, mirror1.mirror1_pos - game.cameraPos, mirror1.mirror1Rec, game.transparentColor);
            theBatch.Draw(calendarTexture, calendar.calendar_pos - game.cameraPos, calendar.calendarRec, game.transparentColor);
            theBatch.Draw(radioTexture, radio.radio_pos - game.cameraPos, radio.radioRec, game.transparentColor);
            theBatch.Draw(tableTexture1, table1.table1_pos - game.cameraPos, table1.table1Rec, game.transparentColor);
            theBatch.Draw(sofaTexture, sofa.sofa_pos - game.cameraPos, sofa.sofaRec, game.transparentColor);

            game.Update_Draw();

        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.hallway_Key.Hallway_keyHitRec) && game.hallway_Key.isVisible == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pick_GuideTexture, pick_Guide_pos - game.cameraPos, pick_Guide.pick_GuideRec, Color.White);
            }

            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.basement_Key.Basement_keyHitRec) && game.basement_Key.isVisible == true && cabinetIsUnlock == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pick_GuideTexture, pick_Guide_pos - game.cameraPos, pick_Guide.pick_GuideRec, Color.White);
            }

            if (game.player.playerHitRec.Intersects(cabinet.CabinetHitRec) && cabinetIsUnlock == false && game.hallway_Key.isVisible == false && game.player.playerHitRec.Intersects(LockerHitRec) == false && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(lock_GuideTexture, lock_Guide_pos - game.cameraPos, lock_Guide.lock_GuideRec, Color.White);
            }

            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(LockerHitRec) && game.player.player_state == "Alive" && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(lockerGuideTexture, guide_pos_locker - game.cameraPos, lockerGuide.lockerGuideRec, Color.White);
            }

            if (doorLeftIsHit == true && front_houseIsUnlock == false)
            {
                theBatch.Draw(lock_GuideTexture, lock_Guide_pos - game.cameraPos, lock_Guide.lock_GuideRec, Color.White);
            }
            else if (doorLeftIsHit == true && front_houseIsUnlock == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            else if (doorRightIsHit == true && hallwayIsUnlock == false)
            {
                theBatch.Draw(lock_GuideTexture, lock_Guide_pos - game.cameraPos, lock_Guide.lock_GuideRec, Color.White);
            }
            else if (doorRightIsHit == true && hallwayIsUnlock == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }

            if (showSwitchGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }
            if (showCalendarGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }
            if (showMirrorGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }
            if (showTableGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }
            if (showSofaGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showSwitchFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_switch, font_Switch_Pos - game.cameraPos, fontRectangle_Switch, Color.White);
            }
            if (showCalendarFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_calendar, font_Calendar_Pos - game.cameraPos, fontRectangle_Calendar, Color.White);
            }
            if (showMirrorFont && (     Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_mirror1, font_Mirror1_Pos - game.cameraPos, fontRectangle_Mirror1, Color.White);
            }
            if (showTableFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_table1, font_Table1_Pos - game.cameraPos, fontRectangle_Table1, Color.White);
            }
            if (showSofaFont && (   Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_sofa, font_Sofa_Pos - game.cameraPos, fontRectangle_Sofa, Color.White);
            }
        }


    }
}
