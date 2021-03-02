using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DJ2
{
    public class YesNoDialog : MonoBehaviour
    {
        [SerializeField] private Text m_text;

        private Action m_onYes;
        private Action m_onNo;

        public float m_alpha { get; set; }
        public Vector2 myVector { get; set; }

        public void ShowYesNo(string message, Action onYes, Action onNo = null)
        {
            gameObject.SetActive(true);
            CanvasGroup group = GetComponent<CanvasGroup>();

            m_text.text = message;
            m_onYes = onYes;
            m_onNo = onNo;
        }

        public void Yes()
        {
            gameObject.SetActive(false);
            if (m_onYes != null) m_onYes();
        }

        public void No()
        {
            gameObject.SetActive(false);
            if (m_onNo != null) m_onNo();
        }
    }
}