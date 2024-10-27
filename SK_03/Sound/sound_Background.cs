using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;
using SK_03.All_Objects.Room01_Objs;

namespace SK_03
{
    internal class sound_Background : Sound_manage
    {
        private Game1 game;
        private SoundEffect backgroundSound;  // เปลี่ยนชื่อเพื่อให้ชัดเจน
        private SoundEffectInstance backgroundSoundInstance;  // ใช้สำหรับเสียงพื้นหลัง
        private KeyboardState _keyboardState;
        private KeyboardState _old_keyboardState;

        List<SoundEffect> soundEffects;

        public sound_Background(Game1 game)
        {
            this.game = game;
            soundEffects = new List<SoundEffect>();

            // โหลดเสียงพื้นหลังและเสียงเปิดประตู
            backgroundSound = game.Content.Load<SoundEffect>("sound_Background1");
            soundEffects.Add(backgroundSound);  // เพิ่มเสียงพื้นหลังลงในลิสต์

            //SoundEffect openDoorSound = game.Content.Load<SoundEffect>("sound_opendoor");
            //7soundEffects.Add(openDoorSound);  // เพิ่มเสียงเปิดประตูลงในลิสต์

            // สร้างอินสแตนซ์สำหรับเสียงพื้นหลัง
            backgroundSoundInstance = backgroundSound.CreateInstance();
            backgroundSoundInstance.IsLooped = true;  // ตั้งค่าให้วนซ้ำ
            backgroundSoundInstance.Play();  // เล่นเสียงพื้นหลัง

            Console.WriteLine("Background sound loaded and playing.");
        }

        public override void Update(GameTime theTime)
        {
            _keyboardState = Keyboard.GetState();

            /*if (_keyboardState.IsKeyDown(Keys.F) && _old_keyboardState.IsKeyUp(Keys.F))  // ตรวจสอบการกดคีย์ F
            {
                soundEffects[1].CreateInstance().Play();  // เล่นเสียงเปิดประตู
            }*/

            _old_keyboardState = _keyboardState;  // อัปเดตสถานะของคีย์บอร์ด
            base.Update(theTime);
        }

    }

}
