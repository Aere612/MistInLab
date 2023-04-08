using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Centrifuge",menuName = "Machines/Centrifuge")]
public class Centrifuge : BaseMachine
{
    public override Ingradiant RunTheMachine(Ingradiant inputOne, Ingradiant inputTwo)
    {
        Ingradiant result;

        if (inputOne == Ingradiant.LightBlue && inputTwo == Ingradiant.BoldYellow)
            result = Ingradiant.Green;
        else
            result = Ingradiant.Empty;
        return result;
    }
}
