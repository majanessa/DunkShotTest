using UnityEngine;

namespace DunkShot.Controllers
{
    public class SettingsController : MonoBehaviour
    {
        public GameObject buttonOn;
        
        public GameObject buttonOff;

        public virtual void On()
        {
            buttonOff.SetActive(false);
            buttonOn.SetActive(true);
        }
        
        public virtual void Off()
        {
            buttonOff.SetActive(true);
            buttonOn.SetActive(false);
        }
    }
}
