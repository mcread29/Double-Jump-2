using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DJ2
{
    [CreateAssetMenu(menuName = "Double Jump 2/Gravity")]
    public class Gravity : ScriptableObject
    {
        [SerializeField] private float m_gravity;
        public float gravity
        {
            get
            {
                return m_gravity;
            }
        }
    }
}
