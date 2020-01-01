using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.CharacterSelect
{
    public class CharacterSelectLight : MonoBehaviour
    {
        public Light light;

        private void Start()
        {
            light = GetComponent<Light>();
            light.enabled = false;
        }
    }
}
