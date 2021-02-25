using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace DJ2
{
    public class ParticleSystemDestroy : MonoBehaviour
    {
        private ParticleSystem m_particles;

        private void Awake()
        {
            m_particles = GetComponent<ParticleSystem>();
        }

        void Update()
        {
            if (m_particles && m_particles.IsAlive() == false)
            {
                Destroy(gameObject);
            }
        }
    }
}
