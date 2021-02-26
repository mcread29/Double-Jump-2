using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class MainMenuPanel : MonoBehaviour
    {

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }

    }
}
