using UnityEngine;
using System;

namespace ScriptableObjectVariable
{

    [CreateAssetMenu(fileName = "soInt", menuName = "soVariables/soInt", order = 1)]
    public class SOInt : ScriptableVariable, ISerializationCallbackReceiver
    {
        //Float value
        [NonSerialized]
        public int value;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private int startingValue = 0;

        /// <summary>
        /// Set sInt value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(int _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sInt value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOInt _value)
        {
            value = _value.value;
        }

        /// <summary>
        /// Add a int value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(int _value)
        {
            value += _value;
        }

        /// <summary>
        /// Add another sInt value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(SOInt _value)
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
        
        public static implicit operator int(SOInt so) => so.value;
        
        public static bool operator ==(SOInt a, int b)
        {
            if (!a)
                throw new Exception("SOInt null");

            return Mathf.Abs(a.value - b) < Mathf.Epsilon;
        }
        
        public static bool operator !=(SOInt a, int b)
        {
            if (!a)
                throw new Exception("SOInt null");

            return Mathf.Abs(a.value - b) > Mathf.Epsilon;
        }
        
        public static bool operator > (SOInt a, int b)
        {
            if (!a)
                throw new Exception("SOInt null");
            return a.value > b;
        }

        public static bool operator < (SOInt a, int b)
        {
            if (!a)
                throw new Exception("SOInt null");
            return a.value < b;
        }
        
        public static bool operator >= (SOInt a, int b)
        {
            if (!a)
                throw new Exception("SOInt null");
            return a.value >= b;
        }

        public static bool operator <= (SOInt a, int b)
        {
            if (!a)
                throw new Exception("SOInt null");
            return a.value <= b;
        }
        
        protected bool Equals(SOInt other)
        {
            return base.Equals(other) && value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((SOInt) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), value);
        }
    }
}
