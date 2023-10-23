using System;
using UnityEngine;

namespace ScriptableObjectVariable
{
    [CreateAssetMenu(fileName = "soFloat", menuName = "soVariables/soColor", order = 1)]
    public class SOColor : ScriptableVariable, ISerializationCallbackReceiver
    {
        //Float value
        [NonSerialized]
        public Color value;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private Color startingValue;

        /// <summary>
        /// Set sColor value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(Color _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sColor value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOColor _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Recieve callback after unity deseriallzes the object
        /// </summary>
        public void OnAfterDeserialize()
        {
            value = startingValue;
        }

        public void OnBeforeSerialize() { }

        /// <summary>
        /// Reset the value to it's inital value if it's resettable
        /// </summary>
        public override void ResetValue()
        {
            value = startingValue;
        }
        
        public static implicit operator Color(SOColor so) => so.value;
        public static implicit operator Color32(SOColor so) => so.value;
    }
}

