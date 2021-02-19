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

        [SerializeField] private PauseMenu m_pauseMenu;

        private void Awake()
        {
            m_instance = this;
            m_player = FindObjectOfType<Player>();
            m_enemies = FindObjectsOfType<Enemy>();
            Debug.Log(m_enemies.Length);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pause();
            }
        }

        public void Respawn()
        {
            m_player.Respawn();
            foreach (var enemy in m_enemies)
            {
                enemy.Respawn();
            }
        }

        public void SetCheckpoint(Transform checkpoint)
        {
            m_player.setCheckpoint(checkpoint.position);
        }

        private void pause()
        {
            Time.timeScale = 0;
            m_pauseMenu.gameObject.SetActive(true);
        }

        public void Resume()
        {
            Time.timeScale = 1;
            m_pauseMenu.gameObject.SetActive(false);
        }
    }
}
