using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Animations;
#endif

namespace Skuld.Utility.Animators
{
    public class AnimatorUtility
    {
#if UNITY_EDITOR
        static public AnimatorState GetAnimatorState(Animator animator, string layerName, string stateName)
        {
            var contorller = animator.runtimeAnimatorController as AnimatorController;
            var layers = contorller.layers;
            foreach (var layer in layers)
            {
                if (layer.stateMachine.name == layerName)
                {
                    var states = layer.stateMachine.states;
                    foreach (var state in states)
                    {
                        if (state.state.name == stateName)
                        {
                            return state.state;
                        }
                    }
                }
            }
            return null;
        }
#endif
    }
}
