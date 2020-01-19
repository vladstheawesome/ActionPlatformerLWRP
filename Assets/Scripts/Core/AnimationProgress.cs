using ActionPlatformer.Control;
using ActionPlatformer.PooledObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Core
{
    public class AnimationProgress : MonoBehaviour
    {
        public bool Jumped;
        public bool CameraShaken;
        public List<PoolObjectType> PoolObjectList = new List<PoolObjectType>();
        public bool AttackTriggered;
        public float MaxPressTime;
        public bool disallowEartlyTurn;
        public float AirMomentum;

        private CharacterControl control;
        private float PressTime;

        private void Awake()
        {
            control = GetComponentInParent<CharacterControl>();
            PressTime = 0f;
        }

        private void Update()
        {
            if(control.Attack)
            {
                PressTime += Time.deltaTime;
            }
            else
            {
                PressTime = 0f;
            }

            if (PressTime == 0f)
            {
                AttackTriggered = false;
            }
            else if(PressTime > MaxPressTime)
            {
                AttackTriggered = false;
            }
            else
            {
                AttackTriggered = true;
            }
        }
    }
}
