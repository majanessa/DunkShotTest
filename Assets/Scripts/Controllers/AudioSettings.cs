using UnityEngine;

namespace DunkShot.Controllers
{
    public class AudioSettings : SettingsController
    {
        private void Awake()
        {
            if (!PlayerPrefs.HasKey("BtnAudioOn"))
                base.On();
            else if (PlayerPrefs.GetInt("BtnAudioOn") == 1)
                base.On();
            else if (PlayerPrefs.GetInt("BtnAudioOn") == 0)
                base.Off();
        }

        public override void On()
        {
            base.On();
            PlayerPrefs.SetInt("BtnAudioOn", 1);
            PlayerPrefs.SetInt("Volume", 1);
            AudioController.Instance.SetVolume();
        }
        
        public override void Off()
        {
            base.Off();
            PlayerPrefs.SetInt("BtnAudioOn", 0);
            PlayerPrefs.SetInt("Volume", 0);
            AudioController.Instance.SetVolume();
        }
    }
}
