using UnityEngine;
using System;

namespace ScriptableObjectVariable
{

    [CreateAssetMenu(fileName = "soString", menuName = "soVariables/soString", order = 1)]
    public class SOString : ScriptableVariable, ISerializationCallbackReceiver
    {
        //Float value
        [NonSerialized]
        public string value;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private string startingValue = null;

        /// <summary>
        /// Set sString value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(string _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sString value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOString _value)
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
        
        public static implicit operator string(SOString so) => so.value;
        
        public static bool operator == (SOString a, string b)
        {
            if (a == null)
                throw new Exception("SOString null");
            return a.value.Equals(b);
        }
        
        public static bool operator != (SOString a, string b)
        {
            if (a == null)
                throw new Exception("SOString null");
            return !a.value.Equals(b);
        }
        
        protected bool Equals(SOString other)
        {
            return base.Equals(other) && value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((SOString) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), value);
        }
    }
}