using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class Player : MonoBehaviour
    {
        private CharacterController2D m_controller2D;
        private bool m_leftDown;
        private bool m_rightDown;
        private bool m_spaceDown;

        private Vector3 m_respawnPos;

        void Start()
        {
            m_controller2D = GetComponent<CharacterController2D>() as CharacterController2D;
            m_respawnPos = transform.position;
        }

        void Update()
        {
            m_leftDown = Input.GetKey(KeyCode.LeftArrow);
            m_rightDown = Input.GetKey(KeyCode.RightArrow);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_controller2D.Jump();
            }
        }

        void FixedUpdate()
        {
            int x = 0;

            if (m_leftDown) x--;
            if (m_rightDown) x++;

            m_controller2D.Move(x);
        }

        public void setCheckpoint(Vector3 position)
        {
            m_respawnPos = position;
        }

        public void Respawn()
        {
            transform.position = m_respawnPos;
            Vector3 camPos = Camera.main.transform.position;
            camPos.x = m_respawnPos.x;
            camPos.y = m_respawnPos.y;
            Camera.main.transform.position = camPos;
        }
    }
}
