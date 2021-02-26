using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DJ2
{
    public class LevelEnd : MonoBehaviour
    {
        [SerializeField] private ParticleSystem m_particles;

        private void OnTriggerEnter2D(Collider2D other)
        {
            CharacterController2D controller = other.GetComponent<CharacterController2D>();
            if (controller != null)
            {
                Save.Instance.levelsComplete.Add(SceneManager.GetActiveScene().name);
                Save.Instance.SaveData();

                controller.Lock();

                m_particles.gameObject.SetActive(true);
                StartCoroutine(goToLevelSelect(m_particles));

                GoTweenChain chain = new GoTweenChain();
                chain.autoRemoveOnComplete = true;
                chain.append(Go.to(controller.transform, 0.5f, new GoTweenConfig().position(transform.position).setEaseType(GoEaseType.QuadIn)));
                chain.append(Go.to(controller.transform, 1.5f, new GoTweenConfig().scale(new Vector3(0, 5, 0)).rotation(new Vector3(0, 359, 0)).setEaseType(GoEaseType.QuadIn)));
                chain.play();
            }
        }



        private IEnumerator goToLevelSelect(ParticleSystem particles)
        {
            while (particles.IsAlive()) yield return null;
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
