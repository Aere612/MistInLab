using UnityEngine;

[CreateAssetMenu(fileName = "Damitma", menuName = "Machines/Damitma")]
public class Damitma : BaseMachine
{
    internal VialSlot input;
    internal VialSlot output;

    public override void CheckTheConditionsAndRun()
    {
        if (input == null || output == null)
            return;

        if (input.CurrentObject.baseIngradiant == Ingradiant.Empty ||
            output.CurrentObject.baseIngradiant != Ingradiant.Empty)
            return;

        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((input.CurrentObject.baseIngradiant == Ingradiant.Purple &&
             input.CurrentObject.sideIngradiant == Ingradiant.Yellow) ||
            (input.CurrentObject.baseIngradiant == Ingradiant.Yellow &&
             input.CurrentObject.sideIngradiant == Ingradiant.Purple))
        {
            input.CurrentObject.baseIngradiant = Ingradiant.Acid;
        }
        else
        {
            input.CurrentObject.baseIngradiant = (Ingradiant)Random.Range(1, 6);
        }

        input.CurrentObject.sideIngradiant = Ingradiant.Empty;
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