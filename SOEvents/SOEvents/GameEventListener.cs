using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectEvent
{
    public class GameEventListener : MonoBehaviour
    {
        public SOGameEvent Event; //Which event does this listen for
        public UnityEvent Response; //Reponse to happen when the event is raised

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        /// <summary>
        /// Raise the response set to this event
        /// </summary>
        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}
