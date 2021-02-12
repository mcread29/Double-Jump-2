using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class BasicEnemySpawner : MonoBehaviour
    {
        [SerializeField] private int m_numEnemies;
        [SerializeField] private GameObject m_enemyPrefab;
        [SerializeField] private int m_startMoveDir;
        [SerializeField] private float m_spawnRate;

        private Queue<EnemyBasic> m_enemies;

        private void Awake()
        {
            m_enemies = new Queue<EnemyBasic>();
            for (int i = 0; i < m_numEnemies; i++)
            {
                GameObject g = GameObject.Instantiate(m_enemyPrefab, transform.position, transform.rotation, transform.parent);
                g.SetActive(false);
                EnemyBasic enemy = g.GetComponent<EnemyBasic>();
                enemy.Move = m_startMoveDir;
                enemy.onRespawn += respawnEnemy;
                m_enemies.Enqueue(g.GetComponent<EnemyBasic>());
            }

            StartCoroutine(spawnEnemy());
        }

        IEnumerator spawnEnemy()
        {
            while (gameObject.activeInHierarchy)
            {
                yield return new WaitForSeconds(m_spawnRate);

                EnemyBasic enemy = m_enemies.Dequeue();
                if (enemy != null)
                {
                    enemy.gameObject.SetActive(true);
                }
            }
            yield return null;
        }

        void respawnEnemy(GameObject enemy)
        {
            enemy.SetActive(false);
            m_enemies.Enqueue(enemy.GetComponent<EnemyBasic>());
        }
    }
}