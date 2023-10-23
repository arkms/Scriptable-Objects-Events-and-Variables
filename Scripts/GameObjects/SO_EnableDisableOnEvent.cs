using ScriptableObjectEvent;
using UnityEngine;

namespace ScriptableObjectScripts
{
    public class SO_EnableDisableOnEvent : MonoBehaviour
    {

        [SerializeField] SOGameEvent gameEvent;

        [SerializeField] GameObject[] gameObjectsToTurnOn;
        [SerializeField] GameObject[] gameObjectsToTurnOff;

        void OnEnable()
        {
            gameEvent.RegisterListener(OnRaise);
        }

        void OnDisable()
        {
            gameEvent.UnregisterListener(OnRaise);
        }

        void OnRaise()
        {
            foreach (GameObject go in gameObjectsToTurnOff)
            {
                if(go)
                    go.SetActive(false);
            }
            foreach (GameObject go in gameObjectsToTurnOn)
            {
                if(go)
                    go.SetActive(true);
            }
        }
    }
}


