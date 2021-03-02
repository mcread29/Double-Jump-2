using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    public class Splash : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(changeScene());
        }

        IEnumerator changeScene()
        {
            yield return new WaitForSeconds(3.5f);
            ScreenTransition.To("Splash");
        }
    }
}
