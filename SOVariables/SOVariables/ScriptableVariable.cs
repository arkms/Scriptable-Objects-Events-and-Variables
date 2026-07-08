using System;
using UnityEngine;

namespace ScriptableObjectVariable
{
    public abstract class ScriptableVariable : ScriptableObject
    {
        public Action OnValueChanged;
        
        /// <summary>
        /// Reset the value to it's inital value if it's resettable
        /// </summary>
        public abstract void ResetValue();
        /// <summary>
        /// Reset the value to it's inital value if it's resettable without trigger change event
        /// </summary>
        public abstract void ResetValueWithoutNotify();
    }
}
