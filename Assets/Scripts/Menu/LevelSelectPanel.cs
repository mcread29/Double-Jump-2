using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class LevelSelectPanel : MonoBehaviour
    {
        [SerializeField] private GameObject m_helpPanel;

        public void Quit()
        {
            Application.Quit();
        }
        public void Help(bool show)
        {
            m_helpPanel.SetActive(show);
        }
        public void StartLevel1()
        {
            SceneManager.LoadScene("Level1");
        }
        public void StartLevel2_1()
        {
            SceneManager.LoadScene("Level2.1");
        }
        public void StartLevel2_2()
        {
            SceneManager.LoadScene("Level2.2");
        }
        public void StartLevel3_1()
        {
            SceneManager.LoadScene("Level3.1");
        }
        public void StartLevel3_2()
        {
            SceneManager.LoadScene("Level3.2");
        }
        public void StartLevel4()
        {
            SceneManager.LoadScene("Level4");
        }
    }
}
