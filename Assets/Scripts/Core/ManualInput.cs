using ActionPlatformer.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Core
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl characterControl;

        private void Awake()
        {
            characterControl = this.gameObject.GetComponent<CharacterControl>();
        }

        // Update is called once per frame
        void Update()
        {
            if (VirtualInputManager.Instance.MoveUp)
            {
                characterControl.MoveUp = true;
            }
            else
            {
                characterControl.MoveUp = false;
            }

            if (VirtualInputManager.Instance.MoveDown)
            {
                characterControl.MoveDown = true;
            }
            else
            {
                characterControl.MoveDown = false;
            }

            if (VirtualInputManager.Instance.MoveRight)
            {
                characterControl.MoveRight = true;
            }
            else
            {
                characterControl.MoveRight = false;
            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                characterControl.MoveLeft = true;
            }
            else
            {
                characterControl.MoveLeft = false;
            }

            if(VirtualInputManager.Instance.Jump)
            {
                characterControl.Jump = true;
            }
            else
            {
                characterControl.Jump = false;
            }

            if(VirtualInputManager.Instance.Attack)
            {
                characterControl.Attack = true;
            }
            else
            {
                characterControl.Attack = false;
            }
        }
    }
}
