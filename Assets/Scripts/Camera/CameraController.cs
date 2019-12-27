﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Camera
{
    public enum CameraTrigger
    {
        Default,
        Shake,
    }

    public class CameraController : MonoBehaviour
    {
        private Animator animator;
               
        public Animator ANIMATOR
        {
            get
            {
                if(animator == null)
                {
                    animator = GetComponent<Animator>();
                }

                return animator;
            }
        }

        public void TriggerCamera(CameraTrigger trigger)
        {
            ANIMATOR.SetTrigger(trigger.ToString());
        }
    }
}
