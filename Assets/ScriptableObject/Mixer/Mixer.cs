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

        if (inputOne.CurrentObject.baseIngradiant.Type == Ingradient.Empty ||
            inputTwo.CurrentObject.baseIngradiant.Type == Ingradient.Empty ||
            output.CurrentObject.baseIngradiant.Type != Ingradient.Empty)
            return;
        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((inputOne.CurrentObject.baseIngradiant.Type == Ingradient.LightBlue
             && inputTwo.CurrentObject.baseIngradiant.Type == Ingradient.BoldYellow)
            ||
            (inputOne.CurrentObject.baseIngradiant.Type == Ingradient.BoldYellow
             && inputTwo.CurrentObject.baseIngradiant.Type == Ingradient.LightBlue))
        {
            output.CurrentObject.baseIngradiant.Type = Ingradient.Green;
        }
        else
        {
            output.CurrentObject.baseIngradiant.Type = Ingradient.Empty;
        }

        inputOne.CurrentObject.baseIngradiant.Type = Ingradient.Empty;
        inputTwo.CurrentObject.baseIngradiant.Type = Ingradient.Empty;
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