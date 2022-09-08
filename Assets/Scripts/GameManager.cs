using DunkShot.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace DunkShot
{
    public class GameManager : MonoBehaviour
    {
        public UIController ui;

        public ScoreController score;

        public bool IsPlay { get; private set; } = false;

        public bool IsPause { get; private set; } = false;

        private void Update()
        {
            DotsController.Instance.Aim();
            CameraFollow.Instace.CameraMove();
        }
        
        public void Play()
        {
            ui.OnGamePanel();
            IsPlay = true;
            IsPause = false;
        }

        public void GameOver()
        {
            IsPause = true;
            score.UpdateBestScoreUI();
            ui.OnGameOverPanel();
        }

        public void Restart()
        {
            SceneManager.LoadScene("Main");
            IsPlay = false;
            IsPause = false;
        }

        public void Pause()
        {
            ui.OnPausePanel();
            IsPause = true;
        }

        public void Settings()
        {
            ui.OnSettingsPanel();
            IsPause = true;
        }

        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }

        public static bool CursorOverUI()
        {
#if (UNITY_ANDROID || UNITY_IOS) && (!UNITY_EDITOR)
        int cursorID = Input.GetTouch(0).fingerId;
        return EventSystem.current.IsPointerOverGameObject(cursorID);
#else
            return EventSystem.current.IsPointerOverGameObject();
#endif
        }
    }
}
