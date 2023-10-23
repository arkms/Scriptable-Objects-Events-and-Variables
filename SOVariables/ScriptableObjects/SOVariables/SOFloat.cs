using UnityEngine;
using System;

namespace ScriptableObjectVariable
{
    [CreateAssetMenu(fileName = "soFloat", menuName = "soVariables/soFloat", order = 1)]
    public class SOFloat : ScriptableVariable, ISerializationCallbackReceiver
    {
        //Float value
        [NonSerialized]
        public float value;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private float startingValue = 0;

        /// <summary>
        /// Set sFloat value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(float _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sBool value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOFloat _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Add a float value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(float _value)
        {
            value += _value;
        }

        /// <summary>
        /// Add another sFloat value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(SOFloat _value)
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
        
        public static implicit operator float(SOFloat so) => so.value;
        
        public static bool operator ==(SOFloat a, float b)
        {
            if (!a)
                throw new Exception("SOFloat null");

            return Mathf.Abs(a.value - b) < Mathf.Epsilon;
        }
        
        public static bool operator !=(SOFloat a, float b)
        {
            if (!a)
                throw new Exception("SOFloat null");

            return Mathf.Abs(a.value - b) > Mathf.Epsilon;
        }
        
        public static bool operator > (SOFloat a, float b)
        {
            if (!a)
                throw new Exception("SOFloat null");
            return a.value > b;
        }

        public static bool operator < (SOFloat a, float b)
        {
            if (!a)
                throw new Exception("SOFloat null");
            return a.value < b;
        }
        
        public static bool operator >= (SOFloat a, float b)
        {
            if (!a)
                throw new Exception("SOFloat null");
            return a.value >= b;
        }

        public static bool operator <= (SOFloat a, float b)
        {
            if (!a)
                throw new Exception("SOFloat null");
            return a.value <= b;
        }
        
        protected bool Equals(SOFloat other)
        {
            return base.Equals(other) && value.Equals(other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((SOFloat) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), value);
        }
    }
}
