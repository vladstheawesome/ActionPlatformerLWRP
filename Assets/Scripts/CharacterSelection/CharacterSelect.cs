using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.CharacterSelect
{
    public enum PlayableCharacterType
    {
        NONE,
        WARRIOR, 
        RED, 
        GREEN,
        YELLOW,
    }

    [CreateAssetMenu(fileName = "characterSelect", menuName = "ActionPlatformer/CharacterSelect/CharacterSelect")]
    public class CharacterSelect : ScriptableObject
    {
        public PlayableCharacterType SelectedCharacterType;
    }
}
