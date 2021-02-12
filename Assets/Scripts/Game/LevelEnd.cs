using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class LevelEnd : MonoBehaviour
    {

        [SerializeField] private bool m_doubleJumps;

        private void OnTriggerEnter2D(Collider2D other)
        {
            CharacterController2D controller = other.GetComponent<CharacterController2D>();
            if (controller != null)
            {
                if (m_doubleJumps && controller.maxJumps == SaveData.Instance.jumps)
                {
                    SaveData.Instance.jumps *= 2;
                    SaveData.Instance.Save();
                }

                // SceneManager.LoadScene("LevelSelect");
                SceneManager.LoadScene("Splash");
            }
        }
    }
}
