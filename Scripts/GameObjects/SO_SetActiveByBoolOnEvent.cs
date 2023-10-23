using ScriptableObjectEvent;
using ScriptableObjectVariable;
using UnityEngine;

namespace ScriptableObjectScripts
{
    public class SO_SetActiveByBoolOnEvent : MonoBehaviour
    {
        [SerializeField] SOBool boolSo;
        [SerializeField] SOGameEvent gameEvent;

        [SerializeField] GameObject[] gameObjectsToMirrorBool;
        [SerializeField] GameObject[] gameObjectsToInverseBool;

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
            foreach (GameObject go in gameObjectsToMirrorBool)
            {
                if(go)
                    go.SetActive(boolSo);
            }

            bool inverse = !boolSo;
            foreach (GameObject go in gameObjectsToInverseBool)
            {
                if(go)
                    go.SetActive(inverse);
            }
        }
    }
}


