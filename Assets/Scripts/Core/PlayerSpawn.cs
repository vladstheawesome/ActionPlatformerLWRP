using ActionPlatformer.CharacterSelect;
using ActionPlatformer.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Core
{
    public class PlayerSpawn : MonoBehaviour
    {
        public CharacterSelection characterSelection;

        private string objName;

        private void Start()
        {
            switch (characterSelection.SelectedCharacterType)
            {
                case PlayableCharacterType.YELLOW:
                    {
                        objName = "yBot - Yellow";
                    }
                    break;
                case PlayableCharacterType.RED:
                    {
                        objName = "yBot - Red Variant";
                    }
                    break;
                case PlayableCharacterType.GREEN:
                    {
                        objName = "yBot - Green Variant";
                    }
                    break;
                case PlayableCharacterType.WARRIOR:
                    {
                        objName = "Warrior";
                    }
                    break;
            }

            GameObject obj = Instantiate(Resources.Load(objName, typeof(GameObject))) as GameObject;
            obj.transform.position = this.transform.position;
            GetComponent<MeshRenderer>().enabled = false;

            Cinemachine.CinemachineVirtualCamera[] arr = GameObject.FindObjectsOfType<Cinemachine.CinemachineVirtualCamera>();
            foreach(Cinemachine.CinemachineVirtualCamera v in arr)
            {
                CharacterControl control = CharacterManager.Instance.GetCharacter(characterSelection.SelectedCharacterType);
                Collider targetA = control.GetBodyPart("Spine1");

                v.LookAt = targetA.transform;
                v.Follow = targetA.transform;                
            }
        }
    }
}
