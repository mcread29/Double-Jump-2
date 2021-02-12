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

        protected float m_minX { get { return m_Collider2D.bounds.min.x; } }
        protected float m_maxX { get { return m_Collider2D.bounds.max.x; } }
        protected float m_centerX { get { return m_Collider2D.bounds.center.x; } }

        protected float m_minY { get { return m_Collider2D.bounds.min.y; } }
        protected float m_maxY { get { return m_Collider2D.bounds.max.y; } }
        protected float m_centerY { get { return m_Collider2D.bounds.center.y; } }

        public System.Action<GameObject> onRespawn;

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
            if (onRespawn != null) onRespawn(gameObject);
        }

        protected bool isCollidingWithWorld(float x, float y, float width, float height, int layerMask)
        {
            bool isColliding = false;

            Collider2D[] groundColliders = Physics2D.OverlapBoxAll(new Vector3(x, y, 0), new Vector2(width, height), 0, layerMask);
            for (int i = 0; i < groundColliders.Length; i++)
            {
                isColliding = isColliding || groundColliders[i].gameObject != gameObject;
            }

            return isColliding;
        }
    }
}
