using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectEvent
{
    [CreateAssetMenu(fileName = "soGameEvent", menuName = "soGameEvents/soGameEvent", order = 1)]
    public class SOGameEvent : ScriptableObject
    {
        //List of all objects/methods subscribed to this GameEvent
        private List<GameEventListener> listeners;
        // actions are not displaye in the Editor window
        Action actions;

        //Description of when this event is raised
        [TextArea]
        [Tooltip("When is this event raised")]
        public string eventDescription = "[When does this event trigger]";

        #if UNITY_EDITOR
        [Header("EditorOnly")] 
        [SerializeField] bool printOnRaised;
        #endif

        public void Raise()
        {
#if UNITY_EDITOR
            //Debug - show the event has been raised
            if(printOnRaised)
                Debug.Log($"{name} event raised");
#endif

            if (listeners != null)
            {
                //Loop through the listener list and raise the events passed
                for (int i = listeners.Count - 1; i >= 0; i--)
                {
                    listeners[i].OnEventRaised();
                }
            }
            
            actions?.Invoke();
        }

        //Add the gameEventListener to the listener list
        public void RegisterListener(GameEventListener listener)
        {
            listeners ??= new List<GameEventListener>();
            
            listeners.Add(listener);
        }

        //Remove the gameEventListener to the listener list
        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
        
        public void RegisterListener(Action action)
        {
            actions += action;
        }

        //Remove the gameEventListener to the listener list
        public void UnregisterListener(Action action)
        {
            actions -= action;
        }
    }
}
