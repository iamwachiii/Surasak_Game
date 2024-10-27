using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SK_03.All_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK_03
{
    public class Balcony : SceneManage
    {
        public Texture2D balconyTexture;
        public Vector2 balcony_pos;

        private Game1 game;
        private Door door;
        private Texture2D doorTexture;
        private Guide guide;
        private Texture2D guideTexture;
        private Screwdriver screwdriver;
        private Texture2D screwdriverTexture;

        private Door_Guide doorGuide;
        private Texture2D doorGuideTexture;

        private Vector2 door_left_pos;
        private Vector2 door_right_pos;
        private Vector2 guide_left_pos;
        private Vector2 guide_right_pos;
        private Vector2 doorGuide_pos;

        private bool doorIsHit = false;

        private Rectangle doorHitRec_left, doorHitRec_right;
        private Rectangle doorGuideRectangle;

        private SoundEffect openDoorSound;
        public Balcony(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            this.game = game;
            balcony_pos = new Vector2(0, 0);
            balconyTexture = game.Content.Load<Texture2D>("balcony");
            doorTexture = game.Content.Load<Texture2D>("Tiles_frontHouse");
            doorGuideTexture = game.Content.Load<Texture2D>("Icon");
            screwdriverTexture = game.Content.Load<Texture2D>("Tilemap_Balcony");

            openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");

            door = new Door(doorTexture);
            guide = new Guide(guideTexture);
            screwdriver = new Screwdriver(screwdriverTexture);
            doorGuide = new Door_Guide(doorGuideTexture);

            door_left_pos = new Vector2(0, 255);
            door_right_pos = new Vector2(balconyTexture.Width - door.doorWidth, 255);

            guide_left_pos = new Vector2(0, 400);
            guide_right_pos = new Vector2(balconyTexture.Width - guide.guideWidth, 400);

            doorGuideRectangle = new Rectangle(0, 0, doorGuide.doorGuideWidth, doorGuide.doorGuideHeight);

        }
        private void OpenDoor()
        {
            if (game.player.playerHitRec.Intersects(doorHitRec_right) && game.player.direction == 1)
            {
                doorIsHit = true;
                doorGuide_pos = new Vector2(
                    game.player.player_pos.X + (game.player.frameWidth / 2) - (doorGuide.doorGuideWidth / 2),
                    game.player.player_pos.Y - doorGuide.doorGuideHeight - 20
                );
                if (Keyboard.GetState().IsKeyDown(Keys.E) == true)
                {
                    openDoorSound.CreateInstance().Play();
                    ScreenEvent.Invoke(game.hallway_2, new EventArgs());
                    return;
                }
            }   
            else { doorIsHit = false; }
        }
        public override void Update(GameTime theTime)
        {
            game.Update_components(theTime);
            game.UpdateLightBalcony();

            doorHitRec_left = new Rectangle((int)door_left_pos.X, (int)door_left_pos.Y, door.doorWidth, door.doorHeight);
            doorHitRec_right = new Rectangle((int)door_right_pos.X, (int)door_right_pos.Y, door.doorWidth, door.doorHeight);

            game.Update_camera();

            OpenDoor();

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(doorTexture, door_right_pos - game.cameraPos, door.doorRec_right, game.transparentColor);
            theBatch.Draw(screwdriverTexture, screwdriver.screwdriver_pos - game.cameraPos, screwdriver.screwdriverRec, game.transparentColor);

            game.Update_Draw();
        }
        public void DrawUI(SpriteBatch theBatch)
        {
            if (doorIsHit)
            {
                theBatch.Draw(doorGuideTexture, doorGuide_pos - game.cameraPos, doorGuide.doorGuideRec, Color.White);
            }
        }
    }
}
