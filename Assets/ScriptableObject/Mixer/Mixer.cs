using UnityEngine;

[CreateAssetMenu(fileName = "Mixer", menuName = "Machines/Mixer")]
public class Mixer : BaseMachine
{
    public override Ingradiant RunTheMachine(Ingradiant baseIngradiant, Ingradiant sideIngradiant)
    {
        Ingradiant result;

        if ((baseIngradiant == Ingradiant.Blue && sideIngradiant == Ingradiant.Orange) ||
            (baseIngradiant == Ingradiant.Orange && sideIngradiant == Ingradiant.Blue))
            result = Ingradiant.LightBlue;
        else if ((baseIngradiant == Ingradiant.Red && sideIngradiant == Ingradiant.Green) ||
                 (baseIngradiant == Ingradiant.Green && sideIngradiant == Ingradiant.Red))
            result = Ingradiant.BoldYellow;
        else
            result = (Ingradiant)Random.Range(1,6);

        return result;
    }
}