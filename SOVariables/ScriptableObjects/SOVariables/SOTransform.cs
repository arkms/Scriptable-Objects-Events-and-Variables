using UnityEngine;
using System;

namespace ScriptableObjectVariable
{
    [CreateAssetMenu(fileName = "soTransform", menuName = "soVariables/soTransform", order = 1)]
    public class SOTransform : ScriptableVariable, ISerializationCallbackReceiver
    {
        //Float value
        [NonSerialized]
        public Transform value;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private Transform startingValue = null;

        /// <summary>
        /// Set sGameObject value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(Transform _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sGameObject value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOTransform _value)
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
        
        public static implicit operator Transform(SOTransform so) => so.value;
        
        public static bool operator == (SOTransform a, Transform b)
        {
            if (a == null)
                throw new Exception("SOTransform null");
            return a.value == b;
        }
        
        public static bool operator != (SOTransform a, Transform b)
        {
            if (a == null)
                throw new Exception("SOTransform null");
            return a.value != b;
        }
        
        protected bool Equals(SOTransform other)
        {
            return base.Equals(other) && Equals(value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((SOTransform) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), value);
        }
    }
}

