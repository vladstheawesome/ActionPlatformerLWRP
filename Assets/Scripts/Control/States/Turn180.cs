﻿using ActionPlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Control
{
    [CreateAssetMenu(fileName = "New State", menuName = "ActionPlatformer/AbilityData/Turn180")]
    public class Turn180 : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (control.IsFacingForward())
            {
                control.FaceForward(false);
            }
            else
            {
                control.FaceForward(true);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
