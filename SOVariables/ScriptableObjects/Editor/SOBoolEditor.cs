﻿using UnityEngine;
using UnityEditor;

namespace ScriptableObjectVariable
{
    [CustomEditor(typeof(SOBool))]
    [CanEditMultipleObjects]
    public class SOBoolEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //Draw the defualt inspector options
            DrawDefaultInspector();

            SOBool script = (SOBool)target;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Debugging Options", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.LabelField("Current value: " + script.value, EditorStyles.boldLabel);

            //Display button that toggles the bool value
            if (GUILayout.Button("Toggle Value"))
            {
                if (EditorApplication.isPlaying)
                {
                    script.Toggle();
                }
            }

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
        
        public override bool RequiresConstantRepaint() { return EditorApplication.isPlaying; }
    }
}
