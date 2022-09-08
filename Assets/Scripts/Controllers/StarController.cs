using UnityEngine;
using UnityEngine.UI;

namespace DunkShot.Controllers
{
    public class StarController : MonoBehaviour
    {
        public static StarController Instance { get; private set; }

        private Text _starText;

        [HideInInspector]
        public int starValue;

        private void Awake()
        {
            _starText = GetComponent<Text>();
            Instance = this;
        }

        private void Start()
        {
            starValue = PlayerPrefs.GetInt("Star");
            UpdateStarUI();
        }

        public void AddStar(int value)
        {
            starValue += value;
            UpdateStarUI();
        }

        private void UpdateStarUI()
        {
            _starText.text = starValue.ToString();
            PlayerPrefs.SetInt("Star", starValue);
        }
    }
}
