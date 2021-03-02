using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DJ2
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Image m_wipe;
        [SerializeField] private AudioClip m_jumpClip;
        [SerializeField] private AudioClip m_deathClip;
        [SerializeField] private AudioClip m_killClip;

        private AudioSource m_source;

        private CharacterController2D m_controller2D;
        private bool m_leftDown;
        private bool m_rightDown;
        private bool m_spaceDown;

        private Vector3 m_respawnPos;

        void Start()
        {
            m_controller2D = GetComponent<CharacterController2D>() as CharacterController2D;
            m_controller2D.jumpAction += jump;
            m_controller2D.killAction += kill;
            m_respawnPos = transform.position;

            m_source = GetComponent<AudioSource>();
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
            m_controller2D.Lock();

            GoTweenChain chain = new GoTweenChain();
            chain.append(new GoTween(m_wipe.rectTransform, 0.25f, new GoTweenConfig().anchoredPosition(new Vector2(0, 0)).onComplete(t =>
            {
                transform.position = m_respawnPos;
                Vector3 camPos = Camera.main.transform.position;
                camPos.x = m_respawnPos.x;
                camPos.y = m_respawnPos.y;
                Camera.main.transform.position = camPos;
            })));
            chain.append(new GoTween(m_wipe.rectTransform, 0.25f, new GoTweenConfig().anchoredPosition(new Vector2(-4000, 0)).onComplete(t =>
            {
                m_controller2D.Lock(false);
            })));

            chain.autoRemoveOnComplete = true;
            chain.play();

            m_source.clip = m_deathClip;
            m_source.Play();
        }

        private void jump()
        {
            m_source.clip = m_jumpClip;
            m_source.Play();
        }

        private void kill()
        {
            m_source.PlayOneShot(m_killClip);
        }
    }
}
