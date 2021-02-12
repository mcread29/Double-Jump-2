using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class MovingKillBox : KillBox
    {
        [SerializeField] private bool m_horizontal;
        [SerializeField] private bool m_vertical;
        [SerializeField] private Transform m_topLeftBound;
        [SerializeField] private Transform m_bottomRightBound;

        private Vector3 m_Velocity = Vector3.zero;
        private Vector2 m_moveVector;

        private float m_speed = 8f;

        protected Rigidbody2D m_Rigidbody2D;
        protected BoxCollider2D m_Collider2D;

        private float m_minX { get { return m_Collider2D.bounds.min.x; } }
        private float m_maxX { get { return m_Collider2D.bounds.max.x; } }
        private float m_centerX { get { return m_Collider2D.bounds.center.x; } }

        private float m_minY { get { return m_Collider2D.bounds.min.y; } }
        private float m_maxY { get { return m_Collider2D.bounds.max.y; } }
        private float m_centerY { get { return m_Collider2D.bounds.center.y; } }

        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Collider2D = GetComponent<BoxCollider2D>();
        }

        private void Awake()
        {
            m_moveVector = new Vector2(0, 0);
            if (m_horizontal) m_moveVector.x = 1;
            if (m_vertical) m_moveVector.y = 1;
        }

        private void FixedUpdate()
        {
            if (m_horizontal)
            {
                if (m_topLeftBound != null && m_minX - 0.25f < m_topLeftBound.position.x) m_moveVector.x = 1;
                if (m_bottomRightBound != null && m_maxX + 0.25f > m_bottomRightBound.position.x) m_moveVector.x = -1;
            }
            if (m_vertical)
            {
                if (m_topLeftBound != null && m_maxY + 0.25f > m_topLeftBound.position.y) m_moveVector.y = -1;
                if (m_bottomRightBound != null && m_minY - 0.25f < m_bottomRightBound.position.y) m_moveVector.y = 1;
            }

            Vector3 targetVelocity = m_moveVector * m_speed;
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, .05f);
        }
    }
}
