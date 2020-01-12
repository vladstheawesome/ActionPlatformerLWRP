﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ActionPlatformer.Core
{
    [CustomEditor(typeof(PathFindingAgent))]
    public class PathFindingAgentEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            PathFindingAgent pathFindingAgent = (PathFindingAgent)target;

            if (GUILayout.Button("Go To Target"))
            {
                pathFindingAgent.GoToTarget();
            }
        }
    }
}