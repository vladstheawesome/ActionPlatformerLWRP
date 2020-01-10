using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Core
{
    public class Ledge : MonoBehaviour
    {
        public Vector3 Offset;
        public Vector3 EndPosition;

        public static bool IsLedge(GameObject obj)
        {
            if (obj.GetComponent<Ledge>() == null)
            {
                return false;
            }

            return true;
        }

        public static bool IsLedgeCheker(GameObject obj)
        {
            if (obj.GetComponent<LedgeChecker>() == null)
            {
                return false;
            }

            return true;
        }
    }
}
