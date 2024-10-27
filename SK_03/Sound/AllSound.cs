using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using SK_03.All_Objects.Room01_Objs;

namespace SK_03.Sound
{
    public class AllSound : Sound_manage
    {
        private Game1 game;

        private SoundEffect Walk;
        private SoundEffect Run;
        private SoundEffect Killer_Chase;
        private SoundEffect Cloase_light;
        private SoundEffect Open_light;
        private SoundEffect In_Hide;
        private SoundEffect Out_Hide;
        private SoundEffect Open_bag;
        private SoundEffect Unlocker_Door;
        private SoundEffect Collect;
        private SoundEffect JumpScare1;

        private SoundEffect Sanity_timeout;
        private SoundEffect Sanity_timeup;

        public SoundEffectInstance WalkInstance;
        public SoundEffectInstance RunInstance;
        public SoundEffectInstance Killer_ChaseInstance;
        public SoundEffectInstance Cloase_lightInstance;
        public SoundEffectInstance Open_lightInstance;
        public SoundEffectInstance In_HideInstance;
        public SoundEffectInstance Out_HideInstance;
        public SoundEffectInstance Open_bagInstance;
        public SoundEffectInstance Unlocker_DoorInstance;
        public SoundEffectInstance CollectInstance;
        public SoundEffectInstance JumpScare1Instance;
        public SoundEffectInstance Sanity_timeoutInstance;
        public SoundEffectInstance Sanity_timeupInstance;
        public AllSound(Game1 game)
        {
            this.game = game;
            Walk = game.Content.Load<SoundEffect>("Sound_Surasuk_Walk");
            Run = game.Content.Load<SoundEffect>("Sound_Surasuk_Run");
            Sanity_timeout = game.Content.Load<SoundEffect>("Sound_Sanity_Timeout");
            Collect = game.Content.Load<SoundEffect>("Sound_Collect");
            Killer_Chase = game.Content.Load<SoundEffect>("Sound_chase");
            Cloase_light = game.Content.Load<SoundEffect>("Sound_Close_light");
            Open_light = game.Content.Load<SoundEffect>("Sound_Open_light");
            In_Hide = game.Content.Load<SoundEffect>("Sound_In_Hide");
            Out_Hide = game.Content.Load<SoundEffect>("Sound_Out_Hide");
            Open_bag = game.Content.Load<SoundEffect>("Sound_Open_bag");
            Unlocker_Door = game.Content.Load<SoundEffect>("Sound_Unlocked_Door");
            Sanity_timeup = game.Content.Load<SoundEffect>("Sound_Sanity_Timeup");
            JumpScare1 = game.Content.Load<SoundEffect>("sound_JumpScare1");

            WalkInstance = Walk.CreateInstance(); // สร้าง Instance สำหรับควบคุม
            RunInstance = Run.CreateInstance();
            Killer_ChaseInstance = Killer_Chase.CreateInstance();
            Cloase_lightInstance = Cloase_light.CreateInstance();
            Open_lightInstance = Open_light.CreateInstance();
            In_HideInstance = In_Hide.CreateInstance();
            Out_HideInstance = Out_Hide.CreateInstance();
            Open_bagInstance = Open_bag.CreateInstance();
            Unlocker_DoorInstance = Unlocker_Door.CreateInstance();
            CollectInstance = Collect.CreateInstance();
            Sanity_timeoutInstance = Sanity_timeout.CreateInstance();
            Sanity_timeupInstance = Sanity_timeup.CreateInstance();
            JumpScare1Instance = JumpScare1.CreateInstance();

        }
    }
}
