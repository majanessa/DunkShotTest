using UnityEngine;

namespace DunkShot.Controllers
{
    public class UIController : MonoBehaviour
    {
        public GameObject[] panels;

        private void SetActivePanel(int index)
        {
            for (var i = 0; i < panels.Length; i++)
            {
                var active = i == index;
                var g = panels[i];
                if (g.activeSelf != active) g.SetActive(active);
            }
        }

        public void OnMainMenu()
        {
            SetActivePanel(0);
        }

        public void OnGamePanel()
        {
            SetActivePanel(1);
        }
        
        public void OnPausePanel()
        {
            SetActivePanel(2);
        }
        
        public void OnSettingsPanel()
        {
            SetActivePanel(3);
        }
        
        public void OnGameOverPanel()
        {
            SetActivePanel(4);
        }
    }
}
