﻿using UnityEngine;
using UnityEngine.Events;

namespace DJ2
{
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private float m_JumpForce = 30f;
        [SerializeField] private float m_speed = 10f;
        [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
        [SerializeField] private LayerMask m_WhatIsGround;
        [SerializeField] private LayerMask m_WhatIsEnemy;
        [SerializeField] private Gravity m_gravity;

        const float k_collisionRadius = .01f;
        private bool m_Grounded;
        private bool m_FacingRight = true;
        private Vector3 m_Velocity = Vector3.zero;

        private Rigidbody2D m_Rigidbody2D;
        private BoxCollider2D m_Collider2D;

        public int maxJumps = 2;
        private int m_numJumps;

        private bool m_jump = false;
        public bool left = false;
        public bool right = false;

        [Header("Events")]
        [Space]

        public UnityEvent OnLandEvent;

        [System.Serializable]
        public class BoolEvent : UnityEvent<bool> { }

        private float m_minX { get { return m_Collider2D.bounds.min.x; } }
        private float m_maxX { get { return m_Collider2D.bounds.max.x; } }
        private float m_centerX { get { return m_Collider2D.bounds.center.x; } }

        private float m_minY { get { return m_Collider2D.bounds.min.y; } }
        private float m_maxY { get { return m_Collider2D.bounds.max.y; } }
        private float m_centerY { get { return m_Collider2D.bounds.center.y; } }

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Collider2D = GetComponent<BoxCollider2D>();

            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();

            m_numJumps = maxJumps;
        }

        private void FixedUpdate()
        {
            Vector3 targetVelocity = m_Rigidbody2D.velocity;

            bool wasGrounded = m_Grounded;
            m_Grounded = isCollidingWithWorld(m_centerX, m_minY, 0.5f, k_collisionRadius, m_WhatIsGround);
            targetVelocity.y -= m_gravity.gravity;

            if (m_jump)
            {
                m_Grounded = false;
                targetVelocity.y = m_JumpForce;
                m_Rigidbody2D.velocity = targetVelocity;
                m_jump = false;
            }
            else
            {
                if (m_Grounded)
                {
                    targetVelocity.y = 0;
                    if (wasGrounded == false)
                        OnLandEvent.Invoke();
                    m_numJumps = maxJumps;
                }

                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            }
        }

        public void Move(float move)
        {
            Vector3 targetVelocity = new Vector2(move * m_speed, m_Rigidbody2D.velocity.y);

            if (isCollidingWithWorld(m_minX, m_centerY, k_collisionRadius, 0.5f, m_WhatIsGround))
            {
                targetVelocity.x = Mathf.Max(0, targetVelocity.x);
            }

            if (isCollidingWithWorld(m_maxX, m_centerY, k_collisionRadius, 0.5f, m_WhatIsGround))
            {
                targetVelocity.x = Mathf.Min(0, targetVelocity.x);
            }

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }

            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        public void Jump()
        {
            if (m_numJumps > 0 && m_jump == false)
            {
                Debug.Log(m_numJumps);
                m_numJumps--;
                m_jump = true;
            }
        }

        private bool isCollidingWithWorld(float x, float y, float width, float height, int layerMask)
        {
            bool isColliding = false;

            Collider2D[] groundColliders = Physics2D.OverlapBoxAll(new Vector3(x, y, 0), new Vector2(width, height), 0, layerMask);
            for (int i = 0; i < groundColliders.Length; i++)
            {
                isColliding = isColliding || groundColliders[i].gameObject != gameObject;
            }

            return isColliding;
        }


        private void Flip()
        {
            m_FacingRight = !m_FacingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log(other.gameObject.name);

                bool collideTop = isCollidingWithWorld(m_centerX, m_minY, 0.5f, k_collisionRadius, m_WhatIsEnemy);
                if (collideTop)
                {
                    m_jump = true;
                    m_numJumps = maxJumps;
                    other.gameObject.SetActive(false);
                }
                else
                {
                    Game.Instance.Respawn();
                }
            }
        }
    }
}