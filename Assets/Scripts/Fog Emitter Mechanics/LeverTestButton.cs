using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(FogEmitterRightSideLever))]
public class LeverTestButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("UseLever"))
        {
            var myScript = (FogEmitterRightSideLever)target;
            myScript.Interaction();
        }
    }
}