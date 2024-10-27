using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using SK_03.All_Objects.Room04_Objs;
using SK_03.All_Objects;
using Microsoft.Xna.Framework.Audio;
using SK_03.All_Objects.All_Icon_Guides;

namespace SK_03
{
    public class Room_04 : SceneManage
    {
        public Texture2D room_04Texture;
        public Vector2 room_04_pos;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Waewdao waewdao;
        private Texture2D waewdaoTexture;
        private Jar_02 jar_02;
        private Texture2D jarTexture2;
        private Pick_Guide pickGuide;
        private Texture2D pickGuideTexture;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 doorGuide_pos;
        private Vector2 waewdao_Heart_pos;
        private Vector2 pickGuide_pos;

        private Rectangle guideRectangle;
        private Rectangle doorGuideRectangle;

        private SoundEffect openDoorSound;
        private bool doorIsHit = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        public Room_04(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;

            if (game.player.direction == 0)
                game.player.player_pos = new Vector2(game.bg_width, 535);
            else if (game.player.direction == 1)
                game.player.player_pos = new Vector2(0, 535);

            room_04_pos = new Vector2(0, 0);
            room_04Texture = game.Content.Load<Texture2D>("Room_04");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            pickGuideTexture = game.Content.Load<Texture2D>("Icon");

            waewdaoTexture = game.Content.Load<Texture2D>("Tiles_Room_04");
            jarTexture2 = game.Content.Load<Texture2D>("Tiles_Room_04");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            waewdao_Heart_pos = new Vector2(1200, 550);

            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            waewdao = new Waewdao(waewdaoTexture);
            jar_02 = new Jar_02(jarTexture2);
            pickGuide = new Pick_Guide(pickGuideTexture);

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(room_04Texture.Width - door.doorWidth, 255);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(room_04Texture.Width - guide.guideWidth, 400);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);

            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_left) && game.player.direction == 0)
            {
                doorIsHit = true;
                doorGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);

                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    ScreenEvent.Invoke(game.kitchen_room, new EventArgs());
                    return;
                }
            }
            else { doorIsHit = false; }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightRoom();

            game.Update_camera();

            OpenDoor();
            
            if (game.player.isHitObj == true)
            {
                pickGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20);
            }

            if (game.waewdao_Heart.isVisible == true)
                game.waewdao_Heart.Waewdao_HeartHitRec = new Rectangle((int)waewdao_Heart_pos.X, (int)waewdao_Heart_pos.Y, game.waewdao_Heart.Waewdao_HeartWidth, game.waewdao_Heart.Waewdao_HeartHeight);

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
           
            theBatch.Draw(doorTexture, door_left_pos - game.cameraPos, door.doorRec_left, game.transparentColor);
            theBatch.Draw(waewdaoTexture, waewdao.waewdao_pos - game.cameraPos, waewdao.waewdaoRec, game.transparentColor);
            theBatch.Draw(jarTexture2, jar_02.jar2_pos - game.cameraPos, jar_02.jar2Rec, game.transparentColor);

            if (game.waewdao_Heart.isVisible == true )
            {
                theBatch.Draw(game.waewdao_HeartTexture, waewdao_Heart_pos - game.cameraPos, game.waewdao_Heart.Waewdao_HeartRec, game.transparentColor);
            }

            game.Update_Draw();
           
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (doorIsHit == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
            if (game.player.isHitObj == true && game.player.playerHitRec.Intersects(game.waewdao_Heart.Waewdao_HeartHitRec) && game.waewdao_Heart.isVisible == true && (Keyboard.GetState().IsKeyDown(Keys.A) == false && Keyboard.GetState().IsKeyDown(Keys.D) == false))
            {
                theBatch.Draw(pickGuideTexture, pickGuide_pos, pickGuide.pick_GuideRec, Color.White);
            }
        }
    }
}
