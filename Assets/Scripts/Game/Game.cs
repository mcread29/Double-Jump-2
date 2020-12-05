using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class Game : MonoBehaviour
    {
        private static Game m_instance;
        public static Game Instance
        {
            get
            {
                if (m_instance == null) m_instance = new Game();
                return m_instance;
            }
        }

        private Enemy[] m_enemies;
        private Player m_player;

        private void Awake()
        {
            m_instance = this;
            m_player = FindObjectOfType<Player>();
            m_enemies = FindObjectsOfType<Enemy>();
            Debug.Log(m_enemies.Length);
        }

        public void Respawn()
        {
            m_player.Respawn();
            foreach (var enemy in m_enemies)
            {
                enemy.Respawn();
            }
        }
    }
}
