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

                //if (control.GetBodyPart("Spine1"))
                //{
                    Collider targetA = control.GetBodyPart("Spine1");
                    v.LookAt = targetA.transform;
                    v.Follow = targetA.transform;
                //}

                //else
                //{
                //    //Collider targetB = control.GetBodyPart("spine_01");
                //    //obj.GetComponentInChildren<GameObject>
                //    //v.LookAt = targetB.transform;
                //    //v.Follow = targetB.transform;

                //    var warriorSpine = obj.transform.Find("spine_01").GetComponentsInChildren<GameObject>();

                //    v.LookAt = obj.transform;
                //    v.Follow = obj.transform;
                //}
            }
        }
    }
}
