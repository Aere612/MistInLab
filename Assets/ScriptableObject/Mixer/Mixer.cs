using UnityEngine;

[CreateAssetMenu(fileName = "Mixer",menuName = "Machines/Mixer")]
public class Mixer : ScriptableObject
{
    [SerializeField] internal int countdown;


    public Ingradiant MixIngradiants(Ingradiant baseIngradiant,Ingradiant sideIngradiant)
    {
        var result = Ingradiant.Empty;
        if ((baseIngradiant == Ingradiant.Blue && sideIngradiant == Ingradiant.Orange) || (baseIngradiant == Ingradiant.Orange && sideIngradiant == Ingradiant.Blue))
            result = Ingradiant.LightBlue;
        else if ((baseIngradiant == Ingradiant.Red && sideIngradiant == Ingradiant.Green)||(baseIngradiant == Ingradiant.Green && sideIngradiant == Ingradiant.Red))
            result = Ingradiant.BoldYellow;
        else
            result = (Ingradiant) Random.Range(1,7);

        return result;
    }
}