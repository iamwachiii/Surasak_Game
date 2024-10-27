using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Audio;
using System.Reflection.Metadata;

namespace SK_03
{
    public class Killer : Sprite
    {
        public float speed;
        private float valueSpeed = 12f;
        private int stop = 0;
        private Player player;
        private int frameWidth, frameHeight;
        private int currentFrame; // เฟรมปัจจุบัน
        private int totalFrames; // จำนวนเฟรมทั้งหมดในแต่ละแถว
        private float animationTimer;
        private float animationInterval = 0.18f; // ระยะเวลาในการเปลี่ยนเฟรม
        private int animationRow; // แถวของอนิเมชั่น

        private int frameAtkWidth, frameAtkHeight;
        private int currentAtkFrame; // เฟรมปัจจุบัน
        private int totalAtkFrames; // จำนวนเฟรมทั้งหมดในแต่ละแถว
        private float animationAtkTimer;
        private float animationAtkInterval = 0.15f; // ระยะเวลาในการเปลี่ยนเฟรม
        private int animationAtkRow; // แถวของอนิเมชั่น

        public Rectangle killerRec;
        public Rectangle killerRecAtk;
        public Rectangle killerHitRec;
        public Vector2 killer_pos;
        public Vector2 killer_pos_atk;

        private float chaseRange = 1000f;
        private float distanceToPlayer;
        private Random r = new Random();
        private float outOfRangeTime = 0f;

        private int minBoundary;
        private int maxBoundary;
        private int outRange = 400;

        //private int escapeDistance; // ระยะทางที่ Killer จะออกจากระยะไล่ล่า

        private float returnTimer = 0f; // ตัวจับเวลาสำหรับ return
        private float escapeTimer = 0f; // ตัวจับเวลาสำหรับ escape
        private float delayDuration = 1f; // เวลาหน่วง 2 วินาที
        public float killerAttack = 0f;
        private int lastDirection;
        private bool timeDelay;

        private int[] distances = { 500, 600, 700 };
        private int moveDistance = 500;

        public string killer_state; // Seek(), Chase(), Searh(), Escape(), Event[i]() 
        public int mainEvents;
        public bool isMainEvents = true;

        public int searchDistance_1, searchDistance_2, searchDistance_3;
        private bool breakDirect;
        private int escapeDirect;
        public int search_state; // 0 = search, 1 = retrun, 2 = escape, 3 = break
        public bool removeKiller;

        public int direction;// ตัวแปรเก็บค่าทิศทาง 0 = ซ้าย, 1 = ขวา
        private bool wasSpaceKeyPressed = false; // เก็บสถานะการกดปุ่ม Space ก่อนหน้านี้
        private bool isPaused = false; // เก็บสถานะการหยุดของ Killer

        private KeyboardState ks, old_ks;
        private Game1 game;
        public bool isAttack;

        public Killer(Texture2D texture, Texture2D textureAtk, Player player, Game1 game, SoundEffect jumpScareSound)
        {
            mainEvents = 1;
            this.game = game;
            this.player = player;
            speed = valueSpeed;
            SetSpawnKiller();
            

            //sound_JumpScare1 = jumpScareSound; // กำหนดค่าให้กับตัวแปร sound_JumpScare1

            frameWidth = texture.Width / 4; // แบ่งเฟรมเป็น 4 คอลัมน์
            frameHeight = texture.Height / 4; // แบ่งเฟรมเป็น 4 แถว
            currentFrame = 0; // เริ่มที่เฟรมแรก
            totalFrames = 4; // จำนวนเฟรมต่อแถว
            animationTimer = 0f;
            animationRow = 0; // เริ่มต้นจากแถวที่ 1

            frameAtkWidth = textureAtk.Width / 4; 
            frameAtkHeight = textureAtk.Height / 2; 
            currentAtkFrame = 0; // เริ่มที่เฟรมแรก
            animationAtkTimer = 0f;
            animationAtkRow = 0; // เริ่มต้นจากแถวที่ 1

            killerRec = new Rectangle(0, 0, frameWidth, frameHeight);
            killerRecAtk = new Rectangle(0, 0, frameAtkWidth, frameAtkHeight);
            this.game = game;
            killer_state = "Seek";
            ks = Keyboard.GetState();
           
        }
        public void SetSpawnKiller()
        {
            // กำหนดขอบเขตการสุ่มเกิด
            minBoundary = 0 - outRange; //ขอบจอทางซ้าย
            maxBoundary = game.bg_width + outRange; // ขอบจอทางขวา
            int minDistance = 2000;
            int maxDistance = 3000; // สามารถปรับได้ตามต้องการ

            // คำนวณตำแหน่งของ Killer ให้อยู่ในช่วงขอบเขตที่กำหนดและห่างจาก Player
            int offset = r.Next(minDistance, maxDistance);
            int startX;

            // ตรวจสอบเพื่อให้ตำแหน่งของ Killer ไม่เกินขอบเขตที่กำหนด
            if (player.player_pos.X - offset >= minBoundary)
            {
                // ถ้าสามารถให้ Killer อยู่ทางซ้ายของ Player ได้
                startX = (int)player.player_pos.X - offset;
                //Console.WriteLine("left " + startX);
            }
            else
            {
                // หากตำแหน่งทางซ้ายไม่อยู่ในขอบเขต ให้ตั้งตำแหน่งทางขวา
                startX = (int)player.player_pos.X + offset;
                //Console.WriteLine("right " + startX);

                // ตรวจสอบตำแหน่งทางขวาให้ไม่เกินขอบเขต
                if (startX > maxBoundary)
                {
                    startX = maxBoundary;
                }
                else if (startX < minBoundary)
                {
                    startX = minBoundary;
                }
            }

            // ค่าตำแหน่ง X ของ Killer
            killer_pos = new Vector2(startX, 250);
        }

        public void SetKillerChase()
        {
            if (player.direction == 0)
            {
                killer_pos.X = game.bg_width + 500;
            }
            else if (player.direction == 1)
            {
                killer_pos.X = 0 - 500;
            }

        }
        public override void Update(GameTime gameTime)
        {
            killerHitRec = new Rectangle((int)killer_pos.X, (int)killer_pos.Y, frameWidth, frameHeight);
            outOfRangeTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            StopKiller();


            float distance = Vector2.Distance(killer_pos, player.player_pos);
            if (distance <= 2000 && (killer_state != "Search" || killer_state != "Escape") && removeKiller == false)
            {
                killer_state = "Chase";              
            }

            
            SearchPlayer(gameTime);

            if (killer_state == "Chase")
            {
                ChasePlayer(gameTime);
                //Console.Write(".");
            }

            if (killerHitRec.Intersects(player.playerHitRec) && player.player_state == "Alive")
            {
                killerAttack += (float)gameTime.ElapsedGameTime.TotalSeconds;
                //speed = stop;


                    isAttack = true;
                    killer_animation_attack(gameTime);

                    if (killerAttack >= 0.9f)
                    {
                        //player.player_state = "Death";
                        player.isDeath = true;                     
                    }
                    //else delayKiller = true;

                //Console.WriteLine("attack = " + killerAttack);
                
            }
            else
            {
                isAttack = false;
            }
            //Check_var();


            base.Update(gameTime);
        }

        private void killer_animation(GameTime gameTime)
        {
            // อัปเดตตัวนับเวลาอนิเมชั่น
            animationTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer >= animationInterval)
            {
                // เปลี่ยนเฟรมเมื่อครบเวลา
                currentFrame++;
                if (currentFrame >= totalFrames)
                {
                    currentFrame = 0;
                }
                animationTimer = 0f;
            }

            if (direction == 0) // ถ้า Killer ไล่จากทางซ้าย
            {
                // ใช้แถวที่ 3 และ 4
                animationRow = 1;
            }
            else if (direction == 1) // ถ้า Killer ไล่จากทางขวา
            {
                // ใช้แถวที่ 1 และ 2
                animationRow = 3;
            }

            if ((timeDelay == true|| player.player_state == "Death")  && direction == 0)
            {
                animationRow = 0;
            }
            else if ((timeDelay == true || player.player_state == "Death") && direction == 1)
            {
                animationRow = 2;
            }

            if (player.player_state == "Death") speed = stop;

            // อัปเดต Rectangle ของอนิเมชั่นเพื่อแสดงเฟรมที่ถูกต้อง
            killerRec = new Rectangle(currentFrame * frameWidth, animationRow * frameHeight, frameWidth, frameHeight);
        }
        private void killer_animation_attack(GameTime gameTime)
        {
            // อัปเดตตัวนับเวลาอนิเมชั่น
            int y = 310;
            animationAtkTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (animationAtkTimer >= animationAtkInterval)
            {
                // เปลี่ยนเฟรมเมื่อครบเวลา
                currentAtkFrame++;
                if (currentAtkFrame >= totalFrames)
                {
                    currentAtkFrame = 0;
                }
                animationAtkTimer = 0f;
            }

            if (direction == 0) // ถ้า Killer ไล่จากทางซ้าย
            {
                // ใช้แถวที่ 3 และ 4
                animationAtkRow = 1;
                killer_pos_atk = new Vector2(killer_pos.X - 140, y);

            }
            else if (direction == 1) // ถ้า Killer ไล่จากทางขวา
            {
                // ใช้แถวที่ 1 และ 2
                animationAtkRow = 0;
                killer_pos_atk = new Vector2(killer_pos.X + 90 , y);
            }

            // อัปเดต Rectangle ของอนิเมชั่นเพื่อแสดงเฟรมที่ถูกต้อง
            killerRecAtk = new Rectangle(currentAtkFrame * frameAtkWidth, animationAtkRow * frameAtkHeight, frameAtkWidth, frameAtkHeight);
        }
        private void ChasePlayer(GameTime gameTime)
        {
            
            Vector2 directionVector = new Vector2(player.player_pos.X - killer_pos.X, 0);

            if (directionVector.X != 0)
            {
                directionVector.Normalize();
            }

            lastDirection = direction;

            if (directionVector.X < 0)
            {
                direction = 0; // ซ้าย
                animationRow = 2;
            }
            else
            {
                direction = 1; // ขวา
                animationRow = 0;
            }

            if (lastDirection != direction)
            {
                killerAttack = 0f; // รีเซ็ตค่า killerAttack เมื่อเปลี่ยนทิศทาง
            }


            /*if (isPaused == false)
            {
                killer_pos.X += directionVector.X * speed;
                game.sound.Killer_ChaseInstance.Play();
            }*/
       
            killer_animation(gameTime);

            //Console.WriteLine("C = ture");
        }
        private void SearchPlayer(GameTime gameTime)
        {
            if (player.player_state == "Alive") search_state = 3;

            if ((player.player_state == "Hide" && killer_state != "Seek"))
            {

                killer_state = "Search";
                if (killer_state == "Search")
                {
                    int moveDistance = distances[r.Next(distances.Length)];

                    if (search_state == 3)
                    {
                        search_state = 0;
                    }

                    if (direction == 1) searchDistance_1 = (int)player.player_pos.X + moveDistance;
                    else if (direction == 0) searchDistance_1 = (int)player.player_pos.X - moveDistance;

                    if (search_state == 0)
                    {
                        if (direction == 1 && killer_pos.X <= searchDistance_1)
                        {
                            killer_pos.X += speed;
                            killer_animation(gameTime);
                            if (killer_pos.X > searchDistance_1)
                            {
                                killer_pos.X = searchDistance_1;                                
                                search_state = 1;
                                returnTimer = 0f;
                                timeDelay = true;                               
                            }

                        }
                        else if (direction == 0 && killer_pos.X >= searchDistance_1)
                        {
                            killer_pos.X -= speed;
                            killer_animation(gameTime);
                            if (killer_pos.X < searchDistance_1)
                            {
                                killer_pos.X = searchDistance_1;
                                search_state = 1;
                                returnTimer = 0f;
                                timeDelay = true;                              
                            }
                        }
                    }

                    else if (search_state == 1)
                    {
                        returnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (timeDelay == true) killer_animation(gameTime);
                        if (returnTimer >= delayDuration)
                        {
                            timeDelay = false;
                            int returnDistance = distances[r.Next(distances.Length)];
                            if (direction == 1 && breakDirect == false) searchDistance_2 = (int)player.player_pos.X - returnDistance;
                            else if (direction == 0 && breakDirect == false) searchDistance_2 = (int)player.player_pos.X + returnDistance;
                            //Console.Write("tt");


                            if (killer_pos.X >= searchDistance_2)
                            {
                                if (direction == 1)
                                {
                                    direction = 0;
                                    breakDirect = true;
                                }
                                killer_pos.X -= speed;
                                killer_animation(gameTime);

                                if (killer_pos.X < searchDistance_2)
                                {

                                    killer_pos.X = searchDistance_2;
                                    search_state = 2;
                                    breakDirect = false;
                                    escapeDirect = 1;
                                    escapeTimer = 0f;
                                    timeDelay = true;
                                }

                            }

                            else if (killer_pos.X <= searchDistance_2)
                            {
                                if (direction == 0)
                                {
                                    direction = 1;
                                    breakDirect = true;
                                }
                                killer_pos.X += speed;
                                killer_animation(gameTime);

                                if (killer_pos.X > searchDistance_2)
                                {
                                    killer_pos.X = searchDistance_2;
                                    search_state = 2;
                                    breakDirect = false;
                                    escapeDirect = 0;
                                    escapeTimer = 0f;
                                    timeDelay = true;
                                }
                            }
                        }
                    }

                    else if (search_state == 2)
                    {
                        escapeTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (timeDelay == true) killer_animation(gameTime);
                        if (escapeTimer >= delayDuration)
                        {
                            timeDelay = false;
                            if (escapeDirect == 0)
                            {
                                if (killer_pos.X > 0 - outRange)
                                {
                                    direction = 0;
                                    killer_pos.X -= speed;
                                    killer_animation(gameTime);
                                    if (killer_pos.X <= 0 - outRange)
                                    {
                                        Console.WriteLine("killer gone");
                                        search_state = 3;
                                        killer_state = "Seek";
                                        removeKiller = true;

                                    }
                                }

                            }
                            else if (escapeDirect == 1)
                            {
                                if (killer_pos.X < game.bg_width + outRange)
                                {
                                    direction = 1;
                                    killer_pos.X += speed;
                                    killer_animation(gameTime);
                                    if (killer_pos.X >= game.bg_width + outRange)
                                    {
                                        Console.WriteLine("killer gone");
                                        search_state = 3;
                                        killer_state = "Seek";
                                        removeKiller = true;


                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void StopKiller()
        {
            KeyboardState ks;
            ks = Keyboard.GetState();
            // ตรวจสอบการกดของปุ่ม Space จากสถานะเดิม (wasSpaceKeyPressed)
            if (ks.IsKeyDown(Keys.P) && !wasSpaceKeyPressed)
            {
                isPaused = !isPaused; // เมื่อกด Space จะสลับสถานะการหยุดของ Killer           
                if (isPaused) { speed = stop; }// ถ้าหยุด ให้ speed เป็น 0, ถ้าไม่หยุด ให้คืนค่า speed
                else { speed = valueSpeed; }
                Console.WriteLine("key space is Pressed, isPaused: " + isPaused);
            }
            wasSpaceKeyPressed = ks.IsKeyDown(Keys.P);
        }
        public void Check_var()
        {
            KeyboardState ks;
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.N) == true && old_ks.IsKeyUp(Keys.N))
            {
                Console.WriteLine("");
                Console.WriteLine("killer_state = " + killer_state);
                Console.WriteLine("player_state = " + player.player_state);
                Console.WriteLine("");

            }
            old_ks = ks;
        }
    }
}


