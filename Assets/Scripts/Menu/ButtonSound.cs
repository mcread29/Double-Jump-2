using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DJ2
{
    [RequireComponent(typeof(Button))]
    public class ButtonSound : MonoBehaviour
    {
        private Button m_button;
        [SerializeField] private AudioSource m_audioSource;

        private void Awake()
        {
            m_button = GetComponent<Button>();
            m_button.onClick.AddListener(playSound);
        }

        private void playSound()
        {
            m_audioSource.Play();
        }
    }

}