using UnityEngine;
using UnityEngine.UI;

namespace DunkShot.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        public static ScoreController Instance { get; private set; }
        
        private Text _scoreText;
        public Text bestScoreText;

        [HideInInspector]
        public int scoreValue;

        private int _bestScore;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _scoreText = GetComponent<Text>();
            scoreValue = 0;
            _bestScore = PlayerPrefs.GetInt("BestScore");
            UpdateScoreUI();
            UpdateBestScoreUI();
        }

        public void AddScore(int value)
        {
            scoreValue += value;
            UpdateScoreUI();
        }

        private void UpdateScoreUI()
        {
            _scoreText.text = scoreValue.ToString();
        }

        public void UpdateBestScoreUI()
        {
            if (scoreValue > _bestScore)
            {
                _bestScore = scoreValue;
                PlayerPrefs.SetInt("BestScore", _bestScore);
            }
            bestScoreText.text = "BEST SCORE \n <b>" + _bestScore + "</b>";
        }
    }
}
