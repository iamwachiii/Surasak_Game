using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SK_03.Components;
using SK_03.Sound;
using System;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SK_03
{
    public class Player : Sprite
    {
        private float speed;
        private float normalSpeed = 10f;
        private float sprintSpeed = 18;//* 3f;
        public int frameWidth, frameHeight;
        public int frameRunWidth, frameRunHeight;
        private int frameIndex;
        private int frameIndexRun;
        private int maxFrames;
        private int offsetX, offsetY;
        private float delayFrames;
        private float delayFramesRun;
        private int direct; // frames
        private int directRun;
        public int direction = 1; //0 = ซ้าย, 1 = ขวา 

        public int frameDieWidth, frameDieHeight;
        private int frameIndexDie;
        private float delayFramesDie;
        private int directDie;

        public Rectangle playerRec; // ส่วนแสดงผลของ Player
        public Rectangle playerRecRun;
        public Rectangle playerRecDie;
        public Rectangle playerHitRec; // พื้นที่การชนของ Player
        public Vector2 player_pos;
        public string player_state;
        public bool PlayerIsHit = false;
        public bool PlayerIsSafe = false;
        public bool isPlayerRun = false;

        public float delayDoor;
        private float delayPlayer;
        public bool isHitObj;

        public int hasFriendsHearts = 0;
        public bool isEndGame;
        public bool hasRoom03Key;
        public bool hasHallwayKey;
        public bool hasBasementKey;
        public bool hasBalconyKey;
        public bool hasBedroomKey;
        public bool hasHairpin;
        public bool hasCabinetKey;

        public float delayDie;
        private float staminaDelay;
        private bool staminaRegen = false;
        public bool isDeath;

        public bool wasFKeyPressed = false; // ตัวแปรใหม่สำหรับติดตามสถานะของปุ่ม F
        private UI_Stamina UI_stamina;
        private  AllSound sound_player;

        public KeyboardState ks, old_ks;
       

        private Game1 game; // New field to hold the game instance

        public Player(Texture2D texture, Texture2D RunTexture,Texture2D DieTexture, UI_Stamina UI_stamina, Game1 game)
        {
            // กำหนดค่าเริ่มต้นต่างๆ ของ Player          
            this.game = game; // Initialize the game instance
            this.UI_stamina = UI_stamina;
            
            speed = normalSpeed;
            player_pos = new Vector2(500, 535);
            player_state = "Alive"; // Alive, Hide, Death
            sound_player = new AllSound(this.game);

            frameWidth = texture.Width / 4;
            frameHeight = texture.Height / 4;

            frameRunWidth = (RunTexture.Width )/ 4;
            frameRunHeight = (RunTexture.Height ) / 2;

            frameDieWidth = (DieTexture.Width) / 4;
            frameDieHeight = (DieTexture.Height) / 2;

            maxFrames = 4;
            delayFrames = 0.2f;
            delayFramesRun = 0.2f;
            frameIndex = 0;
            frameIndexRun = 0;

            delayFramesDie = 0.2f;
            frameIndexDie = 0;

            offsetX = 0;
            offsetY = 0;

            playerRec = new Rectangle(offsetX, offsetY, frameWidth, frameHeight);
            playerRecRun = new Rectangle(offsetX, offsetY, frameRunWidth, frameRunHeight);
            playerRecDie = new Rectangle(offsetX, offsetY, frameDieWidth, frameDieHeight);

            paused(0, frameHeight * 3);
            player_idle_animation();
        }

        public override void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();
            delayFrames -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            delayFramesRun -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            delayFramesDie -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            staminaDelay += (float)gameTime.ElapsedGameTime.TotalSeconds;
            

            if (UI_stamina.stamina > UI_stamina.frameWidth) UI_stamina.stamina = UI_stamina.frameWidth;

            playerHitRec = new Rectangle((int)player_pos.X, (int)player_pos.Y, frameWidth, frameHeight);


            if (game.percentage >= 0.33)
            {
                if (player_state != "Death" && player_state == "Alive")
                {
                    key_process(); // Process key inputs
                }

                if (player_state != "Death")
                {
                    player_run(); // Handle player running
                }
                else
                {
                    // Reset animation to idle when inventory is open
                    player_idle_animation();
                }
            }
            else player_idle_animation();

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                isDeath = true;
                player_die_animation();
            }

            base.Update(gameTime);
        }
        private void player_run()
        {
            // ตรวจสอบค่าของ stamina ก่อน        
            if (ks.IsKeyDown(Keys.LeftShift))
            {
                staminaDelay = 0;
            }

            if (UI_stamina.stamina == 0 && staminaDelay >= 3f)
            {
                staminaRegen = true;
                UI_stamina.stamina += 1f;
            }
            else
            {
                staminaRegen = false;
            }

            if (UI_stamina.stamina < UI_stamina.frameWidth  && staminaDelay >= 1f && UI_stamina.stamina != 0 && ks.IsKeyDown(Keys.LeftShift) == false)
            {
                staminaRegen = true;
                if (staminaRegen == true)
                {
                    UI_stamina.stamina += 1f;
                }
            }            

           // (ks.IsKeyDown(Keys.LeftShift) == false || (ks.IsKeyDown(Keys.LeftShift) == true && (ks.IsKeyDown(Keys.A) == false || ks.IsKeyDown(Keys.D) == false)))

            else
            {
                staminaRegen = false;
            }

            if (ks.IsKeyDown(Keys.LeftShift) && UI_stamina.stamina > 0 && (ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.D)))
            {
                sound_player.RunInstance.Play();
                if (direction == 0)
                {
                    directRun = 1;
                    speed = sprintSpeed;
                    //player_pos.X -= speed;                  
                    if (ks.IsKeyDown(Keys.A))
                    {
                        isPlayerRun = true;                        
                        player_run_animation();
                        ReduceUIstamina();
                    }
                    else
                    {
                        player_idle_animation();
                    }
                }   
                else if (direction == 1)
                {
                    directRun = 0;
                    speed = sprintSpeed;
                    //player_pos.X += speed;
                    if (ks.IsKeyDown(Keys.D))
                    {
                        isPlayerRun = true;
                        player_run_animation();
                        ReduceUIstamina();
                    }
                    else 
                    {
                        player_idle_animation();
                    }
                }
            }
            else if (ks.IsKeyUp(Keys.LeftShift) || (ks.IsKeyUp(Keys.A) || ks.IsKeyUp(Keys.D)))
            {
                sound_player.RunInstance.Stop();
                isPlayerRun = false;
                speed = normalSpeed;
            }
        }
        public void key_process()
        {
            if (ks.IsKeyDown(Keys.A))
            {
                direct = 1;
                directRun = 0;
                player_pos.X -= speed;
                player_animation();
                direction = 0;
                if (ks.IsKeyDown(Keys.LeftShift) == false)
                    sound_player.WalkInstance.Play();
            }
            else if (ks.IsKeyUp(Keys.A) && direction == 0)
            {
                sound_player.WalkInstance.Stop();
                player_idle_animation();
            }
            else if (ks.IsKeyDown(Keys.LeftShift) == true) sound_player.WalkInstance.Stop();

            if (ks.IsKeyDown(Keys.D))
            {
                direct = 3;
                directRun = 1;
                player_pos.X += speed;
                player_animation();
                direction = 1;
                if (ks.IsKeyDown(Keys.LeftShift) == false)
                    sound_player.WalkInstance.Play();

            }          
            else if (ks.IsKeyUp(Keys.D) && direction == 1)
            {
                sound_player.WalkInstance.Stop();
                player_idle_animation();
            }
            else if (ks.IsKeyDown(Keys.LeftShift) == true) sound_player.WalkInstance.Stop();


            // รีเซ็ตตำแหน่ง Player เมื่อกดปุ่ม R
            if (ks.IsKeyDown(Keys.R))
            {
                UI_stamina.stamina += 25;
            }
            old_ks = ks;
        }
        private void player_idle_animation()
        {
            // ถ้า Player หันไปทางซ้าย (direction == 0)
            if (direction == 0)
            {
                if (delayFrames <= 0)
                {
                    frameIndex++;
                    if (frameIndex >= 4) frameIndex = 0;  // วนลูปเฟรม
                    playerRec.X = frameIndex * frameWidth;
                    playerRec.Y = 0;  // แถวที่ 1 (ยืนหันซ้าย)
                    delayFrames = 0.18f;
                }
            }
            // ถ้า Player หันไปทางขวา (direction == 1)
            else if (direction == 1)
            {
                if (delayFrames <= 0)
                {
                    frameIndex++;
                    if (frameIndex >= 4) frameIndex = 0;  // วนลูปเฟรม
                    playerRec.X = frameIndex * frameWidth;
                    playerRec.Y = frameHeight * 2;  // แถวที่ 3 (ยืนหันขวา)
                    delayFrames = 0.18f;
                }
            }
        }
        private void player_animation()
        {
            if (delayFrames <= 0)
            {
                frameIndex++;
                if (frameIndex >= maxFrames) frameIndex = 0;
                int actualoffsetX = offsetX + (frameIndex * frameWidth);

                playerRec.X = actualoffsetX;
                playerRec.Y = frameHeight * direct;

                delayFrames = 0.18f;
            }
        }
        private void player_run_animation()
        {
            
            if (delayFramesRun <= 0)
            {              
                frameIndexRun++;
                if (frameIndexRun >= maxFrames) frameIndexRun = 0;
                int actualoffsetX = offsetX + (frameIndexRun * frameRunWidth);

                playerRecRun.X = actualoffsetX;
                playerRecRun.Y = frameRunHeight * directRun;

                delayFramesRun = 0.18f;
            }
        }
        public void player_die_animation()
        {
            
            if (delayFramesDie <= 0)
            {
                frameIndexDie++;
                if (frameIndexDie >= maxFrames)
                {
                    frameIndexDie = 3;
                    isDeath = false;
                }
                int actualoffsetX = offsetX + (frameIndexDie * frameDieWidth);

                playerRecDie.X = actualoffsetX;
                playerRecDie.Y = frameDieHeight * direction;

                delayFramesDie = 0.18f;
                
            }
        }
        private void ReduceUIstamina()
        {
            //ลดค่า UIspeed (ความกว้างของ uitexture2) ลงตามเวลาที่ใช้ไป
            UI_stamina.stamina -= 1f; // ปรับลดตามต้องการ
            if (UI_stamina.stamina < 0) UI_stamina.stamina = 0; // ไม่ให้ต่ำกว่า 0
        }

        public void paused(int frameWidth, int frameHeight)
        {
            this.playerRec.X = frameWidth;
            this.playerRec.Y = frameHeight;
        }

        public void ResetPosition()
        {
            player_pos = new Vector2(500, 535);
        }
    }
}
