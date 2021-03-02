using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class Tutorial : MonoBehaviour
    {
        public void Close()
        {
            Game.Instance.Player.GetComponent<CharacterController2D>().Lock(false);
            gameObject.SetActive(false);
        }
    }
}
