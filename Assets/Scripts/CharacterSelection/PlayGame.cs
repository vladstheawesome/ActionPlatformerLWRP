using ActionPlatformer.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.CharacterSelect
{
    public class PlayGame : MonoBehaviour
    {
        public CharacterSelection characterSelection;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if (characterSelection.SelectedCharacterType != PlayableCharacterType.NONE)
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
