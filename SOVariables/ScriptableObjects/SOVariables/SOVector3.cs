using UnityEngine;
using System;

namespace ScriptableObjectVariable
{
    [CreateAssetMenu(fileName = "soVector3", menuName = "soVariables/soVector3", order = 1)]
    public class SOVector3 : ScriptableVariable, ISerializationCallbackReceiver
    {
        //Float value
        [NonSerialized]
        public Vector3 value;

        //Can the value be reset in game
        //public bool resettable;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private Vector3 startingValue = Vector3.zero;

        /// <summary>
        /// Set sVector3 value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(Vector3 _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sVector3 value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOVector3 _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Add a Vector3 value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(Vector3 _value)
        {
            value += _value;
        }

        /// <summary>
        /// Add another sVector3 value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(SOVector3 _value)
        {
            value += _value.value;
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
        
        public static implicit operator Vector3(SOVector3 so) => so.value;
        
        public static bool operator ==(SOVector3 a, Vector3 b)
        {
            if (!a)
                throw new Exception("SOVector3 null");

            return a.value == b;
        }
        
        public static bool operator !=(SOVector3 a, Vector3 b)
        {
            if (!a)
                throw new Exception("SOVector3 null");

            return a.value != b;
        }
        
        protected bool Equals(SOVector3 other)
        {
            return base.Equals(other) && value.Equals(other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SOVector3) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), value);
        }
    }
}
