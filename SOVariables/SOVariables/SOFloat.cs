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
            OnValueChanged?.Invoke();
        }
        
        public void SetValueWithoutNotify(float _value)
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
            OnValueChanged?.Invoke();
        }

        /// <summary>
        /// Add a float value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(float _value)
        {
            value += _value;
            OnValueChanged?.Invoke();
        }
        
        public void AddValueClamp(float _value, float _min, float _max)
        {
            value += _value;
            value = Mathf.Clamp(value, _min, _max);
            OnValueChanged?.Invoke();
        }
        
        public void AddValueClampMax(float _value, float _max)
        {
            value += _value;
            if(value > _max)
                value = _max;
            OnValueChanged?.Invoke();
        }
        
        public void AddValueClampMin(float _value, float _min)
        {
            value += _value;
            if(value < _min)
                value = _min;
            OnValueChanged?.Invoke();
        }

        /// <summary>
        /// Add another sFloat value to the value
        /// </summary>
        /// <param name="_value"></param>
        public void AddValue(SOFloat _value)
        {
            value += _value.value;
            OnValueChanged?.Invoke();
        }
        
        public void AddValueClamp(SOFloat _value, float _min, float _max)
        {
            value += _value.value;
            value = Mathf.Clamp(value, _min, _max);
            OnValueChanged?.Invoke();
        }
        
        public void AddValueClampMax(SOFloat _value, float _max)
        {
            value += _value.value;
            if(value > _max)
                value = _max;
            OnValueChanged?.Invoke();
        }
        
        public void AddValueClampMin(SOFloat _value, float _min)
        {
            value += _value.value;
            if(value < _min)
                value = _min;
            OnValueChanged?.Invoke();
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
            OnValueChanged?.Invoke();
        }
        
        public override void ResetValueWithoutNotify()
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
