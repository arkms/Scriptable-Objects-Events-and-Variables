using System;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectVariable;
using ScriptableObjectEvent;

namespace ScriptableObjectScripts
{
    [RequireComponent(typeof(Image))]
    public class SO_UiImageFillByFloat : MonoBehaviour
    {
        [SerializeField] 
        SOFloat floatSO;

        [SerializeField] 
        SOGameEvent gameEvent;

        Image image;

        void Awake()
        {
            image = GetComponent<Image>();
        }

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
            image.fillAmount = floatSO;
        }
    }
}
