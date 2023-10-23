using UnityEditor;
using UnityEngine;

namespace ScriptableObjectVariable
{
    [CustomEditor(typeof(SOFloat))]
    [CanEditMultipleObjects]
    public class SOFloatEditor : Editor
    {

        private float floatModifyValue = 0.0f;

        public override void OnInspectorGUI()
        {
            //Draw the defualt inspector options
            DrawDefaultInspector();

            SOFloat script = (SOFloat)target;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Debugging Options", EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.LabelField("Current value: " + script.value, EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

            //Display a float input field and button to add the inputted value to the current value
            floatModifyValue = EditorGUILayout.FloatField("New value: ", floatModifyValue);

            if (GUILayout.Button("Modify"))
            {
                script.SetValue(floatModifyValue);
            }

            EditorGUILayout.EndHorizontal();

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
