using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class KillBox : MonoBehaviour
    {
        private void Awake()
        {
            MaterialPropertyBlock props = new MaterialPropertyBlock();
            props.SetFloat("Vector1_B8D26E2F", Random.Range(-0.03f, 0.03f));

            MeshRenderer rend = GetComponent<MeshRenderer>();
            rend.SetPropertyBlock(props);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Game.Instance.Respawn();
            }
            else if (other.GetComponent<Enemy>() != null)
            {
                other.GetComponent<Enemy>().Respawn();
            }
        }
    }
}
