//C# Example (LookAtPointEditor.cs)
using UnityEngine;
using UnityEditor;

namespace DJ2
{
    // [CustomEditor(typeof(EnemyBasic))]
    // [CanEditMultipleObjects]
    // public class LookAtPointEditor : Editor
    // {
    //     SerializedProperty m_leftBound;
    //     SerializedProperty m_rightBound;

    //     void OnEnable()
    //     {
    //         m_leftBound = serializedObject.FindProperty("m_leftBound");
    //         m_rightBound = serializedObject.FindProperty("m_rightBound");
    //     }

    //     public override void OnInspectorGUI()
    //     {
    //         serializedObject.Update();
    //         EditorGUILayout.PropertyField(m_leftBound);
    //         EditorGUILayout.PropertyField(m_rightBound);
    //         serializedObject.ApplyModifiedProperties();
    //         if (GUI.changed)
    //         {
    //             Debug.Log("WOW");
    //         }
    //     }
    // }
}