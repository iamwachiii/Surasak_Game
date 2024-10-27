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
using SK_03.All_Objects.Room04_Objs;
using SK_03.All_Objects.All_Icon_Guides;

namespace SK_03
{
    public class Kitchen_room : SceneManage
    {
        public Texture2D kitchen_roomTexture;
        public Vector2 kitchen_room_pos; 
        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;

        private Box box;
        private Texture2D boxTexture;
        private Sink sink;
        private Texture2D sinkTexture;
        private Pot pot;
        private Texture2D potTexture;
        private Fridge fridge;
        private Texture2D fridgeTexture;
        private Lock_Guide lock_Guide;
        private Texture2D lock_GuideTexture;
        private Locker_Guide lockerGuide;
        private Texture2D lockerGuideTexture;
        private Pick_Guide pickGuide;
        private Texture2D pickGuideTexture;

        private Texture2D font_Pot;
        private Texture2D font_Fridge;

        private bool potIsHit = false;
        private bool fridgeIsHit = false;

        private bool showPotFont = false;
        private bool showFridgeFont = false;

        private bool showPotGuide = false;
        private bool showFridgeGuide = false;

        private Vector2 font_Pot_Pos;
        private Vector2 font_Fridge_Pos;

        private Rectangle fontRectangle_Pot;
        private Rectangle fontRectangle_Fridge;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 doorGuide_pos;
        private Vector2 specialDoorGuide_pos;
        private Vector2 lock_Guide_pos;
        private Vector2 lockerGuide_pos;
        private Vector2 arthid_Heart_pos;
        private Vector2 pickGuide_pos;

        private bool doorLeftIsHit, doorRightIsHit = false;
        private bool specialDoorIsHit = false;

        private float fontTimer = 0f;
        private const float FONT_DISPLAY_TIME = 1.5f;

        private Underground_gate underground_gate;
        private Texture2D underground_gateTexture;
        private Vector2 underground_gate_pos;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle potHitRec, fridgeHitRec;
        private Rectangle guideRectangle;
        private Rectangle underground_gateHirRec;
        private Rectangle doorGuideRectangle;
        private Rectangle sinkHitRec;
        private Rectangle boxHitRec;

        private SoundEffect openDoorSound;
        private bool eKeyPressed = false;
        private bool basementIsUnlock = false;
        private bool boxIsUnlock = false;

        public Kitchen_room(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            kitchen_room_pos = new Vector2(0, 0);
            kitchen_roomTexture = game.Content.Load<Texture2D>("Kitchen_room");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");
            underground_gateTexture = game.Content.Load<Texture2D>("tiles_map2");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            lock_GuideTexture = game.Content.Load<Texture2D>("Icon");
            lockerGuideTexture = game.Content.Load<Texture2D>("Icon");
            pickGuideTexture = game.Content.Load<Texture2D>("Icon");

            boxTexture = game.Content.Load<Texture2D>("tiles_map2");
            sinkTexture = game.Content.Load<Texture2D>("tiles_map2");
            potTexture = game.Content.Load<Texture2D>("tiles_map2");
            fridgeTexture = game.Content.Load<Texture2D>("tiles_map2");

            font_Pot = game.Content.Load<Texture2D>("Font_01");
            font_Fridge = game.Content.Load<Texture2D>("Font_01");

            pickGuide = new Pick_Guide(pickGuideTexture);
            lockerGuide = new Locker_Guide(lockerGuideTexture);
            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            underground_gate = new Underground_gate(underground_gateTexture);
            box = new Box(boxTexture);
            sink = new Sink(sinkTexture);
            pot = new Pot(potTexture);
            fridge = new Fridge(fridgeTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            lock_Guide = new Lock_Guide(lock_GuideTexture); 

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            arthid_Heart_pos = new Vector2(500, 790);
            //Console.WriteLine("w = " + living_roomTexture.Width);
            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(kitchen_roomTexture.Width - door.doorWidth, 255);

            guide_pos = new Vector2(1950, 750);
            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(kitchen_roomTexture.Width - guide.guideWidth, 400);

            underground_gate_pos = new Vector2(1800, 900);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);
            underground_gateHirRec = new Rectangle((int)underground_gate_pos.X, (int)underground_gate_pos.Y, underground_gate.Underground_gateWidth, underground_gate.Underground_gateHeight);

            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

            potHitRec = new Rectangle((int)pot.pot_pos.X, (int)pot.pot_pos.Y, pot.potWidth, pot.potHeight);
            fridgeHitRec = new Rectangle((int)fridge.fridge_pos.X, (int)fridge.fridge_pos.Y, fridge.fridgeWidth, fridge.fridgeHeight);
            sinkHitRec = new Rectangle((int)sink.sink_pos.X + 100, (int)sink.sink_pos.Y, sink.sinkWidth - 200, sink.sinkHeight);
            boxHitRec = new Rectangle((int)box.box_pos.X, (int)box.box_pos.Y, box.boxWidth, box.boxHeight);

            fontRectangle_Pot = new Rectangle(0, 639, 200, 54);
            fontRectangle_Fridge = new Rectangle(0, 692, 154, 50);
        }
        public void playerHide()
        {
            if (game.player.playerHitRec.Intersects(sinkHitRec))// ตรวจสอบการชนกับ lockerHitRec 
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
            //Pot
            potIsHit = game.player.playerHitRec.Intersects(potHitRec);
            if (potIsHit)
            {
                if (!showPotFont)
                {
                    showPotGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showPotGuide = false;
                    showPotFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showPotGuide = false;
                showPotFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showPotFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showPotFont = false;
                }
            }

            //Fridge
            fridgeIsHit = game.player.playerHitRec.Intersects(fridgeHitRec);
            if (fridgeIsHit)
            {
                if (!showFridgeFont)
                {
                    showFridgeGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showFridgeGuide = false;
                    showFridgeFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showFridgeGuide = false;
                showFridgeFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showFridgeFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showFridgeFont = false;
                }
            }

            guide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
                game.player.player_pos.Y - guideRectangle.Height - 5
            );

            font_Pot_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Pot.Width / 2),
                game.player.player_pos.Y - fontRectangle_Pot.Height - 5
            );
            font_Fridge_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Fridge.Width / 2),
                game.player.player_pos.Y - fontRectangle_Fridge.Height - 5
            );
        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_left) && game.player.direction == 0)
            {
                doorLeftIsHit = true;
                doorGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20
                );
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    ScreenEvent.Invoke(game.hallway, new EventArgs());
                    return;
                }
            }
            else if (game.player.playerHitRec.Intersects(doorHitRec_right) && game.player.direction == 1)
            {
                doorRightIsHit = true;
                lock_Guide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                if (game.player.hasFriendsHearts == 3)
                {
                    doorGuide_pos = new Vector2(
                        game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                        game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                    if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                    {
                        openDoorSound.CreateInstance().Play();
                        ScreenEvent.Invoke(game.room_04, new EventArgs());
                        return;
                    }
                }

            }
            else if (game.player.playerHitRec.Intersects(underground_gateHirRec) && game.player.delayDoor > 0.5)
            {
                game.switch_Scenes = "GoBasement";
                specialDoorIsHit = true;
                lock_Guide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                if (game.player.hasBasementKey == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        basementIsUnlock = true;
                    }
                    if (basementIsUnlock == true)
                    {
                        specialDoorGuide_pos = new Vector2(
                            game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                            game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                        if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                        {
                            ScreenEvent.Invoke(game.basement, new EventArgs());
                            return;
                        }
                    }
                }
            }
            else if (game.player.playerHitRec.Intersects(boxHitRec))
            {
                lock_Guide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                if (game.player.hasHairpin == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        boxIsUnlock = true;
                    }
                    if (boxIsUnlock == true)
                    {

                    }
                }
            }
            else
            {
                doorLeftIsHit = false;
                doorRightIsHit = false;
                specialDoorIsHit = false;
                game.switch_Scenes = "default";
            }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightPositions();

            game.player.delayDoor += (float)theTime.ElapsedGameTime.TotalSeconds;
           
            game.Update_camera();

            playerHide();
            OpenDoor();
            ObjectInteract(theTime);

            if (boxIsUnlock == true)
            {
                if (game.arthid_Heart.isVisible == true)
                    game.arthid_Heart.Arthid_HeartHitRec = new Rectangle((int)arthid_Heart_pos.X, (int)arthid_Heart_pos.Y, game.arthid_Heart.Arthid_HeartWidth, game.arthid_Heart.Arthid_HeartHeight);
            }
            lock_Guide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

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
            if (game.arthid_Heart.isVisible && boxIsUnlock == true)
                theBatch.Draw(game.arthid_HeartTexture, arthid_Heart_pos - game.cameraPos, game.arthid_Heart.Arthid_HeartRec, game.transparentColor);

            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left, game.transparentColor);
            theBatch.Draw(doorTexture, door_right_pos - game.cameraPos, door.doorRec_right, game.transparentColor);
            theBatch.Draw(underground_gateTexture, underground_gate_pos - game.cameraPos, underground_gate.Underground_gateRec, game.transparentColor);
            theBatch.Draw(boxTexture, box.box_pos - game.cameraPos, box.boxRec, game.transparentColor);
            theBatch.Draw(sinkTexture, sink.sink_pos - game.cameraPos, sink.sinkRec, game.transparentColor);
            theBatch.Draw(potTexture, pot.pot_pos - game.cameraPos, pot.potRec, game.transparentColor);
            theBatch.Draw(fridgeTexture, fridge.fridge_pos - game.cameraPos, fridge.fridgeRec, game.transparentColor);

            
            game.Update_Draw();
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (doorRightIsHit == true && game.player.hasFriendsHearts == 3)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            else if (doorRightIsHit == true && game.player.hasFriendsHearts != 3)
            {
                theBatch.Draw(lock_GuideTexture, lock_Guide_pos - game.cameraPos, lock_Guide.lock_GuideRec, Color.White);
            }
            else if (doorRightIsHit == true && game.player.hasFriendsHearts == 3)
            {
                theBatch.Draw(doorGuideTexture, specialDoorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (specialDoorIsHit == true && basementIsUnlock == false )
            {
                theBatch.Draw(lock_GuideTexture, lock_Guide_pos - game.cameraPos, lock_Guide.lock_GuideRec, Color.White);
            }
            else if (specialDoorIsHit == true && basementIsUnlock == true)
            {
                theBatch.Draw(doorGuideTexture, specialDoorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(boxHitRec) && boxIsUnlock == false && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(lock_GuideTexture, lock_Guide_pos - game.cameraPos, lock_Guide.lock_GuideRec, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.arthid_Heart.Arthid_HeartHitRec) && boxIsUnlock == true && game.arthid_Heart.isVisible == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pickGuideTexture, pickGuide_pos - game.cameraPos, pickGuide.pick_GuideRec, Color.White);
            }

                if (showPotGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }
            if (showFridgeGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showPotFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_Pot, font_Pot_Pos - game.cameraPos, fontRectangle_Pot, Color.White);
            }
            if (showFridgeFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_Fridge, font_Fridge_Pos - game.cameraPos, fontRectangle_Fridge, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(sinkHitRec) && game.player.player_state == "Alive" && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(lockerGuideTexture, lockerGuide_pos - game.cameraPos, lockerGuide.lockerGuideRec, Color.White);
            }
        }
    }
}