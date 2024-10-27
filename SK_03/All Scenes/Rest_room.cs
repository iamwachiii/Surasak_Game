using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using SK_03.All_Objects.RestRoom_Objs;
using Microsoft.Xna.Framework.Audio;
using SK_03.All_Objects;
using SK_03.All_Objects.Basement;
using SK_03.All_Objects.All_keys;
using SK_03.All_Objects.All_Icon_Guides;

namespace SK_03
{
    public class Rest_room : SceneManage
    {
        public Texture2D rest_roomTexture;
        public Vector2 rest_room_pos;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;

        private Texture2D font_Toilet;

        private bool toiletIsHit = false;

        private bool showToiletFont = false;

        private bool showToiletGuide = false;

        private Vector2 font_Toilet_Pos;

        private Rectangle fontRectangle_Toilet;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Toilet toilet;
        private Texture2D toiletTexture;
        private Basin basin;
        private Texture2D basinTexture;
        private Bathtub bathtub;
        private Texture2D bathtubTexture;
        private Pick_Guide pickGuide;
        private Texture2D pickGuideTexture;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 guide_pos;
        private Vector2 doorGuide_pos;
        private Vector2 hairpin_pos;
        private Vector2 pickGuide_pos;

        private Rectangle doorGuideRectangle;
        private Rectangle guideRectangle;
        private Rectangle toiletHitRec;

        private float fontTimer = 0f;
        private const float FONT_DISPLAY_TIME = 1.5f;

        private bool doorIsHit = false;

        private SoundEffect openDoorSound;
        private bool eKeyPressed = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        public Rest_room(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;

            if (game.player.direction == 0)
                game.player.player_pos = new Vector2(game.bg_width, 535);
            else if (game.player.direction == 1)
                game.player.player_pos = new Vector2(0, 535);

            rest_room_pos = new Vector2(0, 0);
            rest_roomTexture = game.Content.Load<Texture2D>("Rest_room");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            pickGuideTexture = game.Content.Load<Texture2D>("Icon");

            toiletTexture = game.Content.Load<Texture2D>("Tiles_Rest_Room");
            basinTexture = game.Content.Load<Texture2D>("Tiles_Rest_Room");
            bathtubTexture = game.Content.Load<Texture2D>("Tiles_Rest_Room");

            font_Toilet = game.Content.Load<Texture2D>("Font_01");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            basin = new Basin(basinTexture);
            toilet = new Toilet(toiletTexture);
            bathtub = new Bathtub(basinTexture);
            pickGuide = new Pick_Guide(pickGuideTexture);

            hairpin_pos = new Vector2(390, 570);

            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(rest_roomTexture.Width - door.doorWidth, 255);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(rest_roomTexture.Width - guide.guideWidth, 400);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);

            toiletHitRec = new Rectangle((int)toilet.toilet_pos.X, (int)toilet.toilet_pos.Y, toilet.toiletWidth, toilet.toiletHeight);
            fontRectangle_Toilet = new Rectangle(0, 911, 127, 58);
        }
        private void ObjectInteract(GameTime theTime)
        {
            //Toilet
            toiletIsHit = game.player.playerHitRec.Intersects(toiletHitRec);
            if (toiletIsHit)
            {
                if (!showToiletFont)
                {
                    showToiletGuide = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.E) && !eKeyPressed)
                {
                    eKeyPressed = true;
                    showToiletGuide = false;
                    showToiletFont = true;
                    fontTimer = 0f;
                }
            }
            else
            {
                showToiletGuide = false;
                showToiletFont = false;
                eKeyPressed = false;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                eKeyPressed = false;
            }
            if (showToiletFont)
            {
                fontTimer += (float)theTime.ElapsedGameTime.TotalSeconds;
                if (fontTimer >= FONT_DISPLAY_TIME)
                {
                    showToiletFont = false;
                }
            }
            guide_pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (guideRectangle.Width / 2),
                game.player.player_pos.Y - guideRectangle.Height - 5
            );

            font_Toilet_Pos = new Vector2(
                game.player.player_pos.X + (game.player.frameWidth / 2) - (fontRectangle_Toilet.Width / 2),
                game.player.player_pos.Y - fontRectangle_Toilet.Height - 5
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
                    ScreenEvent.Invoke(game.bed_Room, new EventArgs());
                    //game.gameReset = false;
                    return;
                }
            }
            else { doorIsHit = false; }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightPositions();

            if (game.hairpin.isVisible == true)
                game.hairpin.HairpinHitRec = new Rectangle((int)hairpin_pos.X, (int)hairpin_pos.Y, game.hairpin.HairpinWidth, game.hairpin.HairpinHeight);

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
                
            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left, game.transparentColor);       
            theBatch.Draw(basinTexture, basin.basin_pos - game.cameraPos, basin.basinRec, game.transparentColor);
            theBatch.Draw(toiletTexture, toilet.toilet_pos - game.cameraPos, toilet.toiletRec, game.transparentColor);
            theBatch.Draw(bathtubTexture, bathtub.bathtub_pos - game.cameraPos, bathtub.bathtubRec, game.transparentColor);
            if (game.hairpin.isVisible == true)
            {
                theBatch.Draw(game.hairpinTexture, hairpin_pos, game.hairpin.HairpinRec, game.transparentColor);
            }

            game.Update_Draw();
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (doorIsHit == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (showToiletGuide && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(guideTexture, guide_pos - game.cameraPos, guide.guideRec_right, Color.White);
            }

            if (showToiletFont && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(font_Toilet, font_Toilet_Pos - game.cameraPos, fontRectangle_Toilet, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.hairpin.HairpinHitRec) && game.hairpin.isVisible == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pickGuideTexture, pickGuide_pos, pickGuide.pick_GuideRec, Color.White);
            }
        }
    }
}
