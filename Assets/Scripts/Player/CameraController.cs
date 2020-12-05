using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform m_follow;
        [SerializeField] private Vector3 m_offset = Vector3.zero;
        private Vector3 m_Position = Vector3.zero;

        private void Start()
        {
            m_offset.z = transform.position.z;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (m_follow)
            {
                Vector3 pos = m_follow.position + m_offset;
                // transform.position = Vector3.Lerp(transform.position, pos, 0.1f);
                transform.position = Vector3.SmoothDamp(transform.position, pos, ref m_Position, 0.05f);
            }
        }
    }
}
