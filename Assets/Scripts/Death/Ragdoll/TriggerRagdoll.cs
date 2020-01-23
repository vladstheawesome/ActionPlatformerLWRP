using ActionPlatformer.Control;
using ActionPlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Death
{
    [CreateAssetMenu(fileName = "New State", menuName = "ActionPlatformer/Death/TriggerRagdoll")]
    public class TriggerRagdoll : StateData
    {
        public float TriggerTiming;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (stateInfo.normalizedTime >= TriggerTiming)
            {
                if (!control.animationProgress.RagdollTriggered)
                {
                    control.TurnOnRagDoll();
                    control.animationProgress.RagdollTriggered = true;
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            control.animationProgress.RagdollTriggered = false;
        }
    }
}
