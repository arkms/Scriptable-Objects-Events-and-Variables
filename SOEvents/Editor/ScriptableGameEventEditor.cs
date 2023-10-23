﻿using UnityEditor;
using UnityEngine;

namespace ScriptableObjectEvent
{
    [CustomEditor(typeof(SOGameEvent))]
    [CanEditMultipleObjects]
    public class ScriptableGameEventEditor : Editor
    {
#if UNITY_EDITOR
        public override void OnInspectorGUI()
        {
            //Draw the defualt inspector options
            DrawDefaultInspector();

            SOGameEvent script = (SOGameEvent)target;

            //Draw button
            if (GUILayout.Button("Raise Event"))
            {
                //If the application is playing - raise/trigger the event
                if (EditorApplication.isPlaying)
                {
                    script.Raise();
                }
            }
        }
#endif
    }
}
