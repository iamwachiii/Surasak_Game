using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SK_03.All_Objects;
using SK_03.All_Objects.All_keys;
using SK_03.Components;
using Penumbra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK_03.All_Objects.All_Friend_Hearts;
using SK_03.CutScenes;
using SK_03.Sound;

namespace SK_03
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //All Scenes
        public Living_room living_room;
        public Front_house front_house;
        public Rest_room rest_room;
        public Hallway hallway;
        public Kitchen_room kitchen_room;
        public Room_04 room_04;
        public Basement basement;
        public Room_02 room_02;
        public Room_01 room_01;
        public Hallway_2 hallway_2;
        public Room_03 room_03;
        public Balcony balcony;
        public Bed_room bed_Room;
        public Main_menu main_menu;
        public Begin begin;
        public FrontHouse_Scenes frontHouse_Scenes;
        public Ending_01 ending_01;
        public Ending_02 ending_02;
        public Ending_03 ending_03;
        public Ending_04 ending_04;


        public SceneManage currentScene;

        private Inventory inventory;
        private Inventory_UI inventory_UI;
        public bool isInventoryVisible = false;
        private Item_Detail_UI item_Detail_UI;
        private Texture2D CersorTexture;
        private Vector2 mouse_pos;
        public Rectangle mouseHitRec;

        SpriteFont font;
        Texture2D inventoryTexture;

        public List<Component> components;
        public Texture2D bgTexture;
        public int bg_width;
        public int bg_height;
        private Texture2D settingTexture;
        private Vector2 setting_pos = new Vector2(910, 0);
        private Rectangle settingHitRec;
        private bool settingIsHit = false;
        private bool settingOn = false;
        public bool isEvent_1 = false;
        private bool isEventsActive = false;

        private Guide guide;
        private Texture2D guideTexture;
        private Vector2 guide_pos;

        public Player player;
        private Texture2D playerTexture, playerRunTexture, playerDieTexture;

        public Locker locker;
        public Texture2D lockerTexture;

        public Note note;
        public Texture2D noteTexture;
        public Texture2D noteDetailTexture;

        public Killer killer;
        private Texture2D killerTexture;
        private Texture2D killerTextureAtk;

        private UI_Sanity UI_sanity;
        private Texture2D UI_sanityTexture;

        private UI_Stamina UI_stamina;
        private Texture2D UI_staminaTexture;

        //All keys
        public Room03_key room03_Key;
        public Texture2D room03_KeyTexture;
        public Hallway_key hallway_Key;
        public Texture2D hallway_KeyTexture;
        public Basement_key basement_Key;
        public Texture2D basement_KeyTexure;
        public Balcony_key balcony_Key;
        public Texture2D balcony_KeyTexture;
        public Bedroom_Key bedroom_Key;
        public Texture2D bedroom_KeyTexture;
        public Cabinet_key cabinet_Key;
        public Texture2D cabinet_KeyTexture;
        public Hairpin hairpin;
        public Texture2D hairpinTexture;

        private Texture2D sanityIcon;
        private Texture2D staminaIcon;
        //All Friend Hearts
        public Phakin_Heart phakin_Heart;
        public Texture2D phakin_HeartTexture;
        public Arthid_Heart arthid_Heart;
        public Texture2D arthid_HeartTexture;
        public Paenghom_Heart paenghom_Heart;
        public Texture2D paenghom_HeartTexture;
        public Waewdao_Heart waewdao_Heart;
        public Texture2D waewdao_HeartTexture;

        //Camera and keyboard
        public Vector2 cameraPos = Vector2.Zero;
        public Vector2 bg_pos = Vector2.Zero;
        private KeyboardState ks, old_ks;
        private MouseState ms, old_ms;
        public bool gameOver;

        private sound_Background backgroundSoundManager;
        private int killer_spawn_chance;
        public string switch_Scenes;

        public PenumbraComponent _penumbra;
        private PointLight _playerLight;
        private Spotlight _flashLight;
        private bool lightsOn = true;
        private SoundEffect sound_JumpScare1;
        //public bool gameReset = true;
        public Color transparentColor;
        public Color transparentColorUI;
        public float percentage;
        public float percentUI;
        

        private SpriteBatch uiSpriteBatch;
        public AllSound sound;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _penumbra = new PenumbraComponent(this);
            Components.Add(_penumbra);
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here         
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();

            uiSpriteBatch = new SpriteBatch(GraphicsDevice);

            base.Initialize();
        }
        private void AllContent()
        {
            // TODO: use this.Content to load your game content here
            CersorTexture = Content.Load<Texture2D>("Cersor");
            guideTexture = Content.Load<Texture2D>("menu");

            UI_sanityTexture = Content.Load<Texture2D>("HealthBar_thumb");
            UI_staminaTexture = Content.Load<Texture2D>("HealthBar_thumb2");
            noteTexture = Content.Load<Texture2D>("Note");
            noteDetailTexture = Content.Load<Texture2D>("Text");
            font = Content.Load<SpriteFont>("Font");
            inventoryTexture = Content.Load<Texture2D>("Inventory");
            playerTexture = Content.Load<Texture2D>("player_surasak");
            playerRunTexture = Content.Load<Texture2D>("player_surasak_Run");
            playerDieTexture = Content.Load<Texture2D>("player_died");
            lockerTexture = Content.Load<Texture2D>("Tiles_Long_Living_room"); //locker Living_Room
            killerTexture = Content.Load<Texture2D>("Killer");
            killerTextureAtk = Content.Load<Texture2D>("Killer_Attact");

            sound_JumpScare1 = Content.Load<SoundEffect>("sound_JumpScare1");
            //All keys content
            room03_KeyTexture = Content.Load<Texture2D>("Key_Tile_Showmap");
            hallway_KeyTexture = Content.Load<Texture2D>("Key_Tile_Showmap");
            basement_KeyTexure = Content.Load<Texture2D>("Key_Tile_Showmap");
            balcony_KeyTexture = Content.Load<Texture2D>("Key_Tile_Showmap");
            bedroom_KeyTexture = Content.Load<Texture2D>("Key_Tile_Showmap");
            hairpinTexture = Content.Load<Texture2D>("Key_Tile_Showmap");
            cabinet_KeyTexture = Content.Load<Texture2D>("Key_Tile_Showmap");

            //All Freind Hearts content
            phakin_HeartTexture = Content.Load<Texture2D>("Heart_Tiles_Showmap");
            paenghom_HeartTexture = Content.Load<Texture2D>("Heart_Tiles_Showmap");
            arthid_HeartTexture = Content.Load<Texture2D>("Heart_Tiles_Showmap");
            waewdao_HeartTexture = Content.Load<Texture2D>("Heart_Tiles_Showmap");

            sanityIcon = Content.Load<Texture2D>("SataminaAndSanity");
            staminaIcon = Content.Load<Texture2D>("SataminaAndSanity");

            room03_Key = new Room03_key(room03_KeyTexture);
            hallway_Key = new Hallway_key(hallway_KeyTexture);
            basement_Key = new Basement_key(basement_KeyTexure);
            balcony_Key = new Balcony_key(balcony_KeyTexture);
            bedroom_Key = new Bedroom_Key(bedroom_KeyTexture);
            cabinet_Key = new Cabinet_key(cabinet_KeyTexture);
            hairpin = new Hairpin(hairpinTexture);
            phakin_Heart = new Phakin_Heart(phakin_HeartTexture);
            paenghom_Heart = new Paenghom_Heart(paenghom_HeartTexture);
            arthid_Heart = new Arthid_Heart(arthid_HeartTexture);
            waewdao_Heart = new Waewdao_Heart(waewdao_HeartTexture);

            guide = new Guide(guideTexture);
            note = new Note(noteTexture);
            inventory = new Inventory();
            item_Detail_UI = new Item_Detail_UI();

            //inventory.AddItem(new Item("Note", noteTexture, note.noteRec, noteDetailTexture));
            //inventory.AddItem(new Item("Kitchen_room_key", kitchen_room_KeyTexture, kitchen_room_Key.Kitchen_room_KeyRec,  noteDetailTexture));
            inventory_UI = new Inventory_UI(inventory, font, guideTexture, inventoryTexture, new Vector2(550, 150), this);
            sound = new AllSound(this);

            UI_stamina = new UI_Stamina(UI_staminaTexture);
            locker = new Locker(lockerTexture);
            player = new Player(playerTexture, playerRunTexture, playerDieTexture, UI_stamina, this);
            killer = new Killer(killerTexture,killerTextureAtk, player, this, sound_JumpScare1);
            UI_sanity = new UI_Sanity(UI_sanityTexture, player, killer);
            backgroundSoundManager = new sound_Background(this);

            // โหลดเนื้อหาอื่นๆ สำหรับฉาก
            spriteBatch = new SpriteBatch(GraphicsDevice);
            front_house = new Front_house(this, new EventHandler(GameplayScreenEvent));
            living_room = new Living_room(this, new EventHandler(GameplayScreenEvent));
            rest_room = new Rest_room(this, new EventHandler(GameplayScreenEvent));
            hallway = new Hallway(this, new EventHandler(GameplayScreenEvent));
            kitchen_room = new Kitchen_room(this, new EventHandler(GameplayScreenEvent));
            room_04 = new Room_04(this, new EventHandler(GameplayScreenEvent));
            basement = new Basement(this, new EventHandler(GameplayScreenEvent));
            room_02 = new Room_02(this, new EventHandler(GameplayScreenEvent));
            room_01 = new Room_01(this, new EventHandler(GameplayScreenEvent));
            hallway_2 = new Hallway_2(this, new EventHandler(GameplayScreenEvent));
            room_03 = new Room_03(this, new EventHandler(GameplayScreenEvent));
            balcony = new Balcony(this, new EventHandler(GameplayScreenEvent));
            bed_Room = new Bed_room(this, new EventHandler(GameplayScreenEvent));
            main_menu = new Main_menu(this, new EventHandler(GameplayScreenEvent));
            begin = new Begin(this, new EventHandler(GameplayScreenEvent));
            frontHouse_Scenes = new FrontHouse_Scenes(this, new EventHandler(GameplayScreenEvent));
            ending_01 = new Ending_01(this, new EventHandler(GameplayScreenEvent));
            ending_02 = new Ending_02(this, new EventHandler(GameplayScreenEvent));
            ending_03 = new Ending_03(this, new EventHandler(GameplayScreenEvent));
            ending_04 = new Ending_04(this, new EventHandler(GameplayScreenEvent));

            _playerLight = new PointLight
            {
                Scale = new Vector2(400f),
                Color = Color.White,
                Intensity = 1f,
                ShadowType = ShadowType.Solid,
            };
            _penumbra.Lights.Add(_playerLight);

            _flashLight = new Spotlight
            {
                Scale = new Vector2(1500f),
                Color = Color.YellowGreen,
                Intensity = 2f,
                ShadowType = ShadowType.Occluded,
                ConeDecay = 0.8f,
                Rotation = 0f
            };
            _penumbra.Lights.Add(_flashLight);

            _penumbra.AmbientColor = new Color(251, 250, 245, 255);

            UpdateLightPositions();
        }
        protected override void LoadContent()
        {
            AllContent();

            currentScene = room_02;

            components = new List<Component>() { player, UI_sanity, UI_stamina };

            if (currentScene == main_menu) gameOver = true;
         
        }
        private void SetSpawnKiller()
        {
            
            if (killer.mainEvents == 1 || killer.mainEvents == 2)
            {
                killer.isMainEvents = true;
            }
            else killer.isMainEvents = false;

            if (killer.isMainEvents == false)
            {
                if (killer.killer_state == "Seek" && killer.isMainEvents == false)
                {
                    Random r = new Random();
                    killer_spawn_chance = r.Next(0, 10);
                    Console.WriteLine("ran chance = " + killer_spawn_chance);
                }

                if (killer.killer_state == "Seek" && killer.killer_state != "Chase" && (killer_spawn_chance == 1 || killer_spawn_chance == 2 || killer_spawn_chance == 3))
                {
                    killer.removeKiller = false;
                    components.Add(killer);
                    killer.SetSpawnKiller();
                    sound.JumpScare1Instance.Play();
                    Console.WriteLine("meet killer = ");
                }
                else killer_spawn_chance = 0;
            }

            //main events = 1
            else if (killer.isMainEvents == true && currentScene == rest_room) 
            {
                if (killer.killer_state == "Seek" && killer.killer_state != "Chase")
                {
                    killer.removeKiller = false;
                    components.Add(killer);
                    killer.SetSpawnKiller();
                    sound.JumpScare1Instance.Play();
                    Console.WriteLine("killer found = ");
                }
            }
            
        }
        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            currentScene = (SceneManage)obj;
            SetPlayerAndKiller();
            //aConsole.WriteLine("Scene" + currentScene);
            percentage = 0;
            killer.killerAttack = 0;
            //killer.delayKiller = true;

            SetSpawnKiller();

            if (killer.killer_state == "Chase")
            {
                killer.SetKillerChase();
            }

        }
        private void SetPlayerAndKiller()
        {
            SetValueBackground();

            switch (switch_Scenes)
            {
                case "GoBasement":
                    player.player_pos = new Vector2(3300, 535);
                    player.delayDoor = 0;
                    break;
                case "GoKitchen_room":
                    player.player_pos = new Vector2(1910, 535);
                    player.delayDoor = 0;
                    break;
                case "GoHallway":
                    player.player_pos = new Vector2(2745, 535);    
                    player.delayDoor = 0;
                    break;
                case "Room_01ToHallway_2":
                    player.player_pos = new Vector2(2600, 535);
                    player.delayDoor = 0;
                    break;
                case "GoHallway_2":
                    player.player_pos = new Vector2(720, 535);
                    player.delayDoor = 0;
                    break;
                case "GoBed_room":
                    player.player_pos = new Vector2(0, 535);
                    player.delayDoor = 0;
                    break;
                case "BedToHallway_2":
                    player.player_pos = new Vector2(1250, 535);
                    player.delayDoor = 0;
                    break;
                case "GoRoom_03":
                    player.player_pos = new Vector2(900, 535);
                    player.delayDoor = 0;
                    break;
                case "Room_03ToBed":
                    player.player_pos = new Vector2(1395, 535);
                    player.delayDoor = 0;
                    break;
                case "GoRoom_01":
                    player.player_pos = new Vector2(0, 535);
                    player.delayDoor = 0;
                    break;
                default:
                    if (player.direction == 0)
                    {
                        player.player_pos = new Vector2(bg_width, 535);
                        //Console.WriteLine("right");
                    }

                    else if (player.direction == 1)
                    {
                        player.player_pos = new Vector2(0, 535);
                        //Console.WriteLine("left");
                    }
                    switch_Scenes = "default";
                    break;
            }                              
        }
        private void check_var()
        {
            if ((ks.IsKeyDown(Keys.H) == true && old_ks.IsKeyUp(Keys.H)))
            {
                Console.WriteLine("___________________________________________________________");
                Console.WriteLine("killer_state = " + killer.killer_state);
                Console.WriteLine("player_state = " + player.player_state);
                //Console.WriteLine("player run = "+ player.isPlayerRun);
                Console.WriteLine("spawn chance = " + killer_spawn_chance);
                Console.WriteLine("direction = " + killer.direction);
                Console.WriteLine("SearchDistance_1 = " + killer.searchDistance_1);
                Console.WriteLine("search_state = " + killer.search_state);
                Console.WriteLine("");
                Console.WriteLine("SearchDistance_2 = " + killer.searchDistance_2);
                Console.WriteLine("killer_pos = " + killer.killer_pos);
                //Console.WriteLine("gameOver = " + gameOver);
                //Console.WriteLine("current Scene = " + currentScene);
                Console.WriteLine("killer speed = " + killer.speed);
                Console.WriteLine("main events = "+ killer.mainEvents);
                Console.WriteLine("bg_width = " + bg_width);
                Console.WriteLine("switch Scenes = "+ switch_Scenes);
                Console.WriteLine("isMainEvents = " + killer.isMainEvents);
                Console.WriteLine("isHitObj = "+ player.isHitObj);
                Console.WriteLine("attack = " + killer.killerAttack);
                //Console.WriteLine("gameReset = "+ gameReset);
                Console.WriteLine("");

            }
        }
        private void MainEvents()
        {
            //main events = 2
            if (isEventsActive == true && killer.mainEvents == 2)
            {
                if (killer.killer_state == "Seek" && killer.killer_state != "Chase")
                {
                    killer.removeKiller = false;
                    components.Add(killer);
                    killer.SetSpawnKiller();
                    sound.JumpScare1Instance.Play();
                    isEventsActive = false;
                    Console.WriteLine("killer found = ");
                }
            }
            //main events = 3
            else if (isEventsActive == true && killer.mainEvents == 3)
            {
                if (killer.killer_state == "Seek" && killer.killer_state != "Chase")
                {
                    killer.removeKiller = false;
                    components.Add(killer);
                    killer.SetSpawnKiller();
                    sound.JumpScare1Instance.Play();
                    isEventsActive = false;
                    Console.WriteLine("killer found = ");
                }
            }
            //main events = 4
            else if (isEventsActive == true && killer.mainEvents == 4)
            {
                if (killer.killer_state == "Seek" && killer.killer_state != "Chase")
                {
                    killer.removeKiller = false;
                    components.Add(killer);
                    killer.SetSpawnKiller();
                    sound.JumpScare1Instance.Play();
                    isEventsActive = false;
                    Console.WriteLine("killer found = ");
                }
            }
            //main events = 5
            else if (isEventsActive == true && killer.mainEvents == 5)
            {
                if (killer.killer_state == "Seek" && killer.killer_state != "Chase")
                {
                    killer.removeKiller = false;
                    components.Add(killer);
                    killer.SetSpawnKiller();
                    sound.JumpScare1Instance.Play();
                    isEventsActive = false;
                    Console.WriteLine("killer found = ");
                }
            }
        }
        protected override void Update(GameTime gameTime)
        {
            MainEvents();
            if (player.player_state == "Death" ) gameOver = true;
            //Console.WriteLine("h = "+ player.isHitObj);
            ms = Mouse.GetState();
            ks = Keyboard.GetState();
            mouse_pos = new Vector2(ms.X, ms.Y);
            mouseHitRec = new Rectangle((int)mouse_pos.X, (int)mouse_pos.Y, CersorTexture.Width, CersorTexture.Height);
            //Console.WriteLine("settingOn = " + settingOn);
            //Console.WriteLine("cuurent = " + currentScene);
            check_var();
            UpdateLightPositions();
            //Console.WriteLine("isHitObjb = " + player.isHitObj);

            if (ks.IsKeyDown(Keys.K) == true && old_ks.IsKeyUp(Keys.K))
            {
                killer.killer_state = "Seek";
                killer.removeKiller = true;
                Console.WriteLine("The World!!");
            }

            if (currentScene == main_menu) settingOn = false;
            else settingOn = true;


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { Exit(); }

           /* if (mouseHitRec.Intersects(settingHitRec))
            {
                settingIsHit = true;

                if (ms.LeftButton == ButtonState.Pressed && old_ms.LeftButton != ButtonState.Pressed)
                {
                    //Console.WriteLine("llll");
                    currentScene = main_menu;
                    settingOn = false;
                    gameOver = true;
                    killer.killer_state = "Seek";
                    killer.isMainEvents = true;
                    //gameReset = true;
                }
            }
            else
            {
                settingIsHit = false;
            }*/


            if (ms.RightButton == ButtonState.Pressed && old_ms.RightButton != ButtonState.Pressed)
            {
                Console.WriteLine("this_pos = " + mouse_pos);
            }
            old_ms = ms;

            
            //Console.WriteLine("persen = "+ percentUI);
            if (gameOver == false)
            {
                HandlePlayerActions();
                if (ks.IsKeyDown(Keys.B) && old_ks.IsKeyUp(Keys.B))
                {

                    sound.Open_bagInstance.Play();
                    isInventoryVisible = !isInventoryVisible;
                    if (isInventoryVisible == true) percentUI = 0;
                    else if (isInventoryVisible == false) percentUI = 1;
                    Console.WriteLine("Draw Inventory");
                    // เมื่อปิด Inventory UI ให้ปิดการแสดงรายละเอียดของไอเทมทั้งหมด
                    if (!isInventoryVisible)
                    {
                        foreach (var item in inventory.Items)
                        {
                            item.IsDetailVisible = false; // ปิดการแสดงรายละเอียด
                        }
                    }
                }
            }
               

            if (isInventoryVisible == true)
            {
                inventory_UI.HandleInput(Mouse.GetState());
            }
            // อัปเดตการทำงานของ ItemDetailUI
            item_Detail_UI.Draw(spriteBatch); // วาดรายละเอียดไอเทม

            // เก็บสถานะการกดปุ่มในเฟรมก่อนหน้า
            old_ks = ks;
            currentScene.Update(gameTime);

            percentage += 0.01f;
            if (percentage > 1) percentage = 1;
            transparentColor = new Color(255, 255, 255) * percentage;

            if (isInventoryVisible == true)
            {
                percentUI += 0.05f;
                if (percentUI > 1) percentUI = 1;
                transparentColorUI = new Color(255, 255, 255) * percentUI;
            }
            else if (isInventoryVisible == false)
            {
                percentUI -= 0.05f;
                if (percentUI <= 0) percentUI = 0;
                transparentColorUI = new Color(255, 255, 255) * percentUI;
            }


            base.Update(gameTime);
        }
        public void UpdateLightPositions()
        {
            _penumbra.AmbientColor = new Color(251, 250, 245, 255);
            OpenFlash();
            // Update light states
            _playerLight.Enabled = lightsOn;
            _flashLight.Enabled = lightsOn;

            float playerWidth = player.frameWidth;
            _playerLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 2, player.frameHeight / 2);

            if (player.direction == 0) // หันขวา
            {
                _flashLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 4f, player.frameHeight / 1.5f);
            }
            else // หันซ้าย
            {
                _flashLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 4f, player.frameHeight / 1.5f);
            }

            _flashLight.Rotation = player.direction == 0 ? MathHelper.Pi : 0f;
        }
        public void UpdateLightRoom()
        {
            _penumbra.AmbientColor = new Color(251, 50, 245, 255);
            OpenFlash();
            // Update light states
            _playerLight.Enabled = lightsOn;
            _flashLight.Enabled = lightsOn;

            float playerWidth = player.frameWidth;
            _playerLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 2, player.frameHeight / 2);

            if (player.direction == 0) // หันขวา
            {
                _flashLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 4f, player.frameHeight / 1.5f);
            }
            else // หันซ้าย
            {
                _flashLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 4f, player.frameHeight / 1.5f);
            }

            _flashLight.Rotation = player.direction == 0 ? MathHelper.Pi : 0f;
        }
        public void UpdateLightBalcony()
        {
            _penumbra.AmbientColor = new Color(251, 255, 45, 255);
            OpenFlash();

            // Update light states
            _playerLight.Enabled = lightsOn;
            _flashLight.Enabled = lightsOn;

            float playerWidth = player.frameWidth;
            _playerLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 2, player.frameHeight / 2);

            if (player.direction == 0) // หันขวา
            {
                _flashLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 4f, player.frameHeight / 1.5f);
            }
            else // หันซ้าย
            {
                _flashLight.Position = player.player_pos - cameraPos + new Vector2(playerWidth / 4f, player.frameHeight / 1.5f);
            }

            _flashLight.Rotation = player.direction == 0 ? MathHelper.Pi : 0f;
        }
        private void OpenFlash()
        {
            if (ks.IsKeyDown(Keys.F) && old_ks.IsKeyUp(Keys.F))
            {
                lightsOn = !lightsOn;
                _playerLight.Enabled = lightsOn;
                _flashLight.Enabled = lightsOn;
                if (lightsOn) 
                sound.Open_lightInstance.Play();
                else
                sound.Cloase_lightInstance.Play();

            }
        }
        public void Update_components(GameTime gameTime)
        {


                for (int i = 0; i < components.Count; i++)
                {
                    components[i].Update(gameTime);
                    if (components[i] is Killer killer && killer.killer_state == "Seek" && killer.removeKiller == true)
                    {
                        components.RemoveAt(i);
                        i--;
                        this.killer.mainEvents = 0;
                        this.killer.isMainEvents = false;
                        Console.WriteLine("remove");
                        sound.Killer_ChaseInstance.Stop();
                        isEvent_1 = true;
                    }
                    else if (components[i] is Player player && player.player_state == "Death")
                    {
                        player.delayDie += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        player.player_die_animation();
                        if (player.delayDie >= 1f)
                        {
                            i--;
                            this.killer.mainEvents = 0;
                            this.killer.isMainEvents = false;
                            Console.WriteLine("player died");
                        }
                    }
                    
                }
            

            if (gameOver == true)
            {
                player.delayDie = 0;
                Console.WriteLine("stop");
            }
        }
        protected override void Draw(GameTime gameTime)
        {

            _penumbra.BeginDraw();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, _penumbra.Transform);

            // วาดฉากปัจจุบันและ background ที่สอดคล้องกัน
            Update_background();

            currentScene.Draw(spriteBatch);

            if (currentScene != main_menu && currentScene != begin && currentScene != frontHouse_Scenes
                && currentScene != ending_01 && currentScene != ending_02 && currentScene != ending_03 && currentScene != ending_04)
                

            Update_Draw();
            spriteBatch.End();

            _penumbra.Draw(gameTime);

            uiSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, _penumbra.Transform);
            DrawUI();
            uiSpriteBatch.End();

            spriteBatch.Begin();

            Draw_Inventory_UI();

            // วาด UI อื่นๆ
            Draw_UI();

            spriteBatch.Draw(CersorTexture, mouse_pos, Color.White);

            spriteBatch.End();

            // อัพเดทระบบเสียง (ถ้าจำเป็น)
            backgroundSoundManager.Update(gameTime);
        }
        private void DrawUI()
        {
            if (currentScene is Front_house frontHouse)
            {
                frontHouse.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Living_room living_Room)
            {
                living_Room.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Hallway hallway)
            {
                hallway.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Kitchen_room kitchen_Room)
            {
                kitchen_Room.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Basement basement)
            {
                basement.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Hallway_2 hallway_2)
            {
                hallway_2.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Bed_room bed_Room)
            {
                bed_Room.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Rest_room rest_room)
            {
                rest_room.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Balcony balcony)
            {
                balcony.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Room_01 room_01)
            {
                room_01.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Room_02 room_02)
            {
                room_02.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Room_03 room_03)
            {
                room_03.DrawUI(uiSpriteBatch);
            }
            if (currentScene is Room_04 room_04)
            {
                room_04.DrawUI(uiSpriteBatch);
            }
        }
        private void SetValueBackground()
        {
            // ตรวจสอบฉากปัจจุบันแล้วเปลี่ยนค่า bgTexture ตามฉากนั้น
            if (currentScene is Living_room)
            {
                bgTexture = living_room.living_roomTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = living_room.living_room_pos;

            }
            else if (currentScene is Front_house)
            {
                bgTexture = front_house.front_houseTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = front_house.front_house_pos;

            }
            else if (currentScene is Rest_room)
            {
                bgTexture = rest_room.rest_roomTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = rest_room.rest_room_pos;

            }
            else if (currentScene is Hallway)
            {
                bgTexture = hallway.hallwayTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = hallway.hallway_pos;

            }
            else if (currentScene is Kitchen_room)
            {
                bgTexture = kitchen_room.kitchen_roomTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = kitchen_room.kitchen_room_pos;
            }
            else if (currentScene is Room_04)
            {
                bgTexture = room_04.room_04Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = room_04.room_04_pos;
            }
            else if (currentScene is Basement)
            {
                bgTexture = basement.basementTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = basement.basement_pos;
            }
            else if (currentScene is Room_02)
            {
                bgTexture = room_02.room_02Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = room_02.room_02_pos;
            }
            else if (currentScene is Room_01)
            {
                bgTexture = room_01.room_01Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = room_01.room_01_pos;
            }
            else if (currentScene is Hallway_2)
            {
                bgTexture = hallway_2.hallway2Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = hallway_2.hallway2_pos;
            }
            else if (currentScene is Room_03)
            {
                bgTexture = room_03.room_03Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = room_03.room_03_pos;
            }
            else if (currentScene is Balcony)
            {
                bgTexture = balcony.balconyTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = balcony.balcony_pos;
            }
            else if (currentScene is Bed_room)
            {
                bgTexture = bed_Room.bed_roomTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = bed_Room.bed_room_pos;

            }
            else if (currentScene is Main_menu)
            {
                bgTexture = main_menu.main_menuTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = main_menu.main_menu_pos;
                player.paused(0, player.frameHeight * 3);

            }
            else if (currentScene is Begin)
            {
                bgTexture = begin.beginTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = begin.begin_pos;
                player.paused(0, player.frameHeight * 3);

            }
            else if (currentScene is FrontHouse_Scenes)
            {
                bgTexture = frontHouse_Scenes.frontHouse_ScenesTexture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = frontHouse_Scenes.frontHouse_Scenes_pos;
                player.paused(0, player.frameHeight * 3);

            }
            else if (currentScene is Ending_01)
            {
                bgTexture = ending_01.ending01_Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = ending_01.ending01_pos;
                player.paused(0, player.frameHeight * 3);

            }
            else if (currentScene is Ending_02)
            {
                bgTexture = ending_02.ending02_Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = ending_02.ending02_pos;
                player.paused(0, player.frameHeight * 3);

            }
            else if (currentScene is Ending_03)
            {
                bgTexture = ending_03.ending03_Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = ending_03.ending03_pos;
                player.paused(0, player.frameHeight * 3);

            }
            else if (currentScene is Ending_04)
            {
                bgTexture = ending_04.ending04_Texture;
                bg_width = bgTexture.Width;
                bg_height = bgTexture.Height;
                bg_pos = ending_04.ending04_pos;
                player.paused(0, player.frameHeight * 3);

            }

        }
        private void Update_background()
        {
            SetValueBackground();
            // Calculate the background position to cover the viewport
            Vector2 viewportSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Vector2 bgPos = bg_pos - cameraPos;

            // Draw the background in 4 positions to cover the viewport
            for (float y = bgPos.Y; y < bgPos.Y + viewportSize.Y + bg_height; y += bg_height)
            {
                for (float x = bgPos.X; x < bgPos.X + viewportSize.X + bg_width; x += bg_width)
                {
                    spriteBatch.Draw(bgTexture, new Vector2(x, y), transparentColor);
                }
            }
        }
        public void Update_camera()
        {
            // Limit the player position within the background bounds
            float playerWidth = player.frameWidth;
            float playerHeight = player.frameHeight;

            float maxPlayerX = Math.Max(0, bg_width - playerWidth); // Maximum X position within the background
            player.player_pos.X = MathHelper.Clamp(player.player_pos.X, 0, maxPlayerX);

            // Update camera position to follow the player
            cameraPos = player.player_pos - new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            // Limit the camera position to the boundaries of the background
            float maxCameraX = Math.Max(0, bg_width - GraphicsDevice.Viewport.Width);
            float maxCameraY = Math.Max(0, bg_height - GraphicsDevice.Viewport.Height);

            cameraPos.X = MathHelper.Clamp(cameraPos.X, 0, maxCameraX);
            cameraPos.Y = MathHelper.Clamp(cameraPos.Y, 0, maxCameraY);
        }
        public void Update_Draw()
        {
            Draw_UI();
            Draw_Inventory_UI();

            if (gameOver == false)
            {
                if (player.player_state != "Hide" && player.player_state != "Death" && player.isPlayerRun == false)
                {
                    spriteBatch.Draw(playerTexture, player.player_pos - cameraPos, player.playerRec, transparentColor);
                }
                else if (player.player_state != "Hide" && player.player_state != "Death" && player.isPlayerRun == true)
                {
                    spriteBatch.Draw(playerRunTexture, player.player_pos - cameraPos, player.playerRecRun, transparentColor);
                }
                else if ((player.player_state == "Hide" && player.player_state != "Death"))
                {

                }               

                if ((killer_spawn_chance == 1 || killer_spawn_chance == 2 || killer_spawn_chance == 3) && killer.killer_state != "Chase" && killer.removeKiller == true && killer.isAttack == false)
                {
                    spriteBatch.Draw(killerTexture, killer.killer_pos - cameraPos, killer.killerRec, transparentColor);
                }
                else if ((killer.killer_state == "Chase" || killer.killer_state == "Search") && killer.removeKiller == false && killer.isAttack == false)
                {
                    spriteBatch.Draw(killerTexture, killer.killer_pos - cameraPos, killer.killerRec, transparentColor);
                }
                else if (killer.killer_state == "Chase" && killer.removeKiller == false && killer.isAttack == true)
                {
                    spriteBatch.Draw(killerTextureAtk, killer.killer_pos_atk - cameraPos, killer.killerRecAtk, transparentColor);
                }

                else killer_spawn_chance = 0;
            }
            if (player.player_state == "Death")//player.player_state == "Death" && 
            {
                spriteBatch.Draw(playerDieTexture, player.player_pos - cameraPos, player.playerRecDie, transparentColor);

            }
            if ((killer.killer_state == "Chase") && killer.removeKiller == false && killer.isAttack == false)
            {
                spriteBatch.Draw(killerTexture, killer.killer_pos - cameraPos, killer.killerRec, transparentColor);
            }
        }
        public void Draw_UI()
        {
                // วาดพื้นหลัง UI_Sanity (ใช้ Width * 0.7 เพื่อทำให้สั้นลง)
                spriteBatch.Draw(UI_sanityTexture,
                    new Rectangle(125, 30, (int)(UI_sanityTexture.Width), 52),
                    UI_sanity.sanityRecInside, Color.White);

                // วาดส่วนที่แสดงค่าตามเงื่อนไข
                if (UI_sanity.sanity > UI_sanityTexture.Width * 0.3)
                {
                    spriteBatch.Draw(UI_sanityTexture,
                        new Rectangle(125, 30, (int)(UI_sanity.sanity), 50),
                        UI_sanity.sanityRecBlank, Color.MediumSeaGreen);
                }
                else
                {
                    spriteBatch.Draw(UI_sanityTexture,
                        new Rectangle(125, 30, (int)(UI_sanity.sanity), 50),
                        UI_sanity.sanityRecBlank, Color.Red);
                }

                // ส่วน stamina คงเดิม
                spriteBatch.Draw(UI_staminaTexture,
                    new Rectangle(125, 150, (int)(UI_staminaTexture.Width * 0.8), 32),
                    UI_stamina.staminaRecInside, Color.White);

                if (UI_stamina.stamina > UI_staminaTexture.Width * 0.3)
                {
                    spriteBatch.Draw(UI_staminaTexture,
                        new Rectangle(125, 150, (int)(UI_stamina.stamina * 0.8), 30),
                        UI_stamina.staminaRecBlank, Color.LightSkyBlue);
                }
                else
                {
                    spriteBatch.Draw(UI_staminaTexture,
                        new Rectangle(125, 150, (int)(UI_stamina.stamina * 0.8), 30),
                        UI_stamina.staminaRecBlank, Color.Red);
                }
                spriteBatch.Draw(sanityIcon, new Vector2(20, 20), new Rectangle(7, 8, 101, 84), Color.White);
                spriteBatch.Draw(staminaIcon, new Vector2(45, 120), new Rectangle(136, 12, 52, 72), Color.White);
            
        }
        private void Draw_Inventory_UI()
        {
            spriteBatch.Draw(inventory_UI._backgroundTexture, inventory_UI._position, transparentColorUI);
            {
                if (isInventoryVisible)
                {
                    inventory_UI.Draw(spriteBatch);
                }

            }
        }
        public void HandlePlayerActions()
        {
            // ตัวอย่างการจัดการเมื่อผู้เล่นกดปุ่มเพื่อเก็บไอเทม
          
            //All keys
            if (basement_Key.isVisible == true)
            {
                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 2, detailHeight * 0, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(basement_Key.Basement_keyHitRec))
                {
                    if (living_room.cabinetIsUnlock == true)
                    {
                        player.isHitObj = true;
                        if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                        {
                            basement_Key.isVisible = false;
                            inventory.AddItem(new Item("Basement_Key", Content.Load<Texture2D>("Key_Tile_Showmap"), basement_Key.Basement_keyRec, DetailTexture, DetailRec));
                            player.hasBasementKey = true;

                            sound.CollectInstance.Play();
                        }
                    }
                }
                //else if (player.playerHitRec.Intersects(basement_Key.Basement_keyHitRec) == false) player.isHitObj = false;

            }
            

            if (hallway_Key.isVisible == true)
            {
                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 3, detailHeight * 0, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(hallway_Key.Hallway_keyHitRec))
                {
                    player.isHitObj = true;
                    if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                    {
                        hallway_Key.isVisible = false;
                        inventory.AddItem(new Item("Hallway_Key", Content.Load<Texture2D>("Key_Tile_Showmap"), hallway_Key.Hallway_keyRec, DetailTexture, DetailRec));
                        player.hasHallwayKey = true;
                        sound.CollectInstance.Play();
                    }
                }
                //else if (player.playerHitRec.Intersects(hallway_Key.Hallway_keyHitRec) == false) player.isHitObj = false;

            }
            if (room03_Key.isVisible == true)
            {
                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 0, detailHeight * 0, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(room03_Key.Room03_keyHitRec))
                {
                    if (bed_Room.safeIsUnlock == true)
                    {
                        player.isHitObj = true;
                        if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                        {
                            room03_Key.isVisible = false;
                            inventory.AddItem(new Item("Room03_Key", Content.Load<Texture2D>("Key_Tile_Showmap"), room03_Key.Room03_keyRec, DetailTexture, DetailRec));
                            player.hasRoom03Key = true;
                            sound.CollectInstance.Play();

                        }
                    }
                }
                //else if (player.playerHitRec.Intersects(room03_Key.Room03_keyHitRec) == false) player.isHitObj = false;

            }
            if (balcony_Key.isVisible == true)
            {
                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 1, detailHeight * 0, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(balcony_Key.Balcony_keyHitRec))
                {
                    player.isHitObj = true;
                    if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                    {
                        balcony_Key.isVisible = false;
                        inventory.AddItem(new Item("Balcony_Key", Content.Load<Texture2D>("Key_Tile_Showmap"), balcony_Key.Balcony_keyRec, DetailTexture, DetailRec));
                        player.hasBalconyKey = true;
                        sound.CollectInstance.Play();

                    }
                }
                //else if (player.playerHitRec.Intersects(basement_Key.Basement_keyHitRec) == false) player.isHitObj = false;

            }
            if (bedroom_Key.isVisible == true)
            {
                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 4, detailHeight * 0, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(bedroom_Key.Bedroom_KeyHitRec))
                {
                    player.isHitObj = true;
                    if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                    {
                        bedroom_Key.isVisible = false;
                        inventory.AddItem(new Item("Bedroom_Key", Content.Load<Texture2D>("Key_Tile_Showmap"), bedroom_Key.Bedroom_KeyRec, DetailTexture, DetailRec));
                        player.hasBedroomKey = true;
                        sound.CollectInstance.Play();

                    }
                }
                //else if (player.playerHitRec.Intersects(bedroom_Key.Bedroom_KeyHitRec) == false) player.isHitObj = false;

            }
            if (hairpin.isVisible == true)
            {
                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 4, detailHeight * 1, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(hairpin.HairpinHitRec))
                {
                    player.isHitObj = true;
                    if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                    {
                        hairpin.isVisible = false;
                        inventory.AddItem(new Item("Hairpin", Content.Load<Texture2D>("Key_Tile_Showmap"), hairpin.HairpinRec, DetailTexture, DetailRec));
                        player.hasHairpin = true;
                        sound.CollectInstance.Play();

                    }
                }
                //else if (player.playerHitRec.Intersects(hairpin.HairpinHitRec) == false) player.isHitObj = false;

            }
            if (cabinet_Key.isVisible == true)
            {
                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 5, detailHeight * 0, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(cabinet_Key.Cabinet_keyHitRec))
                {
                    player.isHitObj = true;
                    if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                    {
                        cabinet_Key.isVisible = false;
                        inventory.AddItem(new Item("Cabinet_key", Content.Load<Texture2D>("Key_Tile_Showmap"), cabinet_Key.Cabinet_keyRec, DetailTexture, DetailRec));
                        player.hasCabinetKey = true;
                        sound.CollectInstance.Play();

                    }
                }
                //else if (player.playerHitRec.Intersects(cabinet_Key.Cabinet_keyHitRec) == false) player.isHitObj = false;

            }

            //Hearts
            if (phakin_Heart.isVisible == true)
            {
                Texture2D HeartTexture = Content.Load<Texture2D>("Heart_Tiles_ShowInventory");
                int HeartWidth = HeartTexture.Width / 4;
                int HeartHeight = HeartTexture.Height;
                Rectangle HeartRec;
                HeartRec = new Rectangle(HeartWidth * 1, 0, HeartWidth, HeartHeight);

                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 1, detailHeight * 1, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(phakin_Heart.Phakin_HeartHitRec))
                {
                    if (living_room.cabinetIsUnlock == true)
                    {
                        player.isHitObj = true;
                        if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                        {
                            phakin_Heart.isVisible = false;
                            inventory.AddItem(new Item("Phakin_Heart", HeartTexture, HeartRec, DetailTexture, DetailRec));
                            player.hasFriendsHearts += 1;
                            sound.CollectInstance.Play();
                            killer.mainEvents = 2;
                            isEventsActive = true;

                        }
                    }
                }
                //else if (player.playerHitRec.Intersects(phakin_Heart.Phakin_HeartHitRec) == false) player.isHitObj = false;

            }
            if (paenghom_Heart.isVisible == true)
            {
                Texture2D HeartTexture = Content.Load<Texture2D>("Heart_Tiles_ShowInventory");
                int HeartWidth = HeartTexture.Width / 4;
                int HeartHeight = HeartTexture.Height;
                Rectangle HeartRec;
                HeartRec = new Rectangle(HeartWidth * 3, 1, HeartWidth, HeartHeight);

                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 2, detailHeight * 1, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(paenghom_Heart.Paenghom_HeartHitRec))
                {
                    if (bed_Room.safeIsUnlock == true)
                    {
                        player.isHitObj = true;
                        if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                        {
                            paenghom_Heart.isVisible = false;
                            inventory.AddItem(new Item("Paenghom_Heart", HeartTexture, HeartRec, DetailTexture, DetailRec));
                            player.hasFriendsHearts += 1;
                            sound.CollectInstance.Play();
                            killer.mainEvents = 3;
                            isEventsActive = true;

                        }
                    }
                }
                //else if (player.playerHitRec.Intersects(paenghom_Heart.Paenghom_HeartHitRec) == false) player.isHitObj = false;

            }
            if (arthid_Heart.isVisible == true)
            {
                Texture2D HeartTexture = Content.Load<Texture2D>("Heart_Tiles_ShowInventory");
                int HeartWidth = HeartTexture.Width / 4;
                int HeartHeight = HeartTexture.Height;
                Rectangle HeartRec;
                HeartRec = new Rectangle(HeartWidth * 0, 1, HeartWidth, HeartHeight);

                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 0, detailHeight * 1, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(arthid_Heart.Arthid_HeartHitRec))
                {
                    player.isHitObj = true;
                    if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                    {
                        arthid_Heart.isVisible = false;
                        inventory.AddItem(new Item("Arthid_Heart", HeartTexture, HeartRec, DetailTexture, DetailRec));
                        player.hasFriendsHearts += 1;
                        sound.CollectInstance.Play();
                        killer.mainEvents = 4;
                        isEventsActive = true;

                    }
                }
                //else if (player.playerHitRec.Intersects(arthid_Heart.Arthid_HeartHitRec) == false) player.isHitObj = false;

            }
            if (waewdao_Heart.isVisible == true)
            {
                Texture2D  HeartTexture = Content.Load<Texture2D>("Heart_Tiles_ShowInventory");
                int HeartWidth = HeartTexture.Width / 4;
                int HeartHeight = HeartTexture.Height;
                Rectangle HeartRec; 
                HeartRec = new Rectangle(HeartWidth * 2, 0, HeartWidth, HeartHeight);

                Texture2D DetailTexture = Content.Load<Texture2D>("DetailTexture_item");
                int detailWidth = DetailTexture.Width / 6;
                int detailHeight = DetailTexture.Height / 2;
                Rectangle DetailRec;
                DetailRec = new Rectangle(detailWidth * 3, detailHeight * 1, detailWidth, detailHeight);

                if (player.playerHitRec.Intersects(waewdao_Heart.Waewdao_HeartHitRec))
                {
                    player.isHitObj = true;
                    if (ks.IsKeyDown(Keys.Space) && old_ks.IsKeyUp(Keys.Space))
                    {
                        waewdao_Heart.isVisible = false;
                        inventory.AddItem(new Item("Waewdao_Heart", HeartTexture, HeartRec, DetailTexture, DetailRec));
                        player.hasFriendsHearts += 1;
                        sound.CollectInstance.Play();
                        killer.mainEvents = 5;
                        isEventsActive = true;

                    }
                }
                //else if (player.playerHitRec.Intersects(waewdao_Heart.Waewdao_HeartHitRec) == false) player.isHitObj = false;

            }
            
            old_ks = ks;
        }
    }
}