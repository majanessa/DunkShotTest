using UnityEngine;
using static DunkShot.Controllers.ThemeController;

namespace DunkShot.Controllers
{
    public class ThemeSettings : SettingsController
    {
        private void Awake()
        {
            if (PlayerPrefs.GetInt("BtnThemeOn") == 1)
                base.On();
            if (PlayerPrefs.GetInt("BtnThemeOn") == 0)
                base.Off();
        }
        
        public override void On()
        {
            base.On();
            PlayerPrefs.SetInt("BtnThemeOn", 1);
            PlayerPrefs.SetInt("ThemeId", 1);
            Instance.SetSprite();
        }
        
        public override void Off()
        {
            base.Off();
            PlayerPrefs.SetInt("BtnThemeOn", 0);
            PlayerPrefs.SetInt("ThemeId", 0);
            Instance.SetSprite();
        }
        
        public void ChangeTheme()
        {
            if (Instance.GetThemeId() == 0)
                On();
            if (Instance.GetThemeId() == 1)
                Off();
        }
    }
}
