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

        if (input.CurrentObject.baseIngradiant == _ingradientTypes.Empty ||
            output.CurrentObject.baseIngradiant != _ingradientTypes.Empty)
            return;

        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((input.CurrentObject.baseIngradiant == _ingradientTypes.Purple &&
             input.CurrentObject.sideIngradiant == _ingradientTypes.Yellow) ||
            (input.CurrentObject.baseIngradiant == _ingradientTypes.Yellow &&
             input.CurrentObject.sideIngradiant == _ingradientTypes.Purple))
        {
            input.CurrentObject.baseIngradiant = _ingradientTypes.Acid;
        }
        else
        {
            input.CurrentObject.baseIngradiant = _ingradientTypes.Black;
        }

        input.CurrentObject.sideIngradiant = _ingradientTypes.Empty;
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