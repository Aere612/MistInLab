using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mixer", menuName = "Machines/Mixer")]
public class Mixer : BaseMachine
{
    internal VialSlot inputOne;
    internal VialSlot inputTwo;
    internal VialSlot output;

    public override void CheckTheConditionsAndRun()
    {
        if (inputOne == null || inputTwo == null || output == null)
            return;

        if (inputOne.CurrentObject.baseIngradiant == Ingradiant.Empty ||
            inputTwo.CurrentObject.baseIngradiant == Ingradiant.Empty ||
            output.CurrentObject.baseIngradiant != Ingradiant.Empty)
            return;
        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((inputOne.CurrentObject.baseIngradiant == Ingradiant.LightBlue
             && inputTwo.CurrentObject.baseIngradiant == Ingradiant.BoldYellow)
            ||
            (inputOne.CurrentObject.baseIngradiant == Ingradiant.BoldYellow
             && inputTwo.CurrentObject.baseIngradiant == Ingradiant.LightBlue))
        {
            output.CurrentObject.baseIngradiant = Ingradiant.Green;
            inputOne.CurrentObject.baseIngradiant = Ingradiant.Empty;
            inputTwo.CurrentObject.baseIngradiant = Ingradiant.Empty;
        }
        else
            output.CurrentObject.baseIngradiant = Ingradiant.Empty;
    }

    public override void RunTheMachine()
    {
        isCountdownStarted = true;
        OnMachineStarted.Raise();   
    }

    public override void StopTheMachine()
    {
        isCountdownStarted = false;
        OnMachineStopped.Raise();
    }
}