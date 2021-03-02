using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    [RequireComponent(typeof(AudioSource))]
    public class LevelStart : MonoBehaviour
    {
        [SerializeField] private string m_scene;
        [SerializeField] private ParticleSystem m_particles;

        private AudioSource m_source;

        private void Awake()
        {
            m_source = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                other.gameObject.GetComponent<CharacterController2D>().Lock();

                m_particles.gameObject.SetActive(true);
                StartCoroutine(goToLevel(m_particles));

                GoTweenChain chain = new GoTweenChain();
                chain.autoRemoveOnComplete = true;
                chain.append(Go.to(other.transform, 0.5f, new GoTweenConfig().position(transform.position).setEaseType(GoEaseType.QuadIn)));
                chain.append(Go.to(other.transform, 1.5f, new GoTweenConfig().scale(new Vector3(0, 5, 0)).rotation(new Vector3(0, 359, 0)).setEaseType(GoEaseType.QuadIn)));
                chain.play();

                m_source.Play();
            }
        }

        private IEnumerator goToLevel(ParticleSystem particles)
        {
            while (particles.IsAlive()) yield return null;
            // SceneManager.LoadScene(m_scene);
            ScreenTransition.To(m_scene);
        }
    }
}
