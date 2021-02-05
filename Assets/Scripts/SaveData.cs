using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
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

        public int jumps;

        SaveData()
        {
            this.jumps = PlayerPrefs.GetInt("SaveData_Jumps", 1);
        }

        public void Save()
        {
            PlayerPrefs.SetInt("SaveData_Jumps", this.jumps);
        }

    }
}
