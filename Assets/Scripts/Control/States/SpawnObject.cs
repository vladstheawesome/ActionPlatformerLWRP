﻿using ActionPlatformer.Core;
using ActionPlatformer.PooledObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Control
{
    [CreateAssetMenu(fileName = "New State", menuName = "ActionPlatformer/AbilityData/SpawnObject")]
    public class SpawnObject : StateData
    {
        public PoolObjectType ObjectType;
        [Range(0f, 1f)]
        public float SpawnTiming;
        public string ParentObjectName = string.Empty; // Body name we want to attach the object to
        public bool StrickToParent;
        
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if(SpawnTiming == 0f)
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                SpawnObj(control);
            }
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);

            if (!control.animationProgress.PoolObjectList.Contains(ObjectType))
            {
                if (stateInfo.normalizedTime >= SpawnTiming)
                {                    
                    SpawnObj(control);                    
                }
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            if (control.animationProgress.PoolObjectList.Contains(ObjectType))
            {
                control.animationProgress.PoolObjectList.Remove(ObjectType);
            }
        }

        private void SpawnObj(CharacterControl control)
        {
            if (control.animationProgress.PoolObjectList.Contains(ObjectType))
            {
                return;
            }

            GameObject obj = PoolManager.Instance.GetObject(ObjectType);

            Debug.Log("Spawning " + ObjectType.ToString() + " | looking for: " + ParentObjectName);

            if (!string.IsNullOrEmpty(ParentObjectName))
            {
                GameObject p = control.GetChildObj(ParentObjectName);
                obj.transform.parent = p.transform;
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
            }

            if(!StrickToParent)
            {
                obj.transform.parent = null;
            }

            obj.SetActive(true);

            control.animationProgress.PoolObjectList.Add(ObjectType);
        }
    }
}
