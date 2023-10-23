using UnityEngine;
using System;

namespace ScriptableObjectVariable
{
    [CreateAssetMenu(fileName = "soGameObject", menuName = "soVariables/soGameObject", order = 1)]
    public class SOGameObject : ScriptableVariable, ISerializationCallbackReceiver
    {
        //GameObject value
        [NonSerialized]
        public GameObject value;

        //When the game starts, the starting value we use (so we can reset if need be)
        [SerializeField]
        private GameObject startingValue = null;

        /// <summary>
        /// Set sGameObject value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(GameObject _value)
        {
            value = _value;
        }

        /// <summary>
        /// Set value to another sGameObject value
        /// </summary>
        /// <param name="_value"></param>
        public void SetValue(SOGameObject _value)
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
        
        public static implicit operator GameObject(SOGameObject so) => so.value;
        
        public static bool operator == (SOGameObject a, GameObject b)
        {
            if (a == null)
                throw new Exception("SOGameObject null");
            return a.value == b;
        }
        
        public static bool operator != (SOGameObject a, GameObject b)
        {
            if (a == null)
                throw new Exception("SOGameObject null");
            return a.value != b;
        }
        
        protected bool Equals(SOGameObject other)
        {
            return base.Equals(other) && Equals(value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((SOGameObject) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), value);
        }
    }
}
