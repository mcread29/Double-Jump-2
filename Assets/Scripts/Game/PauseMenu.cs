using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class PauseMenu : MonoBehaviour
    {
        public void Resume()
        {
            Game.Instance.Resume();
        }
        public void Quit()
        {
            SceneManager.LoadScene("Splash");
        }
    }
}
