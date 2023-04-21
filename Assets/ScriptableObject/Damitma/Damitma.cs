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

        if (input.CurrentObject.baseIngradiant.Type == Ingradient.Empty ||
            output.CurrentObject.baseIngradiant.Type != Ingradient.Empty)
            return;

        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((input.CurrentObject.baseIngradiant.Type == Ingradient.Purple &&
             input.CurrentObject.sideIngradiant.Type == Ingradient.Yellow) ||
            (input.CurrentObject.baseIngradiant.Type == Ingradient.Yellow &&
             input.CurrentObject.sideIngradiant.Type == Ingradient.Purple))
        {
            input.CurrentObject.baseIngradiant.Type = Ingradient.Acid;
        }
        else
        {
            input.CurrentObject.baseIngradiant.Type = (Ingradient)Random.Range(1, 6);
        }

        input.CurrentObject.sideIngradiant.Type = Ingradient.Empty;
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