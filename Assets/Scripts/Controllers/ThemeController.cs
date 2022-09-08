using UnityEngine;

namespace DunkShot.Controllers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ThemeController : MonoBehaviour
    {
        public static ThemeController Instance { get; private set; }
        
        public Sprite[] themes;

        private SpriteRenderer _bgRenderer;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _bgRenderer = GetComponent<SpriteRenderer>();
            SetSprite();
        }
        
        public void SetSprite()
        {
            _bgRenderer.sprite = themes[PlayerPrefs.GetInt("ThemeId")] ?? themes[0];
        }

        public int GetThemeId()
        {
            return PlayerPrefs.GetInt("ThemeId");
        }
    }
}
