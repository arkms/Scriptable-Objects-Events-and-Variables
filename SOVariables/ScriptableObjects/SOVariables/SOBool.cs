using UnityEngine;
using System;

namespace ScriptableObjectVariable
{
    [CreateAssetMenu(fileName = "soBool", menuName = "soVariables/soBool", order = 1)]
    public class SOBool : ScriptableVariable, ISerializationCallbackReceiver
    {
        [NonSerialized]
        public bool value;

        //Can the value be reset in game
        //public bool resettable;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private bool startingValue = false;

        /// <summary>
        /// Set sBool value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(bool _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sBool value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOBool _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Swap the bool value
        /// </summary>
        public void Toggle()
        {
            value = !value;
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

        public static implicit operator bool(SOBool so) => so.value;
        
        public static bool operator == (SOBool a, bool b)
        {
            if (a == null)
                throw new Exception("SoBool null");
            return a.value == b;
        }
        
        public static bool operator != (SOBool a, bool b)
        {
            if (a == null)
                throw new Exception("SoBool null");
            return a.value != b;
        }
        
        protected bool Equals(SOBool other)
        {
            return base.Equals(other) && value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((SOBool) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), value);
        }
    }
}
