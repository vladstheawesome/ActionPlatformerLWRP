﻿using ActionPlatformer.CharacterSelect;
using ActionPlatformer.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Core
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        public List<CharacterControl> Characters = new List<CharacterControl>();

        public CharacterControl GetCharacter(PlayableCharacterType playableCharacterType)
        {
            foreach(CharacterControl control in Characters)
            {
                if(control.playableCharacterType == playableCharacterType)
                {
                    return control;
                }
            }

            return null;
        }
    }
}
