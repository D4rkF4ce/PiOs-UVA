using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiGHTECHNiX.Pi.OperatingSystem.Persistance
{
    public sealed class SoundManager
    {
        private static MainPage _root;
        private readonly static SoundManager _instance = new SoundManager();
        public static SoundManager GetInstance()
        {
            return _instance;
        }

        private SoundManager()
        {
            // only for private using !! 
        }

        public void SetSoundPlayer(MainPage parent)
        {
            _root = parent;
        }

        public void PlayLockSound()
        {
            _root.PlaySound("ms-appx:///Assets/Sounds/Windows_Logon.wav");
        }        
    }
}
