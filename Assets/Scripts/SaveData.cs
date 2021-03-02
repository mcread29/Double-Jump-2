using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    [System.Serializable]
    public class Save
    {
        public string levelsFinished;
        public bool seenCredits;
        public bool seenTutorial;

        public Save()
        {
            levelsFinished = "";
            seenCredits = false;
            seenTutorial = false;
        }
    }

    public class SaveData
    {
        private static SaveData m_instance;
        public static SaveData Instance
        {
            get
            {
                if (m_instance == null) m_instance = new SaveData();
                return m_instance;
            }
        }

        Save save;

        public HashSet<string> levelsFinished;
        public Dictionary<string, float> finishTimes;

        public bool seenCredits
        {
            get { return save.seenCredits; }
            set { save.seenCredits = value; }
        }

        public bool seenTutorial
        {
            get { return save.seenTutorial; }
            set { save.seenTutorial = value; }
        }

        public int jumps
        {
            get { return (int)Mathf.Pow(2, (int)Mathf.Floor(levelsFinished.Count / 2)); }
        }

        SaveData()
        {
            string s = PlayerPrefs.GetString("DJ2_SaveData");

            save = JsonUtility.FromJson<Save>(s);
            if (save == null) save = new Save();

            if (save.levelsFinished == "") this.levelsFinished = new HashSet<string>();
            else this.levelsFinished = new HashSet<string>(save.levelsFinished.Split('|'));

            foreach (string level in this.levelsFinished)
            {
                Debug.Log("FINISHED: " + level);
            }
            Debug.Log(this.levelsFinished.Count);

            this.finishTimes = new Dictionary<string, float>();
        }

        public void Save()
        {
            save.levelsFinished = string.Join("|", levelsFinished);
            // string v = string.Join("|", finishTimes);
            Debug.Log(save.levelsFinished);

            PlayerPrefs.SetString("DJ2_SaveData", JsonUtility.ToJson(save));
            PlayerPrefs.Save();
        }

    }
}
