using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip m_menuSound;
        [SerializeField] private AudioClip m_gameplaySound;

        private static AudioManager m_instance;

        private AudioSource m_source;

        private void Awake()
        {
            if (m_instance != null) Destroy(this);
            else
            {
                DontDestroyOnLoad(this);
                m_instance = this;
                SceneManager.sceneLoaded += onSceneLoaded;
                m_source = GetComponent<AudioSource>();
            }
        }

        private void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Splash" && m_source.clip != m_menuSound)
            {
                m_source.clip = m_menuSound;
                m_source.Play();
            }
            else if (scene.name != "Splash" && m_source.clip != m_gameplaySound)
            {
                m_source.clip = m_gameplaySound;
                m_source.Play();
            }
        }

    }
}
