using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DJ2
{
    public class ScreenTransition : MonoBehaviour
    {
        private static ScreenTransition m_instance;

        public static void To(string scene)
        {
            m_instance.m_scene = scene;
            m_instance.transitionIn();
            SceneManager.sceneLoaded += m_instance.transitionOut;
        }

        [SerializeField] private Image m_image;
        private string m_scene;

        private void Awake()
        {
            if (m_instance) Destroy(this);
            else
            {
                m_instance = this;
                DontDestroyOnLoad(this);
            }
        }

        private void transitionIn()
        {
            m_image.rectTransform.anchoredPosition.Set(4000, 0);
            Go.to(m_image.rectTransform, 0.5f, new GoTweenConfig().anchoredPosition(new Vector2(0, 0)).onComplete(t => SceneManager.LoadScene(m_scene)));
        }

        private void transitionOut(Scene s, LoadSceneMode m)
        {
            SceneManager.sceneLoaded -= transitionOut;
            Go.to(m_image.rectTransform, 0.5f, new GoTweenConfig().anchoredPosition(new Vector2(-4000, 0)));
        }
    }
}
