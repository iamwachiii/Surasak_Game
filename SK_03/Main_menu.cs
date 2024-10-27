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
using SK_03.All_Objects.Menu_Icon;
using SK_03.All_Objects.All_Icon_Guides;
using SK_03.All_Objects;

namespace SK_03
{
    public class Main_menu : SceneManage
    {

        private Game1 game;
        public Texture2D main_menuTexture;
        public Vector2 main_menu_pos;

        private Guide guide;
        private Texture2D guideTexture;
        private Start_Guide start_Guide;
        private Texture2D startGuideTexture;
        private Exit_Guide exit_Guide;
        private Texture2D exitGuideTexture;

        private Vector2 guide_pos_start;
        private Vector2 guide_pos_end;
        private Rectangle icon_startHitRec;
        private Rectangle icon_endHitRec;
        private bool iconStartIsHit;
        private bool iconEndIsHit;

        private Texture2D gameNameTexture;
        private Vector2 gameName_pos;
        private Texture2D startTexture;
        private Vector2 start_pos;
        private Texture2D endTexture;
        private Vector2 end_pos;
        private Texture2D settingTexture;
        private Vector2 setting_pos;

        private MouseState ms;

        public Main_menu(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            main_menu_pos = new Vector2(0, 0);
            main_menuTexture = game.Content.Load<Texture2D>("Cover");
            startGuideTexture = game.Content.Load<Texture2D>("Font_Menu");
            exitGuideTexture = game.Content.Load<Texture2D>("Font_Menu");
            gameNameTexture = game.Content.Load<Texture2D >("Font_Menu");
            startTexture = game.Content.Load<Texture2D>("Font_Menu");
            endTexture = game.Content.Load<Texture2D>("Font_Menu");
            settingTexture = game.Content.Load<Texture2D>("Font_Menu");

            start_Guide = new Start_Guide(startGuideTexture);
            exit_Guide = new Exit_Guide(exitGuideTexture);

            guide_pos_start =  new Vector2(92.5f, 330); 
            guide_pos_end = new Vector2(92.5f, 680); ;
            gameName_pos = new Vector2(40, 100);
            start_pos = new Vector2(90, 330);
            end_pos = new Vector2(90, 680);
            setting_pos = new Vector2(90, 490);

            icon_startHitRec = new Rectangle((int)guide_pos_start.X, (int)guide_pos_start.Y, 200,100);
            icon_endHitRec = new Rectangle((int)guide_pos_end.X, (int)guide_pos_end.Y, 200,100);           
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);

            ms = Mouse.GetState();
            
            game.Update_camera();

            if (game.mouseHitRec.Intersects(icon_startHitRec) )
            {
                iconStartIsHit = true;
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    ScreenEvent.Invoke(game.begin, new EventArgs());
                    game.player.player_pos = new Vector2(0, 535);
                    game.player.direction = 1;
                    game.gameOver = true;
                    return;
                }
            }
            else if (game.mouseHitRec.Intersects(icon_endHitRec))
            {
                iconEndIsHit = true;
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    game.Exit();
                }
            }
                     
            else
            {
                iconStartIsHit = false;
                iconEndIsHit = false;
            }

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(gameNameTexture, gameName_pos, new Rectangle(0, 0 ,801 ,203), Color.White);
            theBatch.Draw(startTexture, start_pos, new Rectangle(300, 290, 300, 110), Color.White);
            theBatch.Draw(endTexture, end_pos, new Rectangle(300, 740, 200, 60), Color.White);
            theBatch.Draw(settingTexture, setting_pos, new Rectangle(300, 485, 220, 115), Color.White);

            if (iconStartIsHit == true)
            {
                theBatch.Draw(startGuideTexture, guide_pos_start - game.cameraPos, start_Guide.startGuideRec, Color.White);
            }
            if(iconEndIsHit == true)
            {
                theBatch.Draw(exitGuideTexture, guide_pos_end - game.cameraPos, exit_Guide.exitGuideRec, Color.White);
            }

        }


    }

}
