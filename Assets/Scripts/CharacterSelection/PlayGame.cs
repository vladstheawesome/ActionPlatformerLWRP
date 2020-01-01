using ActionPlatformer.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.CharacterSelect
{
    public class PlayGame : MonoBehaviour
    {
        public CharacterSelect characterSelect;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if (characterSelect.SelectedCharacterType != PlayableCharacterType.NONE)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(GameScenes.Sandbox01.ToString());
                }
                else
                {
                    Debug.Log("Must select character first");
                }
            }
        }
    }
}
