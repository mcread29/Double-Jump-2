using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class CreditsCheck : MonoBehaviour
    {
        [SerializeField] private GameObject m_credits;
        [SerializeField] private GameObject m_tutorial;

        private void Awake()
        {
            if (SaveData.Instance.levelsFinished.Count >= 8 && SaveData.Instance.seenCredits == false)
            {
                SaveData.Instance.seenCredits = true;
                SaveData.Instance.Save();
                m_credits.SetActive(true);
            }

            if (SaveData.Instance.seenTutorial == false)
            {
                SaveData.Instance.seenTutorial = true;
                SaveData.Instance.Save();
                Game.Instance.Player.GetComponent<CharacterController2D>().Lock();
                m_tutorial.SetActive(true);
            }
        }
    }
}
