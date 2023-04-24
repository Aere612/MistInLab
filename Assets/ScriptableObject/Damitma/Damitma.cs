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

        if (input.CurrentObject.BaseIngradiant == _ingradientTypes.Empty ||
            output.CurrentObject.BaseIngradiant != _ingradientTypes.Empty)
            return;

        RunTheMachine();
    }

    public override void MixTheIngradients()
    {
        if ((input.CurrentObject.BaseIngradiant == _ingradientTypes.Purple &&
             input.CurrentObject.SideIngradiant == _ingradientTypes.Yellow) ||
            (input.CurrentObject.BaseIngradiant == _ingradientTypes.Yellow &&
             input.CurrentObject.SideIngradiant == _ingradientTypes.Purple))
        {
            output.CurrentObject.BaseIngradiant = _ingradientTypes.Acid;
        }
        else
        {
            output.CurrentObject.BaseIngradiant = _ingradientTypes.Black;
        }
        
        input.CurrentObject.BaseIngradiant = _ingradientTypes.Empty;
        input.CurrentObject.SideIngradiant = _ingradientTypes.Empty;
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