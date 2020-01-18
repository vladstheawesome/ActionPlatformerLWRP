using ActionPlatformer.Control;
using ActionPlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ActionPlatformer.AI
{
    [CreateAssetMenu(fileName = "New State", menuName = "ActionPlatformer/AI/StartRunning")]
    public class StartRunning : StateData
    {
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            Vector3 dir = control.aiProgress.pathfindingAgent.StartSphere.transform.position - control.transform.position;

            if (dir.z > 0f)
            {
                control.MoveRight = true;
                control.MoveLeft = false;
            }
            else
            {
                control.MoveRight = false;
                control.MoveLeft = true;
            }

            control.Turbo = true;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            Vector3 dist = control.aiProgress.pathfindingAgent.StartSphere.transform.position - control.transform.position;

            if (Vector3.SqrMagnitude(dist) < 2f)
            {
                control.MoveRight = false;
                control.MoveLeft = false;
                control.Turbo = false;

                //Vector3 playerDist = control.transform.position - CharacterManager.Instance.GetPlayableCharacter().transform.position;
                //if (playerDist.sqrMagnitude > 1f)
                //{
                //    animator.gameObject.SetActive(false);
                //    animator.gameObject.SetActive(true);
                //}
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }
}
