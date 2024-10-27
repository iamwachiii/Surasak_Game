using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK_03.All_Objects.Hallway2_Objs;
using Microsoft.Xna.Framework.Audio;
using SK_03.All_Objects;
using SK_03.All_Objects.Room04_Objs;

namespace SK_03
{
    public class Hallway_2 : SceneManage
    {
        public Texture2D hallway2Texture;
        public Vector2 hallway2_pos;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Incense_02 incense_02;
        private Texture2D incenseTexture2;
        private Plant plant;
        private Texture2D plantTexture;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;
        private StairDown_Guide stairDownGuide;
        private Texture2D stairDownGuideTexture;
        private Lock_Guide lockGuide;
        private Texture2D lockGuideTexture;

        private Texture2D font_Incene02;

        private bool incene02IsHit = false;

        private bool showIncene02Font = false;

        private bool showIncene02Guide = false;

        private Vector2 font_Incene02_Pos;

        private Rectangle fontRectangle_Incene02;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 door_pos_bed_room;
        private Vector2 door_pos_room_01;
        private Vector2 doorGuide_pos;
        private Vector2 lockGuide_pos;
        //private Vector2 ;

        private Vector2 guide_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 guide_pos_stair, guide_pos_bed_room, guide_pos_room_01;
        private Vector2 stair_pos;

        private bool doorIsHit = false;
        private bool stairIsHit = false;
        private bool doorBed_roomIsHit = false;
        private bool doorRoom_01IsHit = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle incene02HitRec;
        private Rectangle doorHitRec_bed_room;
        private Rectangle doorHitRec_room_01;
        private Rectangle stairHitRec;
        private Rectangle doorGuideRectangle;
        private Rectangle stairDownGuideRectangle;
        private Rectangle guideRectangle;

        private float fontTimer = 0f;
        private const float FONT_DISPLAY_TIME = 1.5f;

        private SoundEffect openDoorSound;
        private bool eKeyPressed = false;

        private bool balconyIsUnlock;
        private bool bedroomIsUnlock;
        private bool room01IsUnlock;
        public Hallway_2(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            hallway2_pos = new Vector2(0, 0);
            hallway2Texture = game.Content.Load<Texture2D>("Hallway_2");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            stairDownGuideTexture = game.Content.Load<Texture2D>("Icon_3");
            lockGuideTexture = game.Content.Load<Texture2D>("Icon");

            incenseTexture2 = game.Content.Load<Texture2D>("Tilemap_Hallway_2");
            plantTexture = game.Content.Load<Texture2D>("Tilemap_Hallway_2");

            font_Incene02 = game.Content.Load<Texture2D>("Font_01");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            lockGuide = new Lock_Guide(lockGuideTexture);
            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            plant = new Plant(plantTexture);
            incense_02 = new Incense_02(incenseTexture2);
            doorGuide = new Door_Guide(doorGuideTexture);
            stairDownGuide = new StairDown_Guide(stairDownGuideTexture);

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(hallway2Texture.Width - door.doorWidth, 255);
            door_pos_bed_room = new Vector2(1300, 310);
            door_pos_room_01 = new Vector2(2600, 310);
            stair_pos = new Vector2(720, 500);
            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);

            guide_pos_stair = stair_pos - new Vector2(0, 50); 
            guide_pos_bed_room = door_pos_bed_room + new Vector2(0, 150);
            guide_pos_room_01 = door_pos_room_01 + new Vector2(110, 150);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(hallway2Texture.Width - guide.guideWidth, 400);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_bed_room = new Rectangle((int)door_pos_bed_room.X, (int)door_pos_bed_room.Y, 300, door.doorHeight);
            doorHitRec_room_01 = new Rectangle((int)door_pos_room_01.X, (int)door_pos_room_01.Y, 300, door.doorHeight);
            stairHitRec = new Rectangle((int)stair_pos.X, (int)stair_pos.Y, 150, 50);

            incene02HitRec = new Rectangle((int)incense_02.incense2_pos.X, (int)incense_02.incense2_pos.Y, incense_02.incense2Width, incense_02.incense2Height);

            fontRectangle_Incene02 = new Rectangle(0, 796, 193, 60);
        }
        private void ObjectInteract(GameTime theTime)
        {
            //Incene02
            incene02IsHit = game.player.playerHitRec.Intersects(incene02HitRec);
            if (incene02IsHit)
            {
                if (!showIncene02Font)
                {
                    showIncene02Guide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showIncene02Guide = false;
                    showIncene02Font = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showIncene02Guide = false;
                showIncene02Font = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showIncene02Font)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showIncene02Font = false;
                }
            }
            guide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
                game.player.player_pos.Y - guideRectangle.Height - 5
            );

            font_Incene02_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Incene02.Width / 2),
                game.player.player_pos.Y - fontRectangle_Incene02.Height - 5
            );
        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_left) && game.player.direction == 0)
            {
                doorIsHit = true;
                lockGuide_pos = new Vector2(
                   game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                   game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);
                if (game.player.hasBasementKey == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        balconyIsUnlock = true;
                    }
                    if (balconyIsUnlock == true)
                    {
                        doorGuide_pos = new Vector2(
                            game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                            game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                        if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                        {
                            openDoorSound.CreateInstance().Play();
                            ScreenEvent.Invoke(game.balcony, new EventArgs());
                            return;
                        }
                    }
                }
            }
            else if (game.player.playerHitRec.Intersects(stairHitRec) && game.player.direction == 0)
            {
                game.switch_Scenes = "GoHallway";
                stairIsHit = true;
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    ScreenEvent.Invoke(game.hallway, new EventArgs());
                    return;
                }
            }
            else if (game.player.playerHitRec.Intersects(doorHitRec_bed_room) && game.player.delayDoor > 0.5)
            {
                game.switch_Scenes = "GoBed_room";
                doorBed_roomIsHit = true;
                if (game.player.hasBedroomKey == true)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        bedroomIsUnlock = true;
                    }
                    if (bedroomIsUnlock == true)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                        {
                            openDoorSound.CreateInstance().Play();
                            ScreenEvent.Invoke(game.bed_Room, new EventArgs());
                            return;
                        }
                    }
                }
            }
            else if (game.player.playerHitRec.Intersects(doorHitRec_room_01) && game.player.delayDoor > 0.5)
            {
                game.switch_Scenes = "GoRoom_01";
                doorRoom_01IsHit = true;
                if(game.isEvent_1 == true)
                {
                    room01IsUnlock = true;
                }

                if (room01IsUnlock == true) //EDittt
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                    {
                        openDoorSound.CreateInstance().Play();
                        ScreenEvent.Invoke(game.room_01, new EventArgs());
                        return;
                    }
                }
            }
            else
            {
                doorIsHit = false;
                stairIsHit = false;
                doorBed_roomIsHit = false;
                doorRoom_01IsHit = false;
                game.switch_Scenes = "default";
            }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightPositions();

            game.player.delayDoor += (float)theTime.ElapsedGameTime.TotalSeconds;

            game.Update_camera();

            OpenDoor();
            ObjectInteract(theTime);


            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {

            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left, game.transparentColor);
            theBatch.Draw(incenseTexture2, incense_02.incense2_pos - game.cameraPos, incense_02.incense2Rec, game.transparentColor);
            theBatch.Draw(plantTexture, plant.plant_pos - game.cameraPos, plant.plantRec, game.transparentColor);

            game.Update_Draw();
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (doorIsHit == true && balconyIsUnlock == false)
            {
                theBatch.Draw(lockGuideTexture, lockGuide_pos - game.cameraPos, lockGuide.lock_GuideRec, Color.White);
            }
            else if (doorIsHit == true && balconyIsUnlock == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (stairIsHit == true)
            {
                theBatch.Draw(stairDownGuideTexture, guide_pos_stair - game.cameraPos, stairDownGuide.stairDownGuideRec, Color.White);
            }
            if(doorBed_roomIsHit == true && bedroomIsUnlock == false)
            {
                theBatch.Draw(lockGuideTexture, guide_pos_bed_room - game.cameraPos, lockGuide.lock_GuideRec, Color.White);
            }
            else if (doorBed_roomIsHit == true && bedroomIsUnlock == true)
            {
                theBatch.Draw(doorGuideTexture, guide_pos_bed_room - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (doorRoom_01IsHit == true && room01IsUnlock == false)
            {
                theBatch.Draw(lockGuideTexture, guide_pos_room_01 - game.cameraPos, lockGuide.lock_GuideRec, Color.White);
            }
            else if (doorRoom_01IsHit == true && room01IsUnlock == true)
            {
                theBatch.Draw(doorGuideTexture, guide_pos_room_01 - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (showIncene02Guide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showIncene02Font && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_Incene02, font_Incene02_Pos - game.cameraPos, fontRectangle_Incene02, Color.White);
            }
        }
    }
}
