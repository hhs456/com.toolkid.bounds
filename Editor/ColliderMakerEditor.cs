using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Toolkid.BoundsToolkit
{
    [CustomEditor(typeof(ColliderMaker))]
    public class ColliderMakerEditor : Editor
    {
        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("meshesBase"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("isInsideBall"), true);
            if (GUILayout.Button("Create Box Collider")) {
               Bounds[] bounds = ((ColliderMaker)target).meshesBase.GetComponentsInChildren<MeshRenderer>().GetBounds();
               Bounds temp = bounds.FindBounds();
               BoxCollider collider = ((ColliderMaker)target).gameObject.AddComponent<BoxCollider>();
               collider.center = temp.center - ((ColliderMaker)target).transform.position;
               collider.size = temp.size;
               Debug.Log(temp.center + " " + temp.size);               
            }
            if (GUILayout.Button("Create Sphere Collider")) {
                Bounds[] bounds = ((ColliderMaker)target).meshesBase.GetComponentsInChildren<MeshRenderer>().GetBounds();
                Bounds temp = bounds.FindBounds();
                SphereCollider collider = ((ColliderMaker)target).gameObject.AddComponent<SphereCollider>();
                collider.center = temp.center - ((ColliderMaker)target).transform.position;
                float rate = ((ColliderMaker)target).isInsideBall ? 1.0f : Mathf.Sqrt(3.0f);
                collider.radius = Mathf.Max(temp.size.x, temp.size.y, temp.size.z) * 0.5f * rate;
                Debug.Log(temp.center + " " + temp.size);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
