using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class MainMenuPanel : MonoBehaviour
    {
        private static bool FromLevel = false;

        [SerializeField] private GameObject m_levelSelect;

        private void Awake()
        {
            if (MainMenuPanel.FromLevel)
            {
                GoToLevelSelect();
            }
        }

        public void GoToLevelSelect()
        {
            // SceneManager.LoadScene("LevelSelect");
            MainMenuPanel.FromLevel = true;
            gameObject.SetActive(false);
            m_levelSelect.SetActive(true);
        }
    }
}
