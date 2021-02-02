using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Gravity m_gravity;
        protected float m_gravityVelocity = 0;


        protected Rigidbody2D m_Rigidbody2D;
        protected BoxCollider2D m_Collider2D;

        private Vector3 m_startPosition;

        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Collider2D = GetComponent<BoxCollider2D>();
            m_startPosition = transform.position;
            if (m_gravity != null) m_gravityVelocity = m_gravity.gravity;
        }

        public void Respawn()
        {
            gameObject.SetActive(true);
            transform.position = m_startPosition;
        }
    }
}
