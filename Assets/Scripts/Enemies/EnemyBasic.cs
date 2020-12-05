using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class EnemyBasic : Enemy
    {
        [Header("Basic Enemy Stuff")]
        [SerializeField] private Transform m_leftBound;
        [SerializeField] private Transform m_rightBound;

        private Vector3 m_Velocity = Vector3.zero;

        private int m_move = 1;
        private float m_speed = 8f;

        private float m_minX { get { return m_Collider2D.bounds.min.x; } }
        private float m_maxX { get { return m_Collider2D.bounds.max.x; } }
        private float m_centerX { get { return m_Collider2D.bounds.center.x; } }

        private float m_minY { get { return m_Collider2D.bounds.min.y; } }
        private float m_maxY { get { return m_Collider2D.bounds.max.y; } }
        private float m_centerY { get { return m_Collider2D.bounds.center.y; } }

        private void FixedUpdate()
        {
            if (m_minX - 0.25f < m_leftBound.position.x) m_move = 1;
            if (m_maxX + 0.25f > m_rightBound.position.x) m_move = -1;

            Vector3 targetVelocity = new Vector2(m_move * m_speed, m_Rigidbody2D.velocity.y - m_gravity.gravity);

            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, .05f);
        }
    }
}
