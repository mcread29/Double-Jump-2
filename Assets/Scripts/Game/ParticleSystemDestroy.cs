using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace DJ2
{
    public class ParticleSystemDestroy : MonoBehaviour
    {
        private ParticleSystem m_particles;
        private VisualEffect m_effect;
        private bool m_effectStarted = false;

        private void Awake()
        {
            m_particles = GetComponent<ParticleSystem>();
            m_effect = GetComponent<VisualEffect>();
        }

        void Update()
        {
            if (m_particles && m_particles.IsAlive() == false)
            {
                Destroy(gameObject);
            }
            else if (m_effect && m_effect.aliveParticleCount > 0 && m_effectStarted == false)
            {
                m_effectStarted = true;
            }
            else if (m_effect && m_effectStarted && m_effect.aliveParticleCount < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
