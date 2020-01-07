using ActionPlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Control
{
    [CreateAssetMenu(fileName = "New State", menuName = "ActionPlatformer/AbilityData/SpawnObject")]
    public class SpawnObject : StateData
    {
        [Range(0f, 1f)]
        public float SpawnTiming;
        public string ParentObjectName = string.Empty; // Boby name we want to attach the object to

        private bool IsSpawned;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(SpawnTiming == 0f)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                SpawnObj(control);
                IsSpawned = true;
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(!IsSpawned)
            {
                if (stateInfo.normalizedTime >= SpawnTiming)
                {
                    CharacterControl control = characterState.GetCharacterControl(animator);
                    SpawnObj(control);
                    IsSpawned = true;
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            IsSpawned = false;
        }

        private void SpawnObj(CharacterControl control)
        {
            GameObject obj = PoolManager.Instance.GetObject(PooledObjects.PoolObjectType.HAMMER); // Get Hammer Object from resources
            

            if (!string.IsNullOrEmpty(ParentObjectName))
            {
                GameObject p = control.GetChildObj(ParentObjectName);
                obj.transform.parent = p.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
            }

            obj.SetActive(true);
        }
    }
}
