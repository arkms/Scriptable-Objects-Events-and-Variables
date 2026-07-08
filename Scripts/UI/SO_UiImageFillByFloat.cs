using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectVariable;

namespace ScriptableObjectScripts
{
    [RequireComponent(typeof(Image))]
    public class SO_UiImageFillByFloat : MonoBehaviour
    {
        [SerializeField] 
        SOFloat floatSO;

        Image image;

        void Awake()
        {
            image = GetComponent<Image>();
        }

        void OnEnable()
        {
            floatSO.OnValueChanged += OnRaise;
        }

        void OnDisable()
        {
            floatSO.OnValueChanged -= OnRaise;
        }

        void OnRaise()
        {
            image.fillAmount = floatSO;
        }
    }
}
