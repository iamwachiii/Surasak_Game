using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using SK_03.All_Objects.Room02_Objs;
using SK_03.All_Objects;
using Microsoft.Xna.Framework.Audio;

namespace SK_03
{
    public class Room_02 : SceneManage
    {
        public Texture2D room_02Texture;
        public Vector2 room_02_pos;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Heart_Pic heartPic;
        private Texture2D heartTexture;
        private Paenghom Paenghom;
        private Texture2D paenghomTexture;
        private Candle candle;
        private Texture2D candleTexture;

        private Candle candle2;
        private Texture2D candleTexture2;
        private Vector2 candle2_pos;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 guide_pos;
        private Vector2 doorGuide_pos;

        private Rectangle guideRectangle;
        private Rectangle doorGuideRectangle;

        private SoundEffect openDoorSound;
        private bool doorIsHit = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle candleHitRec_1, candleHitRec_2;

        public Room_02(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;

            if (game.player.direction == 0)
                game.player.player_pos = new Vector2(game.bg_width, 535);
            else if (game.player.direction == 1)
                game.player.player_pos = new Vector2(0, 535);

            room_02_pos = new Vector2(0, 0);
            room_02Texture = game.Content.Load<Texture2D>("Room_02");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");

            guideTexture = game.Content.Load<Texture2D>("Icon_2");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");

            heartTexture = game.Content.Load<Texture2D>("Tiles_Room_02");
            paenghomTexture = game.Content.Load<Texture2D>("Tiles_Room_02");
            candleTexture = game.Content.Load<Texture2D>("Candle");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            doorGuide = new Door_Guide(doorGuideTexture);
            heartPic = new Heart_Pic(heartTexture);
            Paenghom = new Paenghom(paenghomTexture);
            candle = new Candle(game, candleTexture, new Vector2(650, 618));

            // กำหนดตำแหน่งและสร้าง Candle ตัวที่สอง
            candle2_pos = new Vector2(200, 618); // ตั้งค่าตำแหน่งที่ต้องการ
            candleTexture2 = game.Content.Load<Texture2D>("Candle"); // โหลด Texture สำหรับ Candle ตัวที่สอง
            candle2 = new Candle(game, candleTexture2, candle2_pos); // สร้าง Candle ตัวที่สอง

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(room_02Texture.Width - door.doorWidth, 255);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(room_02Texture.Width - guide.guideWidth, 400);

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);

            guideRectangle = new Rectangle(0, 0, guide.guideWidth, guide.guideHeight);
            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

            candle.candle_pos = new Vector2(650, 618);
        }

        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_right) && game.player.direction == 1 && game.player.delayDoor > 0.5)
            {
                doorIsHit = true;
                doorGuide_pos = new Vector2(
                   game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                   game.player.player_pos.Y - doorGuide.doorGuideHeight - 20
               );
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    candle.CleanupLight();
                    candle2.CleanupLight();
                    ScreenEvent.Invoke(game.basement, new EventArgs());
                    return;
                }
            }
            else { doorIsHit = false; }
        }

        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightRoom04();
            candle.InitializeCandleLight();
            candle2.InitializeCandleLight();

            game.player.delayDoor += (float)theTime.ElapsedGameTime.TotalSeconds;

            game.Update_camera();

            OpenDoor();

            candle.Update(theTime);
            candle2.Update(theTime); // อัปเดต Candle ตัวที่สอง

            candleHitRec_2 = new Rectangle((int)candle2_pos.X, (int)candle2_pos.Y, candle.candleWidth, candle.candleHeight);

            if (game.player.playerHitRec.Intersects(candleHitRec_2))
            {

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    candle.ExtinguideCandle();
                    Console.WriteLine("lll");
                }
            }

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(doorTexture, door_right_pos - game.cameraPos, door.doorRec_right, game.transparentColor);
            theBatch.Draw(heartTexture, heartPic.heartPic_pos - game.cameraPos, heartPic.heartPicRec, game.transparentColor);
            theBatch.Draw(paenghomTexture, Paenghom.paenghom_pos - game.cameraPos, Paenghom.paenghomRec, game.transparentColor);

            theBatch.Draw(candleTexture, candle.candle_pos - game.cameraPos, candle.sourceRectangle, game.transparentColor);
            theBatch.Draw(candleTexture2, candle2_pos - game.cameraPos, candle2.sourceRectangle, game.transparentColor);

            game.Update_Draw();
        }

        public void DrawUI(SpriteBatch theBatch)
        {
            if (doorIsHit == true)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
        }
    }
}
