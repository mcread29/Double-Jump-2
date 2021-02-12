using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class Checkpoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Game.Instance.SetCheckpoint(transform);
        }
    }
}
