using ActionPlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Control
{
    [CreateAssetMenu(fileName = "New State", menuName = "ActionPlatformer/AbilityData/ToggleGravity")]
    public class ToggleGravity : StateData
    {
        public bool On;
        public bool OnStart;
        public bool OnEnd;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        { 
            if (OnStart)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                OnToggleGravity(control);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (OnStart)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                OnToggleGravity(control);
            }
        }

        private void OnToggleGravity(CharacterControl control)
        {
            control.RIGID_BODY.velocity = Vector3.zero; // stop player floating from previous jump velocity
            control.RIGID_BODY.useGravity = On;
        }
    }
}
