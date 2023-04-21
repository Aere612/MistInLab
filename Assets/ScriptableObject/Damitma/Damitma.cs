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

        if (input.CurrentObject.BaseIngradiant == Ingradiant.Empty ||
            output.CurrentObject.BaseIngradiant != Ingradiant.Empty)
            return;

        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((input.CurrentObject.BaseIngradiant == Ingradiant.Purple &&
             input.CurrentObject.SideIngradiant == Ingradiant.Yellow) ||
            (input.CurrentObject.BaseIngradiant == Ingradiant.Yellow &&
             input.CurrentObject.SideIngradiant == Ingradiant.Purple))
        {
            input.CurrentObject.BaseIngradiant = Ingradiant.Acid;
        }
        else
        {
            input.CurrentObject.BaseIngradiant = (Ingradiant)Random.Range(1, 6);
        }

        input.CurrentObject.SideIngradiant = Ingradiant.Empty;
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