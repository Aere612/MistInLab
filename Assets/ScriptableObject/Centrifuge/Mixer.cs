using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mixer",menuName = "Machines/Mixer")]
public class Mixer : BaseMachine
{
    public override Ingradiant RunTheMachine(Ingradiant inputOne, Ingradiant inputTwo)
    {
        Ingradiant result;

        if ((inputOne == Ingradiant.LightBlue && inputTwo == Ingradiant.BoldYellow) || (inputOne == Ingradiant.BoldYellow && inputTwo == Ingradiant.LightBlue))
            result = Ingradiant.Green;
        else
            result = Ingradiant.Empty;
        return result;
    }
}
