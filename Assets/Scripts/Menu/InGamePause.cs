using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class InGamePause : MonoBehaviour
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
            gameObject.SetActive(false);
            Time.timeScale = 1;
            ScreenTransition.To("LevelSelect");
        }
    }
}
