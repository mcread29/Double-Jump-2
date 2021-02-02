using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class KillBox : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.name + ", " + other.gameObject.tag);
            if (other.gameObject.tag == "Player")
            {
                Game.Instance.Respawn();
            }
        }
    }
}
