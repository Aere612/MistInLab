using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(FogEmitterRightSideSlider))]
public class TestButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Test"))
        {
            var myScript = (FogEmitterRightSideSlider)target;
            myScript.Interaction();
        }
    }
}