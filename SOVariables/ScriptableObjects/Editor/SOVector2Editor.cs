﻿using UnityEditor;
using UnityEngine;

namespace ScriptableObjectVariable
{
    [CustomEditor(typeof(SOVector2))]
    [CanEditMultipleObjects]
    public class SOVector2Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            //Draw the defualt inspector options
            DrawDefaultInspector();

            SOVector2 script = (SOVector2)target;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Debugging Options", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.LabelField("Current value: " + script.value, EditorStyles.boldLabel);

            //Display button that resets the value to the starting value
            if (GUILayout.Button("Reset Value"))
            {
                if (EditorApplication.isPlaying)
                {
                    script.ResetValue();
                }
            }
            EditorGUILayout.EndVertical();
        }
    }
}
