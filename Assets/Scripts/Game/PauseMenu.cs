using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private YesNoDialog m_yesNo;

        public void Resume()
        {
            Game.Instance.Resume();
        }

        public void Quit()
        {
            m_yesNo.ShowYesNo("Are you sure you want to quit?", actualQuit);
        }

        private void actualQuit()
        {
            Application.Quit();
        }

        public void Restart()
        {
            m_yesNo.ShowYesNo("Are you sure you want to restart? You'll lose all save data.", actualRestart);
        }

        private void actualRestart()
        {
            PlayerPrefs.DeleteAll();
            ScreenTransition.To("Splash");
        }
    }
}
