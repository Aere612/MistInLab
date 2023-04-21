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

        if (inputOne.CurrentObject.BaseIngradiant == Ingradiant.Empty ||
            inputTwo.CurrentObject.BaseIngradiant == Ingradiant.Empty ||
            output.CurrentObject.BaseIngradiant != Ingradiant.Empty)
            return;
        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((inputOne.CurrentObject.BaseIngradiant == Ingradiant.LightBlue
             && inputTwo.CurrentObject.BaseIngradiant == Ingradiant.BoldYellow)
            ||
            (inputOne.CurrentObject.BaseIngradiant == Ingradiant.BoldYellow
             && inputTwo.CurrentObject.BaseIngradiant == Ingradiant.LightBlue))
        {
            output.CurrentObject.BaseIngradiant = Ingradiant.Green;
        }
        else
            output.CurrentObject.BaseIngradiant = Ingradiant.Empty;

        inputOne.CurrentObject.BaseIngradiant = Ingradiant.Empty;
        inputTwo.CurrentObject.BaseIngradiant = Ingradiant.Empty;
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