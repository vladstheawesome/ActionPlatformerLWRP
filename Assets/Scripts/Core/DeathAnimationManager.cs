﻿using ActionPlatformer.AttackInfomation;
using ActionPlatformer.Death;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionPlatformer.Core
{
    public class DeathAnimationManager : Singleton<DeathAnimationManager>
    {
        DeathAnimationLoader deathAnimationLoader;
        List<RuntimeAnimatorController> Candidates = new List<RuntimeAnimatorController>();

        void SetUpDeathAnimationLoader()
        {
            if (deathAnimationLoader == null)
            {
                GameObject obj = Instantiate(Resources.Load("DeathAnimationLoader", typeof(GameObject)) as GameObject);
                DeathAnimationLoader loader = obj.GetComponent<DeathAnimationLoader>();

                deathAnimationLoader = loader;
            }
        }

        public RuntimeAnimatorController GetAnimator(GeneralBodyPart generalBodyPart, AttackInfo info)
        {
            SetUpDeathAnimationLoader();

            Candidates.Clear();

            foreach (DeathAnimationData data in deathAnimationLoader.DeathAnimationList)
            {
                if (info.LaunchIntoAir)
                {
                    if(data.LaunchIntoAir)
                    {
                        Candidates.Add(data.Animator);
                    }
                }
                else if(!info.MustCollide)
                {
                    foreach (GeneralBodyPart part in data.GeneralBodyParts)
                    {
                        if (part == GeneralBodyPart.Lower || part == GeneralBodyPart.Leg)
                        {
                            Candidates.Add(data.Animator);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (GeneralBodyPart part in data.GeneralBodyParts)
                    {
                        if (part == generalBodyPart)
                        {
                            Candidates.Add(data.Animator);
                            break;
                        }
                    }
                }                
            }

            return Candidates[Random.Range(0, Candidates.Count)];
        }
    }
}
