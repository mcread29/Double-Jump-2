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
        [SerializeField] private LayerMask m_whatIsGround;

        private Vector3 m_Velocity = Vector3.zero;

        [SerializeField] private int m_move = 1;
        public int Move
        {
            set
            {
                m_move = value;
            }
        }
        private float m_speed = 6.5f;

        private void FixedUpdate()
        {
            if (m_Rigidbody2D)
            {
                bool collideLeft = isCollidingWithWorld(m_minX, m_centerY, 0.01f, 0.5f, m_whatIsGround);
                bool collideRight = isCollidingWithWorld(m_maxX, m_centerY, 0.01f, 0.5f, m_whatIsGround);

                if (collideLeft || (m_leftBound != null && m_minX - 0.25f < m_leftBound.position.x)) m_move = 1;
                if (collideRight || (m_rightBound != null && m_maxX + 0.25f > m_rightBound.position.x)) m_move = -1;

                Vector3 targetVelocity = new Vector2(m_move * m_speed, m_Rigidbody2D.velocity.y - m_gravityVelocity);
                // targetVelocity.y = Mathf.Max(targetVelocity.y, -30f);

                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, .05f);
            }
        }
    }
}
