using ActionPlatformer.Control;
using ActionPlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.CharacterSelect
{
    public class MouseControl : MonoBehaviour
    {
        Ray ray;
        RaycastHit hit;
        public PlayableCharacterType selectedCharacterType;
        public CharacterSelection characterSelection;
        CharacterSelectLight characterSelectLight;
        CharacterHoverLight characterHoverLight;

        private void Awake()
        {
            characterSelection.SelectedCharacterType = PlayableCharacterType.NONE;
            characterSelectLight = GameObject.FindObjectOfType<CharacterSelectLight>();
            characterHoverLight = GameObject.FindObjectOfType<CharacterHoverLight>();
        }

        private void Update()
        {
            ray = CameraManager.Instance.MainCamera.ScreenPointToRay(Input.mousePosition); // position of mouse click

            if(Physics.Raycast(ray, out hit)) // 1.) if Ray hits something
            {
                // 2.) check if that object is a character or not
                CharacterControl control = hit.collider.gameObject.GetComponent<CharacterControl>();
                if(control != null) // we have clicked on a character
                {
                    selectedCharacterType = control.playableCharacterType;
                }
                else
                {
                    selectedCharacterType = PlayableCharacterType.NONE;
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (selectedCharacterType != PlayableCharacterType.NONE)
                {
                    characterSelection.SelectedCharacterType = selectedCharacterType;
                    characterSelectLight.transform.position = characterHoverLight.transform.position;
                    characterSelectLight.light.enabled = true;
                }
                else
                {
                    characterSelection.SelectedCharacterType = PlayableCharacterType.NONE;
                    characterSelectLight.light.enabled = false;
                }
            }
        }
    }
}
