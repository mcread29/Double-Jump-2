using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class MainMenuPanel : MonoBehaviour
    {
        public void GoToLevelSelect()
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
