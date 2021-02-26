using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    [System.Serializable]
    class SaveData
    {
        string[] levelsComplete;
    }

    public class Save
    {
        private static Save m_instance;
        public static Save Instance
        {
            get
            {
                if (m_instance == null) m_instance = new Save();
                return m_instance;
            }
        }

        public HashSet<string> levelsComplete;
        public int jumps
        {
            get
            {
                return levelsComplete.Count / 2 + 1;
            }
        }

        Save()
        {
            string s = PlayerPrefs.GetString("SaveData_LevelsComplete", "{}");
            Debug.Log(s);

            this.levelsComplete = new HashSet<string>(s.Split('|'));
        }

        public void SaveData()
        {
            string[] stringArray = new string[levelsComplete.Count];
            levelsComplete.CopyTo(stringArray);
            string json = string.Join("|", levelsComplete);

            PlayerPrefs.SetString("SaveData_LevelsComplete", json);
            PlayerPrefs.Save();
        }

    }
}
