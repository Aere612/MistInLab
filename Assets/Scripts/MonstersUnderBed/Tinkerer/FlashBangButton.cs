using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FlashBang))]
public class FlashBangButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("FlashBang")) 
        {
            var myScript = (FlashBang)target;
            myScript.Interaction();
        }
    }
}