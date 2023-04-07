using UnityEngine;

public class Mixer : ScriptableObject
{
    [SerializeField] internal int countdown;
    [SerializeField] internal Ingradiant baseIngradiant;
    [SerializeField] internal Ingradiant sideIngradiant;


    public Ingradiant MixIngradiants()
    {
        var result = Ingradiant.Empty;
        if ((baseIngradiant == Ingradiant.Blue && sideIngradiant == Ingradiant.Orange) || (baseIngradiant == Ingradiant.Orange && sideIngradiant == Ingradiant.Blue))
            result = Ingradiant.LightBlue;
        else if ((baseIngradiant == Ingradiant.Red && sideIngradiant == Ingradiant.Green)||(baseIngradiant == Ingradiant.Green && sideIngradiant == Ingradiant.Red))
            result = Ingradiant.BoldYellow;
        else
            result = (Ingradiant) Random.Range(0,7);

        return result;
    }
}