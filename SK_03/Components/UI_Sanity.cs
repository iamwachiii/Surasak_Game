using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SK_03.Components
{
    public class UI_Sanity : Sprite
    {
        public float sanity;
        public int frameWidth, frameHeight;
        public Rectangle sanityRecInside, sanityRecBlank;
        private Player player;
        private Killer killer;

        private float delayTime;
        private bool delaySanity;

        public bool isSanityBarActive = true;
        public UI_Sanity(Texture2D texture, Player player, Killer killer)
        {
            this.player = player;
            this.killer = killer;
            sanity = texture.Width - 5;
            frameWidth = texture.Width;
            frameHeight = texture.Height;
            sanityRecInside = new Rectangle(0, 0, frameWidth - 4, frameHeight / 2);
            sanityRecBlank = new Rectangle(0, 64, frameWidth - 10, frameHeight / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (player.player_state != "Death")
            {
                Update_sanity(gameTime);
            }
            
        }

        private void Update_sanity(GameTime gameTime)
        {
            // คำนวณระยะห่างระหว่าง Killer และ Player
            float distance = Vector2.Distance(killer.killer_pos, player.player_pos);

            // ลดหลอดสุขภาพเมื่อ Killer อยู่ใกล้
            if (killer.killer_state != "Seek")
            {
                delayTime = 0;
                if (distance < 1000 && killer.removeKiller == false)
                {
                    // ลดค่า currentHeart ลงตามเวลา (50 หน่วยต่อวินาที)
                    if (player.player_state != "Hide")
                    {
                        sanity -= 50f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    // ตรวจสอบไม่ให้ currentHeart ต่ำกว่า 0
                    if (sanity < 0) sanity = 0;
                }
            }
            else if (distance > 1000 || killer.killer_state == "Seek")
            {
                // เพิ่มสุขภาพเมื่อ Player ห่างจาก Killer
                delayTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (delayTime >= 1f)
                {
                    if (sanity < frameWidth - 5)
                    {                       
                        sanity += 20f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        // ตรวจสอบไม่ให้ currentHeart เกินขีดจำกัด
                        if (sanity > frameWidth - 5) sanity = frameWidth - 5; ;
                    }
                }
                
            }
            
        }
    }
}
