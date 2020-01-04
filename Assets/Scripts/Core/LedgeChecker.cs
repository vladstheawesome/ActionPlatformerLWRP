using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Core
{
    public class LedgeChecker : MonoBehaviour
    {
        public bool IsGrabbingLedge;
        public Ledge GrabbedLedge;
        Ledge CheckedLedge = null;

        private void OnTriggerEnter(Collider other)
        {
            CheckedLedge = other.gameObject.GetComponent<Ledge>();
            if (CheckedLedge != null)
            {
                 IsGrabbingLedge = true;
                GrabbedLedge = CheckedLedge;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            CheckedLedge = other.gameObject.GetComponent<Ledge>();
            if (CheckedLedge != null)
            {
                IsGrabbingLedge = false;
                GrabbedLedge = null;
            }
        }
    }
}
