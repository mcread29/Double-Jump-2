using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class LevelStart : MonoBehaviour
    {
        [SerializeField] private string m_scene;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                Debug.Log(m_scene);
                SceneManager.LoadScene(m_scene);
            }
        }
    }
}
