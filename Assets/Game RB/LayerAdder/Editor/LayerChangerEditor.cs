using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ActionPlatformer
{
    [CustomEditor(typeof(LayerChanger))]
    public class NewBehaviourScript : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Change Layer"))
            {
                LayerChanger layerChanger = (LayerChanger)target;

                Dictionary<string, int> dic = LayerAdderEditor.GetAllLayers();

                layerChanger.ChangeLayer(dic);
            }
        }
    }
}
