using UnityEngine;
using ScriptableObjectVariable;

// Pone como encendido un SoBool cuando esta adentro de este animator y falso cuando se sale
// Set bool true when is StateEnter and false on StateExit

namespace ScriptableObjectScripts
{
    [SharedBetweenAnimators]
    public class SO_AnimatorStateSetBool : StateMachineBehaviour
    {
        const float GunIndex = 1f;

        [SerializeField] SOBool soBool;
    
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            soBool.value = true;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            soBool.value = false;
        }
    }
}


