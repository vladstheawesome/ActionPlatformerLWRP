using ActionPlatformer.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.AttackInfomation
{
    public class AttackInfo : MonoBehaviour
    {
        public CharacterControl Attacker = null;
        public Attack AttackAbility;
        public List<string> ColliderNames = new List<string>(); // names for the body parts that are going to carry the attack

        public bool MustCollide;
        public bool MustFaceAttacker;
        public float LethalRange;
        public int MaxHits;
        public int CurrentHits;
        public bool isRegistered;
        public bool isFinished;

        // A clean slate for an attack
        public void ResetInfo(Attack attack, CharacterControl attacker)
        {
            isRegistered = false;
            isFinished = false;
            AttackAbility = attack; // attack should know what ability its based on
            Attacker = attacker;
        }

        public void Register(Attack attack)
        {
            isRegistered = true;

            AttackAbility = attack;
            ColliderNames = attack.ColliderNames;
            MustCollide = attack.MustCollide;
            MustFaceAttacker = attack.MustFaceAttacker;
            LethalRange = attack.LethalRange;
            MaxHits = attack.MaxHits;
            CurrentHits = 0;
        }

        private void OnDisable()
        {
            isFinished = true;
        }
    }
}
