using UnityEditor;

//[CustomEditor(typeof(/*ObjectType*/))]
public class AddButtonAtInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //if (GUILayout.Button(/*"ButtonName"*/))//Button Name
        //{
        //    /*ObjectType*/ myScript = (/*ObjectType*/)target;
        //     myScript./*FunctionName*/();//target function. can be anything
        //}
    }
}