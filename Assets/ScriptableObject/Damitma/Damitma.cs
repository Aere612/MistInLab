using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Damitma", menuName = "Machines/Damitma")]
public class Damitma : BaseMachine
{
    public override Ingradiant RunTheMachine(Ingradiant baseIngradiant, Ingradiant sideIngradiant)
    {
        Ingradiant result;
        if ((baseIngradiant == Ingradiant.Purple && sideIngradiant == Ingradiant.Yellow) ||
            (baseIngradiant == Ingradiant.Yellow && sideIngradiant == Ingradiant.Purple))
        {
            result = Ingradiant.Acid;
        }
        else
        {
            result = (Ingradiant)Random.Range(1, 6);
        }

        return result;
    }
}